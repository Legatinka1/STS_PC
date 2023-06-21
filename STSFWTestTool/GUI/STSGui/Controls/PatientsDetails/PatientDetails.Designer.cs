
namespace STSGui
{
    partial class PatientDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientDetails));
            this.patientTopNameAndIDLabel = new System.Windows.Forms.Label();
            this.patientTopCloseLabel = new System.Windows.Forms.Label();
            this.patientTopNameLabel = new System.Windows.Forms.Label();
            this.leftBigPanel = new System.Windows.Forms.Panel();
            this.shortPatientDetailsControl = new STSGui.ShortPatientDetails();
            this.rightBigPanel = new System.Windows.Forms.Panel();
            this.previousTestsControl = new STSGui.PreviousTests();
            this.timerLabel = new STSGui.LabelExtended();
            this.testProgressPictureBox = new STSGui.RoundedCornersPictureBox();
            this.spiro_TlcButtonPictureBox = new STSGui.ButtonPictureBox();
            this.co2FenoButtonPictureBox = new STSGui.ButtonPictureBox();
            this.dlcoButtonPictureBox = new STSGui.ButtonPictureBox();
            this.startStopTestButtonPictureBox = new STSGui.ButtonPictureBox();
            this.cancelButtonPictureBox = new STSGui.ButtonPictureBox();
            this.saveSessionButtonPictureBox = new STSGui.ButtonPictureBox();
            this.reconnectButtonPictureBox = new STSGui.ButtonPictureBox();
            this.leftBigPanel.SuspendLayout();
            this.rightBigPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testProgressPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiro_TlcButtonPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.co2FenoButtonPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlcoButtonPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startStopTestButtonPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButtonPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveSessionButtonPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reconnectButtonPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // patientTopNameAndIDLabel
            // 
            this.patientTopNameAndIDLabel.AutoSize = true;
            this.patientTopNameAndIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.patientTopNameAndIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.patientTopNameAndIDLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.patientTopNameAndIDLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.patientTopNameAndIDLabel.Location = new System.Drawing.Point(25, 29);
            this.patientTopNameAndIDLabel.Name = "patientTopNameAndIDLabel";
            this.patientTopNameAndIDLabel.Size = new System.Drawing.Size(513, 42);
            this.patientTopNameAndIDLabel.TabIndex = 79;
            this.patientTopNameAndIDLabel.Text = "Brooklyn Smith 9876543210";
            this.patientTopNameAndIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // patientTopCloseLabel
            // 
            this.patientTopCloseLabel.AutoSize = true;
            this.patientTopCloseLabel.BackColor = System.Drawing.Color.Transparent;
            this.patientTopCloseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.patientTopCloseLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.patientTopCloseLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.patientTopCloseLabel.Location = new System.Drawing.Point(28, 100);
            this.patientTopCloseLabel.Name = "patientTopCloseLabel";
            this.patientTopCloseLabel.Size = new System.Drawing.Size(136, 31);
            this.patientTopCloseLabel.TabIndex = 80;
            this.patientTopCloseLabel.Text = "< Patients";
            this.patientTopCloseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.patientTopCloseLabel.Click += new System.EventHandler(this.patientTopCloseLabel_Click);
            // 
            // patientTopNameLabel
            // 
            this.patientTopNameLabel.AutoSize = true;
            this.patientTopNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.patientTopNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.patientTopNameLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.patientTopNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.patientTopNameLabel.Location = new System.Drawing.Point(167, 100);
            this.patientTopNameLabel.Name = "patientTopNameLabel";
            this.patientTopNameLabel.Size = new System.Drawing.Size(217, 31);
            this.patientTopNameLabel.TabIndex = 81;
            this.patientTopNameLabel.Text = "|  Brooklyn Smith";
            this.patientTopNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.patientTopNameLabel.Click += new System.EventHandler(this.patientTopNameLabel_Click);
            // 
            // leftBigPanel
            // 
            this.leftBigPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftBigPanel.Controls.Add(this.shortPatientDetailsControl);
            this.leftBigPanel.Location = new System.Drawing.Point(28, 144);
            this.leftBigPanel.Name = "leftBigPanel";
            this.leftBigPanel.Size = new System.Drawing.Size(620, 890);
            this.leftBigPanel.TabIndex = 82;
            // 
            // shortPatientDetailsControl
            // 
            this.shortPatientDetailsControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("shortPatientDetailsControl.BackgroundImage")));
            this.shortPatientDetailsControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.shortPatientDetailsControl.Location = new System.Drawing.Point(0, 0);
            this.shortPatientDetailsControl.Name = "shortPatientDetailsControl";
            this.shortPatientDetailsControl.Size = new System.Drawing.Size(620, 890);
            this.shortPatientDetailsControl.TabIndex = 0;
            // 
            // rightBigPanel
            // 
            this.rightBigPanel.Controls.Add(this.previousTestsControl);
            this.rightBigPanel.Location = new System.Drawing.Point(667, 144);
            this.rightBigPanel.Name = "rightBigPanel";
            this.rightBigPanel.Size = new System.Drawing.Size(1250, 890);
            this.rightBigPanel.TabIndex = 88;
            // 
            // previousTestsControl
            // 
            this.previousTestsControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("previousTestsControl.BackgroundImage")));
            this.previousTestsControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.previousTestsControl.Location = new System.Drawing.Point(0, 0);
            this.previousTestsControl.Name = "previousTestsControl";
            this.previousTestsControl.Size = new System.Drawing.Size(1250, 890);
            this.previousTestsControl.TabIndex = 0;
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.DisableTextColor = System.Drawing.Color.Black;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.ForeColor = System.Drawing.Color.Black;
            this.timerLabel.Location = new System.Drawing.Point(1799, 96);
            this.timerLabel.MouseDownTextColor = System.Drawing.Color.Empty;
            this.timerLabel.MouseOverTextColor = System.Drawing.Color.Empty;
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.NormalTextColor = System.Drawing.Color.Black;
            this.timerLabel.Size = new System.Drawing.Size(81, 16);
            this.timerLabel.TabIndex = 93;
            this.timerLabel.Text = "6 Seconds";
            this.timerLabel.Visible = false;
            // 
            // testProgressPictureBox
            // 
            this.testProgressPictureBox.BackColor = System.Drawing.Color.Red;
            this.testProgressPictureBox.IsOverrideCreateParams = false;
            this.testProgressPictureBox.Location = new System.Drawing.Point(1288, 99);
            this.testProgressPictureBox.Name = "testProgressPictureBox";
            this.testProgressPictureBox.Radius = 1;
            this.testProgressPictureBox.Size = new System.Drawing.Size(510, 5);
            this.testProgressPictureBox.TabIndex = 92;
            this.testProgressPictureBox.TabStop = false;
            this.testProgressPictureBox.Visible = false;
            // 
            // spiro_TlcButtonPictureBox
            // 
            this.spiro_TlcButtonPictureBox.DisableImage = global::STSGui.Properties.Resources.patients_details_new_test_session_disable;
            this.spiro_TlcButtonPictureBox.DisableTextColor = System.Drawing.Color.Black;
            this.spiro_TlcButtonPictureBox.Image = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.spiro_TlcButtonPictureBox.IsTextColorMouseChanged = false;
            this.spiro_TlcButtonPictureBox.Location = new System.Drawing.Point(1697, 29);
            this.spiro_TlcButtonPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_details_new_test_session_down;
            this.spiro_TlcButtonPictureBox.MouseDownTextColor = System.Drawing.Color.Empty;
            this.spiro_TlcButtonPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_details_new_test_session_over_;
            this.spiro_TlcButtonPictureBox.MouseOverTextColor = System.Drawing.Color.Empty;
            this.spiro_TlcButtonPictureBox.Name = "spiro_TlcButtonPictureBox";
            this.spiro_TlcButtonPictureBox.NormalImage = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.spiro_TlcButtonPictureBox.NormalTextColor = System.Drawing.Color.Black;
            this.spiro_TlcButtonPictureBox.Size = new System.Drawing.Size(163, 64);
            this.spiro_TlcButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.spiro_TlcButtonPictureBox.TabIndex = 90;
            this.spiro_TlcButtonPictureBox.TabStop = false;
            this.spiro_TlcButtonPictureBox.Text = "Spiro & TLC";
            this.spiro_TlcButtonPictureBox.TextColor = System.Drawing.Color.White;
            this.spiro_TlcButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spiro_TlcButtonPictureBox.XTextOffset = 0;
            this.spiro_TlcButtonPictureBox.YTextOffset = 0;
            this.spiro_TlcButtonPictureBox.Click += new System.EventHandler(this.newSessionButtonPictureBox_Click);
            // 
            // co2FenoButtonPictureBox
            // 
            this.co2FenoButtonPictureBox.DisableImage = global::STSGui.Properties.Resources.patients_details_new_test_session_disable;
            this.co2FenoButtonPictureBox.DisableTextColor = System.Drawing.Color.Black;
            this.co2FenoButtonPictureBox.Image = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.co2FenoButtonPictureBox.IsTextColorMouseChanged = false;
            this.co2FenoButtonPictureBox.Location = new System.Drawing.Point(1498, 29);
            this.co2FenoButtonPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_details_new_test_session_down;
            this.co2FenoButtonPictureBox.MouseDownTextColor = System.Drawing.Color.Empty;
            this.co2FenoButtonPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_details_new_test_session_over_;
            this.co2FenoButtonPictureBox.MouseOverTextColor = System.Drawing.Color.Empty;
            this.co2FenoButtonPictureBox.Name = "co2FenoButtonPictureBox";
            this.co2FenoButtonPictureBox.NormalImage = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.co2FenoButtonPictureBox.NormalTextColor = System.Drawing.Color.Black;
            this.co2FenoButtonPictureBox.Size = new System.Drawing.Size(163, 64);
            this.co2FenoButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.co2FenoButtonPictureBox.TabIndex = 90;
            this.co2FenoButtonPictureBox.TabStop = false;
            this.co2FenoButtonPictureBox.Text = "CO2/FENO";
            this.co2FenoButtonPictureBox.TextColor = System.Drawing.Color.White;
            this.co2FenoButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.co2FenoButtonPictureBox.XTextOffset = 0;
            this.co2FenoButtonPictureBox.YTextOffset = 0;
            this.co2FenoButtonPictureBox.Click += new System.EventHandler(this.co2FenoButtonPictureBox_Click);
            // 
            // dlcoButtonPictureBox
            // 
            this.dlcoButtonPictureBox.DisableImage = global::STSGui.Properties.Resources.patients_details_new_test_session_disable;
            this.dlcoButtonPictureBox.DisableTextColor = System.Drawing.Color.Black;
            this.dlcoButtonPictureBox.Image = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.dlcoButtonPictureBox.IsTextColorMouseChanged = false;
            this.dlcoButtonPictureBox.Location = new System.Drawing.Point(1278, 29);
            this.dlcoButtonPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_details_new_test_session_down;
            this.dlcoButtonPictureBox.MouseDownTextColor = System.Drawing.Color.Empty;
            this.dlcoButtonPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_details_new_test_session_over_;
            this.dlcoButtonPictureBox.MouseOverTextColor = System.Drawing.Color.Empty;
            this.dlcoButtonPictureBox.Name = "dlcoButtonPictureBox";
            this.dlcoButtonPictureBox.NormalImage = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.dlcoButtonPictureBox.NormalTextColor = System.Drawing.Color.Black;
            this.dlcoButtonPictureBox.Size = new System.Drawing.Size(163, 64);
            this.dlcoButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.dlcoButtonPictureBox.TabIndex = 90;
            this.dlcoButtonPictureBox.TabStop = false;
            this.dlcoButtonPictureBox.Text = "DLCO";
            this.dlcoButtonPictureBox.TextColor = System.Drawing.Color.White;
            this.dlcoButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dlcoButtonPictureBox.XTextOffset = 0;
            this.dlcoButtonPictureBox.YTextOffset = 0;
            this.dlcoButtonPictureBox.Click += new System.EventHandler(this.dlcoButtonPictureBox_Click);
            // 
            // startStopTestButtonPictureBox
            // 
            this.startStopTestButtonPictureBox.DisableImage = global::STSGui.Properties.Resources.patients_details_new_test_session_disableEX1;
            this.startStopTestButtonPictureBox.DisableTextColor = System.Drawing.Color.Black;
            this.startStopTestButtonPictureBox.Image = global::STSGui.Properties.Resources.patients_details_new_test_session_normalEX;
            this.startStopTestButtonPictureBox.IsTextColorMouseChanged = false;
            this.startStopTestButtonPictureBox.Location = new System.Drawing.Point(1038, 29);
            this.startStopTestButtonPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_details_new_test_session_downEx;
            this.startStopTestButtonPictureBox.MouseDownTextColor = System.Drawing.Color.Empty;
            this.startStopTestButtonPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_details_new_test_session_over_EX1;
            this.startStopTestButtonPictureBox.MouseOverTextColor = System.Drawing.Color.Empty;
            this.startStopTestButtonPictureBox.Name = "startStopTestButtonPictureBox";
            this.startStopTestButtonPictureBox.NormalImage = global::STSGui.Properties.Resources.patients_details_new_test_session_normalEX;
            this.startStopTestButtonPictureBox.NormalTextColor = System.Drawing.Color.Black;
            this.startStopTestButtonPictureBox.Size = new System.Drawing.Size(180, 64);
            this.startStopTestButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.startStopTestButtonPictureBox.TabIndex = 91;
            this.startStopTestButtonPictureBox.TabStop = false;
            this.startStopTestButtonPictureBox.Text = "Start Test";
            this.startStopTestButtonPictureBox.TextColor = System.Drawing.Color.White;
            this.startStopTestButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startStopTestButtonPictureBox.XTextOffset = 0;
            this.startStopTestButtonPictureBox.YTextOffset = 0;
            this.startStopTestButtonPictureBox.Click += new System.EventHandler(this.startStopTestButtonPictureBox_Click);
            // 
            // cancelButtonPictureBox
            // 
            this.cancelButtonPictureBox.DisableImage = global::STSGui.Properties.Resources.patients_details_new_test_session_disable;
            this.cancelButtonPictureBox.DisableTextColor = System.Drawing.Color.Black;
            this.cancelButtonPictureBox.Image = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.cancelButtonPictureBox.IsTextColorMouseChanged = false;
            this.cancelButtonPictureBox.Location = new System.Drawing.Point(700, 29);
            this.cancelButtonPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_details_new_test_session_down;
            this.cancelButtonPictureBox.MouseDownTextColor = System.Drawing.Color.Empty;
            this.cancelButtonPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_details_new_test_session_over_;
            this.cancelButtonPictureBox.MouseOverTextColor = System.Drawing.Color.Empty;
            this.cancelButtonPictureBox.Name = "cancelButtonPictureBox";
            this.cancelButtonPictureBox.NormalImage = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.cancelButtonPictureBox.NormalTextColor = System.Drawing.Color.Black;
            this.cancelButtonPictureBox.Size = new System.Drawing.Size(163, 64);
            this.cancelButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.cancelButtonPictureBox.TabIndex = 90;
            this.cancelButtonPictureBox.TabStop = false;
            this.cancelButtonPictureBox.Text = "Cancel";
            this.cancelButtonPictureBox.TextColor = System.Drawing.Color.White;
            this.cancelButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButtonPictureBox.XTextOffset = 0;
            this.cancelButtonPictureBox.YTextOffset = 0;
            this.cancelButtonPictureBox.Click += new System.EventHandler(this.cancelButtonPictureBox_Click);
            // 
            // saveSessionButtonPictureBox
            // 
            this.saveSessionButtonPictureBox.DisableImage = global::STSGui.Properties.Resources.patients_details_new_test_session_disable;
            this.saveSessionButtonPictureBox.DisableTextColor = System.Drawing.Color.Black;
            this.saveSessionButtonPictureBox.Image = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.saveSessionButtonPictureBox.IsTextColorMouseChanged = false;
            this.saveSessionButtonPictureBox.Location = new System.Drawing.Point(869, 29);
            this.saveSessionButtonPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_details_new_test_session_down;
            this.saveSessionButtonPictureBox.MouseDownTextColor = System.Drawing.Color.Empty;
            this.saveSessionButtonPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_details_new_test_session_over_;
            this.saveSessionButtonPictureBox.MouseOverTextColor = System.Drawing.Color.Empty;
            this.saveSessionButtonPictureBox.Name = "saveSessionButtonPictureBox";
            this.saveSessionButtonPictureBox.NormalImage = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.saveSessionButtonPictureBox.NormalTextColor = System.Drawing.Color.Black;
            this.saveSessionButtonPictureBox.Size = new System.Drawing.Size(163, 64);
            this.saveSessionButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.saveSessionButtonPictureBox.TabIndex = 89;
            this.saveSessionButtonPictureBox.TabStop = false;
            this.saveSessionButtonPictureBox.Text = "Save Session";
            this.saveSessionButtonPictureBox.TextColor = System.Drawing.Color.White;
            this.saveSessionButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSessionButtonPictureBox.XTextOffset = 0;
            this.saveSessionButtonPictureBox.YTextOffset = 0;
            this.saveSessionButtonPictureBox.Click += new System.EventHandler(this.saveSessionButtonPictureBox_Click);
            // 
            // reconnectButtonPictureBox
            // 
            this.reconnectButtonPictureBox.DisableImage = global::STSGui.Properties.Resources.patients_details_new_test_session_disable;
            this.reconnectButtonPictureBox.DisableTextColor = System.Drawing.Color.Black;
            this.reconnectButtonPictureBox.Image = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.reconnectButtonPictureBox.IsTextColorMouseChanged = false;
            this.reconnectButtonPictureBox.Location = new System.Drawing.Point(531, 29);
            this.reconnectButtonPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_details_new_test_session_down;
            this.reconnectButtonPictureBox.MouseDownTextColor = System.Drawing.Color.Empty;
            this.reconnectButtonPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_details_new_test_session_over_;
            this.reconnectButtonPictureBox.MouseOverTextColor = System.Drawing.Color.Empty;
            this.reconnectButtonPictureBox.Name = "reconnectButtonPictureBox";
            this.reconnectButtonPictureBox.NormalImage = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.reconnectButtonPictureBox.NormalTextColor = System.Drawing.Color.Black;
            this.reconnectButtonPictureBox.Size = new System.Drawing.Size(163, 64);
            this.reconnectButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.reconnectButtonPictureBox.TabIndex = 94;
            this.reconnectButtonPictureBox.TabStop = false;
            this.reconnectButtonPictureBox.Text = "Reconnect";
            this.reconnectButtonPictureBox.TextColor = System.Drawing.Color.White;
            this.reconnectButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reconnectButtonPictureBox.Visible = false;
            this.reconnectButtonPictureBox.XTextOffset = 0;
            this.reconnectButtonPictureBox.YTextOffset = 0;
            this.reconnectButtonPictureBox.Click += new System.EventHandler(this.reconnectButtonPictureBox_Click);
            // 
            // PatientDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reconnectButtonPictureBox);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.testProgressPictureBox);
            this.Controls.Add(this.spiro_TlcButtonPictureBox);
            this.Controls.Add(this.co2FenoButtonPictureBox);
            this.Controls.Add(this.dlcoButtonPictureBox);
            this.Controls.Add(this.startStopTestButtonPictureBox);
            this.Controls.Add(this.cancelButtonPictureBox);
            this.Controls.Add(this.saveSessionButtonPictureBox);
            this.Controls.Add(this.rightBigPanel);
            this.Controls.Add(this.patientTopNameLabel);
            this.Controls.Add(this.patientTopCloseLabel);
            this.Controls.Add(this.patientTopNameAndIDLabel);
            this.Controls.Add(this.leftBigPanel);
            this.DoubleBuffered = true;
            this.Name = "PatientDetails";
            this.Size = new System.Drawing.Size(1920, 1069);
            this.Load += new System.EventHandler(this.PatientDetails_Load);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.PatientDetails_ControlRemoved);
            this.Leave += new System.EventHandler(this.PatientDetails_Leave);
            this.leftBigPanel.ResumeLayout(false);
            this.rightBigPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.testProgressPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spiro_TlcButtonPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.co2FenoButtonPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlcoButtonPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startStopTestButtonPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButtonPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveSessionButtonPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reconnectButtonPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label patientTopNameAndIDLabel;
        private System.Windows.Forms.Label patientTopCloseLabel;
        private System.Windows.Forms.Label patientTopNameLabel;
        private System.Windows.Forms.Panel leftBigPanel;
        private ShortPatientDetails shortPatientDetailsControl;
        private System.Windows.Forms.Panel rightBigPanel;
        private PreviousTests previousTestsControl;
        private ButtonPictureBox saveSessionButtonPictureBox;
        private ButtonPictureBox cancelButtonPictureBox;
        private ButtonPictureBox startStopTestButtonPictureBox;
        private ButtonPictureBox dlcoButtonPictureBox;
        private ButtonPictureBox co2FenoButtonPictureBox;
        private ButtonPictureBox spiro_TlcButtonPictureBox;
        private RoundedCornersPictureBox testProgressPictureBox;
        private LabelExtended timerLabel;
        private ButtonPictureBox reconnectButtonPictureBox;
    }
}
