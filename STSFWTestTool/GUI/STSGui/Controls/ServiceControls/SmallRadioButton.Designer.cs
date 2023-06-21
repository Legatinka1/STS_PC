namespace STSGui
{
    partial class SmallRadioButton
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
            this.radioButtonPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.radioButtonPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButtonPictureBox
            // 
            this.radioButtonPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioButtonPictureBox.Image = global::STSGui.Properties.Resources.selected_radiobtn;
            this.radioButtonPictureBox.Location = new System.Drawing.Point(0, 0);
            this.radioButtonPictureBox.MaximumSize = new System.Drawing.Size(16, 16);
            this.radioButtonPictureBox.MinimumSize = new System.Drawing.Size(16, 16);
            this.radioButtonPictureBox.Name = "radioButtonPictureBox";
            this.radioButtonPictureBox.Size = new System.Drawing.Size(16, 16);
            this.radioButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.radioButtonPictureBox.TabIndex = 0;
            this.radioButtonPictureBox.TabStop = false;
            this.radioButtonPictureBox.Click += new System.EventHandler(this.radioButtonPictureBox_Click);
            // 
            // SmallRadioButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::STSGui.Properties.Resources.unselected_radiobtn;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.radioButtonPictureBox);
            this.DoubleBuffered = true;
            this.Name = "SmallRadioButton";
            this.Size = new System.Drawing.Size(16, 16);
            this.Load += new System.EventHandler(this.SmallRadioButton_Load);
            this.Click += new System.EventHandler(this.SmallRadioButton_Click);
            ((System.ComponentModel.ISupportInitialize)(this.radioButtonPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox radioButtonPictureBox;
    }
}
