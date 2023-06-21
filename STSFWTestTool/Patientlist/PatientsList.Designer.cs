
namespace Patientlist
{
    partial class PatientsList
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PPatientsList = new System.Windows.Forms.Panel();
            this.LMainPage = new System.Windows.Forms.Label();
            this.LViewPatientList = new System.Windows.Forms.ListView();
            this.ColumnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnVisitDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnDoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnGender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnEthnicity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnNewPatient = new System.Windows.Forms.Button();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.LPatientList = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.PPatientsList.SuspendLayout();
            this.SuspendLayout();
            // 
            // PPatientsList
            // 
            this.PPatientsList.AutoSize = true;
            this.PPatientsList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PPatientsList.Controls.Add(this.LMainPage);
            this.PPatientsList.Controls.Add(this.LViewPatientList);
            this.PPatientsList.Controls.Add(this.BtnNewPatient);
            this.PPatientsList.Controls.Add(this.TxtSearch);
            this.PPatientsList.Controls.Add(this.LPatientList);
            this.PPatientsList.Location = new System.Drawing.Point(3, 3);
            this.PPatientsList.Name = "PPatientsList";
            this.PPatientsList.Size = new System.Drawing.Size(677, 380);
            this.PPatientsList.TabIndex = 0;
            // 
            // LMainPage
            // 
            this.LMainPage.AutoSize = true;
            this.LMainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LMainPage.Location = new System.Drawing.Point(10, 10);
            this.LMainPage.Name = "LMainPage";
            this.LMainPage.Size = new System.Drawing.Size(108, 20);
            this.LMainPage.TabIndex = 4;
            this.LMainPage.Text = "< Main Page";
            this.LMainPage.Click += new System.EventHandler(this.LMainPage_Click);
            // 
            // LViewPatientList
            // 
            this.LViewPatientList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnName,
            this.ColumnID,
            this.ColumnVisitDate,
            this.ColumnDoc,
            this.ColumnGender,
            this.ColumnEthnicity});
            this.LViewPatientList.HideSelection = false;
            this.LViewPatientList.Location = new System.Drawing.Point(8, 71);
            this.LViewPatientList.Name = "LViewPatientList";
            this.LViewPatientList.Size = new System.Drawing.Size(666, 306);
            this.LViewPatientList.TabIndex = 3;
            this.LViewPatientList.UseCompatibleStateImageBehavior = false;
            this.LViewPatientList.View = System.Windows.Forms.View.Details;
            this.LViewPatientList.SelectedIndexChanged += new System.EventHandler(this.LViewPatientList_SelectedIndexChanged);
            // 
            // ColumnName
            // 
            this.ColumnName.Text = "Name";
            this.ColumnName.Width = 150;
            // 
            // ColumnID
            // 
            this.ColumnID.Text = "ID";
            this.ColumnID.Width = 100;
            // 
            // ColumnVisitDate
            // 
            this.ColumnVisitDate.Text = "Date of visit";
            this.ColumnVisitDate.Width = 126;
            // 
            // ColumnDoc
            // 
            this.ColumnDoc.Text = "Specialist";
            this.ColumnDoc.Width = 93;
            // 
            // ColumnGender
            // 
            this.ColumnGender.Text = "Gender";
            this.ColumnGender.Width = 105;
            // 
            // ColumnEthnicity
            // 
            this.ColumnEthnicity.Text = "Ethnicity";
            this.ColumnEthnicity.Width = 120;
            // 
            // BtnNewPatient
            // 
            this.BtnNewPatient.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnNewPatient.Location = new System.Drawing.Point(583, 5);
            this.BtnNewPatient.Name = "BtnNewPatient";
            this.BtnNewPatient.Size = new System.Drawing.Size(90, 29);
            this.BtnNewPatient.TabIndex = 2;
            this.BtnNewPatient.Text = "+ New Patient";
            this.BtnNewPatient.UseVisualStyleBackColor = false;
            this.BtnNewPatient.Click += new System.EventHandler(this.NewPatient_Click);
            // 
            // TxtSearch
            // 
            this.TxtSearch.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.TxtSearch.Location = new System.Drawing.Point(285, 4);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(279, 34);
            this.TxtSearch.TabIndex = 1;
            this.TxtSearch.TextChanged += new System.EventHandler(this.Search_Changed);
            // 
            // LPatientList
            // 
            this.LPatientList.AutoSize = true;
            this.LPatientList.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.LPatientList.Location = new System.Drawing.Point(9, 37);
            this.LPatientList.Name = "LPatientList";
            this.LPatientList.Size = new System.Drawing.Size(141, 31);
            this.LPatientList.TabIndex = 0;
            this.LPatientList.Text = "Patients List:";
            this.LPatientList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PatientsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(685, 390);
            this.Controls.Add(this.PPatientsList);
            this.Name = "PatientsList";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PatientsList_Load);
            this.PPatientsList.ResumeLayout(false);
            this.PPatientsList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PPatientsList;
        private System.Windows.Forms.Label LPatientList;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Button BtnNewPatient;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ListView LViewPatientList;
        private System.Windows.Forms.ColumnHeader ColumnName;
        private System.Windows.Forms.ColumnHeader ColumnID;
        private System.Windows.Forms.ColumnHeader ColumnVisitDate;
        private System.Windows.Forms.ColumnHeader ColumnDoc;
        private System.Windows.Forms.ColumnHeader ColumnGender;
        private System.Windows.Forms.ColumnHeader ColumnEthnicity;
        private System.Windows.Forms.Label LMainPage;
    }
}

