
namespace GUITest
{
    partial class DoCalcUC
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
            this.GrpPatientDetails = new System.Windows.Forms.GroupBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.numBoxAge = new System.Windows.Forms.NumericUpDown();
            this.lblHeight = new System.Windows.Forms.Label();
            this.numBoxHeight = new System.Windows.Forms.NumericUpDown();
            this.numBoxWeight = new System.Windows.Forms.NumericUpDown();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.radioBtnMale = new System.Windows.Forms.RadioButton();
            this.radioBtnFemale = new System.Windows.Forms.RadioButton();
            this.btnCalc = new System.Windows.Forms.Button();
            this.txtBoxPath = new System.Windows.Forms.TextBox();
            this.btnBrawse = new System.Windows.Forms.Button();
            this.GrpLoad = new System.Windows.Forms.GroupBox();
            this.grpCalculate = new System.Windows.Forms.GroupBox();
            this.GrpPatientDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxWeight)).BeginInit();
            this.GrpLoad.SuspendLayout();
            this.grpCalculate.SuspendLayout();
            this.SuspendLayout();
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
            this.GrpPatientDetails.Location = new System.Drawing.Point(3, 3);
            this.GrpPatientDetails.Name = "GrpPatientDetails";
            this.GrpPatientDetails.Size = new System.Drawing.Size(257, 79);
            this.GrpPatientDetails.TabIndex = 0;
            this.GrpPatientDetails.TabStop = false;
            this.GrpPatientDetails.Text = "Patient Details";
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
            // numBoxAge
            // 
            this.numBoxAge.Location = new System.Drawing.Point(6, 36);
            this.numBoxAge.Name = "numBoxAge";
            this.numBoxAge.Size = new System.Drawing.Size(54, 20);
            this.numBoxAge.TabIndex = 2;
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
            // numBoxHeight
            // 
            this.numBoxHeight.Location = new System.Drawing.Point(70, 36);
            this.numBoxHeight.Name = "numBoxHeight";
            this.numBoxHeight.Size = new System.Drawing.Size(54, 20);
            this.numBoxHeight.TabIndex = 4;
            // 
            // numBoxWeight
            // 
            this.numBoxWeight.Location = new System.Drawing.Point(133, 36);
            this.numBoxWeight.Name = "numBoxWeight";
            this.numBoxWeight.Size = new System.Drawing.Size(54, 20);
            this.numBoxWeight.TabIndex = 5;
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
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(194, 20);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(45, 13);
            this.lblGender.TabIndex = 7;
            this.lblGender.Text = "Gender:";
            // 
            // radioBtnMale
            // 
            this.radioBtnMale.AutoSize = true;
            this.radioBtnMale.Location = new System.Drawing.Point(197, 38);
            this.radioBtnMale.Name = "radioBtnMale";
            this.radioBtnMale.Size = new System.Drawing.Size(48, 17);
            this.radioBtnMale.TabIndex = 8;
            this.radioBtnMale.TabStop = true;
            this.radioBtnMale.Text = "Male";
            this.radioBtnMale.UseVisualStyleBackColor = true;
            // 
            // radioBtnFemale
            // 
            this.radioBtnFemale.AutoSize = true;
            this.radioBtnFemale.Location = new System.Drawing.Point(197, 56);
            this.radioBtnFemale.Name = "radioBtnFemale";
            this.radioBtnFemale.Size = new System.Drawing.Size(59, 17);
            this.radioBtnFemale.TabIndex = 9;
            this.radioBtnFemale.TabStop = true;
            this.radioBtnFemale.Text = "Female";
            this.radioBtnFemale.UseVisualStyleBackColor = true;
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(6, 32);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 10;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.UseVisualStyleBackColor = true;
            // 
            // txtBoxPath
            // 
            this.txtBoxPath.Location = new System.Drawing.Point(6, 35);
            this.txtBoxPath.Name = "txtBoxPath";
            this.txtBoxPath.Size = new System.Drawing.Size(129, 20);
            this.txtBoxPath.TabIndex = 12;
            // 
            // btnBrawse
            // 
            this.btnBrawse.Location = new System.Drawing.Point(141, 35);
            this.btnBrawse.Name = "btnBrawse";
            this.btnBrawse.Size = new System.Drawing.Size(53, 23);
            this.btnBrawse.TabIndex = 13;
            this.btnBrawse.Text = "brawse";
            this.btnBrawse.UseVisualStyleBackColor = true;
            // 
            // GrpLoad
            // 
            this.GrpLoad.Controls.Add(this.txtBoxPath);
            this.GrpLoad.Controls.Add(this.btnBrawse);
            this.GrpLoad.Location = new System.Drawing.Point(266, 3);
            this.GrpLoad.Name = "GrpLoad";
            this.GrpLoad.Size = new System.Drawing.Size(200, 79);
            this.GrpLoad.TabIndex = 14;
            this.GrpLoad.TabStop = false;
            this.GrpLoad.Text = "Load Data(Not Necessary)";
            // 
            // grpCalculate
            // 
            this.grpCalculate.Controls.Add(this.btnCalc);
            this.grpCalculate.Location = new System.Drawing.Point(472, 3);
            this.grpCalculate.Name = "grpCalculate";
            this.grpCalculate.Size = new System.Drawing.Size(89, 79);
            this.grpCalculate.TabIndex = 15;
            this.grpCalculate.TabStop = false;
            this.grpCalculate.Text = "Calculate";
            // 
            // DoCalcUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpCalculate);
            this.Controls.Add(this.GrpLoad);
            this.Controls.Add(this.GrpPatientDetails);
            this.Name = "DoCalcUC";
            this.Size = new System.Drawing.Size(565, 85);
            this.GrpPatientDetails.ResumeLayout(false);
            this.GrpPatientDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxWeight)).EndInit();
            this.GrpLoad.ResumeLayout(false);
            this.GrpLoad.PerformLayout();
            this.grpCalculate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpPatientDetails;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.NumericUpDown numBoxAge;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.NumericUpDown numBoxHeight;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.NumericUpDown numBoxWeight;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.RadioButton radioBtnFemale;
        private System.Windows.Forms.RadioButton radioBtnMale;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.TextBox txtBoxPath;
        private System.Windows.Forms.Button btnBrawse;
        private System.Windows.Forms.GroupBox GrpLoad;
        private System.Windows.Forms.GroupBox grpCalculate;
    }
}
