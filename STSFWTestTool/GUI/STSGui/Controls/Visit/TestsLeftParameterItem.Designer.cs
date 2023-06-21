namespace STSGui
{
    partial class TestsLeftParameterItem
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
            this.actual_Best_ValueLabel = new System.Windows.Forms.Label();
            this.actual_Best_A_P_ValueLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // predictedLabel
            // 
            this.predictedLabel.BackColor = System.Drawing.Color.MediumAquamarine;
            this.predictedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.predictedLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.predictedLabel.Location = new System.Drawing.Point(131, 0);
            this.predictedLabel.Name = "predictedLabel";
            this.predictedLabel.Size = new System.Drawing.Size(75, 33);
            this.predictedLabel.TabIndex = 54;
            this.predictedLabel.Text = "0";
            this.predictedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // typeUnitLabel
            // 
            this.typeUnitLabel.BackColor = System.Drawing.Color.White;
            this.typeUnitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.typeUnitLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.typeUnitLabel.Location = new System.Drawing.Point(0, 0);
            this.typeUnitLabel.Name = "typeUnitLabel";
            this.typeUnitLabel.Size = new System.Drawing.Size(130, 33);
            this.typeUnitLabel.TabIndex = 58;
            this.typeUnitLabel.Text = "Unit";
            this.typeUnitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // actual_Best_ValueLabel
            // 
            this.actual_Best_ValueLabel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.actual_Best_ValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.actual_Best_ValueLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.actual_Best_ValueLabel.Location = new System.Drawing.Point(207, 0);
            this.actual_Best_ValueLabel.Name = "actual_Best_ValueLabel";
            this.actual_Best_ValueLabel.Size = new System.Drawing.Size(70, 33);
            this.actual_Best_ValueLabel.TabIndex = 63;
            this.actual_Best_ValueLabel.Text = "Best";
            this.actual_Best_ValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // actual_Best_A_P_ValueLabel
            // 
            this.actual_Best_A_P_ValueLabel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.actual_Best_A_P_ValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.actual_Best_A_P_ValueLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.actual_Best_A_P_ValueLabel.Location = new System.Drawing.Point(277, 0);
            this.actual_Best_A_P_ValueLabel.Name = "actual_Best_A_P_ValueLabel";
            this.actual_Best_A_P_ValueLabel.Size = new System.Drawing.Size(70, 33);
            this.actual_Best_A_P_ValueLabel.TabIndex = 65;
            this.actual_Best_A_P_ValueLabel.Text = "B%";
            this.actual_Best_A_P_ValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TestsLeftParameterItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.predictedLabel);
            this.Controls.Add(this.typeUnitLabel);
            this.Controls.Add(this.actual_Best_ValueLabel);
            this.Controls.Add(this.actual_Best_A_P_ValueLabel);
            this.DoubleBuffered = true;
            this.Name = "TestsLeftParameterItem";
            this.Size = new System.Drawing.Size(348, 33);
            this.Load += new System.EventHandler(this.TestsLeftParameterItem_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label predictedLabel;
        private System.Windows.Forms.Label typeUnitLabel;
        private System.Windows.Forms.Label actual_Best_ValueLabel;
        private System.Windows.Forms.Label actual_Best_A_P_ValueLabel;
    }
}
