using CommonLib;
using ImplementationLib;
using InterfacesLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace STSGui
{

    public partial class AllPatientsPanel : UserControl
    {
        #region Private Members

 //       private PictureBox clonePictureBox1;
        private Bitmap cloneBitmap;

        List<Patient> allPatients = null;

        List<AllPatientsItem> allGridItems = new List<AllPatientsItem>();

        Color blackTextcolor;
        Color blueTextcolor;
        Color transparentBackcolor;

        int VERTICAL_ITEM_SHIFT = 2;

        private bool isInit = false;

        string searchText = "";

        private Label lastSortClickLabel = null;
        private PictureBox lastSortClickPictureBox = null;
        private bool lastSortClickOrder = false;

        Font normalSortLabelFont = null;
        Font selectedSortLabelFont = null;


        #endregion

        #region Constructor / Control_Load

        public AllPatientsPanel()
        {
            InitializeComponent();
        }

        private void AllPatientsPanel_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            //allGridItems.Clear();

            //PostLanguageChangedInit();

            //SubscrubeForManagerEvents();


        }

        #endregion

        #region Events

        public event Action<Patient> OpenPatientDetails;
        public event Action AddNewPatient;

        #endregion

        #region Public Functions

        public void EnableGrid(bool enable)
        {
            allGridItemsPanel.Enabled = enable;
            scrollPanel.Enabled = enable;
            //gridHeaderPictureBox.Enabled = enable;
            //searchPanel.Enabled = enable;
        }
        public void PrepareCloneBitmap()
        {
            //scrollPanel.DrawToBitmap(cloneBitmap,new Rectangle(0, 0, cloneBitmap.Width, cloneBitmap.Height));
            //clonePictureBox1.Image = cloneBitmap;
            this.DrawToBitmap(cloneBitmap, new Rectangle(0, 0, this.Width, this.Height));
            //clonePictureBox1.Image = cloneBitmap;
        }

        public void InitAllPatients(bool fromParent)
        {
            InitAllPatientsImpl(true, fromParent);
            sortByDateOrderByDescending = false;
        }
        public void PostLoad()
        {
            PostLanguageChangedInit();

            SubscrubeForManagerEvents();

        }
        public void UpdateNavigationButtons()
        {
            if (allPatients != null)
            {
                searchTextBox.Text = searchText;
                if (allPatients.Count > allGridItems.Count)
                {
                    //leftLabel.Visible = true;
                    //statusLabel.Visible = true;
                    //rightLabel.Visible = true;

                    //showMoreBtnPanel.Visible = true;
                }
            }

        }
        #endregion

        #region Private Functions

        private void SubscrubeForManagerEvents()
        {

        }




        #region Service Functions

        private void PostLanguageChangedInit()
        {
            isInit = false;

            //RIGHT_BUTTON_SHIFT = statusLabel.Location.X - leftLabel.Location.X - leftLabel.Width;
            //VERTICAL_ITEM_SHIFT = allPatientsItem1.Location.Y;
            searchText = searchTextBox.Text;
            searchTextBox.BorderStyle = BorderStyle.None;

            //clonePictureBox1.Visible = false;
            //clonePictureBox1.Location = new Point(0, 0);
            //clonePictureBox1.Size = this.Size;
            cloneBitmap = new Bitmap(this.Width, this.Height);

            normalSortLabelFont = dateLabel.Font;
            selectedSortLabelFont = new Font(normalSortLabelFont, FontStyle.Bold);

            InitTextBoxControls();
            InitBitmapControls();
            InitColor();
            InitBitmaps();

            isInit = true;

            InitAllPatients(true);

        }

        private void InitAllPatientsImpl(bool reload,bool fromParent)
        {
            if (isInit == false)
                return;

            if (reload)
            {
                allPatients = Manager.AllPatients;
                if (allPatients != null && fromParent)
                {
                    if(allPatients.Count == 0)
                    {
                        /*for (int ii = 0; ii < 10; ii++) only for testing
                        {
                            allPatients.Add(new Patient());
                        }*/
                    }
                    //for (int i = 0; i < allPatients.Count-1; i++)
                    //{
                    //    allPatients[i].PatientId = $"{i}";
                    //}
                    //InitGrid();
                }

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
                allGridItems[ii].Location=new Point(allGridItems[ii].Location.X, current_Y_Location);
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
                if (allPatients != null && allGridItems.Count == allPatients.Count)
                {
                    allGridItems[ii].CurrentPatient = allPatients[ii];
                    allGridItems[ii].Visible = true;
                }
                else
                    allGridItems[ii].Visible = false;
            }
        }

        private void InitColor()
        {
            Color greenTextcolor = System.Drawing.ColorTranslator.FromHtml("#31bc9c");
            //allUsersLabel.ForeColor = greenTextcolor;
            this.BackColor = Color.FromArgb(247,248,252);
            blackTextcolor = System.Drawing.ColorTranslator.FromHtml("#353840");
            blueTextcolor = Color.FromArgb(62,124,195); ;
            transparentBackcolor = Color.FromArgb(247, 248, 252);


            nameLabel.BackColor = transparentBackcolor;
            idLabel.BackColor = transparentBackcolor;
            dateLabel.BackColor = transparentBackcolor;
            doctorFirstLastNameLabel.BackColor = transparentBackcolor;
            genderNameLabel.BackColor = transparentBackcolor;
            ethnicityNameLabel.BackColor = transparentBackcolor;

            namePictureBox.BackColor = transparentBackcolor;
            idPictureBox.BackColor = transparentBackcolor;
            datePictureBox.BackColor = transparentBackcolor;
            doctorFirstLastNamePictureBox.BackColor = transparentBackcolor;
            genderNamePictureBox.BackColor = transparentBackcolor;
            ethnicityNamePictureBox.BackColor = transparentBackcolor;


            patientsListNameLabel.ForeColor = blueTextcolor;
            searchTextBox.ForeColor = blackTextcolor;
            //userNameLabel.ForeColor = blackTextcolor;
            //passwordLabel.ForeColor = blackTextcolor;
            //creationDateLabel.ForeColor = blackTextcolor;
            //statusLabel.ForeColor = blackTextcolor;
            //rightLabel.ForeColor = blackTextcolor;

            //leftLabel.ForeColor = grayTextcolor;


            //Color greenSliderColor = System.Drawing.ColorTranslator.FromHtml("#31bc9c");
            //itemsScrollColorSlider.BarInnerColor = greenSliderColor;
            //itemsScrollColorSlider.BarPenColorBottom = greenSliderColor;
            //itemsScrollColorSlider.BarPenColorTop = greenSliderColor;

            //itemsScrollColorSlider.ThumbInnerColor = greenSliderColor;
            //itemsScrollColorSlider.ThumbOuterColor = greenSliderColor;
            //itemsScrollColorSlider.ThumbPenColor = greenSliderColor;

            //Color graySliderColor = System.Drawing.ColorTranslator.FromHtml("#b7b7b7");
            //itemsScrollColorSlider.ElapsedInnerColor = graySliderColor;
            //itemsScrollColorSlider.ElapsedPenColorBottom = graySliderColor;
            //itemsScrollColorSlider.ElapsedPenColorTop = graySliderColor;

        }

        private bool isFirst = true;
        private void InitGrid()
        {
            if (allPatients == null)
                return;

            if (allPatients.Count == allGridItems.Count)
                return;
            allGridItems.Clear();
            SuspendLayout();
            allGridItemsPanel.Controls.Clear();

            int xLocation = 1;
            int yLocation = VERTICAL_ITEM_SHIFT;
            for (int ii = 0; ii < allPatients.Count; ii++)
            {
                AllPatientsItem newItem = new AllPatientsItem();

                newItem.BackColor = System.Drawing.Color.White;
                newItem.CurrentPatient = allPatients[ii];
                newItem.Name = $"allPatientsItem{ii}";

                newItem.Size = new Size(1798, 80);
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

                AllPatientsItem.RightButtonClick += AllPatientsItem_RightButtonClick;
                AllPatientsItem.DeleteButtonClick += AllPatientsItem_DeleteButtonClick;

            }


        }

        private void InitTextBoxControls()
        {
            searchTextBox.AutoSize = false;
            searchTextBox.Height = searchTextBox.Height + 15;

            //doctorNameTextBox.AutoSize = false;
            //doctorNameTextBox.Location = new Point(doctorNameTextBox.Location.X, 14);
            //doctorNameTextBox.Height = doctorNamePanel.Height - 20;


        }

        private void InitBitmapControls()
        {
            GuiUtils.SetNewLocation(nameLabel, gridHeaderPictureBox);
            GuiUtils.SetNewLocation(idLabel, gridHeaderPictureBox);
            GuiUtils.SetNewLocation(dateLabel, gridHeaderPictureBox);
            GuiUtils.SetNewLocation(doctorFirstLastNameLabel, gridHeaderPictureBox);
            GuiUtils.SetNewLocation(genderNameLabel, gridHeaderPictureBox);
            GuiUtils.SetNewLocation(ethnicityNameLabel, gridHeaderPictureBox);

            GuiUtils.SetNewLocation(namePictureBox, gridHeaderPictureBox);
            GuiUtils.SetNewLocation(idPictureBox, gridHeaderPictureBox);
            GuiUtils.SetNewLocation(datePictureBox, gridHeaderPictureBox);
            GuiUtils.SetNewLocation(doctorFirstLastNamePictureBox, gridHeaderPictureBox);
            GuiUtils.SetNewLocation(genderNamePictureBox, gridHeaderPictureBox);
            GuiUtils.SetNewLocation(ethnicityNamePictureBox, gridHeaderPictureBox);

            this.Controls.Remove(nameLabel);
            this.Controls.Remove(idLabel);
            this.Controls.Remove(dateLabel);
            this.Controls.Remove(doctorFirstLastNameLabel);
            this.Controls.Remove(genderNameLabel);
            this.Controls.Remove(ethnicityNameLabel);

            this.Controls.Remove(namePictureBox);
            this.Controls.Remove(idPictureBox);
            this.Controls.Remove(datePictureBox);
            this.Controls.Remove(doctorFirstLastNamePictureBox);
            this.Controls.Remove(genderNamePictureBox);
            this.Controls.Remove(ethnicityNamePictureBox);

            gridHeaderPictureBox.Controls.Add(nameLabel);
            gridHeaderPictureBox.Controls.Add(idLabel);
            gridHeaderPictureBox.Controls.Add(dateLabel);
            gridHeaderPictureBox.Controls.Add(doctorFirstLastNameLabel);
            gridHeaderPictureBox.Controls.Add(genderNameLabel);
            gridHeaderPictureBox.Controls.Add(ethnicityNameLabel);

            gridHeaderPictureBox.Controls.Add(namePictureBox);
            gridHeaderPictureBox.Controls.Add(idPictureBox);
            gridHeaderPictureBox.Controls.Add(datePictureBox);
            gridHeaderPictureBox.Controls.Add(doctorFirstLastNamePictureBox);
            gridHeaderPictureBox.Controls.Add(genderNamePictureBox);
            gridHeaderPictureBox.Controls.Add(ethnicityNamePictureBox);

        }

        #endregion

        #region Get Manager

        private ISTSManager Manager
        {
            get => STSManager.GetManager;
        }

        #endregion

        #region Buttons_Click Functions


        #endregion

        #region AllPatients Item Buttons_Click Functions

        private void AllPatientsItem_RightButtonClick(Patient patientCard)
        {
            OpenPatientDetails?.Invoke(patientCard);
        }

        private void AllPatientsItem_DeleteButtonClick(Patient patient)
        {
            Manager.DeletePatient(patient);

            allPatients.Remove(patient);

            InitAllPatientsImpl(true, true);
        }


        #endregion

        #region Mouse Events Functions

        private void control_MouseUp(object sender, MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        private void AllPatientsPanel_Click(object sender, EventArgs e)
        {
            dateLabel.Focus();
        }

        #endregion

        #region Scroll Slider Events Functions

        private void itemsScrollColorSlider_MouseUp(object sender, MouseEventArgs e)
        {
            //allGridItemsPanel.Location = new Point(allGridItemsPanel.Location.X, -(itemsScrollColorSlider.Maximum - itemsScrollColorSlider.Value));
        }

        #endregion

        #region Sorting Patients Functions

        #region Header Buttons_Click Functions

        bool sortByDateOrderByDescending = false;
        private void dateLabel_Click(object sender, EventArgs e)
        {
            ButtonPictureBox.SoundPlay();
            InitAllPatientsImpl(true, false);
            SortByDate(sortByDateOrderByDescending);
            sortByDateOrderByDescending = !sortByDateOrderByDescending;
            SetSortLabelFont(dateLabel);
            SetSortPictureBoxImg(datePictureBox, sortByDateOrderByDescending);
        }
        bool sortByIDOrderByDescending = false;
        private void idLabel_Click(object sender, EventArgs e)
        {
            ButtonPictureBox.SoundPlay();
            InitAllPatients(false);
            SortByID(sortByIDOrderByDescending);
            sortByIDOrderByDescending = !sortByIDOrderByDescending;
            SetSortLabelFont(idLabel);
            SetSortPictureBoxImg(idPictureBox, sortByIDOrderByDescending);
        }
        bool sortByFirstNameOrderByDescending = false;
        private void firstNameLabel_Click(object sender, EventArgs e)
        {
            ButtonPictureBox.SoundPlay();
            InitAllPatients(false);
            SortByFirstName(sortByFirstNameOrderByDescending);

            sortByFirstNameOrderByDescending = !sortByFirstNameOrderByDescending;
            SetSortLabelFont(nameLabel);
            SetSortPictureBoxImg(namePictureBox, sortByFirstNameOrderByDescending);
        }

        bool sortByLastGenderOrderByDescending = false;
        private void genderNameLabel_Click(object sender, EventArgs e)
        {
            ButtonPictureBox.SoundPlay();
            InitAllPatients(false);
            SortByGender(sortByLastGenderOrderByDescending);
            sortByLastGenderOrderByDescending = !sortByLastGenderOrderByDescending;
            SetSortLabelFont(genderNameLabel);
            SetSortPictureBoxImg(genderNamePictureBox, sortByLastGenderOrderByDescending);
        }


        bool sortByDoctorNameOrderByDescending = false;
        private void doctorFirstLastNameLabel_Click(object sender, EventArgs e)
        {
            ButtonPictureBox.SoundPlay();
            InitAllPatients(false);
            SortByDoctorName(sortByDoctorNameOrderByDescending);
            sortByDoctorNameOrderByDescending = !sortByDoctorNameOrderByDescending;
            SetSortLabelFont(doctorFirstLastNameLabel);
            SetSortPictureBoxImg(doctorFirstLastNamePictureBox, sortByDoctorNameOrderByDescending);
        }

        bool sortByEthnicityDescending = false;
        private void ethnicityNameLabel_Click(object sender, EventArgs e)
        {
            ButtonPictureBox.SoundPlay();
            InitAllPatients(false);
            SortByEthnicity(sortByEthnicityDescending);
            sortByEthnicityDescending = !sortByEthnicityDescending;
            SetSortLabelFont(ethnicityNameLabel);
            SetSortPictureBoxImg(ethnicityNamePictureBox, sortByEthnicityDescending);

        }

        #endregion

        #region Sorting Implementation Functions

        private void SortByDate(bool orderByDescending)
        {
            if (allPatients == null || allPatients.Count <= 1)
                return;

            try
            {
                if (orderByDescending)
                    allPatients = allPatients.OrderByDescending(item => item.Visited[0].VisitDateTime).ToList();
                else
                    allPatients = allPatients.OrderBy(item => item.Visited[0].VisitDateTime).ToList();
            }
            catch(Exception e)
            {

            }

            PostSort();
        }
        private void SortByID(bool orderByDescending)
        {
            if (allPatients == null || allPatients.Count <= 1)
                return;

            if (orderByDescending)
                allPatients = allPatients.OrderByDescending(item => item.PatientId).ToList();
            else
                allPatients = allPatients.OrderBy(item => item.PatientId).ToList();

            //if (orderByDescending)
            //    allPatients = allPatients.OrderByDescending(item => int.Parse(item.PatientId)).ToList();
            //else
            //    allPatients = allPatients.OrderBy(item => int.Parse(item.PatientId)).ToList();

            PostSort();
        }
        private void SortByFirstName(bool orderByDescending)
        {
            if (allPatients == null || allPatients.Count <= 1)
                return;

            if (orderByDescending)
                allPatients = allPatients.OrderByDescending(item => item.FullName).ToList();
            else
                allPatients = allPatients.OrderBy(item => item.FullName).ToList();

            PostSort();
        }
        private void SortByGender(bool orderByDescending)
        {
            if (allPatients == null || allPatients.Count <= 1)
                return;

            if (orderByDescending)
                allPatients = allPatients.OrderByDescending(item => item.Gender).ToList();//Need Impl.
            else
                allPatients = allPatients.OrderBy(item => item.Gender).ToList();

            PostSort();
        }

        private void SortByDoctorName(bool orderByDescending)
        {
            if (allPatients == null || allPatients.Count <= 1)
                return;

            if (orderByDescending)//Need impl.
                allPatients = allPatients.OrderByDescending(item => item.LastDoctor.FullName).ToList();
            else
                allPatients = allPatients.OrderBy(item => item.LastDoctor.FullName).ToList();

            PostSort();
        }


        private void SortByEthnicity(bool sortByModeDescending)
        {
            if (allPatients == null || allPatients.Count <= 1)
                return;

            if (sortByModeDescending)
                allPatients = allPatients.OrderByDescending(item => item.Ethnicity).ToList();
            else
                allPatients = allPatients.OrderBy(item => item.Ethnicity).ToList();

            PostSort();
        }

        private void PostSort()
        {
            if (allPatients == null)
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
        private void SetSortPictureBoxImg(PictureBox sortClickPictureBox,bool order)
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

        #endregion


        #region TextBoxes Enter Functions
        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            ButtonPictureBox.SoundPlay();
            if (!isInit)
                return;
            if (searchTextBox.Text == searchText)
                searchTextBox.Text = "";
        }
        #endregion

        #region TextBoxes Validated Functions

        private void searchTextBox_Validated(object sender, EventArgs e)
        {
            searchTextBox_ValidatedImpl();

        }

        private void searchTextBox_ValidatedImpl()
        {
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                searchTextBox.Text = searchText;
                ReloadPatients();
            }
            //else
            //    SearchPatients(searchTextBox.Text);
        }

        private void SearchPatients(string text)
        {
            if (allPatients == null)
                return;
            List<Patient> findPatients = allPatients.FindAll(item => item.PatientId.Contains(text));
            if(findPatients.Count == 0)
                findPatients = allPatients.FindAll(item => item.FullName.ToLower().Contains(text.ToLower()));

            allPatients = findPatients;
            InitAllPatientsImpl(false, false);
        }

        private void ReloadPatients()
        {
            InitAllPatients(false);
        }

        #endregion

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
//            if (string.IsNullOrEmpty(searchTextBox.Text) || searchTextBox.Text == searchText)
            if (searchTextBox.Text == searchText)
                return;
            searchTextBoxTimer.Stop();
            InitAllPatients(false);
            if(string.IsNullOrEmpty(searchTextBox.Text))
                searchTextBoxTimer.Start();
            else
                SearchPatients(searchTextBox.Text);
        }

        private void searchTextBoxTimer_Tick(object sender, EventArgs e)
        {
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ButtonPictureBox.SoundPlay();
            char c = e.KeyChar;
            if (!char.IsDigit(c) && !char.IsLetter(c) && c != '\b' && !char.IsWhiteSpace(c))
            {
                e.Handled = true;
            }

        }


        private void InitBitmaps()
        {
        }

        private void addNewPatientButtonPictureBox_Click(object sender, EventArgs e)
        {
            AddNewPatient?.Invoke();
        }

        private void itemsScrollColorSlider_MouseUp_1(object sender, MouseEventArgs e)
        {
//            allGridItemsPanel.Location = new Point(allGridItemsPanel.Location.X, -(itemsScrollColorSlider.Maximum - itemsScrollColorSlider.Value));
        }

        private void itemsScrollColorSlider_ValueChanged(object sender, EventArgs e)
        {
            allGridItemsPanel.Location = new Point(allGridItemsPanel.Location.X, -(itemsScrollColorSlider.Maximum - itemsScrollColorSlider.Value));

        }

        private void AllPatientsPanel_VisibleChanged(object sender, EventArgs e)
        {
            if(!this.Visible )
            {
                foreach (var item in allGridItems)
                {
                    item.Reset();
                }
            }
        }

        #endregion
    }
}
