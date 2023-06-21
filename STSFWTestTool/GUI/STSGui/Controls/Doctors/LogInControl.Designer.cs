
namespace STSGui.Controls.Doctors
{
    partial class LogInControl
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
            this.centerPanel = new System.Windows.Forms.Panel();
            this.userName_Name_Label = new System.Windows.Forms.Label();
            this.userName_Value_Panel = new System.Windows.Forms.Panel();
            this.userName_Value_ComboBoxClean = new STSGui.ComboBoxClean();
            this.password_Name_Label = new System.Windows.Forms.Label();
            this.loginButtonPictureBox = new STSGui.ButtonPictureBox();
            this.password_Value_Panel = new System.Windows.Forms.Panel();
            this.password_Value_TextBox = new System.Windows.Forms.TextBox();
            this.pleaseLoginLabel = new System.Windows.Forms.Label();
            this.bottomRightButtonPictureBox = new STSGui.ButtonPictureBox();
            this.centerPanel.SuspendLayout();
            this.userName_Value_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loginButtonPictureBox)).BeginInit();
            this.password_Value_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bottomRightButtonPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // centerPanel
            // 
            this.centerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.centerPanel.Controls.Add(this.userName_Name_Label);
            this.centerPanel.Controls.Add(this.userName_Value_Panel);
            this.centerPanel.Controls.Add(this.password_Name_Label);
            this.centerPanel.Controls.Add(this.loginButtonPictureBox);
            this.centerPanel.Controls.Add(this.password_Value_Panel);
            this.centerPanel.Location = new System.Drawing.Point(722, 324);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Size = new System.Drawing.Size(475, 392);
            this.centerPanel.TabIndex = 120;
            // 
            // userName_Name_Label
            // 
            this.userName_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.userName_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.userName_Name_Label.ForeColor = System.Drawing.Color.Gray;
            this.userName_Name_Label.Location = new System.Drawing.Point(25, 57);
            this.userName_Name_Label.Name = "userName_Name_Label";
            this.userName_Name_Label.Size = new System.Drawing.Size(424, 24);
            this.userName_Name_Label.TabIndex = 112;
            this.userName_Name_Label.Text = "User Name";
            this.userName_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userName_Value_Panel
            // 
            this.userName_Value_Panel.BackColor = System.Drawing.Color.White;
            this.userName_Value_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userName_Value_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userName_Value_Panel.Controls.Add(this.userName_Value_ComboBoxClean);
            this.userName_Value_Panel.Location = new System.Drawing.Point(25, 93);
            this.userName_Value_Panel.Name = "userName_Value_Panel";
            this.userName_Value_Panel.Size = new System.Drawing.Size(424, 36);
            this.userName_Value_Panel.TabIndex = 119;
            // 
            // userName_Value_ComboBoxClean
            // 
            this.userName_Value_ComboBoxClean.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.userName_Value_ComboBoxClean.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userName_Value_ComboBoxClean.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.userName_Value_ComboBoxClean.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName_Value_ComboBoxClean.ForeColor = System.Drawing.Color.MidnightBlue;
            this.userName_Value_ComboBoxClean.FormattingEnabled = true;
            this.userName_Value_ComboBoxClean.Location = new System.Drawing.Point(-1, -1);
            this.userName_Value_ComboBoxClean.Name = "userName_Value_ComboBoxClean";
            this.userName_Value_ComboBoxClean.Size = new System.Drawing.Size(424, 36);
            this.userName_Value_ComboBoxClean.TabIndex = 115;
            this.userName_Value_ComboBoxClean.SelectedIndexChanged += new System.EventHandler(this.userName_Value_ComboBoxClean_SelectedIndexChanged);
            // 
            // password_Name_Label
            // 
            this.password_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.password_Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.password_Name_Label.ForeColor = System.Drawing.Color.Gray;
            this.password_Name_Label.Location = new System.Drawing.Point(25, 147);
            this.password_Name_Label.Name = "password_Name_Label";
            this.password_Name_Label.Size = new System.Drawing.Size(424, 24);
            this.password_Name_Label.TabIndex = 113;
            this.password_Name_Label.Text = "Password";
            this.password_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginButtonPictureBox
            // 
            this.loginButtonPictureBox.DisableImage = global::STSGui.Properties.Resources.login_connect_button_disable;
            this.loginButtonPictureBox.DisableTextColor = System.Drawing.Color.Black;
            this.loginButtonPictureBox.Image = global::STSGui.Properties.Resources.login_connect_button_normal;
            this.loginButtonPictureBox.IsTextColorMouseChanged = false;
            this.loginButtonPictureBox.Location = new System.Drawing.Point(25, 271);
            this.loginButtonPictureBox.MouseDownImage = global::STSGui.Properties.Resources.login_connect_button_down;
            this.loginButtonPictureBox.MouseDownTextColor = System.Drawing.Color.Empty;
            this.loginButtonPictureBox.MouseOverImage = global::STSGui.Properties.Resources.login_connect_button_over;
            this.loginButtonPictureBox.MouseOverTextColor = System.Drawing.Color.Empty;
            this.loginButtonPictureBox.Name = "loginButtonPictureBox";
            this.loginButtonPictureBox.NormalImage = global::STSGui.Properties.Resources.login_connect_button_normal;
            this.loginButtonPictureBox.NormalTextColor = System.Drawing.Color.Black;
            this.loginButtonPictureBox.Size = new System.Drawing.Size(424, 64);
            this.loginButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loginButtonPictureBox.TabIndex = 116;
            this.loginButtonPictureBox.TabStop = false;
            this.loginButtonPictureBox.Text = "Connect";
            this.loginButtonPictureBox.TextColor = System.Drawing.Color.White;
            this.loginButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButtonPictureBox.XTextOffset = 0;
            this.loginButtonPictureBox.YTextOffset = 0;
            this.loginButtonPictureBox.Click += new System.EventHandler(this.loginButtonPictureBox_Click);
            // 
            // password_Value_Panel
            // 
            this.password_Value_Panel.BackColor = System.Drawing.Color.White;
            this.password_Value_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.password_Value_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password_Value_Panel.Controls.Add(this.password_Value_TextBox);
            this.password_Value_Panel.Location = new System.Drawing.Point(25, 181);
            this.password_Value_Panel.Name = "password_Value_Panel";
            this.password_Value_Panel.Size = new System.Drawing.Size(424, 37);
            this.password_Value_Panel.TabIndex = 114;
            this.password_Value_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.password_Value_Panel_Paint);
            // 
            // password_Value_TextBox
            // 
            this.password_Value_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password_Value_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.password_Value_TextBox.ForeColor = System.Drawing.Color.MidnightBlue;
            this.password_Value_TextBox.Location = new System.Drawing.Point(3, 5);
            this.password_Value_TextBox.MaxLength = 20;
            this.password_Value_TextBox.Name = "password_Value_TextBox";
            this.password_Value_TextBox.Size = new System.Drawing.Size(416, 22);
            this.password_Value_TextBox.TabIndex = 1;
            this.password_Value_TextBox.TabStop = false;
            this.password_Value_TextBox.Enter += new System.EventHandler(this.password_Value_TextBox_Enter);
            // 
            // pleaseLoginLabel
            // 
            this.pleaseLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pleaseLoginLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.pleaseLoginLabel.Location = new System.Drawing.Point(722, 258);
            this.pleaseLoginLabel.Name = "pleaseLoginLabel";
            this.pleaseLoginLabel.Size = new System.Drawing.Size(475, 55);
            this.pleaseLoginLabel.TabIndex = 122;
            this.pleaseLoginLabel.Text = "Please login ...";
            this.pleaseLoginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bottomRightButtonPictureBox
            // 
            this.bottomRightButtonPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.bottomRightButtonPictureBox.DisableImage = null;
            this.bottomRightButtonPictureBox.DisableTextColor = System.Drawing.Color.Black;
            this.bottomRightButtonPictureBox.IsTextColorMouseChanged = false;
            this.bottomRightButtonPictureBox.Location = new System.Drawing.Point(941, 748);
            this.bottomRightButtonPictureBox.MouseDownImage = null;
            this.bottomRightButtonPictureBox.MouseDownTextColor = System.Drawing.Color.Empty;
            this.bottomRightButtonPictureBox.MouseOverImage = null;
            this.bottomRightButtonPictureBox.MouseOverTextColor = System.Drawing.Color.Empty;
            this.bottomRightButtonPictureBox.Name = "bottomRightButtonPictureBox";
            this.bottomRightButtonPictureBox.NormalImage = null;
            this.bottomRightButtonPictureBox.NormalTextColor = System.Drawing.Color.Black;
            this.bottomRightButtonPictureBox.Size = new System.Drawing.Size(979, 294);
            this.bottomRightButtonPictureBox.TabIndex = 121;
            this.bottomRightButtonPictureBox.TabStop = false;
            this.bottomRightButtonPictureBox.Text = null;
            this.bottomRightButtonPictureBox.TextColor = System.Drawing.Color.Black;
            this.bottomRightButtonPictureBox.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomRightButtonPictureBox.XTextOffset = 0;
            this.bottomRightButtonPictureBox.YTextOffset = 0;
            this.bottomRightButtonPictureBox.MouseEnter += new System.EventHandler(this.bottomRightButtonPictureBox_MouseEnter);
            this.bottomRightButtonPictureBox.MouseLeave += new System.EventHandler(this.bottomRightButtonPictureBox_MouseLeave);
            // 
            // LogInControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.pleaseLoginLabel);
            this.Controls.Add(this.centerPanel);
            this.Controls.Add(this.bottomRightButtonPictureBox);
            this.DoubleBuffered = true;
            this.Name = "LogInControl";
            this.Size = new System.Drawing.Size(1918, 1040);
            this.Load += new System.EventHandler(this.LogInControl_Load);
            this.centerPanel.ResumeLayout(false);
            this.userName_Value_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loginButtonPictureBox)).EndInit();
            this.password_Value_Panel.ResumeLayout(false);
            this.password_Value_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bottomRightButtonPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel password_Value_Panel;
        private System.Windows.Forms.TextBox password_Value_TextBox;
        private System.Windows.Forms.Label password_Name_Label;
        private System.Windows.Forms.Label userName_Name_Label;
        private ButtonPictureBox loginButtonPictureBox;
        private System.Windows.Forms.Panel userName_Value_Panel;
        private ComboBoxClean userName_Value_ComboBoxClean;
        private System.Windows.Forms.Panel centerPanel;
        private ButtonPictureBox bottomRightButtonPictureBox;
        private System.Windows.Forms.Label pleaseLoginLabel;
    }
}
