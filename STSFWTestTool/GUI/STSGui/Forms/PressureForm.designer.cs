
namespace BelkinEagleGui.Forms
{
    partial class PressureForm
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
            this.pressureControl1 = new STSGui.Controls.Pressure.PressureControl();
            this.SuspendLayout();
            // 
            // pressureControl1
            // 
            this.pressureControl1.BackColor = System.Drawing.SystemColors.Control;
            this.pressureControl1.Location = new System.Drawing.Point(144, 12);
            this.pressureControl1.Name = "pressureControl1";
            this.pressureControl1.Size = new System.Drawing.Size(1500, 900);
            this.pressureControl1.TabIndex = 0;
            // 
            // PressureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pressureControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PressureForm";
            this.Text = "MessageBoxFormBackGround";
            this.Load += new System.EventHandler(this.PressureForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private STSGui.Controls.Pressure.PressureControl pressureControl1;
    }
}