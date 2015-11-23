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
        // Data objects
        ExcelExport excelExporter;
        cfr_parser cfrParser;

        int sampleRate = 50;
        double thresholdActivity = 4.2;
        int thresholdTime = 1;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        // GUI element callback functions
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "raw files (*.raw)|*.raw|All files (*.*)|*.*";
            of.RestoreDirectory = true;

            if (of.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    cfrParser = new cfr_parser(of.FileName, sampleRate, thresholdActivity, thresholdTime);
                    cfrParser.ReadRawData();
                    EnableAnalysis();
                }
                catch(Exception formException)
                {
                    MessageBox.Show(formException.Message);
                    DisableAnalysis();
                }
            }
        }
        private void analyse_data_Click(object sender, EventArgs e)
        {
            ProgressBar.Value = 0;
            cfrParser.progressBar = ProgressBar;

            try
            {
                if (checkInterval.Checked)
                    cfrParser.ParseInterval((int)FirstSession.Value, (int)LastSession.Value, (int)IntervalRange.Value);
                else
                    cfrParser.ParsePeriod((int)FirstSession.Value, (int)LastSession.Value, (int)StartPeriod.Value, (int)EndPeriod.Value);
                WriteExcel();
                ProgressBar.Value = ProgressBar.Maximum;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        // GUI manipulator functions
        void EnableAnalysis()
        {
            FirstSession.Minimum = 1;
            FirstSession.Maximum = cfrParser.sessionCount;
            FirstSession.Value = 1;

            LastSession.Minimum = 1;
            LastSession.Maximum = cfrParser.sessionCount;
            LastSession.Value = LastSession.Maximum;

            analyse_data.Enabled = true;
        }

        void DisableAnalysis()
        {
            analyse_data.Enabled = false;
        }

        void WriteExcel()
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            sf.FileName = cfrParser.filename;
            sf.RestoreDirectory = true;
            sf.Title = "To which file do you want to save?";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Check if file is already opened
                if (System.IO.File.Exists(sf.FileName))
                {
                    FileStream stream = null;
                    try
                    {
                        stream = File.OpenWrite(sf.FileName);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Cannot write to file. Is it already open in Excel?");
                        return;
                    }
                }

                // Try to export data
                try
                {
                    excelExporter = new ExcelExport();
                    excelExporter.WriteTable(cfrParser.exportData, sf.FileName);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string aboutString = "CFR Analysis program\n" +
                "Created by Christophe Bossens\n";
            MessageBox.Show(aboutString, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void thresholdParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var tp = new thresholdParameters(thresholdActivity,thresholdTime))
            {
                DialogResult dr = tp.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    thresholdActivity = tp.thresholdActivity;
                    thresholdTime = (int)tp.thresholdTime;
                }
            }
        }
        
        
    }
}
