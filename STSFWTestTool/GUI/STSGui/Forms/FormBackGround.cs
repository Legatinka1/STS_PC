using CommonLib;
using ImplementationLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelkinEagleGui.Forms
{
    public partial class FormBackGround : Form
    {
        public enum FormType
        {
            Pressure
        }

        PatientVisit currentVisit = null;
        DoctorCard currentDoctorCard = null;
        FormType formType = FormType.Pressure;
        PressureForm pressureForm;

        //public FormBackGround()
        //{
        //    LoadForm();
        //}

        private void LoadForm()
        {
            InitializeComponent();
            
            this.FormBorderStyle = FormBorderStyle.None;
            Opacity = 0.39;
            StartPosition = FormStartPosition.CenterParent;

        }

        public FormBackGround(FormType _formType, PatientVisit visit)
        {
            formType = _formType;
            currentVisit = visit;
            currentDoctorCard = null;
            LoadForm();


        }

        private void FormBackGround_Closed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void FormBackGround_Load(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                if (formType == FormType.Pressure)
                {

                    pressureForm = new PressureForm(currentVisit);
                    pressureForm.FormClosed += PressureForm_Closed;
                    pressureForm.StartPosition = FormStartPosition.Manual;
                    pressureForm.DesktopLocation = new Point(Location.X + Size.Width / 4, Location.Y + Size.Height / 4);
                    pressureForm.Owner = this;
                    pressureForm.ShowInTaskbar = false;
                    pressureForm.ShowDialog();
                }
            });
        }
        private void UcSettingsMenu1_OnClose()
        {
            Close();
        }

        private void PressureForm_Closed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
        private void AddEditDoctorForm_Closed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

    }
}
