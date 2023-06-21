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

namespace STSGui.Forms
{
    public partial class MainMenuForm : Form
    {
        #region Private Members

        Color disableTextColor;
        Color mouseDownTextColor;
        Color mouseOverTextColor;
        Color normalTextColor;

        #endregion

        #region Constructor / Control_Load

        public MainMenuForm()
        {
            InitializeComponent();
        }
        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            this.Location = NeedLocation;
            InitColor();
        }

        #endregion

        #region Public Properties

        public MainMenuSelectedItem SelectedItem
        {
            get
            {
                return currentSelectedItem;
            }
        }
        MainMenuSelectedItem currentSelectedItem = MainMenuSelectedItem.Unselected;

        public static Point NeedLocation
        {
            set
            {
                needLocation = value;
            }
            private get
            {
                return needLocation;
            }
        }
        private static Point needLocation = new Point(0, 0);

        #endregion

        #region Get Manager

        private ISTSManager Manager
        {
            get => STSManager.GetManager;
        }

        #endregion

        #region Private Functions

        #region Selected item click Functions
        private void closeLabelExtended_Click(object sender, EventArgs e)
        {
            currentSelectedItem = MainMenuSelectedItem.Close;
            this.Visible = false;
        }

        private void minimizeLabelExtended_Click(object sender, EventArgs e)
        {
            currentSelectedItem = MainMenuSelectedItem.Minimize;
            this.Visible = false;
        }

        private void calibrationTestLabelExtended_Click(object sender, EventArgs e)
        {
            currentSelectedItem = MainMenuSelectedItem.CalibrationTest;
            this.Visible = false;

        }
        private void logOutLabelExtended_Click(object sender, EventArgs e)
        {
            currentSelectedItem = MainMenuSelectedItem.LogOut;
            this.Visible = false;
        }
        private void editDoctorLabelExtended_Click(object sender, EventArgs e)
        {
            currentSelectedItem = MainMenuSelectedItem.EditDoctor;
            this.Visible = false;
        }

        private void addDoctorLabelExtended_Click(object sender, EventArgs e)
        {
            currentSelectedItem = MainMenuSelectedItem.AddDoctor;
            this.Visible = false;
        }

        private void settingsLabelExtended_Click(object sender, EventArgs e)
        {
            currentSelectedItem = MainMenuSelectedItem.Settings;
            this.Visible = false;
        }
        #endregion

        private void MainMenuForm_Deactivate(object sender, EventArgs e)
        {
            this.Visible = false; ;
        }

        private void MainMenuForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                currentSelectedItem = MainMenuSelectedItem.Unselected;
                DoctorCard currentDoctorCard = Manager.CurrentDoctorCard;
                this.Location = NeedLocation;

                if (currentDoctorCard == null)
                {
                    addDoctorLabelExtended.Enabled = false;
                    editDoctorLabelExtended.Enabled = false;
                    settingsLabelExtended.Enabled = false;
                }
                else
                {
                    settingsLabelExtended.Enabled = true;
                    if (currentDoctorCard.DoctorLevel == Enum_Doctor_Level.Techniction)
                    {
                        addDoctorLabelExtended.Enabled = false;
                        editDoctorLabelExtended.Enabled = true;
                    }
                    else
                    {
                        addDoctorLabelExtended.Enabled = true;
                        editDoctorLabelExtended.Enabled = true;
                    }

                }
            }
        }

        private void InitColor()
        {
            disableTextColor = System.Drawing.Color.DarkGray;
            mouseDownTextColor = Color.FromArgb(58, 125, 219);
            mouseOverTextColor = Color.FromArgb(58, 125, 219);
            normalTextColor = Color.FromArgb(92, 105, 128);


            closeLabelExtended.DisableTextColor = disableTextColor;
            closeLabelExtended.MouseDownTextColor = mouseDownTextColor;
            closeLabelExtended.MouseOverTextColor = mouseOverTextColor;
            closeLabelExtended.NormalTextColor = normalTextColor;

            minimizeLabelExtended.DisableTextColor = disableTextColor;
            minimizeLabelExtended.MouseDownTextColor = mouseDownTextColor;
            minimizeLabelExtended.MouseOverTextColor = mouseOverTextColor;
            minimizeLabelExtended.NormalTextColor = normalTextColor;

            calibrationLabelExtended.DisableTextColor = disableTextColor;
            calibrationLabelExtended.MouseDownTextColor = mouseDownTextColor;
            calibrationLabelExtended.MouseOverTextColor = mouseOverTextColor;
            calibrationLabelExtended.NormalTextColor = normalTextColor;

            logOutLabelExtended.DisableTextColor = disableTextColor;
            logOutLabelExtended.MouseDownTextColor = mouseDownTextColor;
            logOutLabelExtended.MouseOverTextColor = mouseOverTextColor;
            logOutLabelExtended.NormalTextColor = normalTextColor;

            editDoctorLabelExtended.DisableTextColor = disableTextColor;
            editDoctorLabelExtended.MouseDownTextColor = mouseDownTextColor;
            editDoctorLabelExtended.MouseOverTextColor = mouseOverTextColor;
            editDoctorLabelExtended.NormalTextColor = normalTextColor;


            addDoctorLabelExtended.DisableTextColor = disableTextColor;
            addDoctorLabelExtended.MouseDownTextColor = mouseDownTextColor;
            addDoctorLabelExtended.MouseOverTextColor = mouseOverTextColor;
            addDoctorLabelExtended.NormalTextColor = normalTextColor;

            settingsLabelExtended.DisableTextColor = disableTextColor;
            settingsLabelExtended.MouseDownTextColor = mouseDownTextColor;
            settingsLabelExtended.MouseOverTextColor = mouseOverTextColor;
            settingsLabelExtended.NormalTextColor = normalTextColor;


        }

        #region MouseEnter / MouseLeave Functions

        private void calibrationLabelExtended_MouseEnter(object sender, EventArgs e)
        {
            calibrationLabelExtended.Image = Properties.Resources.main_menu_calibration_over;
        }

        private void calibrationLabelExtended_MouseLeave(object sender, EventArgs e)
        {
            calibrationLabelExtended.Image = Properties.Resources.main_menu_calibration_normal;
        }

        private void logOutLabelExtended_MouseEnter(object sender, EventArgs e)
        {
            logOutLabelExtended.Image = Properties.Resources.main_menu_logout_over;
        }

        private void logOutLabelExtended_MouseLeave(object sender, EventArgs e)
        {
            logOutLabelExtended.Image = Properties.Resources.main_menu_logout_normal;
        }

        private void settingsLabelExtended_MouseEnter(object sender, EventArgs e)
        {
            settingsLabelExtended.Image = Properties.Resources.main_menu_settings_over;
        }

        private void settingsLabelExtended_MouseLeave(object sender, EventArgs e)
        {
            settingsLabelExtended.Image = Properties.Resources.main_menu_settings_normal;
        }

        #endregion

        #endregion
    }

    public enum MainMenuSelectedItem
    {
        Unselected,
        Close,
        Minimize,
        CalibrationTest,
        LogOut,
        EditDoctor,
        AddDoctor,
        Settings
    }
}
