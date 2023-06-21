
namespace MathUtils
{
    partial class frmMain
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
            this.nudAge = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.cmbEthnicity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFVC = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFEV1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFEV1_FVC = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPEF = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTLC = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTGV = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblRV = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblRV_TLC = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTGV_TLC = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblRAW = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCL = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // nudAge
            // 
            this.nudAge.Location = new System.Drawing.Point(128, 39);
            this.nudAge.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAge.Name = "nudAge";
            this.nudAge.Size = new System.Drawing.Size(72, 20);
            this.nudAge.TabIndex = 0;
            this.nudAge.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudAge.ValueChanged += new System.EventHandler(this.nudAge_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Age in years";
            // 
            // nudHeight
            // 
            this.nudHeight.Location = new System.Drawing.Point(128, 63);
            this.nudHeight.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(72, 20);
            this.nudHeight.TabIndex = 0;
            this.nudHeight.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudHeight.ValueChanged += new System.EventHandler(this.nudHeight_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height in centimeters";
            // 
            // nudWeight
            // 
            this.nudWeight.Location = new System.Drawing.Point(128, 89);
            this.nudWeight.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudWeight.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudWeight.Name = "nudWeight";
            this.nudWeight.Size = new System.Drawing.Size(72, 20);
            this.nudWeight.TabIndex = 0;
            this.nudWeight.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.nudWeight.ValueChanged += new System.EventHandler(this.nudWeight_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Weight in kilogram";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(21, 120);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(48, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Male";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(115, 120);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "Female";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // cmbEthnicity
            // 
            this.cmbEthnicity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEthnicity.FormattingEnabled = true;
            this.cmbEthnicity.Items.AddRange(new object[] {
            "Caucasian",
            "African-American",
            "North and South East Asian"});
            this.cmbEthnicity.Location = new System.Drawing.Point(128, 148);
            this.cmbEthnicity.Name = "cmbEthnicity";
            this.cmbEthnicity.Size = new System.Drawing.Size(174, 21);
            this.cmbEthnicity.TabIndex = 3;
            this.cmbEthnicity.SelectedIndexChanged += new System.EventHandler(this.cmbEthnicity_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ethnicity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "FVC:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblFVC
            // 
            this.lblFVC.AutoSize = true;
            this.lblFVC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFVC.ForeColor = System.Drawing.Color.Blue;
            this.lblFVC.Location = new System.Drawing.Point(149, 218);
            this.lblFVC.Name = "lblFVC";
            this.lblFVC.Size = new System.Drawing.Size(51, 28);
            this.lblFVC.TabIndex = 4;
            this.lblFVC.Text = "N/A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 26);
            this.label6.TabIndex = 4;
            this.label6.Text = "FEV1:";
            // 
            // lblFEV1
            // 
            this.lblFEV1.AutoSize = true;
            this.lblFEV1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFEV1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFEV1.ForeColor = System.Drawing.Color.Blue;
            this.lblFEV1.Location = new System.Drawing.Point(149, 258);
            this.lblFEV1.Name = "lblFEV1";
            this.lblFEV1.Size = new System.Drawing.Size(51, 28);
            this.lblFEV1.TabIndex = 4;
            this.lblFEV1.Text = "N/A";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 26);
            this.label8.TabIndex = 4;
            this.label8.Text = "FEV1/FVC";
            // 
            // lblFEV1_FVC
            // 
            this.lblFEV1_FVC.AutoSize = true;
            this.lblFEV1_FVC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFEV1_FVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFEV1_FVC.ForeColor = System.Drawing.Color.Blue;
            this.lblFEV1_FVC.Location = new System.Drawing.Point(149, 297);
            this.lblFEV1_FVC.Name = "lblFEV1_FVC";
            this.lblFEV1_FVC.Size = new System.Drawing.Size(51, 28);
            this.lblFEV1_FVC.TabIndex = 4;
            this.lblFEV1_FVC.Text = "N/A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 336);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 26);
            this.label7.TabIndex = 4;
            this.label7.Text = "PEF";
            // 
            // lblPEF
            // 
            this.lblPEF.AutoSize = true;
            this.lblPEF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPEF.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPEF.ForeColor = System.Drawing.Color.Blue;
            this.lblPEF.Location = new System.Drawing.Point(149, 336);
            this.lblPEF.Name = "lblPEF";
            this.lblPEF.Size = new System.Drawing.Size(51, 28);
            this.lblPEF.TabIndex = 4;
            this.lblPEF.Text = "N/A";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 375);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 26);
            this.label9.TabIndex = 4;
            this.label9.Text = "TLC";
            // 
            // lblTLC
            // 
            this.lblTLC.AutoSize = true;
            this.lblTLC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTLC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTLC.ForeColor = System.Drawing.Color.Blue;
            this.lblTLC.Location = new System.Drawing.Point(149, 375);
            this.lblTLC.Name = "lblTLC";
            this.lblTLC.Size = new System.Drawing.Size(51, 28);
            this.lblTLC.TabIndex = 4;
            this.lblTLC.Text = "N/A";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(25, 415);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 26);
            this.label10.TabIndex = 4;
            this.label10.Text = "TGV";
            // 
            // lblTGV
            // 
            this.lblTGV.AutoSize = true;
            this.lblTGV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTGV.ForeColor = System.Drawing.Color.Blue;
            this.lblTGV.Location = new System.Drawing.Point(150, 415);
            this.lblTGV.Name = "lblTGV";
            this.lblTGV.Size = new System.Drawing.Size(51, 28);
            this.lblTGV.TabIndex = 4;
            this.lblTGV.Text = "N/A";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(399, 216);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 26);
            this.label11.TabIndex = 4;
            this.label11.Text = "RV";
            // 
            // lblRV
            // 
            this.lblRV.AutoSize = true;
            this.lblRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRV.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRV.ForeColor = System.Drawing.Color.Blue;
            this.lblRV.Location = new System.Drawing.Point(510, 216);
            this.lblRV.Name = "lblRV";
            this.lblRV.Size = new System.Drawing.Size(51, 28);
            this.lblRV.TabIndex = 4;
            this.lblRV.Text = "N/A";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(399, 258);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 26);
            this.label12.TabIndex = 4;
            this.label12.Text = "RV/TLC";
            // 
            // lblRV_TLC
            // 
            this.lblRV_TLC.AutoSize = true;
            this.lblRV_TLC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRV_TLC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRV_TLC.ForeColor = System.Drawing.Color.Blue;
            this.lblRV_TLC.Location = new System.Drawing.Point(510, 258);
            this.lblRV_TLC.Name = "lblRV_TLC";
            this.lblRV_TLC.Size = new System.Drawing.Size(51, 28);
            this.lblRV_TLC.TabIndex = 4;
            this.lblRV_TLC.Text = "N/A";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(399, 297);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 26);
            this.label14.TabIndex = 4;
            this.label14.Text = "TGV/TLC";
            // 
            // lblTGV_TLC
            // 
            this.lblTGV_TLC.AutoSize = true;
            this.lblTGV_TLC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTGV_TLC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTGV_TLC.ForeColor = System.Drawing.Color.Blue;
            this.lblTGV_TLC.Location = new System.Drawing.Point(510, 297);
            this.lblTGV_TLC.Name = "lblTGV_TLC";
            this.lblTGV_TLC.Size = new System.Drawing.Size(51, 28);
            this.lblTGV_TLC.TabIndex = 4;
            this.lblTGV_TLC.Text = "N/A";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(399, 334);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 26);
            this.label15.TabIndex = 4;
            this.label15.Text = "RAW";
            // 
            // lblRAW
            // 
            this.lblRAW.AutoSize = true;
            this.lblRAW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRAW.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRAW.ForeColor = System.Drawing.Color.Blue;
            this.lblRAW.Location = new System.Drawing.Point(510, 334);
            this.lblRAW.Name = "lblRAW";
            this.lblRAW.Size = new System.Drawing.Size(51, 28);
            this.lblRAW.TabIndex = 4;
            this.lblRAW.Text = "N/A";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(399, 373);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 26);
            this.label13.TabIndex = 4;
            this.label13.Text = "CL";
            // 
            // lblCL
            // 
            this.lblCL.AutoSize = true;
            this.lblCL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCL.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCL.ForeColor = System.Drawing.Color.Blue;
            this.lblCL.Location = new System.Drawing.Point(510, 373);
            this.lblCL.Name = "lblCL";
            this.lblCL.Size = new System.Drawing.Size(51, 28);
            this.lblCL.TabIndex = 4;
            this.lblCL.Text = "N/A";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(258, 220);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 26);
            this.label16.TabIndex = 4;
            this.label16.Text = "L";
            this.label16.Click += new System.EventHandler(this.label5_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(258, 260);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 26);
            this.label17.TabIndex = 4;
            this.label17.Text = "L";
            this.label17.Click += new System.EventHandler(this.label5_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(258, 297);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 26);
            this.label18.TabIndex = 4;
            this.label18.Text = "%";
            this.label18.Click += new System.EventHandler(this.label5_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(258, 338);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 26);
            this.label19.TabIndex = 4;
            this.label19.Text = "L/sec";
            this.label19.Click += new System.EventHandler(this.label5_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(258, 375);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(24, 26);
            this.label20.TabIndex = 4;
            this.label20.Text = "L";
            this.label20.Click += new System.EventHandler(this.label5_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(258, 415);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(24, 26);
            this.label21.TabIndex = 4;
            this.label21.Text = "L";
            this.label21.Click += new System.EventHandler(this.label5_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(611, 220);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(24, 26);
            this.label22.TabIndex = 4;
            this.label22.Text = "L";
            this.label22.Click += new System.EventHandler(this.label5_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(611, 260);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(32, 26);
            this.label23.TabIndex = 4;
            this.label23.Text = "%";
            this.label23.Click += new System.EventHandler(this.label5_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(611, 297);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(32, 26);
            this.label24.TabIndex = 4;
            this.label24.Text = "%";
            this.label24.Click += new System.EventHandler(this.label5_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(611, 336);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(88, 26);
            this.label25.TabIndex = 4;
            this.label25.Text = "kPa*s/L";
            this.label25.Click += new System.EventHandler(this.label5_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(611, 373);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(68, 26);
            this.label26.TabIndex = 4;
            this.label26.Text = "L/kPa";
            this.label26.Click += new System.EventHandler(this.label5_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTGV);
            this.Controls.Add(this.lblTLC);
            this.Controls.Add(this.lblPEF);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblFEV1_FVC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblFEV1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCL);
            this.Controls.Add(this.lblRAW);
            this.Controls.Add(this.lblTGV_TLC);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblRV_TLC);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblRV);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblFVC);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbEthnicity);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudWeight);
            this.Controls.Add(this.nudHeight);
            this.Controls.Add(this.nudAge);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudAge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.ComboBox cmbEthnicity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFVC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFEV1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblFEV1_FVC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPEF;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTLC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTGV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblRV;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblRV_TLC;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTGV_TLC;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblRAW;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCL;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
    }
}

