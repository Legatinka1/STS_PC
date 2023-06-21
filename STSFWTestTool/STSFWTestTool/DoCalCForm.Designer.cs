
namespace STSFWTestTool
{
    partial class DoCalCForm
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
            this.components = new System.ComponentModel.Container();
            this.GrpValues = new System.Windows.Forms.GroupBox();
            this.rbResults = new System.Windows.Forms.RichTextBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.GrpLoad = new System.Windows.Forms.GroupBox();
            this.txtBoxPath = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnBrawse = new System.Windows.Forms.Button();
            this.GrpPatientDetails = new System.Windows.Forms.GroupBox();
            this.radioBtnFemale = new System.Windows.Forms.RadioButton();
            this.radioBtnMale = new System.Windows.Forms.RadioButton();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.numBoxWeight = new System.Windows.Forms.NumericUpDown();
            this.numBoxHeight = new System.Windows.Forms.NumericUpDown();
            this.lblHeight = new System.Windows.Forms.Label();
            this.numBoxAge = new System.Windows.Forms.NumericUpDown();
            this.lblAge = new System.Windows.Forms.Label();
            this.zedGraphPressure = new ZedGraph.ZedGraphControl();
            this.zedGraphExhFlow = new ZedGraph.ZedGraphControl();
            this.zedGraphFVC = new ZedGraph.ZedGraphControl();
            this.chkUseSolenoidTime = new System.Windows.Forms.CheckBox();
            this.lblSolTime = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbCalib = new System.Windows.Forms.RichTextBox();
            this.GrpValues.SuspendLayout();
            this.GrpLoad.SuspendLayout();
            this.GrpPatientDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxAge)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpValues
            // 
            this.GrpValues.Controls.Add(this.rbResults);
            this.GrpValues.Location = new System.Drawing.Point(8, 349);
            this.GrpValues.Name = "GrpValues";
            this.GrpValues.Size = new System.Drawing.Size(558, 279);
            this.GrpValues.TabIndex = 27;
            this.GrpValues.TabStop = false;
            this.GrpValues.Text = "Values:";
            // 
            // rbResults
            // 
            this.rbResults.Location = new System.Drawing.Point(7, 19);
            this.rbResults.Name = "rbResults";
            this.rbResults.ReadOnly = true;
            this.rbResults.Size = new System.Drawing.Size(545, 254);
            this.rbResults.TabIndex = 0;
            this.rbResults.Text = "";
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(336, 111);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(221, 54);
            this.btnCalc.TabIndex = 10;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // GrpLoad
            // 
            this.GrpLoad.Controls.Add(this.txtBoxPath);
            this.GrpLoad.Controls.Add(this.btnLoad);
            this.GrpLoad.Controls.Add(this.btnBrawse);
            this.GrpLoad.Location = new System.Drawing.Point(5, 12);
            this.GrpLoad.Name = "GrpLoad";
            this.GrpLoad.Size = new System.Drawing.Size(558, 70);
            this.GrpLoad.TabIndex = 25;
            this.GrpLoad.TabStop = false;
            this.GrpLoad.Text = "Load Data(Not Necessary)";
            // 
            // txtBoxPath
            // 
            this.txtBoxPath.Location = new System.Drawing.Point(6, 13);
            this.txtBoxPath.Name = "txtBoxPath";
            this.txtBoxPath.Size = new System.Drawing.Size(546, 20);
            this.txtBoxPath.TabIndex = 12;
            this.txtBoxPath.Text = "C:\\EfCom\\Technoplumsts\\technoplumsts\\trunk\\pySolution\\rec 1kHz_150-2000_PS-test2." +
    "csv";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(331, 39);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(53, 23);
            this.btnLoad.TabIndex = 13;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnBrawse
            // 
            this.btnBrawse.Location = new System.Drawing.Point(499, 39);
            this.btnBrawse.Name = "btnBrawse";
            this.btnBrawse.Size = new System.Drawing.Size(53, 23);
            this.btnBrawse.TabIndex = 13;
            this.btnBrawse.Text = "Browse";
            this.btnBrawse.UseVisualStyleBackColor = true;
            this.btnBrawse.Click += new System.EventHandler(this.btnBrawse_Click);
            // 
            // GrpPatientDetails
            // 
            this.GrpPatientDetails.Controls.Add(this.radioBtnFemale);
            this.GrpPatientDetails.Controls.Add(this.radioBtnMale);
            this.GrpPatientDetails.Controls.Add(this.lblGender);
            this.GrpPatientDetails.Controls.Add(this.lblWeight);
            this.GrpPatientDetails.Controls.Add(this.numBoxWeight);
            this.GrpPatientDetails.Controls.Add(this.numBoxHeight);
            this.GrpPatientDetails.Controls.Add(this.lblHeight);
            this.GrpPatientDetails.Controls.Add(this.numBoxAge);
            this.GrpPatientDetails.Controls.Add(this.lblAge);
            this.GrpPatientDetails.Location = new System.Drawing.Point(5, 86);
            this.GrpPatientDetails.Name = "GrpPatientDetails";
            this.GrpPatientDetails.Size = new System.Drawing.Size(257, 79);
            this.GrpPatientDetails.TabIndex = 24;
            this.GrpPatientDetails.TabStop = false;
            this.GrpPatientDetails.Text = "Patient Details";
            // 
            // radioBtnFemale
            // 
            this.radioBtnFemale.AutoSize = true;
            this.radioBtnFemale.Location = new System.Drawing.Point(197, 56);
            this.radioBtnFemale.Name = "radioBtnFemale";
            this.radioBtnFemale.Size = new System.Drawing.Size(59, 17);
            this.radioBtnFemale.TabIndex = 9;
            this.radioBtnFemale.Text = "Female";
            this.radioBtnFemale.UseVisualStyleBackColor = true;
            // 
            // radioBtnMale
            // 
            this.radioBtnMale.AutoSize = true;
            this.radioBtnMale.Checked = true;
            this.radioBtnMale.Location = new System.Drawing.Point(197, 38);
            this.radioBtnMale.Name = "radioBtnMale";
            this.radioBtnMale.Size = new System.Drawing.Size(48, 17);
            this.radioBtnMale.TabIndex = 8;
            this.radioBtnMale.TabStop = true;
            this.radioBtnMale.Text = "Male";
            this.radioBtnMale.UseVisualStyleBackColor = true;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(194, 20);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(45, 13);
            this.lblGender.TabIndex = 7;
            this.lblGender.Text = "Gender:";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(130, 20);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(41, 13);
            this.lblWeight.TabIndex = 6;
            this.lblWeight.Text = "Weight";
            // 
            // numBoxWeight
            // 
            this.numBoxWeight.Location = new System.Drawing.Point(133, 36);
            this.numBoxWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numBoxWeight.Name = "numBoxWeight";
            this.numBoxWeight.Size = new System.Drawing.Size(54, 20);
            this.numBoxWeight.TabIndex = 5;
            this.numBoxWeight.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // numBoxHeight
            // 
            this.numBoxHeight.Location = new System.Drawing.Point(70, 36);
            this.numBoxHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numBoxHeight.Name = "numBoxHeight";
            this.numBoxHeight.Size = new System.Drawing.Size(54, 20);
            this.numBoxHeight.TabIndex = 4;
            this.numBoxHeight.Value = new decimal(new int[] {
            174,
            0,
            0,
            0});
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(67, 20);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(38, 13);
            this.lblHeight.TabIndex = 3;
            this.lblHeight.Text = "Height";
            // 
            // numBoxAge
            // 
            this.numBoxAge.Location = new System.Drawing.Point(6, 36);
            this.numBoxAge.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numBoxAge.Name = "numBoxAge";
            this.numBoxAge.Size = new System.Drawing.Size(54, 20);
            this.numBoxAge.TabIndex = 2;
            this.numBoxAge.Value = new decimal(new int[] {
            68,
            0,
            0,
            0});
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(1, 20);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(29, 13);
            this.lblAge.TabIndex = 1;
            this.lblAge.Text = "Age:";
            // 
            // zedGraphPressure
            // 
            this.zedGraphPressure.Location = new System.Drawing.Point(569, 12);
            this.zedGraphPressure.Margin = new System.Windows.Forms.Padding(0);
            this.zedGraphPressure.Name = "zedGraphPressure";
            this.zedGraphPressure.ScrollGrace = 0D;
            this.zedGraphPressure.ScrollMaxX = 0D;
            this.zedGraphPressure.ScrollMaxY = 0D;
            this.zedGraphPressure.ScrollMaxY2 = 0D;
            this.zedGraphPressure.ScrollMinX = 0D;
            this.zedGraphPressure.ScrollMinY = 0D;
            this.zedGraphPressure.ScrollMinY2 = 0D;
            this.zedGraphPressure.Size = new System.Drawing.Size(575, 155);
            this.zedGraphPressure.TabIndex = 29;
            this.zedGraphPressure.UseExtendedPrintDialog = true;
            // 
            // zedGraphExhFlow
            // 
            this.zedGraphExhFlow.Location = new System.Drawing.Point(569, 167);
            this.zedGraphExhFlow.Margin = new System.Windows.Forms.Padding(0);
            this.zedGraphExhFlow.Name = "zedGraphExhFlow";
            this.zedGraphExhFlow.ScrollGrace = 0D;
            this.zedGraphExhFlow.ScrollMaxX = 0D;
            this.zedGraphExhFlow.ScrollMaxY = 0D;
            this.zedGraphExhFlow.ScrollMaxY2 = 0D;
            this.zedGraphExhFlow.ScrollMinX = 0D;
            this.zedGraphExhFlow.ScrollMinY = 0D;
            this.zedGraphExhFlow.ScrollMinY2 = 0D;
            this.zedGraphExhFlow.Size = new System.Drawing.Size(575, 155);
            this.zedGraphExhFlow.TabIndex = 30;
            this.zedGraphExhFlow.UseExtendedPrintDialog = true;
            // 
            // zedGraphFVC
            // 
            this.zedGraphFVC.Location = new System.Drawing.Point(569, 322);
            this.zedGraphFVC.Margin = new System.Windows.Forms.Padding(0);
            this.zedGraphFVC.Name = "zedGraphFVC";
            this.zedGraphFVC.ScrollGrace = 0D;
            this.zedGraphFVC.ScrollMaxX = 0D;
            this.zedGraphFVC.ScrollMaxY = 0D;
            this.zedGraphFVC.ScrollMaxY2 = 0D;
            this.zedGraphFVC.ScrollMinX = 0D;
            this.zedGraphFVC.ScrollMinY = 0D;
            this.zedGraphFVC.ScrollMinY2 = 0D;
            this.zedGraphFVC.Size = new System.Drawing.Size(575, 155);
            this.zedGraphFVC.TabIndex = 31;
            this.zedGraphFVC.UseExtendedPrintDialog = true;
            // 
            // chkUseSolenoidTime
            // 
            this.chkUseSolenoidTime.AutoSize = true;
            this.chkUseSolenoidTime.Location = new System.Drawing.Point(336, 88);
            this.chkUseSolenoidTime.Name = "chkUseSolenoidTime";
            this.chkUseSolenoidTime.Size = new System.Drawing.Size(115, 17);
            this.chkUseSolenoidTime.TabIndex = 32;
            this.chkUseSolenoidTime.Text = "Use Solenoid Time";
            this.chkUseSolenoidTime.UseVisualStyleBackColor = true;
            // 
            // lblSolTime
            // 
            this.lblSolTime.AutoSize = true;
            this.lblSolTime.Location = new System.Drawing.Point(457, 89);
            this.lblSolTime.Name = "lblSolTime";
            this.lblSolTime.Size = new System.Drawing.Size(27, 13);
            this.lblSolTime.TabIndex = 33;
            this.lblSolTime.Text = "N/A";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbCalib);
            this.groupBox1.Location = new System.Drawing.Point(8, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 172);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calibration";
            // 
            // rtbCalib
            // 
            this.rtbCalib.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbCalib.Location = new System.Drawing.Point(3, 16);
            this.rtbCalib.Name = "rtbCalib";
            this.rtbCalib.ReadOnly = true;
            this.rtbCalib.Size = new System.Drawing.Size(552, 153);
            this.rtbCalib.TabIndex = 0;
            this.rtbCalib.Text = "";
            // 
            // DoCalCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 640);
            this.Controls.Add(this.lblSolTime);
            this.Controls.Add(this.chkUseSolenoidTime);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.zedGraphFVC);
            this.Controls.Add(this.zedGraphExhFlow);
            this.Controls.Add(this.zedGraphPressure);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GrpValues);
            this.Controls.Add(this.GrpLoad);
            this.Controls.Add(this.GrpPatientDetails);
            this.Name = "DoCalCForm";
            this.Text = "DoCalCForm";
            this.Load += new System.EventHandler(this.DoCalCForm_Load);
            this.GrpValues.ResumeLayout(false);
            this.GrpLoad.ResumeLayout(false);
            this.GrpLoad.PerformLayout();
            this.GrpPatientDetails.ResumeLayout(false);
            this.GrpPatientDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxAge)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox GrpValues;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.GroupBox GrpLoad;
        private System.Windows.Forms.TextBox txtBoxPath;
        private System.Windows.Forms.Button btnBrawse;
        private System.Windows.Forms.GroupBox GrpPatientDetails;
        private System.Windows.Forms.RadioButton radioBtnFemale;
        private System.Windows.Forms.RadioButton radioBtnMale;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.NumericUpDown numBoxWeight;
        private System.Windows.Forms.NumericUpDown numBoxHeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.NumericUpDown numBoxAge;
        private System.Windows.Forms.Label lblAge;
        private ZedGraph.ZedGraphControl zedGraphPressure;
        private ZedGraph.ZedGraphControl zedGraphExhFlow;
        private ZedGraph.ZedGraphControl zedGraphFVC;
        private System.Windows.Forms.CheckBox chkUseSolenoidTime;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblSolTime;
        private System.Windows.Forms.RichTextBox rbResults;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbCalib;
    }
}