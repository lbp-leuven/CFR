using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace cfr_algorithm
{
    public partial class Form1 : Form
    {
        // Data variables
        List<Byte> RawData;                 // Byte data from the input file
        List<int> StartPositions;           // Index to start positions for each session
        List<int> StopPositions;            // Index to stop positions for each session

        List<List<double>> ConvertedData;   // For each session, the converted activity values
        List<List<int>> SessionIntervals;          // Used to select timep periods within a single session
        
        string FileName;
        //DataTable ExportData;
        DataTable ExportData;
        int SampleRate = 50;

        // Excel export variables
        Microsoft.Office.Interop.Excel.Application xlApp;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        object MissingValue = System.Reflection.Missing.Value;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SuccesLabel1.Text = "\u2713";
            SuccesLabel2.Text = "\u2713";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create open file dialog
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "raw files (*.raw)|*.raw|All files (*.*)|*.*";
            of.RestoreDirectory = true;

            // If user selected file, proceed to processing
            if (of.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Try to load the file in binary mode and read until the end of the file
                    BinaryReader br  = new BinaryReader(File.Open(of.FileName, FileMode.Open,FileAccess.Read)); // File object
                    int TotalBytes = (int)br.BaseStream.Length; // File size
                    Byte NextValue;
                    RawData = new List<byte>(TotalBytes);
                    while (br.BaseStream.Position != TotalBytes)
                    {
                        NextValue = br.ReadByte();
                        RawData.Add(NextValue);
                    }
                    br.Close();

                    // If we reach this point, the file has been read succesfuly and we can start
                    // the process of converting the bytes to activity data
                    FindCodon();
                    ConvertRawData();

                    DataLoadedLabel.Text = of.SafeFileName + " loaded!";
                    FileName = System.IO.Path.GetFileNameWithoutExtension(of.FileName);
                    SuccesLabel1.Visible = true;
                    EnableParameters();
                }
                catch (Exception ex)
                {
                    // If an error occured, warn the user
                    MessageBox.Show(ex.ToString());
                    DataLoadedLabel.Text = "";
                    DataWrittenLabel.Text = "";
                    SuccesLabel1.Visible = false;
                    analyse_data.Enabled = false;
                }

            }

        }

        // This function searches the RawData for the byte sequence coded in Codon
        // The first codon is ignored. From second codon we count every even codon as the start
        // of a sequence and every uneven codon as the corresponding end of a sequence
        // Bytes between a start codon and a stop codon contain the raw data of a single session
        // which needs to be converted
        void FindCodon()
        {
            Byte[] Codon = new Byte[]{100,97,116,97};
            StartPositions = new List<int>(100);
            StopPositions = new List<int>(100);

            int CodonsFound = 0;

            for (int i = 0; i < RawData.Count-4; ++i)
            {
                if ((RawData[i] == Codon[0]))
                {
                    if (RawData[i + 1] == Codon[1] && RawData[i + 2] == Codon[2] && RawData[i + 3] == Codon[3])
                    {
                        ++CodonsFound;
                        if (CodonsFound % 2 != 0 && CodonsFound > 1)
                            StopPositions.Add(i-73);
                        else if ( CodonsFound%2 == 0)
                            StartPositions.Add(i+8);
                    }
                }
            }
            StopPositions.Add((int)RawData.Count);
        }

        // Using the start and stop positions, this functions converts the corresponding
        // raw data values to scaled activity values for each session
        void ConvertRawData()
        {
            ConvertedData = new List<List<double>>((int)StartPositions.Count); // The number of start positions corresponds to the number of sessions

            // Select start and end positions for each session and convert the raw data for that session
            // into activity values. ConvertedData contains these data for each session
            for (int SessionIndex = 0; SessionIndex < (int)StartPositions.Count; ++SessionIndex)
            {
                int SessionLength = StopPositions[SessionIndex] - StartPositions[SessionIndex];
                List<double> ActivityValues = new List<double>(SessionLength);

                // Convert to activity values, each two raw bytes corresponds to a two byte unsigned integer
                for (int i = StartPositions[SessionIndex]; i < StopPositions[SessionIndex]; i += 2)
                {
                    double ConvertedValue = (RawData[i] + (RawData[i + 1] << 8)) / 4096.0;
                    ConvertedValue = System.Math.Abs(ConvertedValue - 0.5) * 200.0;
                    ActivityValues.Add(ConvertedValue);
                }
                ConvertedData.Add(ActivityValues);
            }
        }

        void EnableParameters()
        {
            FirstSession.Minimum = 1;
            FirstSession.Maximum = (int)StartPositions.Count;
            FirstSession.Value = 1;

            LastSession.Minimum = 1;
            LastSession.Maximum = (int)StartPositions.Count;
            LastSession.Value = LastSession.Maximum;

            analyse_data.Enabled = true;

            DataWrittenLabel.Visible = false;
            SuccesLabel2.Visible = false;
        }

        void CalculateFreezing()
        {
            // Use Start and stop to perform analysis on a subset of the sessions
            int Start = (int)FirstSession.Value-1;
            int Stop = (int)LastSession.Value-1;

            double Tress = Convert.ToDouble(Threshold.Text);
            int TimeToRegister = Convert.ToInt32(TTR.Text)*SampleRate;

            GetSessionIntervals();
            InitDataTable();

            // For each session selected, we calculate the average freezing an in interval or in several
            // periods, depending on the user's choice
            int StartIndex, StopIndex;
            bool MaxExceeded;
            DataRow CurrentRow;
            for (int SessionIndex = Start; SessionIndex <= Stop; ++SessionIndex)
            {
                List<int> FreezeVector = CalculateFreezeVector(ConvertedData[SessionIndex], Tress, TimeToRegister);
                CurrentRow = ExportData.NewRow();

                CurrentRow[0] = SessionIndex+1;
                CurrentRow[1] = FreezeVector.Count / (double)SampleRate;
                CurrentRow[2] = Tress; ;
                CurrentRow[3] = Convert.ToInt32(TTR.Text);

                // Calculate average freezing in selected interval(s)
                MaxExceeded = false;
                for ( int IntervalIndex = 0; (IntervalIndex < SessionIntervals.Count) && (MaxExceeded == false);++IntervalIndex)
                {
                    StartIndex = SessionIntervals[IntervalIndex][0];
                    StopIndex = SessionIntervals[IntervalIndex][1];

                    if (StopIndex >= FreezeVector.Count - 1)
                    {
                        StopIndex = FreezeVector.Count - 1;
                        MaxExceeded = true;
                    }
                    CurrentRow[4 + IntervalIndex] = CalculateAverage(FreezeVector, StartIndex, StopIndex);
                }
                ExportData.Rows.Add(CurrentRow);
            }
        }

        // This function computes which sample points to look at to calculate the freezing behavior for
        // the intervals specified by the user
        void GetSessionIntervals()
        {
            SessionIntervals = new List<List<int>>();
            List<int> CurrentInterval;
            int StartTime, StopTime;

            // Case #1: From each session we look at freezing in a specific time period
            if (!Every.Checked)
            {
                StartTime = (int)StartPeriod.Value;
                StopTime = (int)EndPeriod.Value;

                CurrentInterval = new List<int>(2);
                CurrentInterval.Add(SampleRate * (StartTime - 1));
                CurrentInterval.Add(SampleRate * (StopTime - 1));

                SessionIntervals.Add(CurrentInterval);
            }
            // Case #2: From each session we look at freezing during several, equally spaced, intervals
            // Here we calculate the corresponding sample points of these intervals
            else
            {
                // Find the maximum session length, we will use this to compute the maximum possible interval
                int MaxLength = 0;
                for (int i = 0; i < ConvertedData.Count; ++i)
                {
                    if (ConvertedData[i].Count > MaxLength)
                        MaxLength = ConvertedData[i].Count;
                }

                // Calculate interval points until final interval is higher
                // than the maximum possible length
                int IntervalLength = (int)IntervalRange.Value * SampleRate; // Length of the interval in sample points units
                int IntervalCounter = 0;
                bool MaxExceeded = false;
                do
                {
                    ++IntervalCounter;
                    CurrentInterval = new List<int>(2);
                    CurrentInterval.Add( IntervalLength * (IntervalCounter - 1));
                    CurrentInterval.Add( (IntervalLength * IntervalCounter) - 1);

                    if ( CurrentInterval[1] > (MaxLength-1))
                        MaxExceeded = true;

                    SessionIntervals.Add(CurrentInterval);
                } while (!MaxExceeded);
            }
            
        }

        void InitDataTable()
        {
            ExportData = new DataTable();
            ExportData.Clear();
            ExportData.Columns.Add("Session", typeof(int));
            ExportData.Columns.Add("Duration", typeof(double));
            ExportData.Columns.Add("Threshold", typeof(double));
            ExportData.Columns.Add("TTR", typeof(double));
            for (int i = 0; i < SessionIntervals.Count;++i)
                ExportData.Columns.Add("Freezing_" + Convert.ToString(i), typeof(double));
        }

        // Initiates excell application object and initiates new workbook and worksheet
        void InitiateExcel()
        {
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("Error, Excel is not installed on this system!");
                return;
            }

            xlWorkBook = xlApp.Workbooks.Add(MissingValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        }

        void WriteExcel()
        {
            xlWorkSheet.Cells[1, 1] = "Session";
            xlWorkSheet.Cells[1, 2] = "Duration";
            xlWorkSheet.Cells[1, 3] = "Threshold";
            xlWorkSheet.Cells[1, 4] = "TTR";
            xlWorkSheet.Cells[1, 5] = "Percentage Freezing";

            for (int IntervalIndex = 0; IntervalIndex < SessionIntervals.Count; ++IntervalIndex)
                xlWorkSheet.Cells[2,5+IntervalIndex] = Convert.ToString(SessionIntervals[IntervalIndex][0]/SampleRate) + "-" + Convert.ToString(SessionIntervals[IntervalIndex][1]/SampleRate + "s");

            int CellRow = 3, CellCol = 1;
            foreach ( DataRow CurrentRow in ExportData.Rows)
            {
                CellCol = 1;
                foreach ( object item in CurrentRow.ItemArray)
                {
                    xlWorkSheet.Cells[CellRow,CellCol] = Convert.ToString(item);
                    ++CellCol;
                }
                ++CellRow;
            }
            try
            {
                // Create open file dialog
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                sf.FileName = FileName;
                sf.RestoreDirectory = true;
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    xlWorkBook.SaveAs(sf.FileName);
                    SuccesLabel2.Visible = true;
                    DataWrittenLabel.Text = "Data sucesfully written!";
                    DataWrittenLabel.Visible = true;
                }
                else
                {
                    SuccesLabel2.Visible = false;
                    DataWrittenLabel.Visible = false;
                }
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        // Help function for managing Excel com object
        void ReleaseExcel()
        {
            xlWorkBook.Close(false, MissingValue, MissingValue);
            xlApp.Quit();

            ReleaseObject(xlWorkSheet);
            ReleaseObject(xlWorkBook);
            ReleaseObject(xlApp);
        }

        private void ReleaseObject(object o)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
            }
            catch (Exception ex)
            {
                o = null;
                MessageBox.Show("Error releasing " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }


        // For a given data vector, calculates the freeze vector
        List<int> CalculateFreezeVector(List<double> DataVector, double Treshold, int TTR)
        {
            int DataLength = (int)DataVector.Count;
            List<int> FreezeVector = new List<int>(DataLength);

            int DataIndex = 0, StartIndex = 0;
            while (DataIndex < DataLength)
            {
                if (DataVector[DataIndex] > Treshold)
                {
                    FreezeVector.Add(0);
                    ++DataIndex;
                }
                else
                {
                    StartIndex = DataIndex;
                    while ( (DataIndex < DataLength) && (DataVector[DataIndex] < Treshold))
                    {
                        FreezeVector.Add(0);
                        ++DataIndex;
                    }

                    if ( (DataIndex - StartIndex+1) > TTR)
                    {
                        for (int j = StartIndex; j < FreezeVector.Count; ++j)
                            FreezeVector[j] = 1;
                    }
                }
            }
            return FreezeVector;
        }

        // Returns the mean value in a subset of a list
        double CalculateAverage(List<int> DataVector, int StartPosition, int StopPosition)
        {
            double M = 0;
            for (int i = StartPosition; i <= StopPosition; ++i)
                M += DataVector[i];
            return (100.0 * M / (StopPosition - StartPosition + 1)); 
        }

        // Step by step process for writing the data file
        private void analyse_data_Click(object sender, EventArgs e)
        {
            DataWrittenLabel.Text = "Processing...";
            DataWrittenLabel.Visible = true;

            CalculateFreezing();

            InitiateExcel();
            WriteExcel();

            ReleaseExcel();
        }

        private void EndPeriod_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}
