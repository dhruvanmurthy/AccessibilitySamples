namespace AbilitySummit2017_WinForms
{
    partial class ProcessForm
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
            this.labelInstructions = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonProcess = new AbilitySummit2017_WinForms.MyProcessButton(this.labelStatus);
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelInstructions
            // 
            this.labelInstructions.AutoSize = true;
            this.labelInstructions.Location = new System.Drawing.Point(13, 13);
            this.labelInstructions.Name = "labelInstructions";
            this.labelInstructions.Size = new System.Drawing.Size(308, 13);
            this.labelInstructions.TabIndex = 0;
            this.labelInstructions.Text = "Process your data using innovative data processing techniques.";
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(16, 49);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(75, 23);
            this.buttonProcess.TabIndex = 1;
            this.buttonProcess.Text = "&Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(16, 208);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(114, 13);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "Status: Not processing";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(417, 198);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 233);
            this.Controls.Add(this.labelInstructions);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcessForm";
            this.Text = "ProcessForm";
            this.Load += new System.EventHandler(this.ProcessForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInstructions;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonClose;
        private MyProcessButton buttonProcess;
    }
}