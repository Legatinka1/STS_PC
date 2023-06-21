namespace STSGui
{
    partial class TestsLeftParameterHeader
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
            this.predictedLabel = new System.Windows.Forms.Label();
            this.typeUnitLabel = new System.Windows.Forms.Label();
            this.bestNameLabel = new System.Windows.Forms.Label();
            this.actualNameLabel = new System.Windows.Forms.Label();
            this.apNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // predictedLabel
            // 
            this.predictedLabel.BackColor = System.Drawing.Color.MediumAquamarine;
            this.predictedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.predictedLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.predictedLabel.Location = new System.Drawing.Point(131, 0);
            this.predictedLabel.Name = "predictedLabel";
            this.predictedLabel.Size = new System.Drawing.Size(75, 58);
            this.predictedLabel.TabIndex = 54;
            this.predictedLabel.Text = "Predicted";
            this.predictedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // typeUnitLabel
            // 
            this.typeUnitLabel.BackColor = System.Drawing.Color.White;
            this.typeUnitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.typeUnitLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.typeUnitLabel.Location = new System.Drawing.Point(0, 0);
            this.typeUnitLabel.Name = "typeUnitLabel";
            this.typeUnitLabel.Size = new System.Drawing.Size(130, 58);
            this.typeUnitLabel.TabIndex = 58;
            this.typeUnitLabel.Text = "Type (Unit)";
            this.typeUnitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.typeUnitLabel.DoubleClick += new System.EventHandler(this.typeUnitLabel_DoubleClick);
            // 
            // bestNameLabel
            // 
            this.bestNameLabel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.bestNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bestNameLabel.ForeColor = System.Drawing.Color.White;
            this.bestNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bestNameLabel.Location = new System.Drawing.Point(207, 0);
            this.bestNameLabel.Name = "bestNameLabel";
            this.bestNameLabel.Size = new System.Drawing.Size(139, 28);
            this.bestNameLabel.TabIndex = 63;
            this.bestNameLabel.Text = "BEST (Test 5)";
            this.bestNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // actualNameLabel
            // 
            this.actualNameLabel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.actualNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.actualNameLabel.ForeColor = System.Drawing.Color.White;
            this.actualNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.actualNameLabel.Location = new System.Drawing.Point(207, 30);
            this.actualNameLabel.Name = "actualNameLabel";
            this.actualNameLabel.Size = new System.Drawing.Size(70, 28);
            this.actualNameLabel.TabIndex = 66;
            this.actualNameLabel.Text = "Actual";
            this.actualNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // apNameLabel
            // 
            this.apNameLabel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.apNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.apNameLabel.ForeColor = System.Drawing.Color.White;
            this.apNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.apNameLabel.Location = new System.Drawing.Point(276, 30);
            this.apNameLabel.Name = "apNameLabel";
            this.apNameLabel.Size = new System.Drawing.Size(70, 28);
            this.apNameLabel.TabIndex = 67;
            this.apNameLabel.Text = "%(A/P)";
            this.apNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TestsLeftParameterHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.actualNameLabel);
            this.Controls.Add(this.apNameLabel);
            this.Controls.Add(this.predictedLabel);
            this.Controls.Add(this.typeUnitLabel);
            this.Controls.Add(this.bestNameLabel);
            this.DoubleBuffered = true;
            this.Name = "TestsLeftParameterHeader";
            this.Size = new System.Drawing.Size(348, 58);
            this.Load += new System.EventHandler(this.TestsLeftParameterItem_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label predictedLabel;
        private System.Windows.Forms.Label typeUnitLabel;
        private System.Windows.Forms.Label bestNameLabel;
        private System.Windows.Forms.Label actualNameLabel;
        private System.Windows.Forms.Label apNameLabel;
    }
}
