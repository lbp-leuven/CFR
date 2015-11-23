using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
namespace cfr_algorithm
{
    class cfr_parser
    {
        // Data variables
        int sampleRate;
        public int sessionCount;

        byte[] byteData;
        int byteCount;
        public string filename;

        List<int> startPositions;
        List<int> stopPositions;
        List<List<double>> activityData;

        // Extraction variables
        int firstSession, lastSession, TTR;
        double activityThreshold;

        List<int> intervalPoints;
        int nIntervals;
        public DataTable exportData;

        public System.Windows.Forms.ProgressBar progressBar;

        /* Object constructor
         * set default values for sampling rate, activity threshold and TTR
        */ 
        public cfr_parser(string f, int sampleRate, double activityThreshold, int TTR)
        {
            filename = f;

            this.sampleRate = sampleRate;
            this.activityThreshold = activityThreshold;
            this.TTR = TTR*sampleRate;
        }
        

        // Raw data extraction functions
        public int ReadRawData()
        {
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
            activityData = new List<List<double>>(sessionCount);

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
                activityData.Add(currentSessionValues);
            }
        }

        // Data manipulation functions: used to extract freezing data
        public void ParsePeriod(int firstSession, int lastSession, int startTime, int stopTime)
        {
            // Calculates freezing within a specific time window for all specified sessions
            this.firstSession = firstSession-1;
            this.lastSession = lastSession-1;
            intervalPoints = new List<int>(2);

            intervalPoints.Add(sampleRate * startTime);
            intervalPoints.Add(sampleRate * stopTime);
            nIntervals = 2;

            PrepareOutputTable();
            CalculateFreezing();
        }

        public void ParseInterval(int firstSession, int lastSession, int interval)
        {
            this.firstSession = firstSession - 1;
            this.lastSession = lastSession - 1;

            // Calculate the maximum number of samples per session
            int maxSessionSamples = 0;
            for (int i = this.firstSession; i <= this.lastSession; ++i)
            {
                if (maxSessionSamples < activityData[i].Count)
                    maxSessionSamples = activityData[i].Count;
            }

            // Use the maximum number of samples to calculate all the intervals
            int samplesPerInterval = interval * sampleRate;
            nIntervals = (int)Math.Ceiling(maxSessionSamples / (double)samplesPerInterval);

            // Calculate the interval points
            intervalPoints = new List<int>(nIntervals+1);
            for (int intervalIndex = 0; intervalIndex <= nIntervals; ++intervalIndex)
                intervalPoints.Add(intervalIndex * samplesPerInterval);

            PrepareOutputTable();
            CalculateFreezing();
        }

        private void CalculateFreezing()
        {
            int[] freezeVector;
            bool maxInterval;
            DataRow currentRow;

            for (int sessionIndex = firstSession; sessionIndex <= lastSession; ++sessionIndex)
            {
                freezeVector = CalculateSessionFreezing(sessionIndex);
                maxInterval = false;

                currentRow = exportData.NewRow();
                currentRow[0] = sessionIndex + 1;
                currentRow[1] = freezeVector.Length / (double)sampleRate;
                currentRow[2] = activityThreshold;
                currentRow[3] = TTR;

                for (int intervalIndex = 0; (intervalIndex < nIntervals-1) && (maxInterval == false); ++intervalIndex)
                {
                    int intervalStart = intervalPoints[intervalIndex];
                    int intervalEnd = intervalPoints[intervalIndex + 1]-1;
                    if (intervalEnd >= freezeVector.Length - 1)
                    {
                        intervalEnd = freezeVector.Length - 1;
                        maxInterval = true;
                    }
                    currentRow[4 + intervalIndex] = CalculateAverage(freezeVector, intervalStart, intervalEnd);
                }
                exportData.Rows.Add(currentRow);


                if (progressBar != null)
                    progressBar.Value = Math.Min((100 * (sessionIndex - firstSession+1) / (lastSession - firstSession + 1)),95);
            }
        }

        /* Converts activity values into freezing values. Freezing is detected when the activity
         * is below activityThreshold for duration TTR
        */
        private int[] CalculateSessionFreezing(int sessionIndex)
        {
            // Returns a binary vector, 0 if the animal is not freezing, one if the animal is freezing
            int sessionSamples = activityData[sessionIndex].Count;
            int[] output = new int[sessionSamples];

            int sampleIndex = 0,freezeStart = 0;
            while (sampleIndex < sessionSamples)
            {
                if (activityData[sessionIndex][sampleIndex] > activityThreshold)
                {
                    output[sampleIndex] = 0;
                    ++sampleIndex;
                }
                else
                {
                    freezeStart = sampleIndex;
                    while ((sampleIndex < sessionSamples) && activityData[sessionIndex][sampleIndex] < activityThreshold)
                    {
                        output[sampleIndex] = 0;
                        ++sampleIndex;
                    }
                    if ((sampleIndex - freezeStart + 1) > TTR)
                    {
                        for (int i = freezeStart; i < sampleIndex; ++i)
                            output[i] = 1;
                    }
                }
            }
            return output;
        }
        private double CalculateAverage(int[] inputVector, int startIndex, int stopIndex)
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
            for (int intervalIndex = 0; intervalIndex < (nIntervals-1); ++intervalIndex)
            {
                double intervalStart = intervalPoints[intervalIndex] / sampleRate;
                double intervalStop = intervalPoints[intervalIndex+1] / sampleRate;
                string sInterval = intervalStart.ToString("F1") + " <= t < " + intervalStop.ToString("F1");
                exportData.Columns.Add(sInterval, typeof(double));
            }
        }
    }
}
