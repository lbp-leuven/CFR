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
            this.SuccesLabel1 = new System.Windows.Forms.Label();
            this.DataLoadedLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FirstSession = new System.Windows.Forms.NumericUpDown();
            this.LastSession = new System.Windows.Forms.NumericUpDown();
            this.StartPeriod = new System.Windows.Forms.NumericUpDown();
            this.EndPeriod = new System.Windows.Forms.NumericUpDown();
            this.Every = new System.Windows.Forms.CheckBox();
            this.IntervalRange = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Threshold = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TTR = new System.Windows.Forms.TextBox();
            this.analyse_data = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuccesLabel2 = new System.Windows.Forms.Label();
            this.DataWrittenLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FirstSession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastSession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalRange)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.Location = new System.Drawing.Point(12, 12);
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(96, 30);
            this.LoadDataButton.TabIndex = 0;
            this.LoadDataButton.Text = "Load data";
            this.LoadDataButton.UseVisualStyleBackColor = true;
            this.LoadDataButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // SuccesLabel1
            // 
            this.SuccesLabel1.AutoSize = true;
            this.SuccesLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuccesLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SuccesLabel1.Location = new System.Drawing.Point(110, 19);
            this.SuccesLabel1.Name = "SuccesLabel1";
            this.SuccesLabel1.Size = new System.Drawing.Size(58, 17);
            this.SuccesLabel1.TabIndex = 1;
            this.SuccesLabel1.Text = "\\u2713";
            this.SuccesLabel1.Visible = false;
            // 
            // DataLoadedLabel
            // 
            this.DataLoadedLabel.AutoSize = true;
            this.DataLoadedLabel.Location = new System.Drawing.Point(174, 21);
            this.DataLoadedLabel.Name = "DataLoadedLabel";
            this.DataLoadedLabel.Size = new System.Drawing.Size(80, 13);
            this.DataLoadedLabel.TabIndex = 2;
            this.DataLoadedLabel.Text = "No data loaded";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "From";
            // 
            // FirstSession
            // 
            this.FirstSession.Location = new System.Drawing.Point(100, 23);
            this.FirstSession.Name = "FirstSession";
            this.FirstSession.Size = new System.Drawing.Size(61, 20);
            this.FirstSession.TabIndex = 4;
            // 
            // LastSession
            // 
            this.LastSession.Location = new System.Drawing.Point(226, 24);
            this.LastSession.Name = "LastSession";
            this.LastSession.Size = new System.Drawing.Size(57, 20);
            this.LastSession.TabIndex = 5;
            // 
            // StartPeriod
            // 
            this.StartPeriod.Location = new System.Drawing.Point(100, 64);
            this.StartPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.StartPeriod.Name = "StartPeriod";
            this.StartPeriod.Size = new System.Drawing.Size(61, 20);
            this.StartPeriod.TabIndex = 7;
            this.StartPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.EndPeriod.Size = new System.Drawing.Size(57, 20);
            this.EndPeriod.TabIndex = 8;
            this.EndPeriod.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.EndPeriod.ValueChanged += new System.EventHandler(this.EndPeriod_ValueChanged);
            // 
            // Every
            // 
            this.Every.AutoSize = true;
            this.Every.Checked = true;
            this.Every.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Every.Location = new System.Drawing.Point(15, 22);
            this.Every.Name = "Every";
            this.Every.Size = new System.Drawing.Size(53, 17);
            this.Every.TabIndex = 9;
            this.Every.Text = "Every";
            this.Every.UseVisualStyleBackColor = true;
            // 
            // IntervalRange
            // 
            this.IntervalRange.Location = new System.Drawing.Point(100, 21);
            this.IntervalRange.Name = "IntervalRange";
            this.IntervalRange.Size = new System.Drawing.Size(61, 20);
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
            this.label3.Location = new System.Drawing.Point(172, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Second(s)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Threshold";
            // 
            // Threshold
            // 
            this.Threshold.Location = new System.Drawing.Point(101, 35);
            this.Threshold.Name = "Threshold";
            this.Threshold.Size = new System.Drawing.Size(57, 20);
            this.Threshold.TabIndex = 13;
            this.Threshold.Text = "4.2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "TTR";
            // 
            // TTR
            // 
            this.TTR.Location = new System.Drawing.Point(226, 35);
            this.TTR.Name = "TTR";
            this.TTR.Size = new System.Drawing.Size(57, 20);
            this.TTR.TabIndex = 15;
            this.TTR.Text = "1";
            // 
            // analyse_data
            // 
            this.analyse_data.Enabled = false;
            this.analyse_data.Location = new System.Drawing.Point(12, 51);
            this.analyse_data.Name = "analyse_data";
            this.analyse_data.Size = new System.Drawing.Size(96, 30);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 61);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select sessions";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "to";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.IntervalRange);
            this.groupBox2.Controls.Add(this.StartPeriod);
            this.groupBox2.Controls.Add(this.EndPeriod);
            this.groupBox2.Controls.Add(this.Every);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(358, 89);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Extraction method";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(289, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Second(s)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(204, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "to";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "from";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "OR";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.Threshold);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.TTR);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 250);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(358, 69);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Threshold parameters";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(289, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Second(s)";
            // 
            // SuccesLabel2
            // 
            this.SuccesLabel2.AutoSize = true;
            this.SuccesLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuccesLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SuccesLabel2.Location = new System.Drawing.Point(109, 58);
            this.SuccesLabel2.Name = "SuccesLabel2";
            this.SuccesLabel2.Size = new System.Drawing.Size(58, 17);
            this.SuccesLabel2.TabIndex = 20;
            this.SuccesLabel2.Text = "\\u2713";
            this.SuccesLabel2.Visible = false;
            // 
            // DataWrittenLabel
            // 
            this.DataWrittenLabel.AutoSize = true;
            this.DataWrittenLabel.Location = new System.Drawing.Point(174, 58);
            this.DataWrittenLabel.Name = "DataWrittenLabel";
            this.DataWrittenLabel.Size = new System.Drawing.Size(133, 13);
            this.DataWrittenLabel.TabIndex = 21;
            this.DataWrittenLabel.Text = "Data succesfuly extracted!";
            this.DataWrittenLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 328);
            this.Controls.Add(this.DataWrittenLabel);
            this.Controls.Add(this.SuccesLabel2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.analyse_data);
            this.Controls.Add(this.DataLoadedLabel);
            this.Controls.Add(this.SuccesLabel1);
            this.Controls.Add(this.LoadDataButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadDataButton;
        private System.Windows.Forms.Label SuccesLabel1;
        private System.Windows.Forms.Label DataLoadedLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown FirstSession;
        private System.Windows.Forms.NumericUpDown LastSession;
        private System.Windows.Forms.NumericUpDown StartPeriod;
        private System.Windows.Forms.NumericUpDown EndPeriod;
        private System.Windows.Forms.CheckBox Every;
        private System.Windows.Forms.NumericUpDown IntervalRange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Threshold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TTR;
        private System.Windows.Forms.Button analyse_data;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label SuccesLabel2;
        private System.Windows.Forms.Label DataWrittenLabel;
    }
}

