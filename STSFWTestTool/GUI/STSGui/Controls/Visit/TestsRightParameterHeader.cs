using CommonLib;
using ImplementationLib;
using InterfacesLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace STSGui
{
    public partial class TestsRightParameterHeader : UserControl
    {
        #region Private Members

        private PUATestResult testResult = null;
        bool _isNewSession = true;

        Color textColor;

        Dictionary<int, Label> testLabels = new Dictionary<int, Label>();
        Dictionary<Label, ButtonPictureBox> testLabelsToRemove = new Dictionary<Label, ButtonPictureBox>();

        public bool isDesignMode = true;
        #endregion

        #region Constructor / Control_Load

        public TestsRightParameterHeader()
        {
            InitializeComponent();
        }

        private void TestsRightParameterItem_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            PostLanguageChangedInit();
            SubscrubeForManagerEvents();
        }

        #endregion

        #region Get Manager

        private ISTSManager Manager
        {
            get => STSManager.GetManager;
        }

        #endregion

        #region Events

        public event Action<int> RemoveTest;

        #endregion

        #region Public Functions

        public void Reset()
        {
            foreach (var item in testLabels.Values)
            {
                item.Text = "Test";
            }
            foreach (var item in testLabelsToRemove.Values)
            {
                item.Tag = -1;
                item.Visible = false;
            }
            
        }

        public void SetCurrentTestResult(PUATestResult result, bool isNewSession)
        {
            testResult = result;
            _isNewSession = isNewSession;
            InitTestResult();
        }

        #endregion

        #region Private Functions

        private void SubscrubeForManagerEvents()
        {
            Manager.TestDone += Manager_TestDone;
        }

        #region Service Functions

        private void PostLanguageChangedInit()
        {
            InitDictionarys();
            InitColor();
            InitTestResult();

        }

        private void InitDictionarys()
        {
            int index = 0;
            testLabels[index] = test_0_NameLabel;
            testLabelsToRemove[test_0_NameLabel] = removeTest_0_ButtonPictureBox;
            index++;

            testLabels[index] = test_1_NameLabel;
            testLabelsToRemove[test_1_NameLabel] = removeTest_1_ButtonPictureBox;
            index++;

            testLabels[index] = test_2_NameLabel;
            testLabelsToRemove[test_2_NameLabel] = removeTest_2_ButtonPictureBox;
            index++;

            testLabels[index] = test_3_NameLabel;
            testLabelsToRemove[test_3_NameLabel] = removeTest_3_ButtonPictureBox;
            index++;

            testLabels[index] = test_4_NameLabel;
            testLabelsToRemove[test_4_NameLabel] = removeTest_4_ButtonPictureBox;
            index++;

            testLabels[index] = test_5_NameLabel;
            testLabelsToRemove[test_5_NameLabel] = removeTest_5_ButtonPictureBox;
            index++;

            testLabels[index] = test_6_NameLabel;
            testLabelsToRemove[test_6_NameLabel] = removeTest_6_ButtonPictureBox;
            index++;

            testLabels[index] = test_7_NameLabel;
            testLabelsToRemove[test_7_NameLabel] = removeTest_7_ButtonPictureBox;
            index++;

            testLabels[index] = test_8_NameLabel;
            testLabelsToRemove[test_8_NameLabel] = removeTest_8_ButtonPictureBox;
            index++;

            testLabels[index] = test_9_NameLabel;
            testLabelsToRemove[test_9_NameLabel] = removeTest_9_ButtonPictureBox;
            index++;

            testLabels[index] = test_10_NameLabel;
            testLabelsToRemove[test_10_NameLabel] = removeTest_10_ButtonPictureBox;
            index++;

        }

        private void InitColor()
        {
            textColor = Color.White;
            LabelsInitColor(textColor);

        }

        private void LabelsInitColor(Color textColor)
        {
            foreach (var item in testLabels.Values)
            {
                item.ForeColor = textColor;
            }

            Color backColor = Color.FromArgb(240, 115, 145);
            test_0_NameLabel.BackColor = backColor;
            actual_0_NameLabel.BackColor = backColor;
            actual_0_A_P_NameLabel.BackColor = backColor;

            backColor = Color.FromArgb(69, 115, 170);
            test_1_NameLabel.BackColor = backColor;
            actual_1_NameLabel.BackColor = backColor;
            actual_1_A_P_NameLabel.BackColor = backColor;

            backColor = Color.FromArgb(236, 186, 68);
            test_2_NameLabel.BackColor = backColor;
            actual_2_NameLabel.BackColor = backColor;
            actual_2_A_P_NameLabel.BackColor = backColor;

            backColor = Color.FromArgb(140, 171,134 );
            test_3_NameLabel.BackColor = backColor;
            actual_3_NameLabel.BackColor = backColor;
            actual_3_A_P_NameLabel.BackColor = backColor;

            backColor = Color.FromArgb(142,112 ,87 );
            test_4_NameLabel.BackColor = backColor;
            actual_4_NameLabel.BackColor = backColor;
            actual_4_A_P_NameLabel.BackColor = backColor;

            backColor = Color.FromArgb(229,137 ,118 );
            test_5_NameLabel.BackColor = backColor;
            actual_5_NameLabel.BackColor = backColor;
            actual_5_A_P_NameLabel.BackColor = backColor;

            backColor = Color.FromArgb(240, 115, 145);
            test_6_NameLabel.BackColor = backColor;
            actual_6_NameLabel.BackColor = backColor;
            actual_6_A_P_NameLabel.BackColor = backColor;

            backColor = Color.FromArgb(69, 115, 170);
            test_7_NameLabel.BackColor = backColor;
            actual_7_NameLabel.BackColor = backColor;
            actual_7_A_P_NameLabel.BackColor = backColor;

            backColor = Color.FromArgb(236, 186, 68);
            test_8_NameLabel.BackColor = backColor;
            actual_8_NameLabel.BackColor = backColor;
            actual_8_A_P_NameLabel.BackColor = backColor;

            backColor = Color.FromArgb(140, 171, 134);
            test_9_NameLabel.BackColor = backColor;
            actual_9_NameLabel.BackColor = backColor;
            actual_9_A_P_NameLabel.BackColor = backColor;

            backColor = Color.FromArgb(142, 112, 87);
            test_10_NameLabel.BackColor = backColor;
            actual_10_NameLabel.BackColor = backColor;
            actual_10_A_P_NameLabel.BackColor = backColor;

        }

        #endregion



        private void InitTestResult()
        {
            this.InvokeIfRequired(() =>
            {
                if (this.DesignMode)
                    return;
                if (isDesignMode)
                    return;

                    if (testResult == null)
                        this.Size = new Size(0, this.Size.Height);
                    else
                    {
                        if (testResult.AllTests == null || testResult.AllTests.Count == 0)
                        {
                            this.Size = new Size(0, this.Size.Height);
                            return;
                        }
                        foreach (var item in testLabelsToRemove.Values)
                        {
                            item.Visible = _isNewSession;
                        }
                        int maxCount = Math.Min(testResult.AllTests.Count, testLabels.Count);
                        for (int ii = maxCount - 1, jj = 0; ii >= 0; ii--, jj++)
                        {
                            testLabels[jj].Text = $"Test {ii}";
                            testLabelsToRemove[testLabels[jj]].Tag = ii;
                        }
                        this.Size = new Size(testLabels[maxCount - 1].Location.X + testLabels[maxCount - 1].Width + 2, this.Size.Height);
                    }
            });

        }
        private void Manager_TestDone(bool res, PUATestResult result)
        {
            if (res)
            {
                testResult = result;
                InitTestResult();
            }
        }

        #endregion

        private void removeTestButtonPictureBox_Click(object sender, EventArgs e)
        {

            ButtonPictureBox removeButton = (ButtonPictureBox)sender;
            int index = Convert.ToInt32(removeButton.Tag);
            RemoveTest?.Invoke(index);
            //if (MessageBox.Show($"Remove Test index {index}?","",MessageBoxButtons.YesNo)== DialogResult.Yes)
            //{
            //    if (Manager.RemoveTest(testResult, index))
            //    {
            //        Reset();
            //        InitTestResult();
            //    }
            //    else
            //        MessageBox.Show($"Remove Test index {index} False", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            //}
        }
    }
}
