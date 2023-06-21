namespace STSGui
{
    partial class RecentlyVisitedPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecentlyVisitedPanel));
            this.searchTextBoxTimer = new System.Windows.Forms.Timer(this.components);
            this.searchPanel = new System.Windows.Forms.Panel();
            this.searchPictureBox = new STSGui.ButtonPictureBox();
            this.searchTextBoxPanel = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.allGridItemsPanel = new System.Windows.Forms.Panel();
            this.toPatientListPictureBox = new STSGui.ButtonPictureBox();
            this.toPatientListLabel = new System.Windows.Forms.Label();
            this.recentlyVisitedItem_2 = new STSGui.RecentlyVisitedItem();
            this.recentlyVisitedItem_1 = new STSGui.RecentlyVisitedItem();
            this.recentlyVisitedItem_0 = new STSGui.RecentlyVisitedItem();
            this.recentlyVisitedNameLabel = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.addNewPatientButtonPictureBox = new STSGui.ButtonPictureBox();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchPictureBox)).BeginInit();
            this.searchTextBoxPanel.SuspendLayout();
            this.allGridItemsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toPatientListPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addNewPatientButtonPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTextBoxTimer
            // 
            this.searchTextBoxTimer.Interval = 5000;
            this.searchTextBoxTimer.Tick += new System.EventHandler(this.searchTextBoxTimer_Tick);
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
            // allGridItemsPanel
            // 
            this.allGridItemsPanel.BackgroundImage = global::STSGui.Properties.Resources.main_panel_visits_list_background_img;
            resources.ApplyResources(this.allGridItemsPanel, "allGridItemsPanel");
            this.allGridItemsPanel.Controls.Add(this.toPatientListPictureBox);
            this.allGridItemsPanel.Controls.Add(this.toPatientListLabel);
            this.allGridItemsPanel.Controls.Add(this.recentlyVisitedItem_2);
            this.allGridItemsPanel.Controls.Add(this.recentlyVisitedItem_1);
            this.allGridItemsPanel.Controls.Add(this.recentlyVisitedItem_0);
            this.allGridItemsPanel.Controls.Add(this.recentlyVisitedNameLabel);
            this.allGridItemsPanel.Name = "allGridItemsPanel";
            // 
            // toPatientListPictureBox
            // 
            this.toPatientListPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.toPatientListPictureBox.DisableImage = global::STSGui.Properties.Resources.patients_list_arrow_right_btn_disable;
            resources.ApplyResources(this.toPatientListPictureBox, "toPatientListPictureBox");
            this.toPatientListPictureBox.Image = global::STSGui.Properties.Resources.patients_list_arrow_right_btn_normal;
            this.toPatientListPictureBox.IsTextColorMouseChanged = true;
            this.toPatientListPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_list_arrow_right_btn_down;
            this.toPatientListPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_list_arrow_right_btn_over;
            this.toPatientListPictureBox.Name = "toPatientListPictureBox";
            this.toPatientListPictureBox.NormalImage = global::STSGui.Properties.Resources.patients_list_arrow_right_btn_normal;
            this.toPatientListPictureBox.TabStop = false;
            this.toPatientListPictureBox.TextColor = System.Drawing.Color.Black;
            this.toPatientListPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toPatientListPictureBox.XTextOffset = 0;
            this.toPatientListPictureBox.YTextOffset = 0;
            this.toPatientListPictureBox.Click += new System.EventHandler(this.toPatientListPictureBox_Click);
            // 
            // toPatientListLabel
            // 
            this.toPatientListLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.toPatientListLabel, "toPatientListLabel");
            this.toPatientListLabel.Name = "toPatientListLabel";
            // 
            // recentlyVisitedItem_2
            // 
            this.recentlyVisitedItem_2.BackColor = System.Drawing.Color.White;
            this.recentlyVisitedItem_2.CurrentPatient = null;
            resources.ApplyResources(this.recentlyVisitedItem_2, "recentlyVisitedItem_2");
            this.recentlyVisitedItem_2.Name = "recentlyVisitedItem_2";
            // 
            // recentlyVisitedItem_1
            // 
            this.recentlyVisitedItem_1.BackColor = System.Drawing.Color.White;
            this.recentlyVisitedItem_1.CurrentPatient = null;
            resources.ApplyResources(this.recentlyVisitedItem_1, "recentlyVisitedItem_1");
            this.recentlyVisitedItem_1.Name = "recentlyVisitedItem_1";
            // 
            // recentlyVisitedItem_0
            // 
            this.recentlyVisitedItem_0.BackColor = System.Drawing.Color.White;
            this.recentlyVisitedItem_0.CurrentPatient = null;
            resources.ApplyResources(this.recentlyVisitedItem_0, "recentlyVisitedItem_0");
            this.recentlyVisitedItem_0.Name = "recentlyVisitedItem_0";
            // 
            // recentlyVisitedNameLabel
            // 
            resources.ApplyResources(this.recentlyVisitedNameLabel, "recentlyVisitedNameLabel");
            this.recentlyVisitedNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.recentlyVisitedNameLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.recentlyVisitedNameLabel.Name = "recentlyVisitedNameLabel";
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
            this.addNewPatientButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewPatientButtonPictureBox.XTextOffset = 0;
            this.addNewPatientButtonPictureBox.YTextOffset = 2;
            this.addNewPatientButtonPictureBox.Click += new System.EventHandler(this.addNewPatientButtonPictureBox_Click);
            // 
            // RecentlyVisitedPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.allGridItemsPanel);
            this.Controls.Add(this.addNewPatientButtonPictureBox);
            this.Controls.Add(this.searchPanel);
            this.DoubleBuffered = true;
            this.Name = "RecentlyVisitedPanel";
            this.Load += new System.EventHandler(this.RecentlyVisitedPanel_Load);
            this.VisibleChanged += new System.EventHandler(this.AllPatientsPanel_VisibleChanged);
            this.Click += new System.EventHandler(this.AllPatientsPanel_Click);
            this.searchPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchPictureBox)).EndInit();
            this.searchTextBoxPanel.ResumeLayout(false);
            this.searchTextBoxPanel.PerformLayout();
            this.allGridItemsPanel.ResumeLayout(false);
            this.allGridItemsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toPatientListPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addNewPatientButtonPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel allGridItemsPanel;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label recentlyVisitedNameLabel;
        private System.Windows.Forms.Timer searchTextBoxTimer;
        private System.Windows.Forms.Panel searchTextBoxPanel;
        private System.Windows.Forms.BindingSource bindingSource1;
        private ButtonPictureBox searchPictureBox;
        private ButtonPictureBox addNewPatientButtonPictureBox;
        private RecentlyVisitedItem recentlyVisitedItem_2;
        private RecentlyVisitedItem recentlyVisitedItem_1;
        private RecentlyVisitedItem recentlyVisitedItem_0;
        private ButtonPictureBox toPatientListPictureBox;
        private System.Windows.Forms.Label toPatientListLabel;
    }
}
