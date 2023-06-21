
namespace STSGui.Controls.MainPanel
{
    partial class MainPanel
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
            this.recentlyVisitedPanel1 = new STSGui.RecentlyVisitedPanel();
            this.welcomePanel = new System.Windows.Forms.Panel();
            this.allYouDayLabel = new System.Windows.Forms.Label();
            this.breatheAndFlowLabel = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.buttonPictureBox1 = new STSGui.ButtonPictureBox();
            this.viewerPictureBox = new STSGui.RoundedCornersPictureBoxForVideoStream();
            this.monthlyTestsPanel = new System.Windows.Forms.Panel();
            this.circlePictureBox = new STSGui.ButtonPictureBox();
            this.monthlyTestsLabel = new System.Windows.Forms.Label();
            this.dlcoLabelExtended = new STSGui.LabelExtended();
            this.gassFlowLabelExtended = new STSGui.LabelExtended();
            this.spirometriaLabelExtended = new STSGui.LabelExtended();
            this.welcomePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewerPictureBox)).BeginInit();
            this.monthlyTestsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // recentlyVisitedPanel1
            // 
            this.recentlyVisitedPanel1.BackColor = System.Drawing.Color.White;
            this.recentlyVisitedPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.recentlyVisitedPanel1.Location = new System.Drawing.Point(44, 496);
            this.recentlyVisitedPanel1.Name = "recentlyVisitedPanel1";
            this.recentlyVisitedPanel1.Size = new System.Drawing.Size(1777, 528);
            this.recentlyVisitedPanel1.TabIndex = 0;
            // 
            // welcomePanel
            // 
            this.welcomePanel.BackColor = System.Drawing.Color.Transparent;
            this.welcomePanel.Controls.Add(this.allYouDayLabel);
            this.welcomePanel.Controls.Add(this.breatheAndFlowLabel);
            this.welcomePanel.Controls.Add(this.welcomeLabel);
            this.welcomePanel.Location = new System.Drawing.Point(71, 213);
            this.welcomePanel.Name = "welcomePanel";
            this.welcomePanel.Size = new System.Drawing.Size(625, 328);
            this.welcomePanel.TabIndex = 2;
            // 
            // allYouDayLabel
            // 
            this.allYouDayLabel.AutoSize = true;
            this.allYouDayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allYouDayLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.allYouDayLabel.Location = new System.Drawing.Point(8, 250);
            this.allYouDayLabel.Name = "allYouDayLabel";
            this.allYouDayLabel.Size = new System.Drawing.Size(354, 63);
            this.allYouDayLabel.TabIndex = 6;
            this.allYouDayLabel.Text = "All You Day...";
            // 
            // breatheAndFlowLabel
            // 
            this.breatheAndFlowLabel.AutoSize = true;
            this.breatheAndFlowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breatheAndFlowLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.breatheAndFlowLabel.Location = new System.Drawing.Point(8, 128);
            this.breatheAndFlowLabel.Name = "breatheAndFlowLabel";
            this.breatheAndFlowLabel.Size = new System.Drawing.Size(395, 63);
            this.breatheAndFlowLabel.TabIndex = 5;
            this.breatheAndFlowLabel.Text = "Breathe & Flow";
            this.breatheAndFlowLabel.UseMnemonic = false;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.welcomeLabel.Location = new System.Drawing.Point(8, 6);
            this.welcomeLabel.MaximumSize = new System.Drawing.Size(610, 63);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(610, 63);
            this.welcomeLabel.TabIndex = 4;
            this.welcomeLabel.Text = "Welcome Adam!";
            // 
            // buttonPictureBox1
            // 
            this.buttonPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.buttonPictureBox1.DisableImage = global::STSGui.Properties.Resources.main_panel_btn_play_start_disable;
            this.buttonPictureBox1.DisableTextColor = System.Drawing.Color.Black;
            this.buttonPictureBox1.Image = global::STSGui.Properties.Resources.main_panel_btn_play_start_normal;
            this.buttonPictureBox1.IsTextColorMouseChanged = false;
            this.buttonPictureBox1.Location = new System.Drawing.Point(1463, 302);
            this.buttonPictureBox1.MouseDownImage = global::STSGui.Properties.Resources.main_panel_btn_play_start_down;
            this.buttonPictureBox1.MouseDownTextColor = System.Drawing.Color.Empty;
            this.buttonPictureBox1.MouseOverImage = global::STSGui.Properties.Resources.main_panel_btn_play_start_over;
            this.buttonPictureBox1.MouseOverTextColor = System.Drawing.Color.Empty;
            this.buttonPictureBox1.Name = "buttonPictureBox1";
            this.buttonPictureBox1.NormalImage = global::STSGui.Properties.Resources.main_panel_btn_play_start_normal;
            this.buttonPictureBox1.NormalTextColor = System.Drawing.Color.Black;
            this.buttonPictureBox1.Size = new System.Drawing.Size(127, 125);
            this.buttonPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonPictureBox1.TabIndex = 1;
            this.buttonPictureBox1.TabStop = false;
            this.buttonPictureBox1.Text = null;
            this.buttonPictureBox1.TextColor = System.Drawing.Color.Black;
            this.buttonPictureBox1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPictureBox1.XTextOffset = 0;
            this.buttonPictureBox1.YTextOffset = 0;
            this.buttonPictureBox1.Click += new System.EventHandler(this.buttonPictureBox1_Click);
            // 
            // viewerPictureBox
            // 
            this.viewerPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.viewerPictureBox.Image = global::STSGui.Properties.Resources.main_panel_viewer_background_img;
            this.viewerPictureBox.IsOverrideCreateParams = false;
            this.viewerPictureBox.Location = new System.Drawing.Point(1273, 188);
            this.viewerPictureBox.Name = "viewerPictureBox";
            this.viewerPictureBox.Radius = 50;
            this.viewerPictureBox.Size = new System.Drawing.Size(507, 353);
            this.viewerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.viewerPictureBox.TabIndex = 0;
            this.viewerPictureBox.TabStop = false;
            this.viewerPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.viewerPictureBox_Paint);
            // 
            // monthlyTestsPanel
            // 
            this.monthlyTestsPanel.BackgroundImage = global::STSGui.Properties.Resources.main_panel_monthly_tests_background_img;
            this.monthlyTestsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.monthlyTestsPanel.Controls.Add(this.circlePictureBox);
            this.monthlyTestsPanel.Controls.Add(this.monthlyTestsLabel);
            this.monthlyTestsPanel.Controls.Add(this.dlcoLabelExtended);
            this.monthlyTestsPanel.Controls.Add(this.gassFlowLabelExtended);
            this.monthlyTestsPanel.Controls.Add(this.spirometriaLabelExtended);
            this.monthlyTestsPanel.Location = new System.Drawing.Point(703, 178);
            this.monthlyTestsPanel.Name = "monthlyTestsPanel";
            this.monthlyTestsPanel.Size = new System.Drawing.Size(550, 373);
            this.monthlyTestsPanel.TabIndex = 1;
            // 
            // circlePictureBox
            // 
            this.circlePictureBox.DisableImage = null;
            this.circlePictureBox.DisableTextColor = System.Drawing.Color.Black;
            this.circlePictureBox.IsTextColorMouseChanged = false;
            this.circlePictureBox.Location = new System.Drawing.Point(56, 97);
            this.circlePictureBox.MouseDownImage = null;
            this.circlePictureBox.MouseDownTextColor = System.Drawing.Color.Empty;
            this.circlePictureBox.MouseOverImage = null;
            this.circlePictureBox.MouseOverTextColor = System.Drawing.Color.Empty;
            this.circlePictureBox.Name = "circlePictureBox";
            this.circlePictureBox.NormalImage = null;
            this.circlePictureBox.NormalTextColor = System.Drawing.Color.Black;
            this.circlePictureBox.Size = new System.Drawing.Size(295, 258);
            this.circlePictureBox.TabIndex = 4;
            this.circlePictureBox.TabStop = false;
            this.circlePictureBox.Text = null;
            this.circlePictureBox.TextColor = System.Drawing.Color.Black;
            this.circlePictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circlePictureBox.XTextOffset = 0;
            this.circlePictureBox.YTextOffset = 0;
            // 
            // monthlyTestsLabel
            // 
            this.monthlyTestsLabel.AutoSize = true;
            this.monthlyTestsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthlyTestsLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.monthlyTestsLabel.Location = new System.Drawing.Point(51, 46);
            this.monthlyTestsLabel.Name = "monthlyTestsLabel";
            this.monthlyTestsLabel.Size = new System.Drawing.Size(160, 25);
            this.monthlyTestsLabel.TabIndex = 3;
            this.monthlyTestsLabel.Text = "Monthly Tests";
            // 
            // dlcoLabelExtended
            // 
            this.dlcoLabelExtended.DisableTextColor = System.Drawing.Color.Black;
            this.dlcoLabelExtended.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dlcoLabelExtended.ForeColor = System.Drawing.Color.RoyalBlue;
            this.dlcoLabelExtended.Image = global::STSGui.Properties.Resources.main_panel_ellipse_yellow;
            this.dlcoLabelExtended.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dlcoLabelExtended.Location = new System.Drawing.Point(368, 241);
            this.dlcoLabelExtended.MouseDownTextColor = System.Drawing.Color.Empty;
            this.dlcoLabelExtended.MouseOverTextColor = System.Drawing.Color.Empty;
            this.dlcoLabelExtended.Name = "dlcoLabelExtended";
            this.dlcoLabelExtended.NormalTextColor = System.Drawing.Color.RoyalBlue;
            this.dlcoLabelExtended.Size = new System.Drawing.Size(108, 24);
            this.dlcoLabelExtended.TabIndex = 2;
            this.dlcoLabelExtended.Text = "DLCO";
            this.dlcoLabelExtended.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gassFlowLabelExtended
            // 
            this.gassFlowLabelExtended.DisableTextColor = System.Drawing.Color.Black;
            this.gassFlowLabelExtended.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gassFlowLabelExtended.ForeColor = System.Drawing.Color.RoyalBlue;
            this.gassFlowLabelExtended.Image = global::STSGui.Properties.Resources.main_panel_ellipse_pink;
            this.gassFlowLabelExtended.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gassFlowLabelExtended.Location = new System.Drawing.Point(368, 185);
            this.gassFlowLabelExtended.MouseDownTextColor = System.Drawing.Color.Empty;
            this.gassFlowLabelExtended.MouseOverTextColor = System.Drawing.Color.Empty;
            this.gassFlowLabelExtended.Name = "gassFlowLabelExtended";
            this.gassFlowLabelExtended.NormalTextColor = System.Drawing.Color.RoyalBlue;
            this.gassFlowLabelExtended.Size = new System.Drawing.Size(140, 24);
            this.gassFlowLabelExtended.TabIndex = 1;
            this.gassFlowLabelExtended.Text = "Gass Flow";
            this.gassFlowLabelExtended.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spirometriaLabelExtended
            // 
            this.spirometriaLabelExtended.DisableTextColor = System.Drawing.Color.Black;
            this.spirometriaLabelExtended.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spirometriaLabelExtended.ForeColor = System.Drawing.Color.RoyalBlue;
            this.spirometriaLabelExtended.Image = global::STSGui.Properties.Resources.main_panel_ellipse_blue;
            this.spirometriaLabelExtended.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.spirometriaLabelExtended.Location = new System.Drawing.Point(368, 129);
            this.spirometriaLabelExtended.MouseDownTextColor = System.Drawing.Color.Empty;
            this.spirometriaLabelExtended.MouseOverTextColor = System.Drawing.Color.Empty;
            this.spirometriaLabelExtended.Name = "spirometriaLabelExtended";
            this.spirometriaLabelExtended.NormalTextColor = System.Drawing.Color.RoyalBlue;
            this.spirometriaLabelExtended.Size = new System.Drawing.Size(139, 24);
            this.spirometriaLabelExtended.TabIndex = 0;
            this.spirometriaLabelExtended.Text = "Spirometria";
            this.spirometriaLabelExtended.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::STSGui.Properties.Resources.main_panel_background_img;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.buttonPictureBox1);
            this.Controls.Add(this.viewerPictureBox);
            this.Controls.Add(this.welcomePanel);
            this.Controls.Add(this.monthlyTestsPanel);
            this.Controls.Add(this.recentlyVisitedPanel1);
            this.DoubleBuffered = true;
            this.Name = "MainPanel";
            this.Size = new System.Drawing.Size(1918, 1040);
            this.Load += new System.EventHandler(this.MainPanel_Load);
            this.welcomePanel.ResumeLayout(false);
            this.welcomePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewerPictureBox)).EndInit();
            this.monthlyTestsPanel.ResumeLayout(false);
            this.monthlyTestsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RecentlyVisitedPanel recentlyVisitedPanel1;
        private System.Windows.Forms.Panel monthlyTestsPanel;
        private LabelExtended spirometriaLabelExtended;
        private System.Windows.Forms.Panel welcomePanel;
        private LabelExtended dlcoLabelExtended;
        private LabelExtended gassFlowLabelExtended;
        private ButtonPictureBox circlePictureBox;
        private System.Windows.Forms.Label monthlyTestsLabel;
        private System.Windows.Forms.Label allYouDayLabel;
        private System.Windows.Forms.Label breatheAndFlowLabel;
        private System.Windows.Forms.Label welcomeLabel;
        private RoundedCornersPictureBoxForVideoStream viewerPictureBox;
        private ButtonPictureBox buttonPictureBox1;
    }
}
