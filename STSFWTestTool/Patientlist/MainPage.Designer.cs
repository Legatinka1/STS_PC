
namespace Patientlist
{
    partial class MainPage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PRecentlyVisited = new System.Windows.Forms.Panel();
            this.LToList = new System.Windows.Forms.Label();
            this.BtnToList = new System.Windows.Forms.Button();
            this.LRecentVisited = new System.Windows.Forms.Label();
            this.LViewRecentVisited = new System.Windows.Forms.ListView();
            this.ColumnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnDr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PMonthlyTests = new System.Windows.Forms.Panel();
            this.PSearchAndAdd = new System.Windows.Forms.Panel();
            this.BtnAddPatient = new System.Windows.Forms.Button();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.LWelcomeSign = new System.Windows.Forms.Label();
            this.PRecentlyVisited.SuspendLayout();
            this.PSearchAndAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // PRecentlyVisited
            // 
            this.PRecentlyVisited.Controls.Add(this.LToList);
            this.PRecentlyVisited.Controls.Add(this.BtnToList);
            this.PRecentlyVisited.Controls.Add(this.LRecentVisited);
            this.PRecentlyVisited.Controls.Add(this.LViewRecentVisited);
            this.PRecentlyVisited.Location = new System.Drawing.Point(264, 220);
            this.PRecentlyVisited.Name = "PRecentlyVisited";
            this.PRecentlyVisited.Size = new System.Drawing.Size(410, 158);
            this.PRecentlyVisited.TabIndex = 0;
            // 
            // LToList
            // 
            this.LToList.AutoSize = true;
            this.LToList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LToList.Location = new System.Drawing.Point(273, 9);
            this.LToList.Name = "LToList";
            this.LToList.Size = new System.Drawing.Size(99, 17);
            this.LToList.TabIndex = 7;
            this.LToList.Text = "To Patient List";
            // 
            // BtnToList
            // 
            this.BtnToList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnToList.Location = new System.Drawing.Point(378, 4);
            this.BtnToList.Name = "BtnToList";
            this.BtnToList.Size = new System.Drawing.Size(29, 25);
            this.BtnToList.TabIndex = 6;
            this.BtnToList.Text = ">";
            this.BtnToList.UseVisualStyleBackColor = true;
            this.BtnToList.Click += new System.EventHandler(this.BtnToList_Click);
            // 
            // LRecentVisited
            // 
            this.LRecentVisited.AutoSize = true;
            this.LRecentVisited.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LRecentVisited.Location = new System.Drawing.Point(3, 6);
            this.LRecentVisited.Name = "LRecentVisited";
            this.LRecentVisited.Size = new System.Drawing.Size(123, 20);
            this.LRecentVisited.TabIndex = 5;
            this.LRecentVisited.Text = "Recently Visited";
            // 
            // LViewRecentVisited
            // 
            this.LViewRecentVisited.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnName,
            this.ColumnID,
            this.ColumnDate,
            this.ColumnDr});
            this.LViewRecentVisited.HideSelection = false;
            this.LViewRecentVisited.Location = new System.Drawing.Point(3, 35);
            this.LViewRecentVisited.Name = "LViewRecentVisited";
            this.LViewRecentVisited.Size = new System.Drawing.Size(404, 120);
            this.LViewRecentVisited.TabIndex = 4;
            this.LViewRecentVisited.UseCompatibleStateImageBehavior = false;
            this.LViewRecentVisited.View = System.Windows.Forms.View.Details;
            this.LViewRecentVisited.SelectedIndexChanged += new System.EventHandler(this.LViewRecentVisited_SelectedIndexChanged);
            // 
            // ColumnName
            // 
            this.ColumnName.Text = "Name";
            this.ColumnName.Width = 99;
            // 
            // ColumnID
            // 
            this.ColumnID.Text = "ID";
            this.ColumnID.Width = 88;
            // 
            // ColumnDate
            // 
            this.ColumnDate.Text = "Last Time Visited";
            this.ColumnDate.Width = 117;
            // 
            // ColumnDr
            // 
            this.ColumnDr.Text = "Specialist";
            this.ColumnDr.Width = 96;
            // 
            // PMonthlyTests
            // 
            this.PMonthlyTests.Location = new System.Drawing.Point(12, 220);
            this.PMonthlyTests.Name = "PMonthlyTests";
            this.PMonthlyTests.Size = new System.Drawing.Size(231, 158);
            this.PMonthlyTests.TabIndex = 1;
            // 
            // PSearchAndAdd
            // 
            this.PSearchAndAdd.Controls.Add(this.BtnAddPatient);
            this.PSearchAndAdd.Controls.Add(this.TxtSearch);
            this.PSearchAndAdd.Location = new System.Drawing.Point(264, 171);
            this.PSearchAndAdd.Name = "PSearchAndAdd";
            this.PSearchAndAdd.Size = new System.Drawing.Size(410, 43);
            this.PSearchAndAdd.TabIndex = 2;
            // 
            // BtnAddPatient
            // 
            this.BtnAddPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.BtnAddPatient.Location = new System.Drawing.Point(272, 3);
            this.BtnAddPatient.Name = "BtnAddPatient";
            this.BtnAddPatient.Size = new System.Drawing.Size(135, 26);
            this.BtnAddPatient.TabIndex = 4;
            this.BtnAddPatient.Text = "+ Add New patient";
            this.BtnAddPatient.UseVisualStyleBackColor = true;
            this.BtnAddPatient.Click += new System.EventHandler(this.BtnAddPatient_Click);
            // 
            // TxtSearch
            // 
            this.TxtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TxtSearch.Location = new System.Drawing.Point(3, 3);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(263, 26);
            this.TxtSearch.TabIndex = 0;
            this.TxtSearch.TextChanged += new System.EventHandler(this.Search_Changed);
            // 
            // LWelcomeSign
            // 
            this.LWelcomeSign.AutoSize = true;
            this.LWelcomeSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.LWelcomeSign.Location = new System.Drawing.Point(12, 71);
            this.LWelcomeSign.Name = "LWelcomeSign";
            this.LWelcomeSign.Size = new System.Drawing.Size(231, 54);
            this.LWelcomeSign.TabIndex = 3;
            this.LWelcomeSign.Text = "Welcome!";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.LWelcomeSign);
            this.Controls.Add(this.PSearchAndAdd);
            this.Controls.Add(this.PMonthlyTests);
            this.Controls.Add(this.PRecentlyVisited);
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.PRecentlyVisited.ResumeLayout(false);
            this.PRecentlyVisited.PerformLayout();
            this.PSearchAndAdd.ResumeLayout(false);
            this.PSearchAndAdd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PRecentlyVisited;
        private System.Windows.Forms.Panel PMonthlyTests;
        private System.Windows.Forms.Panel PSearchAndAdd;
        private System.Windows.Forms.Label LWelcomeSign;
        private System.Windows.Forms.ListView LViewRecentVisited;
        private System.Windows.Forms.Label LRecentVisited;
        private System.Windows.Forms.Button BtnToList;
        private System.Windows.Forms.Label LToList;
        private System.Windows.Forms.ColumnHeader ColumnName;
        private System.Windows.Forms.ColumnHeader ColumnID;
        private System.Windows.Forms.ColumnHeader ColumnDate;
        private System.Windows.Forms.ColumnHeader ColumnDr;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Button BtnAddPatient;
    }
}