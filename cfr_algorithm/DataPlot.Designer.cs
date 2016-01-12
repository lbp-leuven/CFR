namespace cfr_algorithm
{
    partial class DataPlot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.data_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.plot_session_number = new System.Windows.Forms.NumericUpDown();
            this.horizontal_zoom_scroll = new System.Windows.Forms.HScrollBar();
            this.zoom_in = new System.Windows.Forms.Button();
            this.zoom_out = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot_session_number)).BeginInit();
            this.SuspendLayout();
            // 
            // data_chart
            // 
            this.data_chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea5.AxisX.MajorGrid.Enabled = false;
            chartArea5.AxisX.Minimum = 0D;
            chartArea5.AxisX.Title = "Time (s)";
            chartArea5.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea5.Name = "ChartArea1";
            this.data_chart.ChartAreas.Add(chartArea5);
            this.data_chart.Location = new System.Drawing.Point(2, 1);
            this.data_chart.Name = "data_chart";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.IsVisibleInLegend = false;
            series5.MarkerSize = 2;
            series5.Name = "freezeData";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.data_chart.Series.Add(series5);
            this.data_chart.Size = new System.Drawing.Size(433, 317);
            this.data_chart.TabIndex = 0;
            // 
            // plot_session_number
            // 
            this.plot_session_number.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.plot_session_number.Location = new System.Drawing.Point(172, 349);
            this.plot_session_number.Name = "plot_session_number";
            this.plot_session_number.Size = new System.Drawing.Size(84, 20);
            this.plot_session_number.TabIndex = 1;
            this.plot_session_number.ValueChanged += new System.EventHandler(this.plot_session_number_ValueChanged);
            // 
            // horizontal_zoom_scroll
            // 
            this.horizontal_zoom_scroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.horizontal_zoom_scroll.LargeChange = 101;
            this.horizontal_zoom_scroll.Location = new System.Drawing.Point(2, 309);
            this.horizontal_zoom_scroll.Name = "horizontal_zoom_scroll";
            this.horizontal_zoom_scroll.Size = new System.Drawing.Size(431, 24);
            this.horizontal_zoom_scroll.TabIndex = 2;
            this.horizontal_zoom_scroll.Value = 1;
            this.horizontal_zoom_scroll.ValueChanged += new System.EventHandler(this.horizontal_zoom_scroll_ValueChanged);
            // 
            // zoom_in
            // 
            this.zoom_in.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zoom_in.Location = new System.Drawing.Point(414, 336);
            this.zoom_in.Name = "zoom_in";
            this.zoom_in.Size = new System.Drawing.Size(20, 21);
            this.zoom_in.TabIndex = 3;
            this.zoom_in.Text = "+";
            this.zoom_in.UseVisualStyleBackColor = true;
            this.zoom_in.Click += new System.EventHandler(this.zoom_in_Click);
            // 
            // zoom_out
            // 
            this.zoom_out.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zoom_out.Location = new System.Drawing.Point(388, 336);
            this.zoom_out.Name = "zoom_out";
            this.zoom_out.Size = new System.Drawing.Size(20, 21);
            this.zoom_out.TabIndex = 4;
            this.zoom_out.Text = "-";
            this.zoom_out.UseVisualStyleBackColor = true;
            // 
            // DataPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 370);
            this.Controls.Add(this.zoom_out);
            this.Controls.Add(this.zoom_in);
            this.Controls.Add(this.horizontal_zoom_scroll);
            this.Controls.Add(this.plot_session_number);
            this.Controls.Add(this.data_chart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DataPlot";
            this.Text = "Data plot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataPlot_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.data_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plot_session_number)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart data_chart;
        private System.Windows.Forms.NumericUpDown plot_session_number;
        private System.Windows.Forms.HScrollBar horizontal_zoom_scroll;
        private System.Windows.Forms.Button zoom_in;
        private System.Windows.Forms.Button zoom_out;
    }
}