namespace STSGui
{
    partial class PredictedResultsItem
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
            this.SuspendLayout();
            // 
            // predictedLabel
            // 
            this.predictedLabel.BackColor = System.Drawing.Color.MediumAquamarine;
            this.predictedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.predictedLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.predictedLabel.Location = new System.Drawing.Point(239, 0);
            this.predictedLabel.Name = "predictedLabel";
            this.predictedLabel.Size = new System.Drawing.Size(890, 36);
            this.predictedLabel.TabIndex = 54;
            this.predictedLabel.Text = "0";
            this.predictedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // typeUnitLabel
            // 
            this.typeUnitLabel.BackColor = System.Drawing.Color.White;
            this.typeUnitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.typeUnitLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.typeUnitLabel.Location = new System.Drawing.Point(0, 0);
            this.typeUnitLabel.Name = "typeUnitLabel";
            this.typeUnitLabel.Size = new System.Drawing.Size(249, 36);
            this.typeUnitLabel.TabIndex = 58;
            this.typeUnitLabel.Text = "Unit";
            this.typeUnitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PredictedResultsItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.predictedLabel);
            this.Controls.Add(this.typeUnitLabel);
            this.DoubleBuffered = true;
            this.Name = "PredictedResultsItem";
            this.Size = new System.Drawing.Size(1130, 33);
            this.Load += new System.EventHandler(this.TestsLeftParameterItem_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label predictedLabel;
        private System.Windows.Forms.Label typeUnitLabel;
    }
}
