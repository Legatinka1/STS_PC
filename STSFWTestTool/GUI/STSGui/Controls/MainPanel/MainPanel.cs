using CommonLib;
using ImplementationLib;
using InterfacesLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STSGui.Controls.MainPanel
{
    public partial class MainPanel : UserControl
    {
        #region Private Members

        Size circleNormalSize = new Size(200,200);
        Size circleOverSize = new Size(260, 260);

        Pen spirometriaPen = new Pen(Color.FromArgb(33,151,235), 14);
        Pen gassFlowPen = new Pen(Color.FromArgb(240, 115, 145), 14);
        Pen dlcoPen = new Pen(Color.FromArgb(236, 186, 68), 14);

        SolidBrush textSolidBrush = new SolidBrush(Color.FromArgb(62, 124, 195));


        Bitmap viewBitmap = null;
        object lockObject = new object();

        #endregion

        #region Constructor / Control_Load

        public MainPanel()
        {
            InitializeComponent();
        }

        private void MainPanel_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            SubscrubeForControlsEvents();
            SubscrubeForManagerEvents();
            
            InitColor();
            InitBitmapControls();
            viewBitmap = (Bitmap)viewerPictureBox.Image;
            viewerPictureBox.Invalidate();
        }


        #endregion

        #region Events

        public event Action<Patient> OpenPatientDetails;
        public event Action AddNewPatient;
        public event Action ToPatientList;

        #endregion

        #region Get Manager

        private ISTSManager Manager
        {
            get => STSManager.GetManager;
        }

        #endregion

        #region Public Functions

        public void ResetControls()
        {
            InitMonthlyTestsPanel();
            InitWelcomePanel();
            recentlyVisitedPanel1.InitAllPatients();
        }

        private void InitWelcomePanel()
        {
            DoctorCard doctorCard = Manager.CurrentDoctorCard;
            string fullName = "";
            if (doctorCard != null)
                fullName = doctorCard.FullName;

            welcomeLabel.Text = $"Welcome {fullName}!";


        }

        private void InitMonthlyTestsPanel()
        {
            MonthlyTest monthlyTests = Manager.MonthlyTests;
            if (monthlyTests == null)
                return;

            int spirometriaGradus = (int)((float)360 * monthlyTests.Spirometria / monthlyTests.GetSum());
            int gassFlowGradus = (int)((float)360 * monthlyTests.GassFlow / monthlyTests.GetSum());
            int dlcoGradus = 360 - spirometriaGradus - gassFlowGradus;
            int startPoint = 270;
            Bitmap normalBitmap = new Bitmap(circleNormalSize.Width, circleNormalSize.Height);
            RectangleF normalBitmapDrowRect = new RectangleF(0, 0, circleNormalSize.Width, circleNormalSize.Height);
            normalBitmapDrowRect.Inflate(-14, -14);

            using (Graphics g = Graphics.FromImage(normalBitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                #region Draw Ring

                g.DrawArc(spirometriaPen, normalBitmapDrowRect, startPoint, spirometriaGradus);
                startPoint = (startPoint + spirometriaGradus) % 360;
                g.DrawArc(gassFlowPen, normalBitmapDrowRect, startPoint, gassFlowGradus);
                startPoint = (startPoint + gassFlowGradus) % 360;
                g.DrawArc(dlcoPen, normalBitmapDrowRect, startPoint, dlcoGradus);

                #endregion

                #region Draw Text


                using (Font font = new Font("Microsoft Sans Serif", 30, FontStyle.Regular, GraphicsUnit.Pixel))
                {
                    string text = $"{monthlyTests.GetSum()}";
                    SizeF stringSize = g.MeasureString(text, font);
                    float xCoord = normalBitmapDrowRect.X + (normalBitmapDrowRect.Width - stringSize.Width) / 2;
                    float yCoord = normalBitmapDrowRect.Y + (normalBitmapDrowRect.Height - stringSize.Height) / 2;
                    g.DrawString(text, font, textSolidBrush, xCoord, yCoord);
                }




                #endregion
                circlePictureBox.NormalImage = normalBitmap;

            }

            Bitmap overBitmap = new Bitmap(circleOverSize.Width, circleOverSize.Height);
            RectangleF overBitmapDrowRect = new RectangleF(0, 0, circleOverSize.Width, circleOverSize.Height);
            overBitmapDrowRect.Inflate(-14, -14);
            startPoint = 300;

            using (Graphics g = Graphics.FromImage(overBitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                #region Draw Ring

                g.DrawArc(spirometriaPen, overBitmapDrowRect, startPoint, spirometriaGradus);
                startPoint = (startPoint + spirometriaGradus) % 360;
                g.DrawArc(gassFlowPen, overBitmapDrowRect, startPoint, gassFlowGradus);
                startPoint = (startPoint + gassFlowGradus) % 360;
                g.DrawArc(dlcoPen, overBitmapDrowRect, startPoint, dlcoGradus);

                #endregion

                #region Draw Text


                using (Font font = new Font("Microsoft Sans Serif", 30, FontStyle.Regular, GraphicsUnit.Pixel))
                {
                    string text = $"{monthlyTests.GetSum()}";
                    SizeF stringSize = g.MeasureString(text, font);
                    float xCoord = overBitmapDrowRect.X + (overBitmapDrowRect.Width - stringSize.Width) / 2;
                    float yCoord = overBitmapDrowRect.Y + (overBitmapDrowRect.Height - stringSize.Height) / 2;
                    g.DrawString(text, font, textSolidBrush, xCoord, yCoord);
                }




                #endregion

                circlePictureBox.MouseOverImage = overBitmap;

            }


        }

        #endregion

        #region Private Functions

        private void SubscrubeForControlsEvents()
        {
            recentlyVisitedPanel1.OpenPatientDetails += RecentlyVisitedPanel1_OpenPatientDetails;
            recentlyVisitedPanel1.AddNewPatient += RecentlyVisitedPanel1_AddNewPatient;
            recentlyVisitedPanel1.ToPatientList += RecentlyVisitedPanel1_ToPatientList;
        }

        private void SubscrubeForManagerEvents()
        {
            Manager.VideoStart += Manager_VideoStart;
            Manager.VideoEnd += Manager_VideoEnd;
            Manager.NewVideoFrame += Manager_NewVideoFrame;
        }

        private void Manager_VideoEnd(bool obj)
        {
        }

        private void Manager_VideoStart(bool obj)
        {
        }

        private void Manager_NewVideoFrame(Bitmap image)
        {
            this.BeginInvoke((Action)(() =>
            {

                if (image == null)
                    return;

                lock (lockObject)
                {
                    viewBitmap = (Bitmap)image.Clone();
                }
                viewerPictureBox.Invalidate();
            }));
        }

        private void RecentlyVisitedPanel1_ToPatientList()
        {
            ToPatientList?.Invoke();
        }

        private void RecentlyVisitedPanel1_AddNewPatient()
        {
            AddNewPatient?.Invoke();
        }

        private void RecentlyVisitedPanel1_OpenPatientDetails(Patient patient)
        {
            OpenPatientDetails?.Invoke(patient);
        }

        private void InitColor()
        {
            Color textcolor = Color.FromArgb(48, 133, 250);

            welcomeLabel.ForeColor = textcolor;
            breatheAndFlowLabel.ForeColor = textcolor;

            allYouDayLabel.ForeColor = textcolor;

            textcolor = Color.FromArgb(88, 116, 169);

            spirometriaLabelExtended.NormalTextColor = textcolor;
            gassFlowLabelExtended.NormalTextColor = textcolor;
            dlcoLabelExtended.NormalTextColor = textcolor;

            textcolor = Color.FromArgb(62, 124, 195);
            monthlyTestsLabel.ForeColor = textcolor;

        }


        private void viewerPictureBox_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (viewBitmap != null)
                {
                    lock (lockObject)
                    {
                        e.Graphics.DrawImage(viewBitmap, 0, 0, viewerPictureBox.Width, viewerPictureBox.Height);
                    }

                }
                else
                    e.Graphics.Clear(Color.White);
                ////               e.Graphics.Clear(Color.Red);

                //e.Graphics.DrawImage(bottomViewerImg, bottomViewerImg_X, bottomViewerImg_Y);

            }
            catch (Exception ex)
            {

            }

        }

        private void InitBitmapControls()
        {
            GuiUtils.SetNewLocation(buttonPictureBox1, viewerPictureBox);

            this.Controls.Remove(buttonPictureBox1);


            viewerPictureBox.Controls.Add(buttonPictureBox1);
        }

        private void buttonPictureBox1_Click(object sender, EventArgs e)
        {
            Manager.StartVideo();
        }

        #endregion
    }
}
