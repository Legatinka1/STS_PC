namespace STSGui
{
    partial class RecentlyVisitedItem
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecentlyVisitedItem));
            this.nameLabel = new System.Windows.Forms.Label();
            this.doctorFirstLastNameLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.labelToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.photoPictureBox = new System.Windows.Forms.PictureBox();
            this.openExtentionPictureBox = new STSGui.ButtonPictureBox();
            this.itemBackgroundPictureBox = new STSGui.RoundedCornersPanel();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openExtentionPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.nameLabel, "nameLabel");
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.MouseEnter += new System.EventHandler(this.parameterLabel_MouseEnter);
            // 
            // doctorFirstLastNameLabel
            // 
            this.doctorFirstLastNameLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.doctorFirstLastNameLabel, "doctorFirstLastNameLabel");
            this.doctorFirstLastNameLabel.Name = "doctorFirstLastNameLabel";
            this.doctorFirstLastNameLabel.MouseEnter += new System.EventHandler(this.parameterLabel_MouseEnter);
            // 
            // idLabel
            // 
            this.idLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.idLabel, "idLabel");
            this.idLabel.Name = "idLabel";
            this.idLabel.MouseEnter += new System.EventHandler(this.parameterLabel_MouseEnter);
            // 
            // dateLabel
            // 
            this.dateLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.dateLabel, "dateLabel");
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.MouseEnter += new System.EventHandler(this.parameterLabel_MouseEnter);
            // 
            // labelToolTip
            // 
            this.labelToolTip.IsBalloon = true;
            // 
            // photoPictureBox
            // 
            this.photoPictureBox.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.photoPictureBox, "photoPictureBox");
            this.photoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.photoPictureBox.Name = "photoPictureBox";
            this.photoPictureBox.TabStop = false;
            this.photoPictureBox.Tag = "false";
            this.photoPictureBox.MouseEnter += new System.EventHandler(this.parameterLabel_MouseEnter);
            // 
            // openExtentionPictureBox
            // 
            this.openExtentionPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.openExtentionPictureBox.DisableImage = global::STSGui.Properties.Resources.patients_list_arrow_right_btn_disable;
            resources.ApplyResources(this.openExtentionPictureBox, "openExtentionPictureBox");
            this.openExtentionPictureBox.Image = global::STSGui.Properties.Resources.patients_list_arrow_right_btn_normal;
            this.openExtentionPictureBox.IsTextColorMouseChanged = true;
            this.openExtentionPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_list_arrow_right_btn_down;
            this.openExtentionPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_list_arrow_right_btn_over;
            this.openExtentionPictureBox.Name = "openExtentionPictureBox";
            this.openExtentionPictureBox.NormalImage = global::STSGui.Properties.Resources.patients_list_arrow_right_btn_normal;
            this.openExtentionPictureBox.TabStop = false;
            this.openExtentionPictureBox.TextColor = System.Drawing.Color.Black;
            this.openExtentionPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openExtentionPictureBox.XTextOffset = 0;
            this.openExtentionPictureBox.YTextOffset = 0;
            this.openExtentionPictureBox.Click += new System.EventHandler(this.openExtentionPictureBox_Click);
            this.openExtentionPictureBox.MouseEnter += new System.EventHandler(this.parameterLabel_MouseEnter);
            // 
            // itemBackgroundPictureBox
            // 
            this.itemBackgroundPictureBox.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.itemBackgroundPictureBox, "itemBackgroundPictureBox");
            this.itemBackgroundPictureBox.Name = "itemBackgroundPictureBox";
            this.itemBackgroundPictureBox.Radius = 40;
            this.itemBackgroundPictureBox.MouseEnter += new System.EventHandler(this.settingsPictureBox_MouseEnter);
            this.itemBackgroundPictureBox.MouseLeave += new System.EventHandler(this.settingsPictureBox_MouseLeave);
            // 
            // RecentlyVisitedItem
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.openExtentionPictureBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.doctorFirstLastNameLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.photoPictureBox);
            this.Controls.Add(this.itemBackgroundPictureBox);
            this.DoubleBuffered = true;
            this.Name = "RecentlyVisitedItem";
            this.Load += new System.EventHandler(this.RecentlyVisitedItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openExtentionPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label doctorFirstLastNameLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.ToolTip labelToolTip;
        private System.Windows.Forms.PictureBox photoPictureBox;
        private ButtonPictureBox openExtentionPictureBox;
        private RoundedCornersPanel itemBackgroundPictureBox;
    }
}
