
namespace STSGui
{
    partial class MainForm
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.currentDoctorLabelExtended = new STSGui.LabelExtended();
            this.mainMenuOpenClosePictureBox = new System.Windows.Forms.PictureBox();
            this.healthClinicLabelExtended = new STSGui.LabelExtended();
            this.technoPalmLabelExtended = new STSGui.LabelExtended();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.lblVer = new System.Windows.Forms.Label();
            this.initializingLabelExtended = new STSGui.LabelExtended();
            this.allPatientsPanel1 = new STSGui.AllPatientsPanel();
            this.backPanel = new System.Windows.Forms.Panel();
            this.topLeftButtonPictureBox = new STSGui.ButtonPictureBox();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuOpenClosePictureBox)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.backPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topLeftButtonPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.White;
            this.topPanel.Controls.Add(this.lblVer);
            this.topPanel.Controls.Add(this.currentDoctorLabelExtended);
            this.topPanel.Controls.Add(this.mainMenuOpenClosePictureBox);
            this.topPanel.Controls.Add(this.healthClinicLabelExtended);
            this.topPanel.Controls.Add(this.technoPalmLabelExtended);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1918, 40);
            this.topPanel.TabIndex = 0;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
            this.topPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseUp);
            // 
            // currentDoctorLabelExtended
            // 
            this.currentDoctorLabelExtended.BackColor = System.Drawing.Color.White;
            this.currentDoctorLabelExtended.DisableTextColor = System.Drawing.Color.Black;
            this.currentDoctorLabelExtended.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentDoctorLabelExtended.ForeColor = System.Drawing.Color.Black;
            this.currentDoctorLabelExtended.Image = global::STSGui.Properties.Resources.top_panel_user_img;
            this.currentDoctorLabelExtended.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.currentDoctorLabelExtended.Location = new System.Drawing.Point(1626, 8);
            this.currentDoctorLabelExtended.MouseDownTextColor = System.Drawing.Color.Empty;
            this.currentDoctorLabelExtended.MouseOverTextColor = System.Drawing.Color.Empty;
            this.currentDoctorLabelExtended.Name = "currentDoctorLabelExtended";
            this.currentDoctorLabelExtended.NormalTextColor = System.Drawing.Color.Black;
            this.currentDoctorLabelExtended.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.currentDoctorLabelExtended.Size = new System.Drawing.Size(146, 24);
            this.currentDoctorLabelExtended.TabIndex = 7;
            this.currentDoctorLabelExtended.Text = "Adam James";
            this.currentDoctorLabelExtended.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.currentDoctorLabelExtended.Visible = false;
            // 
            // mainMenuOpenClosePictureBox
            // 
            this.mainMenuOpenClosePictureBox.Image = global::STSGui.Properties.Resources.top_panel_main_menu;
            this.mainMenuOpenClosePictureBox.Location = new System.Drawing.Point(1802, 2);
            this.mainMenuOpenClosePictureBox.Name = "mainMenuOpenClosePictureBox";
            this.mainMenuOpenClosePictureBox.Size = new System.Drawing.Size(37, 37);
            this.mainMenuOpenClosePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mainMenuOpenClosePictureBox.TabIndex = 6;
            this.mainMenuOpenClosePictureBox.TabStop = false;
            this.mainMenuOpenClosePictureBox.Visible = false;
            this.mainMenuOpenClosePictureBox.Click += new System.EventHandler(this.mainMenuOpenClosePictureBox_Click);
            // 
            // healthClinicLabelExtended
            // 
            this.healthClinicLabelExtended.BackColor = System.Drawing.Color.Transparent;
            this.healthClinicLabelExtended.DisableTextColor = System.Drawing.Color.Black;
            this.healthClinicLabelExtended.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthClinicLabelExtended.ForeColor = System.Drawing.Color.Black;
            this.healthClinicLabelExtended.Image = global::STSGui.Properties.Resources.top_panel_health_clinic_logo;
            this.healthClinicLabelExtended.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.healthClinicLabelExtended.Location = new System.Drawing.Point(881, 2);
            this.healthClinicLabelExtended.MouseDownTextColor = System.Drawing.Color.Empty;
            this.healthClinicLabelExtended.MouseOverTextColor = System.Drawing.Color.Empty;
            this.healthClinicLabelExtended.Name = "healthClinicLabelExtended";
            this.healthClinicLabelExtended.NormalTextColor = System.Drawing.Color.Black;
            this.healthClinicLabelExtended.Size = new System.Drawing.Size(156, 37);
            this.healthClinicLabelExtended.TabIndex = 2;
            this.healthClinicLabelExtended.Text = "Health Clinic";
            this.healthClinicLabelExtended.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // technoPalmLabelExtended
            // 
            this.technoPalmLabelExtended.BackColor = System.Drawing.Color.Transparent;
            this.technoPalmLabelExtended.DisableTextColor = System.Drawing.Color.Black;
            this.technoPalmLabelExtended.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.technoPalmLabelExtended.ForeColor = System.Drawing.Color.Black;
            this.technoPalmLabelExtended.Image = global::STSGui.Properties.Resources.top_panel_techno_palm_logo;
            this.technoPalmLabelExtended.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.technoPalmLabelExtended.Location = new System.Drawing.Point(22, 2);
            this.technoPalmLabelExtended.MouseDownTextColor = System.Drawing.Color.Empty;
            this.technoPalmLabelExtended.MouseOverTextColor = System.Drawing.Color.Empty;
            this.technoPalmLabelExtended.Name = "technoPalmLabelExtended";
            this.technoPalmLabelExtended.NormalTextColor = System.Drawing.Color.Black;
            this.technoPalmLabelExtended.Size = new System.Drawing.Size(162, 37);
            this.technoPalmLabelExtended.TabIndex = 1;
            this.technoPalmLabelExtended.Text = "TechnoPulm";
            this.technoPalmLabelExtended.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.technoPalmLabelExtended.Click += new System.EventHandler(this.technoPalmLabelExtended_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.White;
            this.bottomPanel.Controls.Add(this.initializingLabelExtended);
            this.bottomPanel.Controls.Add(this.allPatientsPanel1);
            this.bottomPanel.Location = new System.Drawing.Point(0, 40);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1918, 1040);
            this.bottomPanel.TabIndex = 1;
            // 
            // lblVer
            // 
            this.lblVer.AutoSize = true;
            this.lblVer.Location = new System.Drawing.Point(1872, 8);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(35, 13);
            this.lblVer.TabIndex = 4;
            this.lblVer.Text = "label1";
            // 
            // initializingLabelExtended
            // 
            this.initializingLabelExtended.BackColor = System.Drawing.Color.Transparent;
            this.initializingLabelExtended.DisableTextColor = System.Drawing.Color.Black;
            this.initializingLabelExtended.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initializingLabelExtended.ForeColor = System.Drawing.Color.Black;
            this.initializingLabelExtended.Image = global::STSGui.Properties.Resources.init_process;
            this.initializingLabelExtended.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.initializingLabelExtended.Location = new System.Drawing.Point(871, 60);
            this.initializingLabelExtended.MouseDownTextColor = System.Drawing.Color.Empty;
            this.initializingLabelExtended.MouseOverTextColor = System.Drawing.Color.Empty;
            this.initializingLabelExtended.Name = "initializingLabelExtended";
            this.initializingLabelExtended.NormalTextColor = System.Drawing.Color.Black;
            this.initializingLabelExtended.Size = new System.Drawing.Size(177, 41);
            this.initializingLabelExtended.TabIndex = 3;
            this.initializingLabelExtended.Text = "Initializing";
            this.initializingLabelExtended.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // allPatientsPanel1
            // 
            this.allPatientsPanel1.BackColor = System.Drawing.Color.White;
            this.allPatientsPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.allPatientsPanel1.Location = new System.Drawing.Point(-3, -5);
            this.allPatientsPanel1.Name = "allPatientsPanel1";
            this.allPatientsPanel1.Size = new System.Drawing.Size(1918, 1040);
            this.allPatientsPanel1.TabIndex = 0;
            this.allPatientsPanel1.Visible = false;
            // 
            // backPanel
            // 
            this.backPanel.BackColor = System.Drawing.Color.Transparent;
            this.backPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backPanel.Controls.Add(this.topLeftButtonPictureBox);
            this.backPanel.Controls.Add(this.bottomPanel);
            this.backPanel.Controls.Add(this.topPanel);
            this.backPanel.Location = new System.Drawing.Point(0, 0);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(1920, 1080);
            this.backPanel.TabIndex = 2;
            // 
            // topLeftButtonPictureBox
            // 
            this.topLeftButtonPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.topLeftButtonPictureBox.DisableImage = global::STSGui.Properties.Resources.login_top_left_disable_;
            this.topLeftButtonPictureBox.DisableTextColor = System.Drawing.Color.Black;
            this.topLeftButtonPictureBox.Image = global::STSGui.Properties.Resources.login_top_left_normal;
            this.topLeftButtonPictureBox.IsTextColorMouseChanged = false;
            this.topLeftButtonPictureBox.Location = new System.Drawing.Point(0, -41);
            this.topLeftButtonPictureBox.MouseDownImage = global::STSGui.Properties.Resources.login_top_left_down;
            this.topLeftButtonPictureBox.MouseDownTextColor = System.Drawing.Color.Empty;
            this.topLeftButtonPictureBox.MouseOverImage = global::STSGui.Properties.Resources.login_top_left_over;
            this.topLeftButtonPictureBox.MouseOverTextColor = System.Drawing.Color.Empty;
            this.topLeftButtonPictureBox.Name = "topLeftButtonPictureBox";
            this.topLeftButtonPictureBox.NormalImage = global::STSGui.Properties.Resources.login_top_left_normal;
            this.topLeftButtonPictureBox.NormalTextColor = System.Drawing.Color.Black;
            this.topLeftButtonPictureBox.Size = new System.Drawing.Size(865, 200);
            this.topLeftButtonPictureBox.TabIndex = 4;
            this.topLeftButtonPictureBox.TabStop = false;
            this.topLeftButtonPictureBox.Text = "TechnoPulm";
            this.topLeftButtonPictureBox.TextColor = System.Drawing.Color.White;
            this.topLeftButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topLeftButtonPictureBox.Visible = false;
            this.topLeftButtonPictureBox.XTextOffset = -200;
            this.topLeftButtonPictureBox.YTextOffset = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.backPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuOpenClosePictureBox)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.backPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.topLeftButtonPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel backPanel;
        private AllPatientsPanel allPatientsPanel1;
        private LabelExtended technoPalmLabelExtended;
        private LabelExtended healthClinicLabelExtended;
        private LabelExtended initializingLabelExtended;
        private System.Windows.Forms.PictureBox mainMenuOpenClosePictureBox;
        private ButtonPictureBox topLeftButtonPictureBox;
        private LabelExtended currentDoctorLabelExtended;
        private System.Windows.Forms.Label lblVer;
    }
}

