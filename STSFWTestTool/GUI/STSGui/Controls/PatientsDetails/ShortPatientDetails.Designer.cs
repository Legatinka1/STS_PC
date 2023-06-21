
namespace STSGui
{
    partial class ShortPatientDetails
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
            this.smokingStatusPictureBox = new System.Windows.Forms.PictureBox();
            this.medicationsStatusPictureBox = new System.Windows.Forms.PictureBox();
            this.editButtonPictureBox = new STSGui.ButtonPictureBox();
            this.address_Value_Label = new System.Windows.Forms.Label();
            this.address_Name_Label = new System.Windows.Forms.Label();
            this.smoking_Value_Label = new System.Windows.Forms.Label();
            this.smoking_Name_Label = new System.Windows.Forms.Label();
            this.medications_Value_Label = new System.Windows.Forms.Label();
            this.medications_Name_Label = new System.Windows.Forms.Label();
            this.bmi_Value_Label = new System.Windows.Forms.Label();
            this.bmi_Name_Label = new System.Windows.Forms.Label();
            this.weight_Value_Label = new System.Windows.Forms.Label();
            this.weight_Name_Label = new System.Windows.Forms.Label();
            this.height_Value_Label = new System.Windows.Forms.Label();
            this.ethnicity_Value_Label = new System.Windows.Forms.Label();
            this.gender_Value_Label = new System.Windows.Forms.Label();
            this.birthDate_Value_Label = new System.Windows.Forms.Label();
            this.height_Name_Label = new System.Windows.Forms.Label();
            this.ethnicity_Name_Label = new System.Windows.Forms.Label();
            this.gender_Name_Label = new System.Windows.Forms.Label();
            this.birthDate_Name_Label = new System.Windows.Forms.Label();
            this.patientDetails_Name_Label = new System.Windows.Forms.Label();
            this.itemBackgroundPictureBox = new STSGui.RoundedCornersPictureBox();
            this.patientPhone_Value_Label = new System.Windows.Forms.Label();
            this.patientID_Value_Label = new System.Windows.Forms.Label();
            this.patientAge_Value_Label = new System.Windows.Forms.Label();
            this.patientName_Value_Label = new System.Windows.Forms.Label();
            this.patientPhone_Name_Label = new System.Windows.Forms.Label();
            this.patientID_Name_Label = new System.Windows.Forms.Label();
            this.patientAge_Name_Label = new System.Windows.Forms.Label();
            this.patientName_Name_Label = new System.Windows.Forms.Label();
            this.photoPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.smokingStatusPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicationsStatusPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editButtonPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBackgroundPictureBox)).BeginInit();
            this.itemBackgroundPictureBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // smokingStatusPictureBox
            // 
            this.smokingStatusPictureBox.Image = global::STSGui.Properties.Resources.patients_details_red_res_ellipse;
            this.smokingStatusPictureBox.Location = new System.Drawing.Point(421, 681);
            this.smokingStatusPictureBox.Name = "smokingStatusPictureBox";
            this.smokingStatusPictureBox.Size = new System.Drawing.Size(25, 24);
            this.smokingStatusPictureBox.TabIndex = 94;
            this.smokingStatusPictureBox.TabStop = false;
            // 
            // medicationsStatusPictureBox
            // 
            this.medicationsStatusPictureBox.Image = global::STSGui.Properties.Resources.patients_details_green_res_ellipse;
            this.medicationsStatusPictureBox.Location = new System.Drawing.Point(171, 681);
            this.medicationsStatusPictureBox.Name = "medicationsStatusPictureBox";
            this.medicationsStatusPictureBox.Size = new System.Drawing.Size(25, 24);
            this.medicationsStatusPictureBox.TabIndex = 93;
            this.medicationsStatusPictureBox.TabStop = false;
            // 
            // editButtonPictureBox
            // 
            this.editButtonPictureBox.DisableImage = global::STSGui.Properties.Resources.patients_details_edit_btn_disable;
            this.editButtonPictureBox.DisableTextColor = System.Drawing.Color.Black;
            this.editButtonPictureBox.Image = global::STSGui.Properties.Resources.patients_details_edit_btn_normal;
            this.editButtonPictureBox.IsTextColorMouseChanged = false;
            this.editButtonPictureBox.Location = new System.Drawing.Point(521, 67);
            this.editButtonPictureBox.MouseDownImage = global::STSGui.Properties.Resources.patients_details_edit_btn_down;
            this.editButtonPictureBox.MouseDownTextColor = System.Drawing.Color.Empty;
            this.editButtonPictureBox.MouseOverImage = global::STSGui.Properties.Resources.patients_details_edit_btn_over;
            this.editButtonPictureBox.MouseOverTextColor = System.Drawing.Color.Empty;
            this.editButtonPictureBox.Name = "editButtonPictureBox";
            this.editButtonPictureBox.NormalImage = global::STSGui.Properties.Resources.patients_details_edit_btn_normal;
            this.editButtonPictureBox.NormalTextColor = System.Drawing.Color.Black;
            this.editButtonPictureBox.Size = new System.Drawing.Size(52, 44);
            this.editButtonPictureBox.TabIndex = 92;
            this.editButtonPictureBox.TabStop = false;
            this.editButtonPictureBox.Text = null;
            this.editButtonPictureBox.TextColor = System.Drawing.Color.Black;
            this.editButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButtonPictureBox.XTextOffset = 0;
            this.editButtonPictureBox.YTextOffset = 0;
            this.editButtonPictureBox.Click += new System.EventHandler(this.editButtonPictureBox_Click);
            // 
            // address_Value_Label
            // 
            this.address_Value_Label.AutoSize = true;
            this.address_Value_Label.BackColor = System.Drawing.Color.Transparent;
            this.address_Value_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.address_Value_Label.ForeColor = System.Drawing.Color.MidnightBlue;
            this.address_Value_Label.Location = new System.Drawing.Point(48, 794);
            this.address_Value_Label.Name = "address_Value_Label";
            this.address_Value_Label.Size = new System.Drawing.Size(288, 24);
            this.address_Value_Label.TabIndex = 91;
            this.address_Value_Label.Text = "Herzl 43,Tel Aviv-Yafo,752880";
            this.address_Value_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // address_Name_Label
            // 
            this.address_Name_Label.AutoSize = true;
            this.address_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.address_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.address_Name_Label.ForeColor = System.Drawing.Color.Gray;
            this.address_Name_Label.Location = new System.Drawing.Point(48, 756);
            this.address_Name_Label.Name = "address_Name_Label";
            this.address_Name_Label.Size = new System.Drawing.Size(80, 24);
            this.address_Name_Label.TabIndex = 90;
            this.address_Name_Label.Text = "Address";
            this.address_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // smoking_Value_Label
            // 
            this.smoking_Value_Label.AutoSize = true;
            this.smoking_Value_Label.BackColor = System.Drawing.Color.Transparent;
            this.smoking_Value_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.smoking_Value_Label.ForeColor = System.Drawing.Color.MidnightBlue;
            this.smoking_Value_Label.Location = new System.Drawing.Point(323, 719);
            this.smoking_Value_Label.Name = "smoking_Value_Label";
            this.smoking_Value_Label.Size = new System.Drawing.Size(174, 24);
            this.smoking_Value_Label.TabIndex = 89;
            this.smoking_Value_Label.Text = "Quit. 2 years ago.";
            this.smoking_Value_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // smoking_Name_Label
            // 
            this.smoking_Name_Label.AutoSize = true;
            this.smoking_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.smoking_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.smoking_Name_Label.ForeColor = System.Drawing.Color.Gray;
            this.smoking_Name_Label.Location = new System.Drawing.Point(323, 681);
            this.smoking_Name_Label.Name = "smoking_Name_Label";
            this.smoking_Name_Label.Size = new System.Drawing.Size(84, 24);
            this.smoking_Name_Label.TabIndex = 88;
            this.smoking_Name_Label.Text = "Smoking";
            this.smoking_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // medications_Value_Label
            // 
            this.medications_Value_Label.AutoSize = true;
            this.medications_Value_Label.BackColor = System.Drawing.Color.Transparent;
            this.medications_Value_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.medications_Value_Label.ForeColor = System.Drawing.Color.MidnightBlue;
            this.medications_Value_Label.Location = new System.Drawing.Point(48, 719);
            this.medications_Value_Label.Name = "medications_Value_Label";
            this.medications_Value_Label.Size = new System.Drawing.Size(159, 24);
            this.medications_Value_Label.TabIndex = 87;
            this.medications_Value_Label.Text = "Recontextualize";
            this.medications_Value_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // medications_Name_Label
            // 
            this.medications_Name_Label.AutoSize = true;
            this.medications_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.medications_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.medications_Name_Label.ForeColor = System.Drawing.Color.Gray;
            this.medications_Name_Label.Location = new System.Drawing.Point(48, 681);
            this.medications_Name_Label.Name = "medications_Name_Label";
            this.medications_Name_Label.Size = new System.Drawing.Size(111, 24);
            this.medications_Name_Label.TabIndex = 86;
            this.medications_Name_Label.Text = "Medications";
            this.medications_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bmi_Value_Label
            // 
            this.bmi_Value_Label.AutoSize = true;
            this.bmi_Value_Label.BackColor = System.Drawing.Color.Transparent;
            this.bmi_Value_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.bmi_Value_Label.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bmi_Value_Label.Location = new System.Drawing.Point(393, 618);
            this.bmi_Value_Label.Name = "bmi_Value_Label";
            this.bmi_Value_Label.Size = new System.Drawing.Size(49, 24);
            this.bmi_Value_Label.TabIndex = 85;
            this.bmi_Value_Label.Text = "23.1";
            this.bmi_Value_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bmi_Name_Label
            // 
            this.bmi_Name_Label.AutoSize = true;
            this.bmi_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.bmi_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.bmi_Name_Label.ForeColor = System.Drawing.Color.Gray;
            this.bmi_Name_Label.Location = new System.Drawing.Point(393, 580);
            this.bmi_Name_Label.Name = "bmi_Name_Label";
            this.bmi_Name_Label.Size = new System.Drawing.Size(74, 24);
            this.bmi_Name_Label.TabIndex = 84;
            this.bmi_Name_Label.Text = "BMI (%)";
            this.bmi_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // weight_Value_Label
            // 
            this.weight_Value_Label.AutoSize = true;
            this.weight_Value_Label.BackColor = System.Drawing.Color.Transparent;
            this.weight_Value_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.weight_Value_Label.ForeColor = System.Drawing.Color.MidnightBlue;
            this.weight_Value_Label.Location = new System.Drawing.Point(221, 618);
            this.weight_Value_Label.Name = "weight_Value_Label";
            this.weight_Value_Label.Size = new System.Drawing.Size(49, 24);
            this.weight_Value_Label.TabIndex = 83;
            this.weight_Value_Label.Text = "64.4";
            this.weight_Value_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // weight_Name_Label
            // 
            this.weight_Name_Label.AutoSize = true;
            this.weight_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.weight_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.weight_Name_Label.ForeColor = System.Drawing.Color.Gray;
            this.weight_Name_Label.Location = new System.Drawing.Point(221, 580);
            this.weight_Name_Label.Name = "weight_Name_Label";
            this.weight_Name_Label.Size = new System.Drawing.Size(106, 24);
            this.weight_Name_Label.TabIndex = 82;
            this.weight_Name_Label.Text = "Weight (kg)";
            this.weight_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // height_Value_Label
            // 
            this.height_Value_Label.AutoSize = true;
            this.height_Value_Label.BackColor = System.Drawing.Color.Transparent;
            this.height_Value_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.height_Value_Label.ForeColor = System.Drawing.Color.MidnightBlue;
            this.height_Value_Label.Location = new System.Drawing.Point(48, 618);
            this.height_Value_Label.Name = "height_Value_Label";
            this.height_Value_Label.Size = new System.Drawing.Size(43, 24);
            this.height_Value_Label.TabIndex = 81;
            this.height_Value_Label.Text = "150";
            this.height_Value_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ethnicity_Value_Label
            // 
            this.ethnicity_Value_Label.AutoSize = true;
            this.ethnicity_Value_Label.BackColor = System.Drawing.Color.Transparent;
            this.ethnicity_Value_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.ethnicity_Value_Label.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ethnicity_Value_Label.Location = new System.Drawing.Point(393, 514);
            this.ethnicity_Value_Label.Name = "ethnicity_Value_Label";
            this.ethnicity_Value_Label.Size = new System.Drawing.Size(171, 24);
            this.ethnicity_Value_Label.TabIndex = 80;
            this.ethnicity_Value_Label.Text = "African-American";
            this.ethnicity_Value_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gender_Value_Label
            // 
            this.gender_Value_Label.AutoSize = true;
            this.gender_Value_Label.BackColor = System.Drawing.Color.Transparent;
            this.gender_Value_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.gender_Value_Label.ForeColor = System.Drawing.Color.MidnightBlue;
            this.gender_Value_Label.Location = new System.Drawing.Point(247, 514);
            this.gender_Value_Label.Name = "gender_Value_Label";
            this.gender_Value_Label.Size = new System.Drawing.Size(80, 24);
            this.gender_Value_Label.TabIndex = 79;
            this.gender_Value_Label.Text = "Female";
            this.gender_Value_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // birthDate_Value_Label
            // 
            this.birthDate_Value_Label.AutoSize = true;
            this.birthDate_Value_Label.BackColor = System.Drawing.Color.Transparent;
            this.birthDate_Value_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.birthDate_Value_Label.ForeColor = System.Drawing.Color.MidnightBlue;
            this.birthDate_Value_Label.Location = new System.Drawing.Point(48, 514);
            this.birthDate_Value_Label.Name = "birthDate_Value_Label";
            this.birthDate_Value_Label.Size = new System.Drawing.Size(88, 24);
            this.birthDate_Value_Label.TabIndex = 78;
            this.birthDate_Value_Label.Text = "26/09/92";
            this.birthDate_Value_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // height_Name_Label
            // 
            this.height_Name_Label.AutoSize = true;
            this.height_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.height_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.height_Name_Label.ForeColor = System.Drawing.Color.Gray;
            this.height_Name_Label.Location = new System.Drawing.Point(48, 580);
            this.height_Name_Label.Name = "height_Name_Label";
            this.height_Name_Label.Size = new System.Drawing.Size(108, 24);
            this.height_Name_Label.TabIndex = 77;
            this.height_Name_Label.Text = "Height (cm)";
            this.height_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ethnicity_Name_Label
            // 
            this.ethnicity_Name_Label.AutoSize = true;
            this.ethnicity_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.ethnicity_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.ethnicity_Name_Label.ForeColor = System.Drawing.Color.Gray;
            this.ethnicity_Name_Label.Location = new System.Drawing.Point(393, 476);
            this.ethnicity_Name_Label.Name = "ethnicity_Name_Label";
            this.ethnicity_Name_Label.Size = new System.Drawing.Size(80, 24);
            this.ethnicity_Name_Label.TabIndex = 76;
            this.ethnicity_Name_Label.Text = "Ethnicity";
            this.ethnicity_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gender_Name_Label
            // 
            this.gender_Name_Label.AutoSize = true;
            this.gender_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.gender_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.gender_Name_Label.ForeColor = System.Drawing.Color.Gray;
            this.gender_Name_Label.Location = new System.Drawing.Point(247, 476);
            this.gender_Name_Label.Name = "gender_Name_Label";
            this.gender_Name_Label.Size = new System.Drawing.Size(74, 24);
            this.gender_Name_Label.TabIndex = 75;
            this.gender_Name_Label.Text = "Gender";
            this.gender_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // birthDate_Name_Label
            // 
            this.birthDate_Name_Label.AutoSize = true;
            this.birthDate_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.birthDate_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.birthDate_Name_Label.ForeColor = System.Drawing.Color.Gray;
            this.birthDate_Name_Label.Location = new System.Drawing.Point(48, 476);
            this.birthDate_Name_Label.Name = "birthDate_Name_Label";
            this.birthDate_Name_Label.Size = new System.Drawing.Size(90, 24);
            this.birthDate_Name_Label.TabIndex = 74;
            this.birthDate_Name_Label.Text = "Birth Date";
            this.birthDate_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // patientDetails_Name_Label
            // 
            this.patientDetails_Name_Label.AutoSize = true;
            this.patientDetails_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.patientDetails_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.patientDetails_Name_Label.ForeColor = System.Drawing.Color.DodgerBlue;
            this.patientDetails_Name_Label.Location = new System.Drawing.Point(34, 74);
            this.patientDetails_Name_Label.Name = "patientDetails_Name_Label";
            this.patientDetails_Name_Label.Size = new System.Drawing.Size(205, 31);
            this.patientDetails_Name_Label.TabIndex = 69;
            this.patientDetails_Name_Label.Text = "Patient Details";
            this.patientDetails_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // itemBackgroundPictureBox
            // 
            this.itemBackgroundPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.itemBackgroundPictureBox.Controls.Add(this.patientPhone_Value_Label);
            this.itemBackgroundPictureBox.Controls.Add(this.patientID_Value_Label);
            this.itemBackgroundPictureBox.Controls.Add(this.patientAge_Value_Label);
            this.itemBackgroundPictureBox.Controls.Add(this.patientName_Value_Label);
            this.itemBackgroundPictureBox.Controls.Add(this.patientPhone_Name_Label);
            this.itemBackgroundPictureBox.Controls.Add(this.patientID_Name_Label);
            this.itemBackgroundPictureBox.Controls.Add(this.patientAge_Name_Label);
            this.itemBackgroundPictureBox.Controls.Add(this.patientName_Name_Label);
            this.itemBackgroundPictureBox.Controls.Add(this.photoPictureBox);
            this.itemBackgroundPictureBox.Image = global::STSGui.Properties.Resources.patient_details_blue_background;
            this.itemBackgroundPictureBox.IsOverrideCreateParams = false;
            this.itemBackgroundPictureBox.Location = new System.Drawing.Point(25, 148);
            this.itemBackgroundPictureBox.Name = "itemBackgroundPictureBox";
            this.itemBackgroundPictureBox.Radius = 30;
            this.itemBackgroundPictureBox.Size = new System.Drawing.Size(557, 262);
            this.itemBackgroundPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.itemBackgroundPictureBox.TabIndex = 68;
            this.itemBackgroundPictureBox.TabStop = false;
            // 
            // patientPhone_Value_Label
            // 
            this.patientPhone_Value_Label.AutoSize = true;
            this.patientPhone_Value_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.patientPhone_Value_Label.ForeColor = System.Drawing.Color.White;
            this.patientPhone_Value_Label.Location = new System.Drawing.Point(368, 175);
            this.patientPhone_Value_Label.Name = "patientPhone_Value_Label";
            this.patientPhone_Value_Label.Size = new System.Drawing.Size(173, 25);
            this.patientPhone_Value_Label.TabIndex = 73;
            this.patientPhone_Value_Label.Text = "(058) 555-0115";
            this.patientPhone_Value_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // patientID_Value_Label
            // 
            this.patientID_Value_Label.AutoSize = true;
            this.patientID_Value_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.patientID_Value_Label.ForeColor = System.Drawing.Color.White;
            this.patientID_Value_Label.Location = new System.Drawing.Point(128, 175);
            this.patientID_Value_Label.Name = "patientID_Value_Label";
            this.patientID_Value_Label.Size = new System.Drawing.Size(142, 25);
            this.patientID_Value_Label.TabIndex = 72;
            this.patientID_Value_Label.Text = "9876543210";
            this.patientID_Value_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // patientAge_Value_Label
            // 
            this.patientAge_Value_Label.AutoSize = true;
            this.patientAge_Value_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.patientAge_Value_Label.ForeColor = System.Drawing.Color.White;
            this.patientAge_Value_Label.Location = new System.Drawing.Point(368, 69);
            this.patientAge_Value_Label.Name = "patientAge_Value_Label";
            this.patientAge_Value_Label.Size = new System.Drawing.Size(38, 25);
            this.patientAge_Value_Label.TabIndex = 71;
            this.patientAge_Value_Label.Text = "29";
            this.patientAge_Value_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // patientName_Value_Label
            // 
            this.patientName_Value_Label.AutoSize = true;
            this.patientName_Value_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.patientName_Value_Label.ForeColor = System.Drawing.Color.White;
            this.patientName_Value_Label.Location = new System.Drawing.Point(128, 69);
            this.patientName_Value_Label.Name = "patientName_Value_Label";
            this.patientName_Value_Label.Size = new System.Drawing.Size(170, 25);
            this.patientName_Value_Label.TabIndex = 70;
            this.patientName_Value_Label.Text = "Brooklyn Smith";
            this.patientName_Value_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // patientPhone_Name_Label
            // 
            this.patientPhone_Name_Label.AutoSize = true;
            this.patientPhone_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.patientPhone_Name_Label.ForeColor = System.Drawing.Color.Navy;
            this.patientPhone_Name_Label.Location = new System.Drawing.Point(368, 135);
            this.patientPhone_Name_Label.Name = "patientPhone_Name_Label";
            this.patientPhone_Name_Label.Size = new System.Drawing.Size(71, 24);
            this.patientPhone_Name_Label.TabIndex = 69;
            this.patientPhone_Name_Label.Text = "Phone";
            this.patientPhone_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // patientID_Name_Label
            // 
            this.patientID_Name_Label.AutoSize = true;
            this.patientID_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.patientID_Name_Label.ForeColor = System.Drawing.Color.Navy;
            this.patientID_Name_Label.Location = new System.Drawing.Point(128, 135);
            this.patientID_Name_Label.Name = "patientID_Name_Label";
            this.patientID_Name_Label.Size = new System.Drawing.Size(29, 24);
            this.patientID_Name_Label.TabIndex = 68;
            this.patientID_Name_Label.Text = "ID";
            this.patientID_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // patientAge_Name_Label
            // 
            this.patientAge_Name_Label.AutoSize = true;
            this.patientAge_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.patientAge_Name_Label.ForeColor = System.Drawing.Color.Navy;
            this.patientAge_Name_Label.Location = new System.Drawing.Point(368, 32);
            this.patientAge_Name_Label.Name = "patientAge_Name_Label";
            this.patientAge_Name_Label.Size = new System.Drawing.Size(48, 24);
            this.patientAge_Name_Label.TabIndex = 67;
            this.patientAge_Name_Label.Text = "Age";
            this.patientAge_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // patientName_Name_Label
            // 
            this.patientName_Name_Label.AutoSize = true;
            this.patientName_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.patientName_Name_Label.ForeColor = System.Drawing.Color.Navy;
            this.patientName_Name_Label.Location = new System.Drawing.Point(128, 32);
            this.patientName_Name_Label.Name = "patientName_Name_Label";
            this.patientName_Name_Label.Size = new System.Drawing.Size(65, 24);
            this.patientName_Name_Label.TabIndex = 66;
            this.patientName_Name_Label.Text = "Name";
            this.patientName_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // photoPictureBox
            // 
            this.photoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.photoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.photoPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.photoPictureBox.Location = new System.Drawing.Point(28, 96);
            this.photoPictureBox.Name = "photoPictureBox";
            this.photoPictureBox.Size = new System.Drawing.Size(70, 70);
            this.photoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.photoPictureBox.TabIndex = 65;
            this.photoPictureBox.TabStop = false;
            this.photoPictureBox.Tag = "false";
            // 
            // ShortPatientDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::STSGui.Properties.Resources.patients_details_left_background_img_noraml;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.smokingStatusPictureBox);
            this.Controls.Add(this.medicationsStatusPictureBox);
            this.Controls.Add(this.patientDetails_Name_Label);
            this.Controls.Add(this.editButtonPictureBox);
            this.Controls.Add(this.itemBackgroundPictureBox);
            this.Controls.Add(this.address_Value_Label);
            this.Controls.Add(this.birthDate_Name_Label);
            this.Controls.Add(this.address_Name_Label);
            this.Controls.Add(this.gender_Name_Label);
            this.Controls.Add(this.smoking_Value_Label);
            this.Controls.Add(this.ethnicity_Name_Label);
            this.Controls.Add(this.smoking_Name_Label);
            this.Controls.Add(this.height_Name_Label);
            this.Controls.Add(this.medications_Value_Label);
            this.Controls.Add(this.birthDate_Value_Label);
            this.Controls.Add(this.medications_Name_Label);
            this.Controls.Add(this.gender_Value_Label);
            this.Controls.Add(this.bmi_Value_Label);
            this.Controls.Add(this.ethnicity_Value_Label);
            this.Controls.Add(this.bmi_Name_Label);
            this.Controls.Add(this.height_Value_Label);
            this.Controls.Add(this.weight_Value_Label);
            this.Controls.Add(this.weight_Name_Label);
            this.DoubleBuffered = true;
            this.Name = "ShortPatientDetails";
            this.Size = new System.Drawing.Size(620, 890);
            this.Load += new System.EventHandler(this.ShortPatientDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.smokingStatusPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicationsStatusPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editButtonPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBackgroundPictureBox)).EndInit();
            this.itemBackgroundPictureBox.ResumeLayout(false);
            this.itemBackgroundPictureBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RoundedCornersPictureBox itemBackgroundPictureBox;
        private System.Windows.Forms.Label height_Value_Label;
        private System.Windows.Forms.Label ethnicity_Value_Label;
        private System.Windows.Forms.Label gender_Value_Label;
        private System.Windows.Forms.Label birthDate_Value_Label;
        private System.Windows.Forms.Label height_Name_Label;
        private System.Windows.Forms.Label ethnicity_Name_Label;
        private System.Windows.Forms.Label gender_Name_Label;
        private System.Windows.Forms.Label birthDate_Name_Label;
        private System.Windows.Forms.Label patientDetails_Name_Label;
        private System.Windows.Forms.Label patientPhone_Value_Label;
        private System.Windows.Forms.Label patientID_Value_Label;
        private System.Windows.Forms.Label patientAge_Value_Label;
        private System.Windows.Forms.Label patientName_Value_Label;
        private System.Windows.Forms.Label patientPhone_Name_Label;
        private System.Windows.Forms.Label patientID_Name_Label;
        private System.Windows.Forms.Label patientAge_Name_Label;
        private System.Windows.Forms.Label patientName_Name_Label;
        private System.Windows.Forms.PictureBox photoPictureBox;
        private System.Windows.Forms.Label weight_Value_Label;
        private System.Windows.Forms.Label weight_Name_Label;
        private System.Windows.Forms.Label address_Value_Label;
        private System.Windows.Forms.Label address_Name_Label;
        private System.Windows.Forms.Label smoking_Value_Label;
        private System.Windows.Forms.Label smoking_Name_Label;
        private System.Windows.Forms.Label medications_Value_Label;
        private System.Windows.Forms.Label medications_Name_Label;
        private System.Windows.Forms.Label bmi_Value_Label;
        private System.Windows.Forms.Label bmi_Name_Label;
        private ButtonPictureBox editButtonPictureBox;
        private System.Windows.Forms.PictureBox smokingStatusPictureBox;
        private System.Windows.Forms.PictureBox medicationsStatusPictureBox;
    }
}
