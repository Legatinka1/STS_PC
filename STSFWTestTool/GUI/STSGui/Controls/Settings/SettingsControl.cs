using CommonLib;
using Globals;
using ImplementationLib;
using InterfacesLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STSGui.Controls.Doctors
{
    public partial class SettingsControl : UserControl
    {
        #region Private Members

        //private Config config = ConfigurationFileManager<Config>.Instance.GetData;

        #endregion

        #region Constructor / Control_Load
        public SettingsControl()
        {
            InitializeComponent();
        }

        private void SettingsControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            PostLanguageChangedInit();
        }

        #endregion

        #region Public Functions

        public void ResetControls()
        {
            if (serialSmallRadioButton.Checked)
            {
                string[] ports = SerialPort.GetPortNames();
                int currentIndex = ports.ToList().FindIndex(item => item.ToString() == $"COM{Manager.ComPort}");
                currentIndex = Math.Max(currentIndex, 0);

                comPorts_Value_ComboBoxClean.Items.Clear();
                comPorts_Value_ComboBoxClean.Items.AddRange(ports);

                if (comPorts_Value_ComboBoxClean.Items.Count != 0)
                    comPorts_Value_ComboBoxClean.SelectedIndex = currentIndex;
            }
            else
            {
                comPorts_Value_ComboBoxClean.Items.Clear();
                comPorts_Value_ComboBoxClean.Items.AddRange(Manager.GetAllSTSBluetoothDevices());

                if (comPorts_Value_ComboBoxClean.Items.Count != 0)
                    comPorts_Value_ComboBoxClean.SelectedIndex = 0;
            }

            Hospital hospital = Manager.HospitalData;
            if (hospital == null)
            {
                hospitalName_Value_TextBox.Text = "";
                className_Value_TextBox.Text = "";
            }
            else
            {
                hospitalName_Value_TextBox.Text = hospital.HospitalName;
                className_Value_TextBox.Text = hospital.ClassName;
            }


            if (Manager.UnitSystem == Enum_Unit_System.Metric)
            {
                metricSmallRadioButton.Checked = true;
                imperialSmallRadioButton.Checked = false;
                usaSmallRadioButton.Checked = false;
            }
            else if (Manager.UnitSystem == Enum_Unit_System.Imperial)
            {
                metricSmallRadioButton.Checked = false;
                imperialSmallRadioButton.Checked = true;
                usaSmallRadioButton.Checked = false;
            }
            else
            {
                metricSmallRadioButton.Checked = false;
                imperialSmallRadioButton.Checked = false;
                usaSmallRadioButton.Checked = true;
            }
            saveButtonPictureBox.Enabled = IsSaveButtonEnabled();

            if(Manager.TestCommunication == Enum_TestCommunication.Serial)
            {
                serialSmallRadioButton.Checked = true;
                bluetoothSmallRadioButton.Checked = false;
            }
            else if (Manager.TestCommunication == Enum_TestCommunication.BlueTooth)
            {
                serialSmallRadioButton.Checked = false;
                bluetoothSmallRadioButton.Checked = true;
            }

            comPortLabel.Focus();

        }
        #endregion

        #region Get Manager

        private ISTSManager Manager
        {
            get => STSManager.GetManager;
        }

        #endregion

        #region Events

        public event Action Save;
        public event Action Cancel;

        #endregion

        #region Private Functions

        private void PostLanguageChangedInit()
        {
            InitColor();
            InitRadioButtons();
        }

        private void InitColor()
        {
            Color textcolor = Color.FromArgb(95, 161, 250);
            unitSystemLabel.ForeColor = textcolor;
            settings_Name_Label.ForeColor = textcolor;
            hospitalNameLabel.ForeColor = textcolor;
            comPortLabel.ForeColor = textcolor;

            textcolor = Color.FromArgb(149, 158, 172);

            metric_Name_Label.ForeColor = textcolor;
            imperial_Name_Label.ForeColor = textcolor;
            usa_Name_Label.ForeColor = textcolor;

            hospitalName_Name_Label.ForeColor = textcolor;
            className_Name_Label.ForeColor = textcolor;

            textcolor = Color.FromArgb(92, 105, 128);

            hospitalName_Value_TextBox.ForeColor = textcolor;
            className_Value_TextBox.ForeColor = textcolor;
            comPorts_Value_ComboBoxClean.ForeColor = textcolor;
        }
        private void InitRadioButtons()
        {
            List<SmallRadioButton> partners = new List<SmallRadioButton>() { metricSmallRadioButton, imperialSmallRadioButton, usaSmallRadioButton };
            foreach (var item in partners)
            {
                metricSmallRadioButton.AddPartner(item);
                imperialSmallRadioButton.AddPartner(item);
                usaSmallRadioButton.AddPartner(item);
            }

            // Avi
            List<SmallRadioButton> CommunicationPartners = new List<SmallRadioButton>() { serialSmallRadioButton, bluetoothSmallRadioButton };
            foreach (var item in CommunicationPartners)
            {
                serialSmallRadioButton.AddPartner(item);
                bluetoothSmallRadioButton.AddPartner(item);
            }
        }


        private void metric_Name_Label_Click(object sender, EventArgs e)
        {
            metricSmallRadioButton.Checked = true;
            imperialSmallRadioButton.Checked = false;
            usaSmallRadioButton.Checked = false;
        }

        private void imperial_Name_Label_Click(object sender, EventArgs e)
        {
            metricSmallRadioButton.Checked = false;
            imperialSmallRadioButton.Checked = true;
            usaSmallRadioButton.Checked = false;
        }

        private void usa_Name_Label_Click(object sender, EventArgs e)
        {
            metricSmallRadioButton.Checked = false;
            imperialSmallRadioButton.Checked = false;
            usaSmallRadioButton.Checked = true;
        }

        private void serial_Name_Label_Click(object sender, EventArgs e)
        {
            Manager.TestCommunication = Enum_TestCommunication.Serial;

            serialSmallRadioButton.Checked = true;
            bluetoothSmallRadioButton.Checked = false;
            
            comPorts_Value_ComboBoxClean_DropDown(sender, e);
        }

        private void bluetooth_Name_Label_Click(object sender, EventArgs e)
        {
            Manager.TestCommunication = Enum_TestCommunication.BlueTooth;

            serialSmallRadioButton.Checked = false;
            bluetoothSmallRadioButton.Checked = true;
            
            comPorts_Value_ComboBoxClean_DropDown(sender, e);
        }

        private void cancelButtonPictureBox_Click(object sender, EventArgs e)
        {
            Cancel?.Invoke();
        }

        private void saveButtonPictureBox_Click(object sender, EventArgs e)
        {
            if(SaveImpl())
                Save?.Invoke();
        }

        private bool SaveImpl()
        {
            if (string.IsNullOrEmpty(hospitalName_Value_TextBox.Text) || string.IsNullOrEmpty(className_Value_TextBox.Text))
                return false;

            string selectedPort = "0";
            if (comPorts_Value_ComboBoxClean.SelectedItem != null)
                selectedPort = comPorts_Value_ComboBoxClean.SelectedItem.ToString().Remove(0,3);

            int selectedPortIndex = 0;
            if (int.TryParse(selectedPort, out selectedPortIndex))
            {
                if (serialSmallRadioButton.Checked)
                    Manager.ComPort = selectedPortIndex;
                else
                {
                    if (bluetoothSmallRadioButton.Checked)
                        Manager.BlueToothDevice = comPorts_Value_ComboBoxClean.SelectedItem.ToString();

                    Manager.ComPort = 0;
                }
            }
            Hospital hospital = new Hospital() { HospitalName  = hospitalName_Value_TextBox.Text , ClassName = className_Value_TextBox.Text };
            Manager.HospitalData = hospital ;


            if (metricSmallRadioButton.Checked)
                Manager.UnitSystem = Enum_Unit_System.Metric;
            else if (imperialSmallRadioButton.Checked)
                Manager.UnitSystem = Enum_Unit_System.Imperial;
            else
                Manager.UnitSystem = Enum_Unit_System.USA;

            if (serialSmallRadioButton.Checked)
                Manager.TestCommunication = Enum_TestCommunication.Serial;
            else if (bluetoothSmallRadioButton.Checked)
                Manager.TestCommunication = Enum_TestCommunication.BlueTooth;


            return true;
        }


        private void hospitalName_Value_TextBox_Validated(object sender, EventArgs e)
        {
            saveButtonPictureBox.Enabled = IsSaveButtonEnabled();
        }

        private void className_Value_TextBox_Validated(object sender, EventArgs e)
        {
            saveButtonPictureBox.Enabled = IsSaveButtonEnabled();
        }
        private bool IsSaveButtonEnabled()
        {
            bool res = !string.IsNullOrEmpty(hospitalName_Value_TextBox.Text) &&
                        !string.IsNullOrEmpty(className_Value_TextBox.Text);

                return res;
        }

        #endregion

        private void userName_Value_ComboBoxClean_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comPorts_Value_ComboBoxClean_SelectedIndexChanged(object sender, EventArgs e)
        {
            comPortLabel.Focus();
        }

        private void metricSmallRadioButton_Load(object sender, EventArgs e)
        {

        }
        private void comPorts_Value_ComboBoxClean_DropDown(object sender, EventArgs e)
        {
            if (serialSmallRadioButton.Checked)
            {
                string[] ports = SerialPort.GetPortNames();
                int currentIndex = ports.ToList().FindIndex(item => item.ToString() == $"COM{Manager.ComPort}");
                currentIndex = Math.Max(currentIndex, 0);

                comPorts_Value_ComboBoxClean.Items.Clear();
                comPorts_Value_ComboBoxClean.Items.AddRange(ports);

                if (comPorts_Value_ComboBoxClean.Items.Count != 0)
                    comPorts_Value_ComboBoxClean.SelectedIndex = currentIndex;
            }
            else if (bluetoothSmallRadioButton.Checked)
            {
                comPorts_Value_ComboBoxClean.Items.Clear();
                comPorts_Value_ComboBoxClean.Items.AddRange(Manager.GetAllSTSBluetoothDevices());

                if (comPorts_Value_ComboBoxClean.Items.Count != 0)
                    comPorts_Value_ComboBoxClean.SelectedIndex = 0;
            }
        }

        private void serialSmallRadioButton_Click(object sender, EventArgs e)
        {
            Manager.TestCommunication = Enum_TestCommunication.Serial; 
            comPorts_Value_ComboBoxClean_DropDown(sender, e);
        }

        private void bluetoothSmallRadioButton_Click(object sender, EventArgs e)
        {
            Manager.TestCommunication = Enum_TestCommunication.BlueTooth; 
            comPorts_Value_ComboBoxClean_DropDown(sender, e);
        }

        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            if (openFileDialogConfig.ShowDialog() == DialogResult.OK)
            {
                Manager.SetCalibarationFileName(openFileDialogConfig.FileName);
                /*newCalibInfo = Serializer.Load<DoCalc.DoCalc.CalibInfo>(openFileDialogConfig.FileName);

                calc.CalibrationInfo.LoadFrom(newCalibInfo);
                rtbCalib.Text = calc.CalibrationInfo.ToString();*/
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
