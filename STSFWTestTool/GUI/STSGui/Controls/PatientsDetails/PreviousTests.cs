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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STSGui
{
    public partial class PreviousTests : UserControl
    {
        #region Private Members

        Patient currentPatient = null;
        List<PatientVisit> allVisits = new List<PatientVisit>();
        List<AllVisitsItem> allGridItems = new List<AllVisitsItem>();

        private Bitmap cloneBitmap;
        private Label lastSortClickLabel = null;
        private PictureBox lastSortClickPictureBox = null;
        private bool lastSortClickOrder = false;
        private bool isFirst = true;

        Font normalSortLabelFont = null;
        Font selectedSortLabelFont = null;

        int VERTICAL_ITEM_SHIFT = 2;

        private bool isInit = false;

        #endregion

        #region Constructor / Control_Load

        public PreviousTests()
        {
            InitializeComponent();
        }

        private void PreviousTests_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            isInit = false;

            cloneBitmap = new Bitmap(this.Width, this.Height);
            normalSortLabelFont = dateLabel.Font;
            selectedSortLabelFont = new Font(normalSortLabelFont, FontStyle.Bold);

            InitBitmapControls();
            InitColor();

            InitUnits();

            isInit = true;
        }

        #endregion

        #region Events

        public event Action<Patient, PatientVisit> ShowHistoryTest;

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
        }

        public void SetPatient(Patient patient)
        {
            currentPatient = patient;

            scrollPanel.Visible = false;
            InitAllVisits(true);
            SetPatientImpl();
            Thread.Sleep(100);
            scrollPanel.Visible = true;
        }

        public void InitAllVisits(bool fromParent)
        {
            InitAllVisitsImpl(true, fromParent);
            sortByDateOrderByDescending = false;
        }
        #endregion

        #region Private Functions

        private void InitUnits()
        {
            if (Manager.UnitSystem == Enum_Unit_System.Metric)
                tempertureUnitsLabel.Text = Utils.GetCelsiusUnitString();
            else if(Manager.UnitSystem == Enum_Unit_System.USA)
                tempertureUnitsLabel.Text = Utils.GetFahrenheitUnitString();
            else if (Manager.UnitSystem == Enum_Unit_System.Imperial)
                tempertureUnitsLabel.Text = Utils.GetCelsiusUnitString();
            else
                tempertureUnitsLabel.Text = "";
        }

        private void SetPatientImpl()
        {

        }
        private void InitBitmapControls()
        {
            GuiUtils.SetNewLocation(dateLabel, gridHeaderPictureBox);
            GuiUtils.SetNewLocation(doctorFirstLastNameLabel, gridHeaderPictureBox);
            GuiUtils.SetNewLocation(pulseLabel, gridHeaderPictureBox);
            GuiUtils.SetNewLocation(tempertureLabel, gridHeaderPictureBox);
            GuiUtils.SetNewLocation(tempertureUnitsLabel, gridHeaderPictureBox);
            
            GuiUtils.SetNewLocation(bloodPresureLabel, gridHeaderPictureBox);
            GuiUtils.SetNewLocation(testTypeLabel, gridHeaderPictureBox);

            GuiUtils.SetNewLocation(datePictureBox, gridHeaderPictureBox);
            GuiUtils.SetNewLocation(doctorFirstLastNamePictureBox, gridHeaderPictureBox);
            GuiUtils.SetNewLocation(testTypePictureBox, gridHeaderPictureBox);

            this.Controls.Remove(dateLabel);
            this.Controls.Remove(doctorFirstLastNameLabel);
            this.Controls.Remove(pulseLabel);
            this.Controls.Remove(tempertureLabel);
            this.Controls.Remove(tempertureUnitsLabel);
            
            this.Controls.Remove(bloodPresureLabel);
            this.Controls.Remove(testTypeLabel);

            this.Controls.Remove(datePictureBox);
            this.Controls.Remove(doctorFirstLastNamePictureBox);
            this.Controls.Remove(testTypePictureBox);

            gridHeaderPictureBox.Controls.Add(dateLabel);
            gridHeaderPictureBox.Controls.Add(doctorFirstLastNameLabel);
            gridHeaderPictureBox.Controls.Add(pulseLabel);
            gridHeaderPictureBox.Controls.Add(tempertureLabel);
            gridHeaderPictureBox.Controls.Add(tempertureUnitsLabel);
            
            gridHeaderPictureBox.Controls.Add(bloodPresureLabel);
            gridHeaderPictureBox.Controls.Add(testTypeLabel);

            gridHeaderPictureBox.Controls.Add(datePictureBox);
            gridHeaderPictureBox.Controls.Add(doctorFirstLastNamePictureBox);
            gridHeaderPictureBox.Controls.Add(testTypePictureBox);

        }
        private void InitColor()
        {

            this.BackColor = Color.FromArgb(247, 248, 252);


            Color textcolor = Color.FromArgb(110, 157, 209);

            previousTests_Name_Label.ForeColor = textcolor;

            textcolor = Color.FromArgb(149, 158, 172);

            dateLabel.ForeColor = textcolor;
            doctorFirstLastNameLabel.ForeColor = textcolor;
            pulseLabel.ForeColor = textcolor;
            tempertureLabel.ForeColor = textcolor;
            tempertureUnitsLabel.ForeColor = textcolor;

            bloodPresureLabel.ForeColor = textcolor;
            testTypeLabel.ForeColor = textcolor;

        }


        private void InitAllVisitsImpl(bool reload, bool fromParent)
        {
            if (isInit == false)
                return;

            if (reload)
            {
                allVisits.Clear();
                if(currentPatient!=null && currentPatient.Visited!=null)
                    allVisits.AddRange(currentPatient.Visited);
            }
            InitGrid();
            FillItems();
            InitScrollItems();
            SortByDate(true);
            SetSortLabelFont(dateLabel);
            SetSortPictureBoxImg(datePictureBox, sortByDateOrderByDescending);
        }

        void InitScrollItems()
        {
            int current_Y_Location = VERTICAL_ITEM_SHIFT;

            for (int ii = 0; ii < allGridItems.Count; ii++)
            {
                allGridItems[ii].Location = new Point(allGridItems[ii].Location.X, current_Y_Location);
                current_Y_Location = current_Y_Location + VERTICAL_ITEM_SHIFT + allGridItems[ii].Size.Height;
            }
            allGridItemsPanel.Height = current_Y_Location;
            allGridItemsPanel.Location = new Point(allGridItemsPanel.Location.X, 0);

            BuildScrollItems();
            //itemsScrollColorSlider.Visible = false;
        }

        void BuildScrollItems()
        {
            if (allGridItemsPanel.Height > scrollPanel.Height)
            {
                itemsScrollColorSlider.Maximum = allGridItemsPanel.Height - scrollPanel.Height;
                itemsScrollColorSlider.Value = itemsScrollColorSlider.Maximum;
                allGridItemsPanel.Location = new Point(allGridItemsPanel.Location.X, 0);
                itemsScrollColorSlider.Visible = true;

            }
            else
            {
                itemsScrollColorSlider.Visible = false;
                allGridItemsPanel.Location = new Point(allGridItemsPanel.Location.X, 0);
            }

        }


        private void FillItems()
        {
            for (int ii = 0; ii < allGridItems.Count; ii++)
            {
                if (allVisits != null && allGridItems.Count == allVisits.Count)
                {
                    allGridItems[ii].CurrentVisit = allVisits[ii];
                    allGridItems[ii].Visible = true;
                }
                else
                    allGridItems[ii].Visible = false;
            }
        }
        private void InitGrid()
        {
            if (allVisits == null)
                return;

            if (allVisits.Count == allGridItems.Count)
                return;
            allGridItems.Clear();
            SuspendLayout();
            allGridItemsPanel.Controls.Clear();

            int xLocation = 1;
            int yLocation = VERTICAL_ITEM_SHIFT;
            for (int ii = 0; ii < allVisits.Count; ii++)
            {
                AllVisitsItem newItem = new AllVisitsItem();

                newItem.BackColor = System.Drawing.Color.White;
                newItem.CurrentVisit = allVisits[ii];
                newItem.Name = $"allVisitsItem{ii}";

                newItem.Size = new Size(1090, 51);
                allGridItemsPanel.Controls.Add(newItem);
                newItem.Location = new Point(xLocation, yLocation);

                allGridItems.Add(newItem);
                yLocation = yLocation + VERTICAL_ITEM_SHIFT + 80;

            }

            allGridItemsPanel.Height = yLocation;

            this.ResumeLayout(false);
            this.PerformLayout();

            if (isFirst)
            {
                isFirst = false;

                AllVisitsItem.RightButtonClick += AllVisitsItem_RightButtonClick;
                AllVisitsItem.DeleteButtonClick += AllVisitsItem_DeleteButtonClick;
            }
        }

        private void AllVisitsItem_DeleteButtonClick(PatientVisit visit)
        {
            Manager.DeleteVisit(currentPatient, visit);

            allVisits.Remove(visit);

            InitGrid();
        }

        #region AllPatients Item Buttons_Click Functions

        private void AllVisitsItem_RightButtonClick(PatientVisit visit)
        {
            ShowHistoryTest?.Invoke(currentPatient, visit);
        }

        #endregion

        #region Header Buttons_Click Functions

        bool sortByDateOrderByDescending = false;
        private void dateLabel_Click(object sender, EventArgs e)
        {
            ButtonPictureBox.SoundPlay();
            InitAllVisitsImpl(true, false);
            SortByDate(sortByDateOrderByDescending);
            sortByDateOrderByDescending = !sortByDateOrderByDescending;
            SetSortLabelFont(dateLabel);
            SetSortPictureBoxImg(datePictureBox, sortByDateOrderByDescending);
        }

        bool sortByDoctorNameOrderByDescending = false;
        private void doctorFirstLastNameLabel_Click(object sender, EventArgs e)
        {
            ButtonPictureBox.SoundPlay();
            InitAllVisits(false);
            SortByDoctorName(sortByDoctorNameOrderByDescending);
            sortByDoctorNameOrderByDescending = !sortByDoctorNameOrderByDescending;
            SetSortLabelFont(doctorFirstLastNameLabel);
            SetSortPictureBoxImg(doctorFirstLastNamePictureBox, sortByDoctorNameOrderByDescending);
        }

        bool sortByTestTypeDescending = false;
        private void testTypeNameLabel_Click(object sender, EventArgs e)
        {
            ButtonPictureBox.SoundPlay();
            InitAllVisits(false);
            SortByTestType(sortByTestTypeDescending);
            sortByTestTypeDescending = !sortByTestTypeDescending;
            SetSortLabelFont(testTypeLabel);
            SetSortPictureBoxImg(testTypePictureBox, sortByTestTypeDescending);

        }

        #endregion

        #region Sorting Implementation Functions

        private void SortByDate(bool orderByDescending)
        {
            if (allVisits == null || allVisits.Count <= 1)
                return;

            if (orderByDescending)
                allVisits = allVisits.OrderByDescending(item => item.VisitDateTime).ToList();
            else
                allVisits = allVisits.OrderBy(item => item.VisitDateTime).ToList();


            PostSort();
        }

        private void SortByDoctorName(bool orderByDescending)
        {
            if (allVisits == null || allVisits.Count <= 1)
                return;

            if (orderByDescending)//Need impl.
                allVisits = allVisits.OrderByDescending(item => item.Doctor.FullName).ToList();
            else
                allVisits = allVisits.OrderBy(item => item.Doctor.FullName).ToList();

            PostSort();
        }


        private void SortByTestType(bool sortByModeDescending)
        {
            if (allVisits == null || allVisits.Count <= 1)
                return;

            if (sortByModeDescending)
                allVisits = allVisits.OrderByDescending(item => item.TestType).ToList();
            else
                allVisits = allVisits.OrderBy(item => item.TestType).ToList();

            PostSort();
        }

        private void PostSort()
        {
            if (allVisits == null)
                return;

            FillItems();
            InitScrollItems();
        }
        private void SetSortLabelFont(Label sortClickLabel)
        {
            if (lastSortClickLabel == sortClickLabel)
                return;

            if (lastSortClickLabel != null)
                lastSortClickLabel.Font = normalSortLabelFont;

            lastSortClickLabel = sortClickLabel;
            lastSortClickLabel.Font = selectedSortLabelFont;
        }
        private void SetSortPictureBoxImg(PictureBox sortClickPictureBox, bool order)
        {
            if (lastSortClickPictureBox == sortClickPictureBox && lastSortClickOrder == order)
                return;
            if (lastSortClickPictureBox != null)
                lastSortClickPictureBox.Image = Properties.Resources.patients_list_sort_unknown;
            lastSortClickPictureBox = sortClickPictureBox;
            lastSortClickOrder = order;

            if (lastSortClickOrder)
                lastSortClickPictureBox.Image = Properties.Resources.patients_list_sort_up_arrow;
            else
                lastSortClickPictureBox.Image = Properties.Resources.patients_list_sort_down_arrow;
        }

        #endregion


        private void itemsScrollColorSlider_ValueChanged(object sender, EventArgs e)
        {
            allGridItemsPanel.Location = new Point(allGridItemsPanel.Location.X, -(itemsScrollColorSlider.Maximum - itemsScrollColorSlider.Value));

        }




        #endregion
    }
}
