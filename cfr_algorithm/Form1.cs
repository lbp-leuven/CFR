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
        DataParser cfrParser;
        DataPlot dataPlot;

        // List to store interval points that need to be extracted
        List<int> binStartPoints;
        List<int> binEndPoints;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            binStartPoints = new List<int>(10);
            binEndPoints = new List<int>(10);

            output_label.Text = "Press Load Data to load a raw data file";

            cfrParser = new DataParser();

            dataPlot = new DataPlot();
            dataPlot.SetDataParser(cfrParser);
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
                    cfrParser.ReadRawData(of.FileName);
                    EnableAnalysis();
                    dataPlot.SetMaxSession(cfrParser.sessionCount);
                    dataPlot.SetCurrentSession(1);
                    output_label.Text = "Loaded file: " + Path.GetFileName(of.FileName) + "\n\n" +
                        "You can now select your session and extraction method.\n" +
                        "Press analyze data button when ready";
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
            try
            {
                if (checkInterval.Checked)
                {
                    output_label.Text = "Analyzing...";
                    cfrParser.ParseFullSession((int)FirstSession.Value, (int)LastSession.Value, (int)interval_range.Value);
                }
                else
                {
                    if (binStartPoints.Count == 0)
                    {
                        output_label.Text = "Please specify at least one interval.";
                        return;
                    }

                    cfrParser.ParseSelectedIntervals((int)FirstSession.Value, (int)LastSession.Value, binStartPoints, binEndPoints);
                }

                output_label.Text += "Done!\n";
                output_label.Text += "Saving to excel...";
                WriteExcel();
                output_label.Text = "Done. You can now select another file.";
                
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
        private void add_interval_button_Click(object sender, EventArgs e)
        {
            binStartPoints.Add((int)start_interval_time.Value);
            binEndPoints.Add((int)stop_interval_time.Value);

            interval_listbox.Items.Add("From " + start_interval_time.Value.ToString() + " to " + stop_interval_time.Value.ToString() + " seconds");
        }
        private void remove_interval_button_Click(object sender, EventArgs e)
        {
            if (interval_listbox.SelectedIndex >= 0)
            {
                binStartPoints.RemoveAt(interval_listbox.SelectedIndex);
                binEndPoints.RemoveAt(interval_listbox.SelectedIndex);
                interval_listbox.Items.RemoveAt(interval_listbox.SelectedIndex);
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

            analyse_data_button.Enabled = true;
        }
        void DisableAnalysis()
        {
            analyse_data_button.Enabled = false;
        }

        void WriteExcel()
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            sf.FileName = Path.GetFileNameWithoutExtension(cfrParser.filename) + ".xlsx";
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
                        MessageBox.Show("Cannot write to file. If the file is open in Excel, please close it and try to save again.");
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



        private void stop_interval_time_ValueChanged(object sender, EventArgs e)
        {
            if (stop_interval_time.Value <= start_interval_time.Value)
                stop_interval_time.Value = start_interval_time.Value + 1;
        }
        private void start_interval_time_ValueChanged(object sender, EventArgs e)
        {
            if (start_interval_time.Value >= stop_interval_time.Value)
                start_interval_time.Value = stop_interval_time.Value - 1;
        }

        // Menu items callback functions
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string aboutString = "CFR Analysis program\n" +
                "Created by Christophe Bossens\n";
            MessageBox.Show(aboutString, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void thresholdParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var tp = new thresholdParameters(cfrParser.activityThreshold, cfrParser.timeToThreshold))
            {
                DialogResult dr = tp.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    cfrParser.activityThreshold = tp.thresholdActivity;
                    cfrParser.timeToThreshold = tp.thresholdTime;
                }
            }
        }
        private void plotSessionDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (menuItem.Checked)
            {
                dataPlot.Hide();
                menuItem.Checked = false;
            }
            else
            {
                menuItem.Checked = true;
                dataPlot.Show();
            }
        }

    }
}
