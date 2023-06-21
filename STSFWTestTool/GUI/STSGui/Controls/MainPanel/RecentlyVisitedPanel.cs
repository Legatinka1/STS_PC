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

    public partial class RecentlyVisitedPanel : UserControl
    {
        #region Private Members

        private Bitmap cloneBitmap;

        List<Patient> allPatients = null;

        List<RecentlyVisitedItem> allGridItems = new List<RecentlyVisitedItem>();

        Color blackTextcolor;
        Color blueTextcolor;
        Color transparentBackcolor;


        private bool isInit = false;

        string searchText = "";

        #endregion

        #region Constructor / Control_Load

        public RecentlyVisitedPanel()
        {
            InitializeComponent();
        }

        private void RecentlyVisitedPanel_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            PostLanguageChangedInit();

            SubscrubeForManagerEvents();


        }

        #endregion

        #region Events

        public event Action<Patient> OpenPatientDetails;
        public event Action AddNewPatient;
        public event Action ToPatientList;

        #endregion

        #region Public Functions

        public void EnableGrid(bool enable)
        {
            allGridItemsPanel.Enabled = enable;
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

        public void InitAllPatients()
        {
            InitAllPatientsImpl();
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

            searchText = searchTextBox.Text;
            searchTextBox.BorderStyle = BorderStyle.None;

            cloneBitmap = new Bitmap(this.Width, this.Height);
            allGridItems.Clear();
            allGridItems.Add(recentlyVisitedItem_0);
            allGridItems.Add(recentlyVisitedItem_1);
            allGridItems.Add(recentlyVisitedItem_2);

            InitTextBoxControls();
            InitColor();

            isInit = true;


        }

        private void InitAllPatientsImpl()
        {
            if (isInit == false)
                return;

            allPatients = Manager.AllPatients;
            foreach (Patient patient in allPatients)
            {
                if (patient.Visited != null)
                    patient.Visited = patient.Visited.OrderByDescending(item => item.VisitDateTime).ToList();
            }
            if (allPatients != null)
            {
                if (allPatients.Count != 0)
                {
                    try
                    {
                        allPatients = allPatients.OrderByDescending(item => item.Visited?[0].VisitDateTime).ToList();
                        if (allPatients.Count > 3)
                            allPatients.RemoveRange(3, allPatients.Count - 3);
                    }
                    catch(Exception ex)
                    {

                    }
                }
            }

            InitGrid();
            FillItems();
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


            recentlyVisitedNameLabel.ForeColor = blueTextcolor;
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


            if (isFirst)
            {
                isFirst = false;

                RecentlyVisitedItem.RightButtonClick += AllPatientsItem_RightButtonClick;

            }


        }


        private void InitTextBoxControls()
        {
            searchTextBox.AutoSize = false;
            searchTextBox.Height = searchTextBox.Height + 15;
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
            //dateLabel.Focus();
        }

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
                findPatients = allPatients.FindAll(item => item.FullName.Contains(text));

            allPatients = findPatients;
            InitAllPatientsImpl();
        }

        private void ReloadPatients()
        {
            InitAllPatients();
        }

        #endregion

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
//            if (string.IsNullOrEmpty(searchTextBox.Text) || searchTextBox.Text == searchText)
            if (searchTextBox.Text == searchText)
                return;
            searchTextBoxTimer.Stop();
            InitAllPatients();
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


        private void addNewPatientButtonPictureBox_Click(object sender, EventArgs e)
        {
            AddNewPatient?.Invoke();
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
        private void toPatientListPictureBox_Click(object sender, EventArgs e)
        {
            ToPatientList?.Invoke();
        }

        #endregion
    }
}
