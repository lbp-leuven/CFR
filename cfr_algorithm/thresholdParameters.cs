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
    public partial class thresholdParameters : Form
    {
        public double thresholdTime;
        public double thresholdActivity;
        public thresholdParameters()
        {
            InitializeComponent();
        }

        public thresholdParameters(double v1, double v2)
        {
            InitializeComponent();
            thresholdActivity = v1;
            thresholdTime = v2;
        }
        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            thresholdTime = Convert.ToDouble(threshold_time.Text);
            thresholdActivity = Convert.ToDouble(threshold_activity.Text);
            this.Close();
        }

        private void thresholdParameters_Load(object sender, EventArgs e)
        {
            threshold_time.Text = thresholdTime.ToString();
            threshold_activity.Text = thresholdActivity.ToString();
        }
    }
}
