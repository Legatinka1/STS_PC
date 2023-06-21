namespace STSGui
{
    partial class AllPatientsPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllPatientsPanel));
            this.allGridItemsPanel = new System.Windows.Forms.Panel();
            this.allPatientsItem2 = new STSGui.AllPatientsItem();
            this.allPatientsItem1 = new STSGui.AllPatientsItem();
            this.ethnicityNameLabel = new System.Windows.Forms.Label();
            this.genderNameLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.doctorFirstLastNameLabel = new System.Windows.Forms.Label();
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.patientsListNameLabel = new System.Windows.Forms.Label();
            this.searchTextBoxTimer = new System.Windows.Forms.Timer(this.components);
            this.itemsScrollColorSlider = new STSGui.ColorSlider();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.addNewPatientButtonPictureBox = new STSGui.ButtonPictureBox();
            this.ethnicityNamePictureBox = new System.Windows.Forms.PictureBox();
            this.genderNamePictureBox = new System.Windows.Forms.PictureBox();
            this.namePictureBox = new System.Windows.Forms.PictureBox();
            this.idPictureBox = new System.Windows.Forms.PictureBox();
            this.datePictureBox = new System.Windows.Forms.PictureBox();
            this.doctorFirstLastNamePictureBox = new System.Windows.Forms.PictureBox();
            this.gridHeaderPictureBox = new System.Windows.Forms.PictureBox();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.searchPictureBox = new STSGui.ButtonPictureBox();
            this.searchTextBoxPanel = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.allGridItemsPanel.SuspendLayout();
            this.scrollPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addNewPatientButtonPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ethnicityNamePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genderNamePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.namePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doctorFirstLastNamePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeaderPictureBox)).BeginInit();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchPictureBox)).BeginInit();
            this.searchTextBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // allGridItemsPanel
            // 
            this.allGridItemsPanel.Controls.Add(this.allPatientsItem2);
            this.allGridItemsPanel.Controls.Add(this.allPatientsItem1);
            resources.ApplyResources(this.allGridItemsPanel, "allGridItemsPanel");
            this.allGridItemsPanel.Name = "allGridItemsPanel";
            // 
            // allPatientsItem2
            // 
            this.allPatientsItem2.BackColor = System.Drawing.Color.White;
            this.allPatientsItem2.CurrentPatient = null;
            resources.ApplyResources(this.allPatientsItem2, "allPatientsItem2");
            this.allPatientsItem2.Name = "allPatientsItem2";
            // 
            // allPatientsItem1
            // 
            this.allPatientsItem1.BackColor = System.Drawing.Color.White;
            this.allPatientsItem1.CurrentPatient = null;
            resources.ApplyResources(this.allPatientsItem1, "allPatientsItem1");
            this.allPatientsItem1.Name = "allPatientsItem1";
            // 
            // ethnicityNameLabel
            // 
            resources.ApplyResources(this.ethnicityNameLabel, "ethnicityNameLabel");
            this.ethnicityNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.ethnicityNameLabel.ForeColor = System.Drawing.Color.Black;
            this.ethnicityNameLabel.Name = "ethnicityNameLabel";
            this.ethnicityNameLabel.Click += new System.EventHandler(this.ethnicityNameLabel_Click);
            // 
            // genderNameLabel
            // 
            resources.ApplyResources(this.genderNameLabel, "genderNameLabel");
            this.genderNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.genderNameLabel.ForeColor = System.Drawing.Color.Black;
            this.genderNameLabel.Name = "genderNameLabel";
            this.genderNameLabel.Click += new System.EventHandler(this.genderNameLabel_Click);
            // 
            // idLabel
            // 
            resources.ApplyResources(this.idLabel, "idLabel");
            this.idLabel.BackColor = System.Drawing.Color.Transparent;
            this.idLabel.ForeColor = System.Drawing.Color.Black;
            this.idLabel.Name = "idLabel";
            this.idLabel.Click += new System.EventHandler(this.idLabel_Click);
            // 
            // dateLabel
            // 
            resources.ApplyResources(this.dateLabel, "dateLabel");
            this.dateLabel.BackColor = System.Drawing.Color.Transparent;
            this.dateLabel.ForeColor = System.Drawing.Color.Black;
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Click += new System.EventHandler(this.dateLabel_Click);
            // 
            // nameLabel
            // 
            resources.ApplyResources(this.nameLabel, "nameLabel");
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.ForeColor = System.Drawing.Color.Black;
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Click += new System.EventHandler(this.firstNameLabel_Click);
            // 
            // doctorFirstLastNameLabel
            // 
            resources.ApplyResources(this.doctorFirstLastNameLabel, "doctorFirstLastNameLabel");
            this.doctorFirstLastNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.doctorFirstLastNameLabel.ForeColor = System.Drawing.Color.Black;
            this.doctorFirstLastNameLabel.Name = "doctorFirstLastNameLabel";
            this.doctorFirstLastNameLabel.Click += new System.EventHandler(this.doctorFirstLastNameLabel_Click);
            // 
            // scrollPanel
            // 
            this.scrollPanel.BackColor = System.Drawing.Color.White;
            this.scrollPanel.Controls.Add(this.allGridItemsPanel);
            resources.ApplyResources(this.scrollPanel, "scrollPanel");
            this.scrollPanel.Name = "scrollPanel";
            // 
            // patientsListNameLabel
            // 
            resources.ApplyResources(this.patientsListNameLabel, "patientsListNameLabel");
            this.patientsListNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.patientsListNameLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.patientsListNameLabel.Name = "patientsListNameLabel";
            // 
            // searchTextBoxTimer
            // 
            this.searchTextBoxTimer.Interval = 5000;
            this.searchTextBoxTimer.Tick += new System.EventHandler(this.searchTextBoxTimer_Tick);
            // 
            // itemsScrollColorSlider
            // 
            this.itemsScrollColorSlider.BackColor = System.Drawing.Color.Transparent;
            this.itemsScrollColorSlider.BarInnerColor = System.Drawing.Color.ForestGreen;
            this.itemsScrollColorSlider.BarInnerColorRight = System.Drawing.Color.ForestGreen;
            this.itemsScrollColorSlider.BarPenColorBottom = System.Drawing.Color.Tomato;
            this.itemsScrollColorSlider.BarPenColorTop = System.Drawing.Color.ForestGreen;
            this.itemsScrollColorSlider.BorderRoundRectSize = new System.Drawing.Size(1, 1);
            this.itemsScrollColorSlider.DrawSemitransparentThumb = false;
            this.itemsScrollColorSlider.ElapsedBarThickness = 3;
            this.itemsScrollColorSlider.ElapsedInnerColor = System.Drawing.Color.DarkGray;
            this.itemsScrollColorSlider.ElapsedPenColorBottom = System.Drawing.Color.DarkGray;
            this.itemsScrollColorSlider.ElapsedPenColorTop = System.Drawing.Color.DarkGray;
            resources.ApplyResources(this.itemsScrollColorSlider, "itemsScrollColorSlider");
            this.itemsScrollColorSlider.ForeColor = System.Drawing.Color.Transparent;
            this.itemsScrollColorSlider.LargeChange = ((uint)(3u));
            this.itemsScrollColorSlider.MouseEffects = false;
            this.itemsScrollColorSlider.Name = "itemsScrollColorSlider";
            this.itemsScrollColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.itemsScrollColorSlider.ScaleDivisions = 1;
            this.itemsScrollColorSlider.ScaleSubDivisions = 1;
            this.itemsScrollColorSlider.ShowDivisionsText = false;
            this.itemsScrollColorSlider.ShowSmallScale = false;
            this.itemsScrollColorSlider.SmallChange = ((uint)(1u));
            this.itemsScrollColorSlider.ThumbInnerColor = System.Drawing.Color.ForestGreen;
            this.itemsScrollColorSlider.ThumbOuterColor = System.Drawing.Color.ForestGreen;
            this.itemsScrollColorSlider.ThumbPenColor = System.Drawing.Color.ForestGreen;
            this.itemsScrollColorSlider.ThumbRoundRectSize = new System.Drawing.Size(2, 2);
            this.itemsScrollColorSlider.ThumbSize = new System.Drawing.Size(12, 20);
            this.itemsScrollColorSlider.TickAdd = 0F;
            this.itemsScrollColorSlider.TickColor = System.Drawing.Color.Transparent;
            this.itemsScrollColorSlider.TickDivide = 0F;
            this.itemsScrollColorSlider.Value = 50;
            this.itemsScrollColorSlider.ValueChanged += new System.EventHandler(this.itemsScrollColorSlider_ValueChanged);
            this.itemsScrollColorSlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.itemsScrollColorSlider_MouseUp_1);
            // 
            // addNewPatientButtonPictureBox
            // 
            this.addNewPatientButtonPictureBox.DisableImage = global::STSGui.Properties.Resources.patients_list_add_new_patient_disable;
            resources.ApplyResources(this.addNewPatientButtonPictureBox, "addNewPatientButtonPictureBox");
            this.addNewPatientButtonPictureBox.Image = global::STSGui.Properties.Resources.patients_list_add_new_patient_normal;
            this.addNewPatientButtonPictureBox.IsTextColorMouseChanged = false;
            this.addNewPatientButtonPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_list_add_new_patient_down;
            this.addNewPatientButtonPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_list_add_new_patient_over_;
            this.addNewPatientButtonPictureBox.Name = "addNewPatientButtonPictureBox";
            this.addNewPatientButtonPictureBox.NormalImage = global::STSGui.Properties.Resources.patients_list_add_new_patient_normal;
            this.addNewPatientButtonPictureBox.TabStop = false;
            this.addNewPatientButtonPictureBox.TextColor = System.Drawing.Color.White;
            this.addNewPatientButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 21.75F);
            this.addNewPatientButtonPictureBox.XTextOffset = 0;
            this.addNewPatientButtonPictureBox.YTextOffset = 2;
            this.addNewPatientButtonPictureBox.Click += new System.EventHandler(this.addNewPatientButtonPictureBox_Click);
            // 
            // ethnicityNamePictureBox
            // 
            this.ethnicityNamePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.ethnicityNamePictureBox.Image = global::STSGui.Properties.Resources.patients_list_sort_unknown;
            resources.ApplyResources(this.ethnicityNamePictureBox, "ethnicityNamePictureBox");
            this.ethnicityNamePictureBox.Name = "ethnicityNamePictureBox";
            this.ethnicityNamePictureBox.TabStop = false;
            // 
            // genderNamePictureBox
            // 
            this.genderNamePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.genderNamePictureBox.Image = global::STSGui.Properties.Resources.patients_list_sort_unknown;
            resources.ApplyResources(this.genderNamePictureBox, "genderNamePictureBox");
            this.genderNamePictureBox.Name = "genderNamePictureBox";
            this.genderNamePictureBox.TabStop = false;
            this.genderNamePictureBox.Click += new System.EventHandler(this.genderNameLabel_Click);
            // 
            // namePictureBox
            // 
            this.namePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.namePictureBox.Image = global::STSGui.Properties.Resources.patients_list_sort_unknown;
            resources.ApplyResources(this.namePictureBox, "namePictureBox");
            this.namePictureBox.Name = "namePictureBox";
            this.namePictureBox.TabStop = false;
            this.namePictureBox.Click += new System.EventHandler(this.firstNameLabel_Click);
            // 
            // idPictureBox
            // 
            this.idPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.idPictureBox.Image = global::STSGui.Properties.Resources.patients_list_sort_unknown;
            resources.ApplyResources(this.idPictureBox, "idPictureBox");
            this.idPictureBox.Name = "idPictureBox";
            this.idPictureBox.TabStop = false;
            this.idPictureBox.Click += new System.EventHandler(this.idLabel_Click);
            // 
            // datePictureBox
            // 
            this.datePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.datePictureBox.Image = global::STSGui.Properties.Resources.patients_list_sort_unknown;
            resources.ApplyResources(this.datePictureBox, "datePictureBox");
            this.datePictureBox.Name = "datePictureBox";
            this.datePictureBox.TabStop = false;
            this.datePictureBox.Click += new System.EventHandler(this.dateLabel_Click);
            // 
            // doctorFirstLastNamePictureBox
            // 
            this.doctorFirstLastNamePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.doctorFirstLastNamePictureBox.Image = global::STSGui.Properties.Resources.patients_list_sort_unknown;
            resources.ApplyResources(this.doctorFirstLastNamePictureBox, "doctorFirstLastNamePictureBox");
            this.doctorFirstLastNamePictureBox.Name = "doctorFirstLastNamePictureBox";
            this.doctorFirstLastNamePictureBox.TabStop = false;
            this.doctorFirstLastNamePictureBox.Click += new System.EventHandler(this.doctorFirstLastNameLabel_Click);
            // 
            // gridHeaderPictureBox
            // 
            this.gridHeaderPictureBox.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.gridHeaderPictureBox, "gridHeaderPictureBox");
            this.gridHeaderPictureBox.Name = "gridHeaderPictureBox";
            this.gridHeaderPictureBox.TabStop = false;
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.searchPanel, "searchPanel");
            this.searchPanel.Controls.Add(this.searchPictureBox);
            this.searchPanel.Controls.Add(this.searchTextBoxPanel);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Click += new System.EventHandler(this.AllPatientsPanel_Click);
            // 
            // searchPictureBox
            // 
            this.searchPictureBox.DisableImage = global::STSGui.Properties.Resources.patients_list_search_disable;
            resources.ApplyResources(this.searchPictureBox, "searchPictureBox");
            this.searchPictureBox.Image = global::STSGui.Properties.Resources.patients_list_normal;
            this.searchPictureBox.IsTextColorMouseChanged = false;
            this.searchPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_list_down;
            this.searchPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_list_over;
            this.searchPictureBox.Name = "searchPictureBox";
            this.searchPictureBox.NormalImage = global::STSGui.Properties.Resources.patients_list_normal;
            this.searchPictureBox.TabStop = false;
            this.searchPictureBox.TextColor = System.Drawing.Color.Black;
            this.searchPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchPictureBox.XTextOffset = 0;
            this.searchPictureBox.YTextOffset = 0;
            // 
            // searchTextBoxPanel
            // 
            this.searchTextBoxPanel.BackColor = System.Drawing.Color.Transparent;
            this.searchTextBoxPanel.BackgroundImage = global::STSGui.Properties.Resources.patients_list_search_background_image;
            resources.ApplyResources(this.searchTextBoxPanel, "searchTextBoxPanel");
            this.searchTextBoxPanel.Controls.Add(this.searchTextBox);
            this.searchTextBoxPanel.Name = "searchTextBoxPanel";
            // 
            // searchTextBox
            // 
            this.searchTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.searchTextBox, "searchTextBox");
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.TabStop = false;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            this.searchTextBox.Enter += new System.EventHandler(this.searchTextBox_Enter);
            this.searchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchTextBox_KeyPress);
            this.searchTextBox.Validated += new System.EventHandler(this.searchTextBox_Validated);
            // 
            // AllPatientsPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.addNewPatientButtonPictureBox);
            this.Controls.Add(this.itemsScrollColorSlider);
            this.Controls.Add(this.ethnicityNamePictureBox);
            this.Controls.Add(this.genderNamePictureBox);
            this.Controls.Add(this.namePictureBox);
            this.Controls.Add(this.idPictureBox);
            this.Controls.Add(this.datePictureBox);
            this.Controls.Add(this.doctorFirstLastNamePictureBox);
            this.Controls.Add(this.ethnicityNameLabel);
            this.Controls.Add(this.scrollPanel);
            this.Controls.Add(this.genderNameLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.doctorFirstLastNameLabel);
            this.Controls.Add(this.gridHeaderPictureBox);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.patientsListNameLabel);
            this.DoubleBuffered = true;
            this.Name = "AllPatientsPanel";
            this.Load += new System.EventHandler(this.AllPatientsPanel_Load);
            this.VisibleChanged += new System.EventHandler(this.AllPatientsPanel_VisibleChanged);
            this.Click += new System.EventHandler(this.AllPatientsPanel_Click);
            this.allGridItemsPanel.ResumeLayout(false);
            this.scrollPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addNewPatientButtonPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ethnicityNamePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genderNamePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.namePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doctorFirstLastNamePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeaderPictureBox)).EndInit();
            this.searchPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchPictureBox)).EndInit();
            this.searchTextBoxPanel.ResumeLayout(false);
            this.searchTextBoxPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel allGridItemsPanel;
        private System.Windows.Forms.Label ethnicityNameLabel;
        private System.Windows.Forms.Label genderNameLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label doctorFirstLastNameLabel;
        private System.Windows.Forms.PictureBox doctorFirstLastNamePictureBox;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Panel scrollPanel;
        private System.Windows.Forms.PictureBox gridHeaderPictureBox;
        private System.Windows.Forms.Label patientsListNameLabel;
        private System.Windows.Forms.Timer searchTextBoxTimer;
        private System.Windows.Forms.Panel searchTextBoxPanel;
        private System.Windows.Forms.PictureBox datePictureBox;
        private System.Windows.Forms.PictureBox idPictureBox;
        private System.Windows.Forms.PictureBox namePictureBox;
        private System.Windows.Forms.PictureBox genderNamePictureBox;
        private AllPatientsItem allPatientsItem1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.PictureBox ethnicityNamePictureBox;
        private ColorSlider itemsScrollColorSlider;
        private ButtonPictureBox searchPictureBox;
        private ButtonPictureBox addNewPatientButtonPictureBox;
        private AllPatientsItem allPatientsItem2;
    }
}
