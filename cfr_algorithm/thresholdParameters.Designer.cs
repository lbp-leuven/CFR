namespace cfr_algorithm
{
    partial class thresholdParameters
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
            this.threshold_activity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.threshold_time = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ok_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // threshold_activity
            // 
            this.threshold_activity.Location = new System.Drawing.Point(164, 9);
            this.threshold_activity.Name = "threshold_activity";
            this.threshold_activity.Size = new System.Drawing.Size(66, 20);
            this.threshold_activity.TabIndex = 13;
            this.threshold_activity.Text = "4.2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Threshold value";
            // 
            // threshold_time
            // 
            this.threshold_time.Location = new System.Drawing.Point(164, 35);
            this.threshold_time.Name = "threshold_time";
            this.threshold_time.Size = new System.Drawing.Size(66, 20);
            this.threshold_time.TabIndex = 15;
            this.threshold_time.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Threshold time";
            // 
            // ok_button
            // 
            this.ok_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ok_button.Location = new System.Drawing.Point(164, 73);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(66, 31);
            this.ok_button.TabIndex = 16;
            this.ok_button.Text = "OK";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cancel_button.Location = new System.Drawing.Point(92, 73);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(66, 31);
            this.cancel_button.TabIndex = 17;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // thresholdParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 108);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.threshold_time);
            this.Controls.Add(this.threshold_activity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "thresholdParameters";
            this.Text = "Threshold parameters";
            this.Load += new System.EventHandler(this.thresholdParameters_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox threshold_activity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox threshold_time;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.Button cancel_button;
    }
}