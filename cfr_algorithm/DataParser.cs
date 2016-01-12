using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
namespace cfr_algorithm
{
    public class DataParser
    {
        // Data parameters
        byte[] byteData;
        int byteCount;
        public string filename;

        // Codon data
        public int sessionCount;
        List<int> startPositions;
        List<int> stopPositions;
        List<List<double>> sessionActivityMatrix;

        // Extraction parameters
        bool extractFull = false;
        int firstSession, lastSession, samplesToThreshold, sampleRate;
        public double activityThreshold{get; set;}
        public double timeToThreshold { get; set; }
        List<int> binLocations;


        public DataTable exportData;

        /* Object constructor
         * set default values for sampling rate, activity threshold and TTR
        */ 
        public DataParser()
        {
            this.sampleRate = 50;
            this.activityThreshold = 4.2;
            this.timeToThreshold = 1.0;

            sessionActivityMatrix = new List<List<double>>();
        }
        
        // Raw data extraction functions
        public int ReadRawData(string filename)
        {
            this.filename = filename;
            using (BinaryReader br = new BinaryReader(File.Open(filename, FileMode.Open, FileAccess.Read)))
            {
                byteCount = (int)br.BaseStream.Length;
                byteData = br.ReadBytes(byteCount);
                br.Close();
            }

            GenerateCodonList();
            ConvertToActivity();
            return sessionCount;
        }
        private void GenerateCodonList()
        {
            byte[] codon = new byte[] { 100, 97, 116, 97 };
            startPositions = new List<int>(100); // 100 is an estimated upper-bound for the maximum number of start positions
            stopPositions = new List<int>(100);

            int codonsFound = 0;
            for (int byteIndex = 0; byteIndex < byteCount - 4; ++byteIndex)
            {
                if (byteData[byteIndex] == codon[0])
                {
                    if (byteData[byteIndex + 1] == codon[1] && byteData[byteIndex + 2] == codon[2] && byteData[byteIndex + 3] == codon[3])
                    {
                        ++codonsFound;
                        if (codonsFound % 2 != 0 && codonsFound > 1)
                            stopPositions.Add(byteIndex - 73);
                        if (codonsFound % 2 == 0)
                            startPositions.Add(byteIndex + 8);
                    }
                }
            }
            stopPositions.Add(byteCount);
            sessionCount = startPositions.Count;
        }
        private void ConvertToActivity()
        {
            sessionActivityMatrix = new List<List<double>>(sessionCount);

            int sessionLength;
            double convertedValue;
            List<double> currentSessionValues;

            for (int sessionIndex = 0; sessionIndex < sessionCount; ++sessionIndex)
            {
                sessionLength = 1 + (stopPositions[sessionIndex] - startPositions[sessionIndex]) / 2;
                currentSessionValues = new List<double>(sessionLength);

                for (int dataIndex = startPositions[sessionIndex]; dataIndex < stopPositions[sessionIndex]; dataIndex += 2)
                {
                    convertedValue = (byteData[dataIndex] + (byteData[dataIndex + 1] << 8)) / 4096.0;
                    convertedValue = System.Math.Abs(convertedValue - 0.5) * 200.0;
                    currentSessionValues.Add(convertedValue);
                }
                sessionActivityMatrix.Add(currentSessionValues);
            }
        }

        // ParseSelectedIntervals: for each session in the range firsSession-lastSession
        // look at the time interval startTime-stopTime and calculate the percentage freezing in that interval
        public void ParseSelectedIntervals(int firstSession, int lastSession, List<int> startTime, List<int> stopTime)
        {
            this.firstSession = firstSession-1;
            this.lastSession = lastSession-1;
            binLocations = new List<int>(2*startTime.Count);

            for (int i = 0; i < startTime.Count; ++i)
            {
                binLocations.Add(sampleRate * startTime[i]);
                binLocations.Add(sampleRate * stopTime[i]);
            }
            extractFull = false;

            PrepareOutputTable();
            ParseActivityMatrix();
        }

        // ParseFullSession: for each session in the range firstSession-lastSession
        // construct time bins with size equal to interval and calculate the percentage
        // of freezing within each bin
        public void ParseFullSession(int firstSession, int lastSession, int timeInterval)
        {
            this.firstSession = firstSession - 1;
            this.lastSession = lastSession - 1;

            // Get the upper limit of samples per session
            int maxSessionSamples = 0;
            for (int i = this.firstSession; i <= this.lastSession; ++i)
            {
                if (maxSessionSamples < sessionActivityMatrix[i].Count)
                    maxSessionSamples = sessionActivityMatrix[i].Count;
            }

            // Use the maximum number of samples to construct the time bins in which to look
            int binSize = timeInterval * sampleRate;
            int nBins = (int)Math.Ceiling(maxSessionSamples / (double)binSize);
            binLocations = new List<int>(nBins+1);
            for (int locationIndex = 0; locationIndex < nBins; ++locationIndex)
                binLocations.Add(locationIndex * binSize);
            binLocations.Add(maxSessionSamples);
            extractFull = true;

            PrepareOutputTable();
            ParseActivityMatrix();
        }

