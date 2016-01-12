using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cfr_algorithm
{
    public partial class DataPlot : Form
    {
        DataParser dataParser;
        List<double> sessionActivity;
        int sessionPoints;
        double sessionDuration;
        double sessionThreshold;

        int currentSessionNumber;
        int previousSessionNumber;
        int maxSessions;

        public DataPlot()
        {
            InitializeComponent();

            currentSessionNumber = 0;
            previousSessionNumber = 0;
            maxSessions = -1;
        }

        public void SetDataParser(DataParser dp)
        {
            this.dataParser = dp;
        }

        public void SetMaxSession(int maxSessions)
        {
            this.maxSessions = maxSessions;
            plot_session_number.Maximum = maxSessions;
        }
        public void SetCurrentSession(int sessionIndex)
        {
            currentSessionNumber = sessionIndex;

            if (currentSessionNumber < 1 || currentSessionNumber > maxSessions)
            {
                currentSessionNumber = previousSessionNumber;
                plot_session_number.Value = previousSessionNumber;
                return;
            }

            previousSessionNumber = currentSessionNumber;
            plot_session_number.Value = currentSessionNumber;
            Update();
        }
        private void plot_session_number_ValueChanged(object sender, EventArgs e)
        {
            currentSessionNumber = (int)plot_session_number.Value;
            if (currentSessionNumber < 1 || currentSessionNumber > maxSessions)
            {
                currentSessionNumber = previousSessionNumber;
                plot_session_number.Value = previousSessionNumber;
                return;
            }

            previousSessionNumber = currentSessionNumber;
            Update();
        }

        private void Update()
        {
            sessionPoints = dataParser.GetSessionActivityLength(currentSessionNumber-1);

            if (sessionPoints > 0)
            {
                sessionActivity = dataParser.GetSessionActivityValues(currentSessionNumber-1);
                sessionDuration = dataParser.GetSessionDuration(currentSessionNumber-1);
                sessionThreshold = dataParser.activityThreshold;
                PlotActivity();
            }
            else
            {
                ClearPlot();
            }
        }
        private void PlotActivity()
        {
            data_chart.ChartAreas[0].AxisX.Minimum = 0;
            data_chart.ChartAreas[0].AxisX.Maximum = sessionDuration;
            data_chart.ChartAreas[0].AxisY.Minimum = 0;
            data_chart.ChartAreas[0].AxisY.Maximum = 100.0;

            data_chart.Series[0].Points.Clear();
            for (int i = 0; i < sessionPoints; ++i)
            {
                data_chart.Series[0].Points.AddXY(0.02 * i, sessionActivity[i]);
                if (sessionActivity[i] < sessionThreshold)
                    data_chart.Series[0].Points[i].Color = System.Drawing.Color.Green;
                else
                    data_chart.Series[0].Points[i].Color = System.Drawing.Color.Red;
            }
            
            data_chart.Update();
        }
        private void ClearPlot()
        {
            data_chart.Series[0].Points.Clear();
            data_chart.Update();
        }

        private void DataPlot_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void zoom_in_Click(object sender, EventArgs e)
        {
            data_chart.ChartAreas[0].AxisX.Maximum = sessionDuration / 2.0;
            horizontal_zoom_scroll.LargeChange = (int)Math.Max(25.0, horizontal_zoom_scroll.LargeChange / 2.0);
            data_chart.Update();
        }

        private void horizontal_zoom_scroll_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
