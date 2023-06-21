
namespace STSFWTestTool
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
            this.components = new System.ComponentModel.Container();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cmbxFreePorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.btnStartCommand = new System.Windows.Forms.Button();
            this.btnStopCommand = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numLpf = new System.Windows.Forms.NumericUpDown();
            this.lblAvg = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudMinTrsh = new System.Windows.Forms.NumericUpDown();
            this.rawThresh = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.slowDur = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.slowFreq = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.fastDur = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.fastFreq = new System.Windows.Forms.NumericUpDown();
            this.btnAcquireCommand = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nudFreq = new System.Windows.Forms.NumericUpDown();
            this.btnDoCalc = new System.Windows.Forms.Button();
            this.buttonShutterClose = new System.Windows.Forms.Button();
            this.buttonShutterOpen = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioBtnSerial = new System.Windows.Forms.RadioButton();
            this.radioBtnBlueTooth = new System.Windows.Forms.RadioButton();
            this.lblPhase = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ucCalibPanel1 = new STSFWTestTool.ucCalibPanel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLpf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinTrsh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rawThresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slowDur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slowFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastDur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFreq)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(23, 86);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(220, 30);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cmbxFreePorts
            // 
            this.cmbxFreePorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFreePorts.FormattingEnabled = true;
            this.cmbxFreePorts.Location = new System.Drawing.Point(122, 19);
            this.cmbxFreePorts.Name = "cmbxFreePorts";
            this.cmbxFreePorts.Size = new System.Drawing.Size(121, 28);
            this.cmbxFreePorts.TabIndex = 6;
            this.cmbxFreePorts.DropDown += new System.EventHandler(this.cmbxFreePorts_DropDown);
            this.cmbxFreePorts.SelectedIndexChanged += new System.EventHandler(this.cmbxFreePorts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Available Ports:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(12, 141);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status:";
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Location = new System.Drawing.Point(15, 157);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(1236, 553);
            this.zedGraphControl.TabIndex = 9;
            this.zedGraphControl.UseExtendedPrintDialog = true;
            this.zedGraphControl.Load += new System.EventHandler(this.zedGraphControl_Load);
            // 
            // btnStartCommand
            // 
            this.btnStartCommand.Location = new System.Drawing.Point(6, 32);
            this.btnStartCommand.Name = "btnStartCommand";
            this.btnStartCommand.Size = new System.Drawing.Size(112, 32);
            this.btnStartCommand.TabIndex = 10;
            this.btnStartCommand.Text = "Start";
            this.btnStartCommand.UseVisualStyleBackColor = true;
            this.btnStartCommand.Click += new System.EventHandler(this.btnStartCommand_Click);
            // 
            // btnStopCommand
            // 
            this.btnStopCommand.Location = new System.Drawing.Point(6, 70);
            this.btnStopCommand.Name = "btnStopCommand";
            this.btnStopCommand.Size = new System.Drawing.Size(112, 32);
            this.btnStopCommand.TabIndex = 11;
            this.btnStopCommand.Text = "Stop";
            this.btnStopCommand.UseVisualStyleBackColor = true;
            this.btnStopCommand.Click += new System.EventHandler(this.btnStopCommand_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numLpf);
            this.groupBox1.Controls.Add(this.lblAvg);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.nudMinTrsh);
            this.groupBox1.Controls.Add(this.rawThresh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.slowDur);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.slowFreq);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.fastDur);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.fastFreq);
            this.groupBox1.Controls.Add(this.btnAcquireCommand);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudFreq);
            this.groupBox1.Controls.Add(this.btnStartCommand);
            this.groupBox1.Controls.Add(this.btnStopCommand);
            this.groupBox1.Enabled = false;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(289, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(845, 122);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Command Control";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(735, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 18);
            this.label9.TabIndex = 28;
            this.label9.Text = "lpf";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label9.Visible = false;
            // 
            // numLpf
            // 
            this.numLpf.BackColor = System.Drawing.Color.Black;
            this.numLpf.DecimalPlaces = 2;
            this.numLpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLpf.ForeColor = System.Drawing.Color.Yellow;
            this.numLpf.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numLpf.Location = new System.Drawing.Point(735, 53);
            this.numLpf.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLpf.Name = "numLpf";
            this.numLpf.Size = new System.Drawing.Size(110, 26);
            this.numLpf.TabIndex = 29;
            this.numLpf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numLpf.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numLpf.Visible = false;
            // 
            // lblAvg
            // 
            this.lblAvg.AutoSize = true;
            this.lblAvg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAvg.ForeColor = System.Drawing.Color.Blue;
            this.lblAvg.Location = new System.Drawing.Point(161, 76);
            this.lblAvg.Name = "lblAvg";
            this.lblAvg.Size = new System.Drawing.Size(37, 22);
            this.lblAvg.TabIndex = 27;
            this.lblAvg.Text = "N/A";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(252, 80);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(112, 29);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(619, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Min Threshold";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(609, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Raw Threshold";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nudMinTrsh
            // 
            this.nudMinTrsh.BackColor = System.Drawing.Color.Black;
            this.nudMinTrsh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMinTrsh.ForeColor = System.Drawing.Color.Yellow;
            this.nudMinTrsh.Location = new System.Drawing.Point(619, 82);
            this.nudMinTrsh.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nudMinTrsh.Name = "nudMinTrsh";
            this.nudMinTrsh.Size = new System.Drawing.Size(110, 26);
            this.nudMinTrsh.TabIndex = 23;
            this.nudMinTrsh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMinTrsh.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // rawThresh
            // 
            this.rawThresh.BackColor = System.Drawing.Color.Black;
            this.rawThresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rawThresh.ForeColor = System.Drawing.Color.Yellow;
            this.rawThresh.Location = new System.Drawing.Point(619, 36);
            this.rawThresh.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.rawThresh.Name = "rawThresh";
            this.rawThresh.Size = new System.Drawing.Size(110, 26);
            this.rawThresh.TabIndex = 23;
            this.rawThresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rawThresh.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(497, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Slow Duration";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Visible = false;
            // 
            // slowDur
            // 
            this.slowDur.BackColor = System.Drawing.Color.Black;
            this.slowDur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slowDur.ForeColor = System.Drawing.Color.Yellow;
            this.slowDur.Location = new System.Drawing.Point(497, 83);
            this.slowDur.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.slowDur.Name = "slowDur";
            this.slowDur.Size = new System.Drawing.Size(110, 26);
            this.slowDur.TabIndex = 21;
            this.slowDur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slowDur.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.slowDur.Visible = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(496, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Slow Frequency";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label6.Visible = false;
            // 
            // slowFreq
            // 
            this.slowFreq.BackColor = System.Drawing.Color.Black;
            this.slowFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slowFreq.ForeColor = System.Drawing.Color.Yellow;
            this.slowFreq.Location = new System.Drawing.Point(496, 36);
            this.slowFreq.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.slowFreq.Name = "slowFreq";
            this.slowFreq.Size = new System.Drawing.Size(110, 26);
            this.slowFreq.TabIndex = 19;
            this.slowFreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slowFreq.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.slowFreq.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(371, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Fast Duration";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // fastDur
            // 
            this.fastDur.BackColor = System.Drawing.Color.Black;
            this.fastDur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastDur.ForeColor = System.Drawing.Color.Yellow;
            this.fastDur.Location = new System.Drawing.Point(371, 83);
            this.fastDur.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.fastDur.Name = "fastDur";
            this.fastDur.Size = new System.Drawing.Size(110, 26);
            this.fastDur.TabIndex = 17;
            this.fastDur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fastDur.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(370, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Fast Frequency";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // fastFreq
            // 
            this.fastFreq.BackColor = System.Drawing.Color.Black;
            this.fastFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastFreq.ForeColor = System.Drawing.Color.Yellow;
            this.fastFreq.Location = new System.Drawing.Point(370, 36);
            this.fastFreq.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.fastFreq.Name = "fastFreq";
            this.fastFreq.Size = new System.Drawing.Size(110, 26);
            this.fastFreq.TabIndex = 15;
            this.fastFreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fastFreq.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnAcquireCommand
            // 
            this.btnAcquireCommand.Location = new System.Drawing.Point(252, 32);
            this.btnAcquireCommand.Name = "btnAcquireCommand";
            this.btnAcquireCommand.Size = new System.Drawing.Size(112, 32);
            this.btnAcquireCommand.TabIndex = 13;
            this.btnAcquireCommand.Text = "Acquire";
            this.btnAcquireCommand.UseVisualStyleBackColor = true;
            this.btnAcquireCommand.Click += new System.EventHandler(this.btnAcquireCommand_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(136, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Frequency";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nudFreq
            // 
            this.nudFreq.BackColor = System.Drawing.Color.Black;
            this.nudFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFreq.ForeColor = System.Drawing.Color.Yellow;
            this.nudFreq.Location = new System.Drawing.Point(136, 36);
            this.nudFreq.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudFreq.Name = "nudFreq";
            this.nudFreq.Size = new System.Drawing.Size(110, 26);
            this.nudFreq.TabIndex = 12;
            this.nudFreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudFreq.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnDoCalc
            // 
            this.btnDoCalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoCalc.Location = new System.Drawing.Point(1150, 30);
            this.btnDoCalc.Name = "btnDoCalc";
            this.btnDoCalc.Size = new System.Drawing.Size(92, 32);
            this.btnDoCalc.TabIndex = 28;
            this.btnDoCalc.Text = "DoCalc";
            this.btnDoCalc.UseVisualStyleBackColor = true;
            this.btnDoCalc.Click += new System.EventHandler(this.btnDoCalc_Click);
            // 
            // buttonShutterClose
            // 
            this.buttonShutterClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShutterClose.Location = new System.Drawing.Point(1150, 106);
            this.buttonShutterClose.Name = "buttonShutterClose";
            this.buttonShutterClose.Size = new System.Drawing.Size(92, 32);
            this.buttonShutterClose.TabIndex = 25;
            this.buttonShutterClose.Text = "Close Shutter";
            this.buttonShutterClose.UseVisualStyleBackColor = true;
            this.buttonShutterClose.Click += new System.EventHandler(this.buttonShutterClose_Click);
            // 
            // buttonShutterOpen
            // 
            this.buttonShutterOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShutterOpen.Location = new System.Drawing.Point(1150, 68);
            this.buttonShutterOpen.Name = "buttonShutterOpen";
            this.buttonShutterOpen.Size = new System.Drawing.Size(92, 32);
            this.buttonShutterOpen.TabIndex = 24;
            this.buttonShutterOpen.Text = "Open Shutter";
            this.buttonShutterOpen.UseVisualStyleBackColor = true;
            this.buttonShutterOpen.Click += new System.EventHandler(this.buttonShutterOpen_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioBtnSerial);
            this.groupBox2.Controls.Add(this.radioBtnBlueTooth);
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbxFreePorts);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(15, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 122);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Serial Port Control";
            // 
            // radioBtnSerial
            // 
            this.radioBtnSerial.AutoSize = true;
            this.radioBtnSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnSerial.Location = new System.Drawing.Point(103, 53);
            this.radioBtnSerial.Name = "radioBtnSerial";
            this.radioBtnSerial.Size = new System.Drawing.Size(51, 17);
            this.radioBtnSerial.TabIndex = 30;
            this.radioBtnSerial.TabStop = true;
            this.radioBtnSerial.Text = "Serial";
            this.radioBtnSerial.UseVisualStyleBackColor = true;
            this.radioBtnSerial.CheckedChanged += new System.EventHandler(this.radioBtnSerial_CheckedChanged);
            // 
            // radioBtnBlueTooth
            // 
            this.radioBtnBlueTooth.AutoSize = true;
            this.radioBtnBlueTooth.Checked = true;
            this.radioBtnBlueTooth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnBlueTooth.Location = new System.Drawing.Point(23, 52);
            this.radioBtnBlueTooth.Name = "radioBtnBlueTooth";
            this.radioBtnBlueTooth.Size = new System.Drawing.Size(74, 17);
            this.radioBtnBlueTooth.TabIndex = 29;
            this.radioBtnBlueTooth.TabStop = true;
            this.radioBtnBlueTooth.Text = "BlueTooth";
            this.radioBtnBlueTooth.UseVisualStyleBackColor = true;
            this.radioBtnBlueTooth.CheckedChanged += new System.EventHandler(this.radioBtnBlueTooth_CheckedChanged);
            // 
            // lblPhase
            // 
            this.lblPhase.AutoSize = true;
            this.lblPhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhase.ForeColor = System.Drawing.Color.Blue;
            this.lblPhase.Location = new System.Drawing.Point(482, 141);
            this.lblPhase.Name = "lblPhase";
            this.lblPhase.Size = new System.Drawing.Size(46, 13);
            this.lblPhase.TabIndex = 8;
            this.lblPhase.Text = "Phase:";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            // 
            // ucCalibPanel1
            // 
            this.ucCalibPanel1.Location = new System.Drawing.Point(1257, 114);
            this.ucCalibPanel1.Name = "ucCalibPanel1";
            this.ucCalibPanel1.Size = new System.Drawing.Size(498, 596);
            this.ucCalibPanel1.TabIndex = 29;
            this.ucCalibPanel1.Load += new System.EventHandler(this.ucCalibPanel1_Load);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1762, 722);
            this.Controls.Add(this.ucCalibPanel1);
            this.Controls.Add(this.btnDoCalc);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonShutterClose);
            this.Controls.Add(this.zedGraphControl);
            this.Controls.Add(this.buttonShutterOpen);
            this.Controls.Add(this.lblPhase);
            this.Controls.Add(this.lblStatus);
            this.Name = "frmMain";
            this.Text = "PlumpDeviceSerial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLpf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinTrsh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rawThresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slowDur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slowFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastDur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFreq)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cmbxFreePorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.Button btnStartCommand;
        private System.Windows.Forms.Button btnStopCommand;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudFreq;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAcquireCommand;
        private System.Windows.Forms.Button buttonShutterClose;
        private System.Windows.Forms.Button buttonShutterOpen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown rawThresh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown slowDur;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown slowFreq;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown fastDur;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown fastFreq;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblPhase;
        private System.Windows.Forms.NumericUpDown nudMinTrsh;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblAvg;
        private System.Windows.Forms.Button btnDoCalc;
        private System.Windows.Forms.RadioButton radioBtnBlueTooth;
        private System.Windows.Forms.RadioButton radioBtnSerial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numLpf;
        private System.Windows.Forms.Label label8;
        private ucCalibPanel ucCalibPanel1;
    }
}