        // ParseActivityMatrix: for each session within range, convert activity to freezing
        // values (vector with value 1 if the animal is freezing, 0 otherwise
        private void ParseActivityMatrix()
        {
            int[] sessionFreezeVector;
            bool sessionParsed;
            DataRow currentRow;

            int indexIncrement = 1;
            if (extractFull == false)
                indexIncrement = 2;

            for (int sessionIndex = firstSession; sessionIndex <= lastSession; ++sessionIndex)
            {
                sessionFreezeVector = CalculateFreezeVector(sessionIndex);
                sessionParsed = false;

                currentRow = exportData.NewRow();
                currentRow[0] = sessionIndex + 1;
                currentRow[1] = sessionFreezeVector.Length / (double)sampleRate;
                currentRow[2] = activityThreshold;
                currentRow[3] = samplesToThreshold;

                int columnIndex = 0;
                for (int binIndex = 0; (binIndex < (binLocations.Count-1)) && (sessionParsed == false); binIndex += indexIncrement)
                {
                    int binStart = binLocations[binIndex];
                    int binStop = binLocations[binIndex + 1]-1;
                    if (binStop >= sessionFreezeVector.Length - 1)
                    {
                        binStop = sessionFreezeVector.Length - 1;
                        sessionParsed = true;
                    }
                    currentRow[4 + columnIndex] = Mean(sessionFreezeVector, binStart, binStop);
                    columnIndex += 1;
                }
                exportData.Rows.Add(currentRow);
            }
        }

        // CalculateFreezeVector: converts the activity values into a binary vector.
        // The algorithm looks for sequences of activity values that are below the activity threshold.
        // If a given sequence takes longer than the time to threshold these activity values are coded as 1
        private int[] CalculateFreezeVector(int sessionIndex)
        {
            this.samplesToThreshold = (int)(timeToThreshold * sampleRate);

            int sampleCount = sessionActivityMatrix[sessionIndex].Count;
            int[] freezeVector = new int[sampleCount];

            int sampleIndex = 0,freezeStart = 0;
            while (sampleIndex < sampleCount)
            {
                if (sessionActivityMatrix[sessionIndex][sampleIndex] > activityThreshold)
                {
                    freezeVector[sampleIndex] = 0;
                    ++sampleIndex;
                }
                else
                {
                    freezeStart = sampleIndex;
                    while ((sampleIndex < sampleCount) && sessionActivityMatrix[sessionIndex][sampleIndex] < activityThreshold)
                    {
                        freezeVector[sampleIndex] = 0;
                        ++sampleIndex;
                    }
                    if ((sampleIndex - freezeStart + 1) > samplesToThreshold)
                    {
                        for (int i = freezeStart; i < sampleIndex; ++i)
                            freezeVector[i] = 1;
                    }
                }
            }
            return freezeVector;
        }
        private double Mean(int[] inputVector, int startIndex, int stopIndex)
        {
            double output = 0.0;
            for (int i = startIndex; i <= stopIndex; ++i)
                output += inputVector[i];
            return (100.0 * output / (stopIndex - startIndex + 1));
        }
        private void PrepareOutputTable()
        {
            exportData = new DataTable();
            exportData.Clear();
            exportData.Columns.Add("Session number", typeof(int));
            exportData.Columns.Add("Session duration [s]", typeof(double));
            exportData.Columns.Add("Threshold activity [%]", typeof(double));
            exportData.Columns.Add("Threshold samples", typeof(double));

            int indexIncrement = 1;
            if (extractFull == false)
                indexIncrement = 2;

            for (int binIndex = 0; binIndex < (binLocations.Count-1); binIndex += indexIncrement)
            {
                double intervalStart = binLocations[binIndex] / (double)sampleRate;
                double intervalStop = binLocations[binIndex + 1] / (double)sampleRate;
                string sInterval = intervalStart.ToString("F2") + " <= t < " + intervalStop.ToString("F2");
                exportData.Columns.Add(sInterval, typeof(double));
            }
        }

        // Functions for extracting activity values for a single session
        public int GetSessionActivityLength(int sessionIndex)
        {
            int length = 0;
            if (sessionIndex >= 0 && sessionIndex < sessionActivityMatrix.Count)
                length = sessionActivityMatrix[sessionIndex].Count;
            return length;
        }
        public List<double> GetSessionActivityValues(int sessionIndex)
        {
            if (sessionIndex >= 0 && sessionIndex < sessionActivityMatrix.Count)
                return sessionActivityMatrix[sessionIndex];
            return null;
        }
        public double GetSessionDuration(int sessionIndex)
        {
            double sessionDuration = -1.0;
            if (sessionIndex >= 0 && sessionIndex < sessionActivityMatrix.Count)
                sessionDuration = Math.Round((double)sessionActivityMatrix[sessionIndex].Count / this.sampleRate,2);
            return sessionDuration;
        }
    }
}
