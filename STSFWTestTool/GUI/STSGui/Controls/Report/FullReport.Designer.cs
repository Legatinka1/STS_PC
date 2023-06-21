
namespace STSGui.Controls.Report
{
    partial class FullReport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportResultTest1 = new STSGui.Controls.Report.ReportTestControl();
            this.printer1 = new STSGui.Controls.Report.Printer();
            this.SuspendLayout();
            // 
            // reportResultTest1
            // 
            this.reportResultTest1.BackColor = System.Drawing.Color.White;
            this.reportResultTest1.Location = new System.Drawing.Point(769, 0);
            this.reportResultTest1.Name = "reportResultTest1";
            this.reportResultTest1.Size = new System.Drawing.Size(1120, 900);
            this.reportResultTest1.TabIndex = 1;
            this.reportResultTest1.Load += new System.EventHandler(this.reportResultTest1_Load);
            // 
            // printer1
            // 
            this.printer1.BackColor = System.Drawing.Color.Bisque;
            this.printer1.Location = new System.Drawing.Point(72, 0);
            this.printer1.Name = "printer1";
            this.printer1.Size = new System.Drawing.Size(620, 900);
            this.printer1.TabIndex = 0;
            // 
            // FullReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportResultTest1);
            this.Controls.Add(this.printer1);
            this.Name = "FullReport";
            this.Size = new System.Drawing.Size(1920, 913);
            this.Load += new System.EventHandler(this.FullReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Printer printer1;
        private ReportTestControl reportResultTest1;
    }
}
