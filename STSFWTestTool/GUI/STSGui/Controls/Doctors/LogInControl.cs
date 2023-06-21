using CommonLib;
using ImplementationLib;
using InterfacesLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STSGui.Controls.Doctors
{
    public partial class LogInControl : UserControl
    {
        #region Private Members

        Pen redBorderPen = new Pen(Color.Red, 6); 
        bool isLoginValid = true;
        Point bottomRightStartLocation = new Point();
        Point bottomRightOverLocation = new Point();

        #endregion

        #region Constructor / Control_Load
        public LogInControl()
        {
            InitializeComponent();
        }

        private void LogInControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            bottomRightStartLocation = bottomRightButtonPictureBox.Location;
            bottomRightOverLocation = new Point(bottomRightStartLocation.X, bottomRightStartLocation.Y-60);
            pleaseLoginLabel.ForeColor = Color.FromArgb(95,161,250);
            PostLanguageChangedInit();
        }

        #endregion

        #region Public Functions

        public void ResetControls()
        {
            Manager.Logout();
            userName_Value_ComboBoxClean.Items.Clear();

            List<DoctorCard>  doctors = Manager.AllDoctorCard;
            if(doctors!=null && doctors.Count>0)
            {
                foreach (var item in doctors)
                {
                    userName_Value_ComboBoxClean.Items.Add(item.UserName);
                }
                userName_Value_ComboBoxClean.SelectedIndex = 0;
            }
            password_Value_TextBox.Text = "";
            isLoginValid = true;
            userName_Value_Panel.Invalidate();
            password_Value_Panel.Invalidate();
        }
        #endregion

        #region Get Manager

        private ISTSManager Manager
        {
            get => STSManager.GetManager;
        }

        #endregion

        #region Events

        public event Action LoginSuccess;

        #endregion

        #region Private Functions

        private void PostLanguageChangedInit()
        {
            InitColor();
        }

        private void InitColor()
        {
            Color textcolor = Color.FromArgb(62, 124, 195);
            textcolor = Color.FromArgb(149, 158, 172);

            userName_Name_Label.ForeColor = textcolor;
            userName_Value_ComboBoxClean.ForeColor = textcolor;

            password_Name_Label.ForeColor = textcolor;
            password_Value_TextBox.ForeColor = textcolor;
        }

        private void loginButtonPictureBox_Click(object sender, EventArgs e)
        {
            //Manager.Login("a", "a");
            //LoginSuccess?.Invoke();
            //return;
            isLoginValid = Manager.Login(userName_Value_ComboBoxClean.SelectedItem.ToString(), password_Value_TextBox.Text);
            if (isLoginValid)
                LoginSuccess?.Invoke();
            else
            {
                password_Value_TextBox.Text = "";
                userName_Value_Panel.Invalidate();
                password_Value_Panel.Invalidate();
            }
        }


        private void userName_Value_Panel_Paint(object sender, PaintEventArgs e)
        {
            if (isLoginValid)
                return;

            e.Graphics.DrawRectangle(redBorderPen, userName_Value_Panel.ClientRectangle);
        }

        private void password_Value_Panel_Paint(object sender, PaintEventArgs e)
        {
            if (isLoginValid)
                return;

            e.Graphics.DrawRectangle(redBorderPen, password_Value_Panel.ClientRectangle);

        }
        private void password_Value_TextBox_Enter(object sender, EventArgs e)
        {
            isLoginValid = true;
            password_Value_Panel.Invalidate();
        }


        private void userName_Value_ComboBoxClean_SelectedIndexChanged(object sender, EventArgs e)
        {
            password_Value_TextBox.Focus();
        }

        private void bottomRightButtonPictureBox_MouseEnter(object sender, EventArgs e)
        {
            //bottomRightButtonPictureBox.Location = bottomRightOverLocation;
        }

        private void bottomRightButtonPictureBox_MouseLeave(object sender, EventArgs e)
        {
            //bottomRightButtonPictureBox.Location = bottomRightStartLocation;
        }

        #endregion

    }
}
