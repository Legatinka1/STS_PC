
namespace GUITest
{
    partial class TestSession
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("FLow/Volume Prameters:", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Volume Prameters:", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Resistance/Compliance Prameters:", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "FVC(L)",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "FEV1(L)",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "FEV1/FVC(%)",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "FEV6(L)",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "FEV3(L)",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "FEV3/FVC(%)",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "PEF(L/S)",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "FEF-25-75(L/S)",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new string[] {
            "VC(L)",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new string[] {
            "TLC(L)",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new string[] {
            "TGV(L)",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem(new string[] {
            "RV(L)",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem(new string[] {
            "TGV/TLC(%)",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem(new string[] {
            "RV/TLC(%)",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem(new string[] {
            "RAW(Pa*s/L)",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem(new string[] {
            "CL(m^3/Pa)",
            "",
            ""}, -1);
            this.LPatientInfo = new System.Windows.Forms.Label();
            this.PTest = new System.Windows.Forms.Panel();
            this.PTestGraph = new System.Windows.Forms.Panel();
            this.LViewPreviousTest = new System.Windows.Forms.ListView();
            this.ColumnTypeUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnPredicted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnBest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LPatientsData = new System.Windows.Forms.Label();
            this.PTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // LPatientInfo
            // 
            this.LPatientInfo.AutoSize = true;
            this.LPatientInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPatientInfo.Location = new System.Drawing.Point(165, 7);
            this.LPatientInfo.Name = "LPatientInfo";
            this.LPatientInfo.Size = new System.Drawing.Size(90, 46);
            this.LPatientInfo.TabIndex = 1;
            this.LPatientInfo.Text = "Info";
            this.LPatientInfo.Click += new System.EventHandler(this.LPatientInfo_Click);
            // 
            // PTest
            // 
            this.PTest.Controls.Add(this.PTestGraph);
            this.PTest.Controls.Add(this.LViewPreviousTest);
            this.PTest.Location = new System.Drawing.Point(2, 56);
            this.PTest.Name = "PTest";
            this.PTest.Size = new System.Drawing.Size(682, 332);
            this.PTest.TabIndex = 0;
            // 
            // PTestGraph
            // 
            this.PTestGraph.Location = new System.Drawing.Point(292, 0);
            this.PTestGraph.Name = "PTestGraph";
            this.PTestGraph.Size = new System.Drawing.Size(389, 331);
            this.PTestGraph.TabIndex = 4;
            // 
            // LViewPreviousTest
            // 
            this.LViewPreviousTest.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnTypeUnit,
            this.ColumnPredicted,
            this.ColumnBest});
            listViewGroup1.Header = "FLow/Volume Prameters:";
            listViewGroup1.Name = "FLowPrameters";
            listViewGroup1.Tag = "";
            listViewGroup2.Header = "Volume Prameters:";
            listViewGroup2.Name = "VolumePrameters";
            listViewGroup3.Header = "Resistance/Compliance Prameters:";
            listViewGroup3.Name = "ResistancePrameters";
            this.LViewPreviousTest.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.LViewPreviousTest.HideSelection = false;
            listViewItem1.Group = listViewGroup1;
            listViewItem2.Group = listViewGroup1;
            listViewItem3.Group = listViewGroup1;
            listViewItem4.Group = listViewGroup1;
            listViewItem5.Group = listViewGroup1;
            listViewItem6.Group = listViewGroup1;
            listViewItem7.Group = listViewGroup1;
            listViewItem8.Group = listViewGroup1;
            listViewItem9.Group = listViewGroup2;
            listViewItem10.Group = listViewGroup2;
            listViewItem11.Group = listViewGroup2;
            listViewItem12.Group = listViewGroup2;
            listViewItem13.Group = listViewGroup2;
            listViewItem14.Group = listViewGroup2;
            listViewItem15.Group = listViewGroup3;
            listViewItem16.Group = listViewGroup3;
            this.LViewPreviousTest.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16});
            this.LViewPreviousTest.Location = new System.Drawing.Point(3, 0);
            this.LViewPreviousTest.Name = "LViewPreviousTest";
            this.LViewPreviousTest.Size = new System.Drawing.Size(292, 329);
            this.LViewPreviousTest.TabIndex = 3;
            this.LViewPreviousTest.UseCompatibleStateImageBehavior = false;
            this.LViewPreviousTest.View = System.Windows.Forms.View.Details;
            this.LViewPreviousTest.SelectedIndexChanged += new System.EventHandler(this.LViewTestInfo_SelectedIndexChanged);
            // 
            // ColumnTypeUnit
            // 
            this.ColumnTypeUnit.Text = "Type Unit";
            this.ColumnTypeUnit.Width = 86;
            // 
            // ColumnPredicted
            // 
            this.ColumnPredicted.Text = "Predicted";
            // 
            // ColumnBest
            // 
            this.ColumnBest.Text = "BEST";
            this.ColumnBest.Width = 100;
            // 
            // LPatientsData
            // 
            this.LPatientsData.AutoSize = true;
            this.LPatientsData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LPatientsData.Location = new System.Drawing.Point(2, 16);
            this.LPatientsData.Name = "LPatientsData";
            this.LPatientsData.Size = new System.Drawing.Size(90, 20);
            this.LPatientsData.TabIndex = 2;
            this.LPatientsData.Text = "< Patients";
            this.LPatientsData.Click += new System.EventHandler(this.LPatientsData_Click);
            // 
            // TestSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 390);
            this.Controls.Add(this.LPatientsData);
            this.Controls.Add(this.LPatientInfo);
            this.Controls.Add(this.PTest);
            this.Name = "TestSession";
            this.Text = "TestSession";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestSession_FormClosed);
            this.Load += new System.EventHandler(this.TestSession_Load);
            this.PTest.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LPatientInfo;
        private System.Windows.Forms.Panel PTest;
        private System.Windows.Forms.ListView LViewPreviousTest;
        private System.Windows.Forms.ColumnHeader ColumnTypeUnit;
        private System.Windows.Forms.ColumnHeader ColumnPredicted;
        private System.Windows.Forms.ColumnHeader ColumnBest;
        private System.Windows.Forms.Label LPatientsData;
        private System.Windows.Forms.Panel PTestGraph;
    }
}