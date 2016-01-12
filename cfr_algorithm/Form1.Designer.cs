namespace cfr_algorithm
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.load_data_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FirstSession = new System.Windows.Forms.NumericUpDown();
            this.LastSession = new System.Windows.Forms.NumericUpDown();
            this.start_interval_time = new System.Windows.Forms.NumericUpDown();
            this.stop_interval_time = new System.Windows.Forms.NumericUpDown();
            this.interval_range = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.analyse_data_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.remove_interval_button = new System.Windows.Forms.Button();
            this.add_interval_button = new System.Windows.Forms.Button();
            this.interval_listbox = new System.Windows.Forms.ListBox();
            this.checkPeriod = new System.Windows.Forms.RadioButton();
            this.checkInterval = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.output_label = new System.Windows.Forms.Label();
            this.plotSessionDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.FirstSession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastSession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.start_interval_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stop_interval_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interval_range)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // load_data_button
            // 
            this.load_data_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.load_data_button.Location = new System.Drawing.Point(12, 37);
            this.load_data_button.Name = "load_data_button";
            this.load_data_button.Size = new System.Drawing.Size(161, 52);
            this.load_data_button.TabIndex = 0;
            this.load_data_button.Text = "Load data";
            this.load_data_button.UseVisualStyleBackColor = true;
            this.load_data_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "From";
            // 
            // FirstSession
            // 
            this.FirstSession.Location = new System.Drawing.Point(137, 19);
            this.FirstSession.Name = "FirstSession";
            this.FirstSession.Size = new System.Drawing.Size(61, 21);
            this.FirstSession.TabIndex = 4;
            // 
            // LastSession
            // 
            this.LastSession.Location = new System.Drawing.Point(226, 17);
            this.LastSession.Name = "LastSession";
            this.LastSession.Size = new System.Drawing.Size(57, 21);
            this.LastSession.TabIndex = 5;
            // 
            // start_interval_time
            // 
            this.start_interval_time.Location = new System.Drawing.Point(137, 49);
            this.start_interval_time.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.start_interval_time.Name = "start_interval_time";
            this.start_interval_time.Size = new System.Drawing.Size(61, 21);
            this.start_interval_time.TabIndex = 7;
            this.start_interval_time.ValueChanged += new System.EventHandler(this.start_interval_time_ValueChanged);
            // 
            // stop_interval_time
            // 
            this.stop_interval_time.Location = new System.Drawing.Point(226, 49);
            this.stop_interval_time.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.stop_interval_time.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stop_interval_time.Name = "stop_interval_time";
            this.stop_interval_time.Size = new System.Drawing.Size(57, 21);
            this.stop_interval_time.TabIndex = 8;
            this.stop_interval_time.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.stop_interval_time.ValueChanged += new System.EventHandler(this.stop_interval_time_ValueChanged);
            // 
            // interval_range
            // 
            this.interval_range.Location = new System.Drawing.Point(137, 22);
            this.interval_range.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.interval_range.Name = "interval_range";
            this.interval_range.Size = new System.Drawing.Size(61, 21);
            this.interval_range.TabIndex = 10;
            this.interval_range.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Second(s)";
            // 
            // analyse_data_button
            // 
            this.analyse_data_button.Enabled = false;
            this.analyse_data_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyse_data_button.Location = new System.Drawing.Point(213, 37);
            this.analyse_data_button.Name = "analyse_data_button";
            this.analyse_data_button.Size = new System.Drawing.Size(164, 52);
            this.analyse_data_button.TabIndex = 16;
            this.analyse_data_button.Text = "Analyse";
            this.analyse_data_button.UseVisualStyleBackColor = true;
            this.analyse_data_button.Click += new System.EventHandler(this.analyse_data_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.LastSession);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FirstSession);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 50);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select sessions";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "to";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.remove_interval_button);
            this.groupBox2.Controls.Add(this.add_interval_button);
            this.groupBox2.Controls.Add(this.interval_listbox);
            this.groupBox2.Controls.Add(this.checkPeriod);
            this.groupBox2.Controls.Add(this.checkInterval);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.interval_range);
            this.groupBox2.Controls.Add(this.start_interval_time);
            this.groupBox2.Controls.Add(this.stop_interval_time);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 201);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose extraction method";
            // 
            // remove_interval_button
            // 
            this.remove_interval_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.remove_interval_button.Location = new System.Drawing.Point(328, 73);
            this.remove_interval_button.Name = "remove_interval_button";
            this.remove_interval_button.Size = new System.Drawing.Size(24, 27);
            this.remove_interval_button.TabIndex = 18;
            this.remove_interval_button.Text = "-";
            this.remove_interval_button.UseVisualStyleBackColor = true;
            this.remove_interval_button.Click += new System.EventHandler(this.remove_interval_button_Click);
            // 
            // add_interval_button
            // 
            this.add_interval_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.add_interval_button.Location = new System.Drawing.Point(298, 73);
            this.add_interval_button.Name = "add_interval_button";
            this.add_interval_button.Size = new System.Drawing.Size(24, 27);
            this.add_interval_button.TabIndex = 17;
            this.add_interval_button.Text = "+";
            this.add_interval_button.UseVisualStyleBackColor = true;
            this.add_interval_button.Click += new System.EventHandler(this.add_interval_button_Click);
            // 
            // interval_listbox
            // 
            this.interval_listbox.FormattingEnabled = true;
            this.interval_listbox.ItemHeight = 15;
            this.interval_listbox.Location = new System.Drawing.Point(137, 101);
            this.interval_listbox.Name = "interval_listbox";
            this.interval_listbox.Size = new System.Drawing.Size(215, 94);
            this.interval_listbox.TabIndex = 16;
            // 
            // checkPeriod
            // 
            this.checkPeriod.AutoSize = true;
            this.checkPeriod.Location = new System.Drawing.Point(7, 48);
            this.checkPeriod.Name = "checkPeriod";
            this.checkPeriod.Size = new System.Drawing.Size(90, 19);
            this.checkPeriod.TabIndex = 15;
            this.checkPeriod.Text = "Extract from";
            this.checkPeriod.UseVisualStyleBackColor = true;
            // 
            // checkInterval
            // 
            this.checkInterval.AutoSize = true;
            this.checkInterval.Checked = true;
            this.checkInterval.Location = new System.Drawing.Point(6, 22);
            this.checkInterval.Name = "checkInterval";
            this.checkInterval.Size = new System.Drawing.Size(53, 19);
            this.checkInterval.TabIndex = 14;
            this.checkInterval.TabStop = true;
            this.checkInterval.Text = "Each";
            this.checkInterval.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(289, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 15);
            this.label10.TabIndex = 13;
            this.label10.Text = "Second(s)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(204, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "to";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(383, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thresholdParametersToolStripMenuItem,
            this.plotSessionDataToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionToolStripMenuItem.Text = "&Options";
            // 
            // thresholdParametersToolStripMenuItem
            // 
            this.thresholdParametersToolStripMenuItem.Name = "thresholdParametersToolStripMenuItem";
            this.thresholdParametersToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.thresholdParametersToolStripMenuItem.Text = "Threshold parameters";
            this.thresholdParametersToolStripMenuItem.Click += new System.EventHandler(this.thresholdParametersToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // output_label
            // 
            this.output_label.BackColor = System.Drawing.Color.NavajoWhite;
            this.output_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.output_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.output_label.Location = new System.Drawing.Point(12, 363);
            this.output_label.Name = "output_label";
            this.output_label.Size = new System.Drawing.Size(365, 100);
            this.output_label.TabIndex = 24;
            // 
            // plotSessionDataToolStripMenuItem
            // 
            this.plotSessionDataToolStripMenuItem.Name = "plotSessionDataToolStripMenuItem";
            this.plotSessionDataToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.plotSessionDataToolStripMenuItem.Text = "Plot session data";
            this.plotSessionDataToolStripMenuItem.Click += new System.EventHandler(this.plotSessionDataToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 472);
            this.Controls.Add(this.output_label);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.analyse_data_button);
            this.Controls.Add(this.load_data_button);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CFR";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FirstSession)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastSession)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.start_interval_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stop_interval_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interval_range)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button load_data_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown FirstSession;
        private System.Windows.Forms.NumericUpDown LastSession;
        private System.Windows.Forms.NumericUpDown start_interval_time;
        private System.Windows.Forms.NumericUpDown stop_interval_time;
        private System.Windows.Forms.NumericUpDown interval_range;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button analyse_data_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton checkPeriod;
        private System.Windows.Forms.RadioButton checkInterval;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdParametersToolStripMenuItem;
        private System.Windows.Forms.Label output_label;
        private System.Windows.Forms.Button remove_interval_button;
        private System.Windows.Forms.Button add_interval_button;
        private System.Windows.Forms.ListBox interval_listbox;
        private System.Windows.Forms.ToolStripMenuItem plotSessionDataToolStripMenuItem;
    }
}

