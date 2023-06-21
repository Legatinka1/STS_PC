using CommonLib;
using ImplementationLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelkinEagleGui.Forms
{
    public partial class PressureForm : Form
    {
        PatientVisit currentVisit = null;
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        int Radius = 50;

        public PressureForm(PatientVisit visit)
        {
            currentVisit = visit;
            LoadForm();
        }

        private void LoadForm()
        {
            InitializeComponent();
            
            //this.FormBorderStyle = FormBorderStyle.None;
            //Opacity = 0.39;
            //StartPosition = FormStartPosition.CenterParent;

        }

        private void PressureForm_Load(object sender, EventArgs e)
        {
            Form activForm = Form.ActiveForm;
            if (activForm == null)
                activForm = Owner;
            int newX = activForm.Location.X + (activForm.Width - this.Width) / 2;
            int newY = activForm.Location.Y + (activForm.Height - this.Height) / 2;
            this.Location = new Point(newX, newY);

            //BackColor = Color.Transparent;
            pressureControl1.Location = new Point(0, 0);
            //aboutControl1.BorderStyle = BorderStyle.Fixed3D;

            Size = new Size(pressureControl1.Width, pressureControl1.Height);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, Radius, Radius));
            //(new Core.DropShadow()).ApplyShadows(this);

            CenterToParent();

            //this.BackgroundImage = Utils.CreateDisableImg(this);
            pressureControl1.ClosePressureControl += PressureControl1_ClosePressureControl;
            pressureControl1.SetCurrentTestResult(currentVisit);

        }

        private void PressureControl1_ClosePressureControl()
        {
            this.Close();
        }



    }
}
