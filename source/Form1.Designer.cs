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
            this.LoadDataButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FirstSession = new System.Windows.Forms.NumericUpDown();
            this.LastSession = new System.Windows.Forms.NumericUpDown();
            this.StartPeriod = new System.Windows.Forms.NumericUpDown();
            this.EndPeriod = new System.Windows.Forms.NumericUpDown();
            this.IntervalRange = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.analyse_data = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkPeriod = new System.Windows.Forms.RadioButton();
            this.checkInterval = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.FirstSession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastSession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalRange)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadDataButton.Location = new System.Drawing.Point(12, 26);
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(161, 69);
            this.LoadDataButton.TabIndex = 0;
            this.LoadDataButton.Text = "Load data";
            this.LoadDataButton.UseVisualStyleBackColor = true;
            this.LoadDataButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "From";
            // 
            // FirstSession
            // 
            this.FirstSession.Location = new System.Drawing.Point(137, 23);
            this.FirstSession.Name = "FirstSession";
            this.FirstSession.Size = new System.Drawing.Size(61, 23);
            this.FirstSession.TabIndex = 4;
            // 
            // LastSession
            // 
            this.LastSession.Location = new System.Drawing.Point(226, 23);
            this.LastSession.Name = "LastSession";
            this.LastSession.Size = new System.Drawing.Size(57, 23);
            this.LastSession.TabIndex = 5;
            // 
            // StartPeriod
            // 
            this.StartPeriod.Location = new System.Drawing.Point(137, 63);
            this.StartPeriod.Name = "StartPeriod";
            this.StartPeriod.Size = new System.Drawing.Size(61, 23);
            this.StartPeriod.TabIndex = 7;
            // 
            // EndPeriod
            // 
            this.EndPeriod.Location = new System.Drawing.Point(226, 64);
            this.EndPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EndPeriod.Name = "EndPeriod";
            this.EndPeriod.Size = new System.Drawing.Size(57, 23);
            this.EndPeriod.TabIndex = 8;
            this.EndPeriod.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // IntervalRange
            // 
            this.IntervalRange.Location = new System.Drawing.Point(137, 22);
            this.IntervalRange.Name = "IntervalRange";
            this.IntervalRange.Size = new System.Drawing.Size(61, 23);
            this.IntervalRange.TabIndex = 10;
            this.IntervalRange.Value = new decimal(new int[] {
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
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Second(s)";
            // 
            // analyse_data
            // 
            this.analyse_data.Enabled = false;
            this.analyse_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyse_data.Location = new System.Drawing.Point(213, 26);
            this.analyse_data.Name = "analyse_data";
            this.analyse_data.Size = new System.Drawing.Size(164, 69);
            this.analyse_data.TabIndex = 16;
            this.analyse_data.Text = "Analyse";
            this.analyse_data.UseVisualStyleBackColor = true;
            this.analyse_data.Click += new System.EventHandler(this.analyse_data_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.LastSession);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FirstSession);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 61);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select sessions";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "to";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkPeriod);
            this.groupBox2.Controls.Add(this.checkInterval);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.IntervalRange);
            this.groupBox2.Controls.Add(this.StartPeriod);
            this.groupBox2.Controls.Add(this.EndPeriod);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 89);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose extraction method";
            // 
            // checkPeriod
            // 
            this.checkPeriod.AutoSize = true;
            this.checkPeriod.Location = new System.Drawing.Point(7, 62);
            this.checkPeriod.Name = "checkPeriod";
            this.checkPeriod.Size = new System.Drawing.Size(101, 21);
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
            this.checkInterval.Size = new System.Drawing.Size(58, 21);
            this.checkInterval.TabIndex = 14;
            this.checkInterval.TabStop = true;
            this.checkInterval.Text = "Each";
            this.checkInterval.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(289, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 17);
            this.label10.TabIndex = 13;
            this.label10.Text = "Second(s)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(204, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "to";
            // 
            // ProgressBar
            // 
            this.ProgressBar.BackColor = System.Drawing.SystemColors.Control;
            this.ProgressBar.Location = new System.Drawing.Point(12, 101);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(365, 19);
            this.ProgressBar.Step = 1;
            this.ProgressBar.TabIndex = 22;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(389, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thresholdParametersToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionToolStripMenuItem.Text = "&Options";
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
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // thresholdParametersToolStripMenuItem
            // 
            this.thresholdParametersToolStripMenuItem.Name = "thresholdParametersToolStripMenuItem";
            this.thresholdParametersToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.thresholdParametersToolStripMenuItem.Text = "Threshold parameters";
            this.thresholdParametersToolStripMenuItem.Click += new System.EventHandler(this.thresholdParametersToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 310);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.analyse_data);
            this.Controls.Add(this.LoadDataButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CFR";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FirstSession)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastSession)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalRange)).EndInit();
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

        private System.Windows.Forms.Button LoadDataButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown FirstSession;
        private System.Windows.Forms.NumericUpDown LastSession;
        private System.Windows.Forms.NumericUpDown StartPeriod;
        private System.Windows.Forms.NumericUpDown EndPeriod;
        private System.Windows.Forms.NumericUpDown IntervalRange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button analyse_data;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton checkPeriod;
        private System.Windows.Forms.RadioButton checkInterval;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdParametersToolStripMenuItem;
    }
}

