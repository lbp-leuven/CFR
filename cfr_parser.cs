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
        int sampleRate;
        int sessionCount;
        int firstSession, lastSession, TTR;
        double activityThreshold;

        byte[] byteData;
        int byteCount;
        string filename;

        List<int> startPositions;
        List<int> stopPositions;
        List<List<double>> activityData;
        List<int> intervalPoints;
        DataTable exportData;

        public cfr_parser(string f, int sampleRate, double activityThreshold, int TTR)
        {
            filename = f;

            this.sampleRate = sampleRate;
            this.activityThreshold = activityThreshold;
            this.TTR = TTR;
        }
        
        public int ReadRawData()
        {
            try
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
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return -1;
            }
        }

        public void ParsePeriod(int firstSession, int lastSession, int startTime, int stopTime)
        {
            this.firstSession = firstSession-1;
            this.lastSession = lastSession-1;
            intervalPoints = new List<int>(2);

            intervalPoints.Add(sampleRate * startTime);
            intervalPoints.Add(sampleRate * stopTime);

            PrepareOutputTable();
            CalculateFreezing();
        }

        public void ParseInterval(int firstSession, int interval)
        {
            int maxSessionSamples = 0;
            for (int i = 0; i < activityData.Count; ++i)
            {
                if (maxSessionSamples < activityData[i].Count)
                    maxSessionSamples = activityData.Count;
            }

            int samplesPerInterval = interval * sampleRate;
            int nIntervals = (int)Math.Ceiling(maxSessionSamples / (double)samplesPerInterval);

            intervalPoints = new List<int>(nIntervals);
            for (int intervalIndex = 0; intervalIndex < nIntervals; ++intervalIndex)
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

                for (int intervalIndex = 0; (intervalIndex < intervalPoints.Count-1) && (maxInterval == false); ++intervalIndex)
                {
                    int intervalStart = intervalPoints[intervalIndex];
                    int intervalEnd = intervalPoints[intervalIndex + 1]-1;
                    if (intervalEnd > freezeVector.Length - 1)
                    {
                        intervalEnd = freezeVector.Length - 1;
                        maxInterval = true;
                    }
                    currentRow[4 + intervalIndex] = CalculateAverage(freezeVector, intervalStart, intervalEnd);
                }
            }
        }

        /* Look up the positions of codons (sequence of four bytes) in the raw data file
         * the first codon is ignored. Every even codon marks the start of a sequence and every
         * uneven codon marks the end of a sequence
        */
        private void GenerateCodonList()
        {
            byte[] codon = new byte[] { 100, 97, 116, 97 };
            startPositions = new List<int>(100);
            stopPositions = new List<int>(100);

            int codonsFound = 0;
            for (int byteIndex = 0; byteIndex < byteCount; ++byteIndex)
            {
                if (byteData[byteIndex] == codon[0])
                {
                    if (byteData[byteIndex + 1] == codon[1] && byteData[byteIndex + 2] == codon[2] && byteData[byteIndex + 3] == codon[3])
                    {
                        ++codonsFound;
                        if (codonsFound % 2 != 0 && codonsFound > 1)
                            stopPositions.Add(byteIndex-73);
                        if (codonsFound % 2 == 0)
                            startPositions.Add(byteIndex+8);
                    }
                }
            }
            stopPositions.Add(byteCount);
            sessionCount = startPositions.Count;
        }

        /* Convert the byte stream into activity values. The conversion algorithm is taken from
         * Ben's script. Unfortunately I have no idea where the original documentation for this
         * algorithm can be found.
        */ 
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

                for (int dataIndex = startPositions[sessionIndex]; dataIndex < stopPositions[sessionIndex]; ++dataIndex)
                {
                    convertedValue = (byteData[dataIndex] + (byteData[dataIndex + 1]<<8)) / 4096.0;
                    convertedValue = System.Math.Abs(convertedValue - 0.5) * 200.0;
                    currentSessionValues.Add(convertedValue);
                }
                activityData.Add(currentSessionValues);
            }
        }


        /* Converts activity values into freezing values. Freezing is detected when the activity
         * is below activityThreshold for duration TTR
        */
        private int[] CalculateSessionFreezing(int sessionIndex)
        {
            int sessionSamples = activityData[sessionIndex].Count;
            int[] output = new int[sessionSamples];

            int sampleIndex = 0,firstFreeze = 0;
            while (sampleIndex < sessionSamples)
            {
                if (activityData[sessionIndex][sampleIndex] > activityThreshold)
                {
                    output[sampleIndex] = 0;
                    ++sampleIndex;
                }
                else
                {
                    firstFreeze = sampleIndex;
                    while ((sampleIndex < sessionSamples) && activityData[sessionIndex][sampleIndex] < activityThreshold)
                    {
                        output[sampleIndex] = 0;
                        ++sampleIndex;
                    }
                    if ((sampleIndex - firstFreeze + 1) > TTR)
                    {
                        for (int i = firstFreeze; i < sampleIndex; ++i)
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
            exportData.Columns.Add("Session", typeof(int));
            exportData.Columns.Add("Duration", typeof(double));
            exportData.Columns.Add("Threshold", typeof(double));
            exportData.Columns.Add("TTR", typeof(double));
            for (int i = 0; i < intervalPoints.Count - 1; ++i)
                exportData.Columns.Add("Freezing_" + Convert.ToString(i), typeof(double));

            DataRow currentRow = exportData.NewRow();
            for (int intervalIndex = 0; intervalIndex < intervalPoints.Count - 1; ++intervalIndex)
                currentRow[5 + intervalIndex] = intervalPoints[intervalIndex];
        }
    }
}
