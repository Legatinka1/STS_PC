
namespace STSGui.Controls.Doctors
{
    partial class SettingsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsControl));
            this.unitSystemPanel = new System.Windows.Forms.Panel();
            this.usaSmallRadioButton = new STSGui.SmallRadioButton();
            this.usa_Name_Label = new System.Windows.Forms.Label();
            this.imperialSmallRadioButton = new STSGui.SmallRadioButton();
            this.metricSmallRadioButton = new STSGui.SmallRadioButton();
            this.metric_Name_Label = new System.Windows.Forms.Label();
            this.imperial_Name_Label = new System.Windows.Forms.Label();
            this.unitSystemLabel = new System.Windows.Forms.Label();
            this.hospitalNameLabel = new System.Windows.Forms.Label();
            this.hospitalPanel = new System.Windows.Forms.Panel();
            this.hospitalName_Value_Panel = new System.Windows.Forms.Panel();
            this.hospitalName_Value_TextBox = new System.Windows.Forms.TextBox();
            this.className_Value_Panel = new System.Windows.Forms.Panel();
            this.className_Value_TextBox = new System.Windows.Forms.TextBox();
            this.hospitalName_Name_Label = new System.Windows.Forms.Label();
            this.className_Name_Label = new System.Windows.Forms.Label();
            this.settings_Name_Label = new System.Windows.Forms.Label();
            this.comPortLabel = new System.Windows.Forms.Label();
            this.CommunicationPanel = new System.Windows.Forms.Panel();
            this.serial_Name_Label = new System.Windows.Forms.Label();
            this.bluetooth_Name_Label = new System.Windows.Forms.Label();
            this.bluetoothSmallRadioButton = new STSGui.SmallRadioButton();
            this.serialSmallRadioButton = new STSGui.SmallRadioButton();
            this.comPorts_Value_Panel = new System.Windows.Forms.Panel();
            this.comPorts_Value_ComboBoxClean = new STSGui.ComboBoxClean();
            this.cancelButtonPictureBox = new STSGui.ButtonPictureBox();
            this.saveButtonPictureBox = new STSGui.ButtonPictureBox();
            this.openFileDialogConfig = new System.Windows.Forms.OpenFileDialog();
            this.unitSystemPanel.SuspendLayout();
            this.hospitalPanel.SuspendLayout();
            this.hospitalName_Value_Panel.SuspendLayout();
            this.className_Value_Panel.SuspendLayout();
            this.CommunicationPanel.SuspendLayout();
            this.comPorts_Value_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButtonPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveButtonPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // unitSystemPanel
            // 
            this.unitSystemPanel.BackgroundImage = global::STSGui.Properties.Resources.login_dialog_background;
            this.unitSystemPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.unitSystemPanel.Controls.Add(this.usaSmallRadioButton);
            this.unitSystemPanel.Controls.Add(this.usa_Name_Label);
            this.unitSystemPanel.Controls.Add(this.imperialSmallRadioButton);
            this.unitSystemPanel.Controls.Add(this.metricSmallRadioButton);
            this.unitSystemPanel.Controls.Add(this.metric_Name_Label);
            this.unitSystemPanel.Controls.Add(this.imperial_Name_Label);
            this.unitSystemPanel.Location = new System.Drawing.Point(105, 243);
            this.unitSystemPanel.Name = "unitSystemPanel";
            this.unitSystemPanel.Size = new System.Drawing.Size(292, 255);
            this.unitSystemPanel.TabIndex = 120;
            // 
            // usaSmallRadioButton
            // 
            this.usaSmallRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.usaSmallRadioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("usaSmallRadioButton.BackgroundImage")));
            this.usaSmallRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.usaSmallRadioButton.Checked = false;
            this.usaSmallRadioButton.Location = new System.Drawing.Point(39, 199);
            this.usaSmallRadioButton.Name = "usaSmallRadioButton";
            this.usaSmallRadioButton.Size = new System.Drawing.Size(16, 16);
            this.usaSmallRadioButton.TabIndex = 119;
            // 
            // usa_Name_Label
            // 
            this.usa_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.usa_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.usa_Name_Label.ForeColor = System.Drawing.Color.Gray;
            this.usa_Name_Label.Location = new System.Drawing.Point(64, 195);
            this.usa_Name_Label.Name = "usa_Name_Label";
            this.usa_Name_Label.Size = new System.Drawing.Size(149, 24);
            this.usa_Name_Label.TabIndex = 118;
            this.usa_Name_Label.Text = "USA";
            this.usa_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.usa_Name_Label.Click += new System.EventHandler(this.usa_Name_Label_Click);
            // 
            // imperialSmallRadioButton
            // 
            this.imperialSmallRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.imperialSmallRadioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imperialSmallRadioButton.BackgroundImage")));
            this.imperialSmallRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imperialSmallRadioButton.Checked = false;
            this.imperialSmallRadioButton.Location = new System.Drawing.Point(39, 114);
            this.imperialSmallRadioButton.Name = "imperialSmallRadioButton";
            this.imperialSmallRadioButton.Size = new System.Drawing.Size(16, 16);
            this.imperialSmallRadioButton.TabIndex = 117;
            // 
            // metricSmallRadioButton
            // 
            this.metricSmallRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.metricSmallRadioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metricSmallRadioButton.BackgroundImage")));
            this.metricSmallRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.metricSmallRadioButton.Checked = false;
            this.metricSmallRadioButton.Location = new System.Drawing.Point(39, 29);
            this.metricSmallRadioButton.Name = "metricSmallRadioButton";
            this.metricSmallRadioButton.Size = new System.Drawing.Size(16, 16);
            this.metricSmallRadioButton.TabIndex = 115;
            this.metricSmallRadioButton.Load += new System.EventHandler(this.metricSmallRadioButton_Load);
            // 
            // metric_Name_Label
            // 
            this.metric_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.metric_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.metric_Name_Label.ForeColor = System.Drawing.Color.Gray;
            this.metric_Name_Label.Location = new System.Drawing.Point(64, 25);
            this.metric_Name_Label.Name = "metric_Name_Label";
            this.metric_Name_Label.Size = new System.Drawing.Size(149, 24);
            this.metric_Name_Label.TabIndex = 112;
            this.metric_Name_Label.Text = "Metric";
            this.metric_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metric_Name_Label.Click += new System.EventHandler(this.metric_Name_Label_Click);
            // 
            // imperial_Name_Label
            // 
            this.imperial_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.imperial_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.imperial_Name_Label.ForeColor = System.Drawing.Color.Gray;
            this.imperial_Name_Label.Location = new System.Drawing.Point(64, 110);
            this.imperial_Name_Label.Name = "imperial_Name_Label";
            this.imperial_Name_Label.Size = new System.Drawing.Size(149, 24);
            this.imperial_Name_Label.TabIndex = 113;
            this.imperial_Name_Label.Text = "Imperial";
            this.imperial_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.imperial_Name_Label.Click += new System.EventHandler(this.imperial_Name_Label_Click);
            // 
            // unitSystemLabel
            // 
            this.unitSystemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitSystemLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.unitSystemLabel.Location = new System.Drawing.Point(105, 160);
            this.unitSystemLabel.Name = "unitSystemLabel";
            this.unitSystemLabel.Size = new System.Drawing.Size(292, 55);
            this.unitSystemLabel.TabIndex = 122;
            this.unitSystemLabel.Text = "Unit System";
            this.unitSystemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hospitalNameLabel
            // 
            this.hospitalNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hospitalNameLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.hospitalNameLabel.Location = new System.Drawing.Point(593, 160);
            this.hospitalNameLabel.Name = "hospitalNameLabel";
            this.hospitalNameLabel.Size = new System.Drawing.Size(292, 55);
            this.hospitalNameLabel.TabIndex = 124;
            this.hospitalNameLabel.Text = "Hospital";
            this.hospitalNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hospitalPanel
            // 
            this.hospitalPanel.BackgroundImage = global::STSGui.Properties.Resources.login_dialog_background;
            this.hospitalPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hospitalPanel.Controls.Add(this.hospitalName_Value_Panel);
            this.hospitalPanel.Controls.Add(this.className_Value_Panel);
            this.hospitalPanel.Controls.Add(this.hospitalName_Name_Label);
            this.hospitalPanel.Controls.Add(this.className_Name_Label);
            this.hospitalPanel.Location = new System.Drawing.Point(563, 243);
            this.hospitalPanel.Name = "hospitalPanel";
            this.hospitalPanel.Size = new System.Drawing.Size(811, 255);
            this.hospitalPanel.TabIndex = 123;
            // 
            // hospitalName_Value_Panel
            // 
            this.hospitalName_Value_Panel.BackColor = System.Drawing.Color.White;
            this.hospitalName_Value_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hospitalName_Value_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hospitalName_Value_Panel.Controls.Add(this.hospitalName_Value_TextBox);
            this.hospitalName_Value_Panel.Location = new System.Drawing.Point(42, 61);
            this.hospitalName_Value_Panel.Name = "hospitalName_Value_Panel";
            this.hospitalName_Value_Panel.Size = new System.Drawing.Size(731, 37);
            this.hospitalName_Value_Panel.TabIndex = 115;
            // 
            // hospitalName_Value_TextBox
            // 
            this.hospitalName_Value_TextBox.BackColor = System.Drawing.Color.White;
            this.hospitalName_Value_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hospitalName_Value_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.hospitalName_Value_TextBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.hospitalName_Value_TextBox.Location = new System.Drawing.Point(3, 5);
            this.hospitalName_Value_TextBox.MaxLength = 20;
            this.hospitalName_Value_TextBox.Name = "hospitalName_Value_TextBox";
            this.hospitalName_Value_TextBox.Size = new System.Drawing.Size(714, 22);
            this.hospitalName_Value_TextBox.TabIndex = 1;
            this.hospitalName_Value_TextBox.TabStop = false;
            this.hospitalName_Value_TextBox.Text = "a";
            this.hospitalName_Value_TextBox.Validated += new System.EventHandler(this.hospitalName_Value_TextBox_Validated);
            // 
            // className_Value_Panel
            // 
            this.className_Value_Panel.BackColor = System.Drawing.Color.White;
            this.className_Value_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.className_Value_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.className_Value_Panel.Controls.Add(this.className_Value_TextBox);
            this.className_Value_Panel.Location = new System.Drawing.Point(42, 181);
            this.className_Value_Panel.Name = "className_Value_Panel";
            this.className_Value_Panel.Size = new System.Drawing.Size(731, 37);
            this.className_Value_Panel.TabIndex = 114;
            // 
            // className_Value_TextBox
            // 
            this.className_Value_TextBox.BackColor = System.Drawing.Color.White;
            this.className_Value_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.className_Value_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.className_Value_TextBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.className_Value_TextBox.Location = new System.Drawing.Point(3, 5);
            this.className_Value_TextBox.MaxLength = 20;
            this.className_Value_TextBox.Name = "className_Value_TextBox";
            this.className_Value_TextBox.Size = new System.Drawing.Size(714, 22);
            this.className_Value_TextBox.TabIndex = 1;
            this.className_Value_TextBox.TabStop = false;
            this.className_Value_TextBox.Text = "a";
            this.className_Value_TextBox.Validated += new System.EventHandler(this.className_Value_TextBox_Validated);
            // 
            // hospitalName_Name_Label
            // 
            this.hospitalName_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.hospitalName_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.hospitalName_Name_Label.ForeColor = System.Drawing.Color.Gray;
            this.hospitalName_Name_Label.Location = new System.Drawing.Point(36, 25);
            this.hospitalName_Name_Label.Name = "hospitalName_Name_Label";
            this.hospitalName_Name_Label.Size = new System.Drawing.Size(737, 24);
            this.hospitalName_Name_Label.TabIndex = 112;
            this.hospitalName_Name_Label.Text = "Hospital Name";
            this.hospitalName_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // className_Name_Label
            // 
            this.className_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.className_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.className_Name_Label.ForeColor = System.Drawing.Color.Gray;
            this.className_Name_Label.Location = new System.Drawing.Point(36, 146);
            this.className_Name_Label.Name = "className_Name_Label";
            this.className_Name_Label.Size = new System.Drawing.Size(737, 24);
            this.className_Name_Label.TabIndex = 113;
            this.className_Name_Label.Text = "Class Name";
            this.className_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // settings_Name_Label
            // 
            this.settings_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_Name_Label.ForeColor = System.Drawing.Color.SteelBlue;
            this.settings_Name_Label.Location = new System.Drawing.Point(28, 24);
            this.settings_Name_Label.Name = "settings_Name_Label";
            this.settings_Name_Label.Size = new System.Drawing.Size(292, 55);
            this.settings_Name_Label.TabIndex = 127;
            this.settings_Name_Label.Text = "Settings";
            this.settings_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comPortLabel
            // 
            this.comPortLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comPortLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.comPortLabel.Location = new System.Drawing.Point(1495, 160);
            this.comPortLabel.Name = "comPortLabel";
            this.comPortLabel.Size = new System.Drawing.Size(335, 55);
            this.comPortLabel.TabIndex = 129;
            this.comPortLabel.Text = "Communiction";
            this.comPortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CommunicationPanel
            // 
            this.CommunicationPanel.BackgroundImage = global::STSGui.Properties.Resources.login_dialog_background;
            this.CommunicationPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CommunicationPanel.Controls.Add(this.serial_Name_Label);
            this.CommunicationPanel.Controls.Add(this.bluetooth_Name_Label);
            this.CommunicationPanel.Controls.Add(this.bluetoothSmallRadioButton);
            this.CommunicationPanel.Controls.Add(this.serialSmallRadioButton);
            this.CommunicationPanel.Controls.Add(this.comPorts_Value_Panel);
            this.CommunicationPanel.Location = new System.Drawing.Point(1514, 243);
            this.CommunicationPanel.Name = "CommunicationPanel";
            this.CommunicationPanel.Size = new System.Drawing.Size(292, 255);
            this.CommunicationPanel.TabIndex = 128;
            // 
            // serial_Name_Label
            // 
            this.serial_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.serial_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.serial_Name_Label.ForeColor = System.Drawing.Color.Gray;
            this.serial_Name_Label.Location = new System.Drawing.Point(46, 43);
            this.serial_Name_Label.Name = "serial_Name_Label";
            this.serial_Name_Label.Size = new System.Drawing.Size(149, 24);
            this.serial_Name_Label.TabIndex = 133;
            this.serial_Name_Label.Text = "Serial";
            this.serial_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.serial_Name_Label.Click += new System.EventHandler(this.serial_Name_Label_Click);
            // 
            // bluetooth_Name_Label
            // 
            this.bluetooth_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.bluetooth_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.bluetooth_Name_Label.ForeColor = System.Drawing.Color.Gray;
            this.bluetooth_Name_Label.Location = new System.Drawing.Point(46, 96);
            this.bluetooth_Name_Label.Name = "bluetooth_Name_Label";
            this.bluetooth_Name_Label.Size = new System.Drawing.Size(149, 24);
            this.bluetooth_Name_Label.TabIndex = 120;
            this.bluetooth_Name_Label.Text = "Bluetooth";
            this.bluetooth_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bluetooth_Name_Label.Click += new System.EventHandler(this.bluetooth_Name_Label_Click);
            // 
            // bluetoothSmallRadioButton
            // 
            this.bluetoothSmallRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.bluetoothSmallRadioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bluetoothSmallRadioButton.BackgroundImage")));
            this.bluetoothSmallRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bluetoothSmallRadioButton.Checked = false;
            this.bluetoothSmallRadioButton.Location = new System.Drawing.Point(24, 100);
            this.bluetoothSmallRadioButton.Name = "bluetoothSmallRadioButton";
            this.bluetoothSmallRadioButton.Size = new System.Drawing.Size(16, 16);
            this.bluetoothSmallRadioButton.TabIndex = 132;
            this.bluetoothSmallRadioButton.Click += new System.EventHandler(this.bluetoothSmallRadioButton_Click);
            // 
            // serialSmallRadioButton
            // 
            this.serialSmallRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.serialSmallRadioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("serialSmallRadioButton.BackgroundImage")));
            this.serialSmallRadioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.serialSmallRadioButton.Checked = false;
            this.serialSmallRadioButton.Location = new System.Drawing.Point(24, 47);
            this.serialSmallRadioButton.Name = "serialSmallRadioButton";
            this.serialSmallRadioButton.Size = new System.Drawing.Size(16, 16);
            this.serialSmallRadioButton.TabIndex = 131;
            this.serialSmallRadioButton.Click += new System.EventHandler(this.serialSmallRadioButton_Click);
            // 
            // comPorts_Value_Panel
            // 
            this.comPorts_Value_Panel.BackColor = System.Drawing.Color.White;
            this.comPorts_Value_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.comPorts_Value_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.comPorts_Value_Panel.Controls.Add(this.comPorts_Value_ComboBoxClean);
            this.comPorts_Value_Panel.Location = new System.Drawing.Point(21, 183);
            this.comPorts_Value_Panel.Name = "comPorts_Value_Panel";
            this.comPorts_Value_Panel.Size = new System.Drawing.Size(251, 36);
            this.comPorts_Value_Panel.TabIndex = 130;
            // 
            // comPorts_Value_ComboBoxClean
            // 
            this.comPorts_Value_ComboBoxClean.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comPorts_Value_ComboBoxClean.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPorts_Value_ComboBoxClean.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comPorts_Value_ComboBoxClean.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comPorts_Value_ComboBoxClean.ForeColor = System.Drawing.Color.MidnightBlue;
            this.comPorts_Value_ComboBoxClean.FormattingEnabled = true;
            this.comPorts_Value_ComboBoxClean.Location = new System.Drawing.Point(-1, -1);
            this.comPorts_Value_ComboBoxClean.Name = "comPorts_Value_ComboBoxClean";
            this.comPorts_Value_ComboBoxClean.Size = new System.Drawing.Size(251, 36);
            this.comPorts_Value_ComboBoxClean.TabIndex = 115;
            this.comPorts_Value_ComboBoxClean.DropDown += new System.EventHandler(this.comPorts_Value_ComboBoxClean_DropDown);
            this.comPorts_Value_ComboBoxClean.SelectedIndexChanged += new System.EventHandler(this.comPorts_Value_ComboBoxClean_SelectedIndexChanged);
            // 
            // cancelButtonPictureBox
            // 
            this.cancelButtonPictureBox.DisableImage = global::STSGui.Properties.Resources.patients_details_new_test_session_disable;
            this.cancelButtonPictureBox.DisableTextColor = System.Drawing.Color.Black;
            this.cancelButtonPictureBox.Image = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.cancelButtonPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cancelButtonPictureBox.IsTextColorMouseChanged = false;
            this.cancelButtonPictureBox.Location = new System.Drawing.Point(1541, 35);
            this.cancelButtonPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_details_new_test_session_down;
            this.cancelButtonPictureBox.MouseDownTextColor = System.Drawing.Color.Empty;
            this.cancelButtonPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_details_new_test_session_over_;
            this.cancelButtonPictureBox.MouseOverTextColor = System.Drawing.Color.Empty;
            this.cancelButtonPictureBox.Name = "cancelButtonPictureBox";
            this.cancelButtonPictureBox.NormalImage = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.cancelButtonPictureBox.NormalTextColor = System.Drawing.Color.Black;
            this.cancelButtonPictureBox.Size = new System.Drawing.Size(124, 44);
            this.cancelButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cancelButtonPictureBox.TabIndex = 126;
            this.cancelButtonPictureBox.TabStop = false;
            this.cancelButtonPictureBox.Text = "Cancel";
            this.cancelButtonPictureBox.TextColor = System.Drawing.Color.White;
            this.cancelButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButtonPictureBox.XTextOffset = 0;
            this.cancelButtonPictureBox.YTextOffset = 0;
            this.cancelButtonPictureBox.Click += new System.EventHandler(this.cancelButtonPictureBox_Click);
            // 
            // saveButtonPictureBox
            // 
            this.saveButtonPictureBox.DisableImage = global::STSGui.Properties.Resources.patients_details_new_test_session_disable;
            this.saveButtonPictureBox.DisableTextColor = System.Drawing.Color.Black;
            this.saveButtonPictureBox.Image = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.saveButtonPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.saveButtonPictureBox.IsTextColorMouseChanged = false;
            this.saveButtonPictureBox.Location = new System.Drawing.Point(1682, 35);
            this.saveButtonPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_details_new_test_session_down;
            this.saveButtonPictureBox.MouseDownTextColor = System.Drawing.Color.Empty;
            this.saveButtonPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_details_new_test_session_over_;
            this.saveButtonPictureBox.MouseOverTextColor = System.Drawing.Color.Empty;
            this.saveButtonPictureBox.Name = "saveButtonPictureBox";
            this.saveButtonPictureBox.NormalImage = global::STSGui.Properties.Resources.patients_details_new_test_session_normal;
            this.saveButtonPictureBox.NormalTextColor = System.Drawing.Color.Black;
            this.saveButtonPictureBox.Size = new System.Drawing.Size(124, 44);
            this.saveButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.saveButtonPictureBox.TabIndex = 125;
            this.saveButtonPictureBox.TabStop = false;
            this.saveButtonPictureBox.Text = "Save";
            this.saveButtonPictureBox.TextColor = System.Drawing.Color.White;
            this.saveButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButtonPictureBox.XTextOffset = 0;
            this.saveButtonPictureBox.YTextOffset = 0;
            this.saveButtonPictureBox.Click += new System.EventHandler(this.saveButtonPictureBox_Click);
            // 
            // openFileDialogConfig
            // 
            this.openFileDialogConfig.DefaultExt = "*.xml";
            this.openFileDialogConfig.FileName = "openFileDialogConfig";
            this.openFileDialogConfig.Filter = "Xml files|*.xml";
            this.openFileDialogConfig.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.comPortLabel);
            this.Controls.Add(this.CommunicationPanel);
            this.Controls.Add(this.settings_Name_Label);
            this.Controls.Add(this.cancelButtonPictureBox);
            this.Controls.Add(this.saveButtonPictureBox);
            this.Controls.Add(this.hospitalNameLabel);
            this.Controls.Add(this.hospitalPanel);
            this.Controls.Add(this.unitSystemLabel);
            this.Controls.Add(this.unitSystemPanel);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(1918, 1040);
            this.Load += new System.EventHandler(this.SettingsControl_Load);
            this.unitSystemPanel.ResumeLayout(false);
            this.hospitalPanel.ResumeLayout(false);
            this.hospitalName_Value_Panel.ResumeLayout(false);
            this.hospitalName_Value_Panel.PerformLayout();
            this.className_Value_Panel.ResumeLayout(false);
            this.className_Value_Panel.PerformLayout();
            this.CommunicationPanel.ResumeLayout(false);
            this.comPorts_Value_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cancelButtonPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveButtonPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label imperial_Name_Label;
        private System.Windows.Forms.Label metric_Name_Label;
        private System.Windows.Forms.Panel unitSystemPanel;
        private System.Windows.Forms.Label unitSystemLabel;
        private SmallRadioButton imperialSmallRadioButton;
        private SmallRadioButton metricSmallRadioButton;
        private SmallRadioButton usaSmallRadioButton;
        private System.Windows.Forms.Label usa_Name_Label;
        private System.Windows.Forms.Label hospitalNameLabel;
        private System.Windows.Forms.Panel hospitalPanel;
        private System.Windows.Forms.Label hospitalName_Name_Label;
        private System.Windows.Forms.Label className_Name_Label;
        private System.Windows.Forms.Panel hospitalName_Value_Panel;
        private System.Windows.Forms.TextBox hospitalName_Value_TextBox;
        private System.Windows.Forms.Panel className_Value_Panel;
        private System.Windows.Forms.TextBox className_Value_TextBox;
        private ButtonPictureBox cancelButtonPictureBox;
        private ButtonPictureBox saveButtonPictureBox;
        private System.Windows.Forms.Label settings_Name_Label;
        private System.Windows.Forms.Label comPortLabel;
        private System.Windows.Forms.Panel CommunicationPanel;
        private System.Windows.Forms.Panel comPorts_Value_Panel;
        private ComboBoxClean comPorts_Value_ComboBoxClean;
        private SmallRadioButton bluetoothSmallRadioButton;
        private SmallRadioButton serialSmallRadioButton;
        private System.Windows.Forms.Label bluetooth_Name_Label;
        private System.Windows.Forms.Label serial_Name_Label;
        private System.Windows.Forms.OpenFileDialog openFileDialogConfig;
    }
}
