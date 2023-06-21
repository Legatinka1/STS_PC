namespace STSGui
{
    partial class AllVisitsItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllVisitsItem));
            this.doctorFirstLastNameLabel = new System.Windows.Forms.Label();
            this.dateVisitLabel = new System.Windows.Forms.Label();
            this.bloodPresureLabel = new System.Windows.Forms.Label();
            this.labelToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.testTypeLabel = new System.Windows.Forms.Label();
            this.openExtentionPictureBox = new STSGui.ButtonPictureBox();
            this.itemBackgroundPictureBox = new STSGui.RoundedCornersPanel();
            this.deleteExtentionPictureBox = new STSGui.ButtonPictureBox();
            this.tempertureLabel = new System.Windows.Forms.Label();
            this.pulseLabel = new System.Windows.Forms.Label();
            this.statusPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.openExtentionPictureBox)).BeginInit();
            this.itemBackgroundPictureBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deleteExtentionPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // doctorFirstLastNameLabel
            // 
            this.doctorFirstLastNameLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.doctorFirstLastNameLabel, "doctorFirstLastNameLabel");
            this.doctorFirstLastNameLabel.Name = "doctorFirstLastNameLabel";
            this.doctorFirstLastNameLabel.MouseEnter += new System.EventHandler(this.parameterLabel_MouseEnter);
            // 
            // dateVisitLabel
            // 
            this.dateVisitLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.dateVisitLabel, "dateVisitLabel");
            this.dateVisitLabel.Name = "dateVisitLabel";
            this.dateVisitLabel.MouseEnter += new System.EventHandler(this.parameterLabel_MouseEnter);
            // 
            // bloodPresureLabel
            // 
            this.bloodPresureLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.bloodPresureLabel, "bloodPresureLabel");
            this.bloodPresureLabel.Name = "bloodPresureLabel";
            this.bloodPresureLabel.MouseEnter += new System.EventHandler(this.parameterLabel_MouseEnter);
            // 
            // labelToolTip
            // 
            this.labelToolTip.IsBalloon = true;
            // 
            // testTypeLabel
            // 
            this.testTypeLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.testTypeLabel, "testTypeLabel");
            this.testTypeLabel.Name = "testTypeLabel";
            this.testTypeLabel.MouseEnter += new System.EventHandler(this.parameterLabel_MouseEnter);
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
            this.itemBackgroundPictureBox.Controls.Add(this.deleteExtentionPictureBox);
            this.itemBackgroundPictureBox.Controls.Add(this.tempertureLabel);
            this.itemBackgroundPictureBox.Controls.Add(this.pulseLabel);
            this.itemBackgroundPictureBox.Controls.Add(this.dateVisitLabel);
            this.itemBackgroundPictureBox.Controls.Add(this.statusPictureBox);
            resources.ApplyResources(this.itemBackgroundPictureBox, "itemBackgroundPictureBox");
            this.itemBackgroundPictureBox.Name = "itemBackgroundPictureBox";
            this.itemBackgroundPictureBox.Radius = 40;
            this.itemBackgroundPictureBox.MouseEnter += new System.EventHandler(this.settingsPictureBox_MouseEnter);
            this.itemBackgroundPictureBox.MouseLeave += new System.EventHandler(this.settingsPictureBox_MouseLeave);
            // 
            // deleteExtentionPictureBox
            // 
            this.deleteExtentionPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.deleteExtentionPictureBox.DisableImage = global::STSGui.Properties.Resources.visit_remove_test_over;
            resources.ApplyResources(this.deleteExtentionPictureBox, "deleteExtentionPictureBox");
            this.deleteExtentionPictureBox.Image = global::STSGui.Properties.Resources.visit_remove_test_over;
            this.deleteExtentionPictureBox.IsTextColorMouseChanged = true;
            this.deleteExtentionPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_details_red_res_ellipse;
            this.deleteExtentionPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_details_red_res_ellipse;
            this.deleteExtentionPictureBox.Name = "deleteExtentionPictureBox";
            this.deleteExtentionPictureBox.NormalImage = global::STSGui.Properties.Resources.visit_remove_test_over;
            this.deleteExtentionPictureBox.TabStop = false;
            this.deleteExtentionPictureBox.TextColor = System.Drawing.Color.Black;
            this.deleteExtentionPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteExtentionPictureBox.XTextOffset = 0;
            this.deleteExtentionPictureBox.YTextOffset = 0;
            this.deleteExtentionPictureBox.Click += new System.EventHandler(this.deleteExtentionPictureBox_Click);
            // 
            // tempertureLabel
            // 
            this.tempertureLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.tempertureLabel, "tempertureLabel");
            this.tempertureLabel.Name = "tempertureLabel";
            this.tempertureLabel.MouseEnter += new System.EventHandler(this.parameterLabel_MouseEnter);
            // 
            // pulseLabel
            // 
            this.pulseLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pulseLabel, "pulseLabel");
            this.pulseLabel.Name = "pulseLabel";
            this.pulseLabel.MouseEnter += new System.EventHandler(this.parameterLabel_MouseEnter);
            // 
            // statusPictureBox
            // 
            this.statusPictureBox.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.statusPictureBox, "statusPictureBox");
            this.statusPictureBox.Image = global::STSGui.Properties.Resources.patients_details_green_res_ellipse;
            this.statusPictureBox.Name = "statusPictureBox";
            this.statusPictureBox.TabStop = false;
            this.statusPictureBox.Tag = "false";
            this.statusPictureBox.MouseEnter += new System.EventHandler(this.parameterLabel_MouseEnter);
            // 
            // AllVisitsItem
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.openExtentionPictureBox);
            this.Controls.Add(this.doctorFirstLastNameLabel);
            this.Controls.Add(this.bloodPresureLabel);
            this.Controls.Add(this.testTypeLabel);
            this.Controls.Add(this.itemBackgroundPictureBox);
            this.DoubleBuffered = true;
            this.Name = "AllVisitsItem";
            this.Load += new System.EventHandler(this.AllVisitsItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.openExtentionPictureBox)).EndInit();
            this.itemBackgroundPictureBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deleteExtentionPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label pulseLabel;
        private System.Windows.Forms.Label doctorFirstLastNameLabel;
        private System.Windows.Forms.Label tempertureLabel;
        private System.Windows.Forms.Label dateVisitLabel;
        private System.Windows.Forms.Label bloodPresureLabel;
        private System.Windows.Forms.ToolTip labelToolTip;
        private System.Windows.Forms.PictureBox statusPictureBox;
        private System.Windows.Forms.Label testTypeLabel;
        private ButtonPictureBox openExtentionPictureBox;
        private RoundedCornersPanel itemBackgroundPictureBox;
        private ButtonPictureBox deleteExtentionPictureBox;
    }
}
