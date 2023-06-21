
namespace STSFWTestTool
{
    partial class ucCalibPanel
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkUse2 = new System.Windows.Forms.CheckBox();
            this.lstCalibVectors = new System.Windows.Forms.ListBox();
            this.btnClearList = new System.Windows.Forms.Button();
            this.btnProcessC = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnLoadVector = new System.Windows.Forms.Button();
            this.btnProcessVector = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.rtbCalib = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveCalibFile = new System.Windows.Forms.Button();
            this.saveFileDialogConfig = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogConfig = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadCalib = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkUse2);
            this.groupBox3.Controls.Add(this.lstCalibVectors);
            this.groupBox3.Controls.Add(this.btnClearList);
            this.groupBox3.Controls.Add(this.btnProcessC);
            this.groupBox3.Controls.Add(this.btnProcess);
            this.groupBox3.Controls.Add(this.btnLoadVector);
            this.groupBox3.Controls.Add(this.btnProcessVector);
            this.groupBox3.Location = new System.Drawing.Point(15, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 578);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Calibration";
            // 
            // chkUse2
            // 
            this.chkUse2.AutoSize = true;
            this.chkUse2.Location = new System.Drawing.Point(20, 53);
            this.chkUse2.Name = "chkUse2";
            this.chkUse2.Size = new System.Drawing.Size(72, 17);
            this.chkUse2.TabIndex = 27;
            this.chkUse2.Text = "Use D,C2";
            this.chkUse2.UseVisualStyleBackColor = true;
            this.chkUse2.CheckedChanged += new System.EventHandler(this.chkUse2_CheckedChanged);
            // 
            // lstCalibVectors
            // 
            this.lstCalibVectors.FormattingEnabled = true;
            this.lstCalibVectors.Location = new System.Drawing.Point(20, 259);
            this.lstCalibVectors.Name = "lstCalibVectors";
            this.lstCalibVectors.Size = new System.Drawing.Size(161, 199);
            this.lstCalibVectors.TabIndex = 26;
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(20, 547);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(161, 25);
            this.btnClearList.TabIndex = 0;
            this.btnClearList.Text = "Clear";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // btnProcessC
            // 
            this.btnProcessC.Location = new System.Drawing.Point(20, 505);
            this.btnProcessC.Name = "btnProcessC";
            this.btnProcessC.Size = new System.Drawing.Size(161, 25);
            this.btnProcessC.TabIndex = 0;
            this.btnProcessC.Text = "Process Calibration C";
            this.btnProcessC.UseVisualStyleBackColor = true;
            this.btnProcessC.Click += new System.EventHandler(this.btnProcessC_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(20, 464);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(161, 25);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Process Calibration C, D";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnLoadVector
            // 
            this.btnLoadVector.Location = new System.Drawing.Point(113, 21);
            this.btnLoadVector.Name = "btnLoadVector";
            this.btnLoadVector.Size = new System.Drawing.Size(93, 25);
            this.btnLoadVector.TabIndex = 0;
            this.btnLoadVector.Text = "Load Vector";
            this.btnLoadVector.UseVisualStyleBackColor = true;
            this.btnLoadVector.Click += new System.EventHandler(this.btnLoadVector_Click);
            // 
            // btnProcessVector
            // 
            this.btnProcessVector.Location = new System.Drawing.Point(20, 20);
            this.btnProcessVector.Name = "btnProcessVector";
            this.btnProcessVector.Size = new System.Drawing.Size(93, 25);
            this.btnProcessVector.TabIndex = 0;
            this.btnProcessVector.Text = "Process Vector";
            this.btnProcessVector.UseVisualStyleBackColor = true;
            this.btnProcessVector.Click += new System.EventHandler(this.btnProcessVector_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(242, 356);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 152);
            this.textBox1.TabIndex = 31;
            // 
            // rtbCalib
            // 
            this.rtbCalib.Location = new System.Drawing.Point(242, 73);
            this.rtbCalib.Name = "rtbCalib";
            this.rtbCalib.ReadOnly = true;
            this.rtbCalib.Size = new System.Drawing.Size(229, 108);
            this.rtbCalib.TabIndex = 32;
            this.rtbCalib.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Current calibration info:";
            // 
            // btnSaveCalibFile
            // 
            this.btnSaveCalibFile.Location = new System.Drawing.Point(300, 525);
            this.btnSaveCalibFile.Name = "btnSaveCalibFile";
            this.btnSaveCalibFile.Size = new System.Drawing.Size(105, 23);
            this.btnSaveCalibFile.TabIndex = 34;
            this.btnSaveCalibFile.Text = "Save New Calib";
            this.btnSaveCalibFile.UseVisualStyleBackColor = true;
            this.btnSaveCalibFile.Click += new System.EventHandler(this.btnSaveCalibFile_Click);
            // 
            // saveFileDialogConfig
            // 
            this.saveFileDialogConfig.Filter = "Xml files|*.xml";
            // 
            // openFileDialogConfig
            // 
            this.openFileDialogConfig.DefaultExt = "*.xml";
            this.openFileDialogConfig.Filter = "Xml files|*.xml";
            // 
            // btnLoadCalib
            // 
            this.btnLoadCalib.Location = new System.Drawing.Point(242, 25);
            this.btnLoadCalib.Name = "btnLoadCalib";
            this.btnLoadCalib.Size = new System.Drawing.Size(75, 23);
            this.btnLoadCalib.TabIndex = 35;
            this.btnLoadCalib.Text = "Load Calib File";
            this.btnLoadCalib.UseVisualStyleBackColor = true;
            this.btnLoadCalib.Click += new System.EventHandler(this.btnLoadCalib_Click);
            // 
            // ucCalibPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLoadCalib);
            this.Controls.Add(this.btnSaveCalibFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbCalib);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "ucCalibPanel";
            this.Size = new System.Drawing.Size(498, 596);
            this.Load += new System.EventHandler(this.ucCalibPanel_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnProcessVector;
        private System.Windows.Forms.ListBox lstCalibVectors;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.CheckBox chkUse2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox rtbCalib;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveCalibFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialogConfig;
        private System.Windows.Forms.OpenFileDialog openFileDialogConfig;
        private System.Windows.Forms.Button btnLoadCalib;
        private System.Windows.Forms.Button btnLoadVector;
        private System.Windows.Forms.Button btnProcessC;
    }
}
