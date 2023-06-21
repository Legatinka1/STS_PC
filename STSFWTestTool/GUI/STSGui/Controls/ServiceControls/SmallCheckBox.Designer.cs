namespace STSGui
{
    partial class SmallCheckBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmallCheckBox));
            this.checkBoxPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxPictureBox
            // 
            resources.ApplyResources(this.checkBoxPictureBox, "checkBoxPictureBox");
            this.checkBoxPictureBox.Name = "checkBoxPictureBox";
            this.checkBoxPictureBox.TabStop = false;
            this.checkBoxPictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // SmallCheckBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.checkBoxPictureBox);
            resources.ApplyResources(this, "$this");
            this.Name = "SmallCheckBox";
            this.Load += new System.EventHandler(this.SmallCheckBox_Load);
            this.Click += new System.EventHandler(this.SmallCheckBox_Click);
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox checkBoxPictureBox;
    }
}
