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

namespace STSGui.Controls.Report
{
    public partial class Printer : UserControl
    {
        #region Private Members

        private Bitmap cloneBitmap;

        private bool isInit = false;

        #endregion

        #region Constructor / Control_Load
        public Printer()
        {
            InitializeComponent();
        }

        private void Printer_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            isInit = false;

            cloneBitmap = new Bitmap(this.Width, this.Height);

            InitColor();
            InitComboBoxAndTextBox();

            isInit = true;

        }

        #endregion

        #region Events

        public event Action<PrintData> StartPrint;
        public event Action CancelPrint;

        #endregion

        #region Get Manager

        private ISTSManager Manager
        {
            get => STSManager.GetManager;
        }

        #endregion

        #region Private Functions

        private void InitColor()
        {

            this.BackColor = Color.FromArgb(247, 248, 252);

            Color textcolor = Color.FromArgb(37, 55, 86);

            printHeaderLabel.ForeColor = textcolor;
            sheetOfPaperLabel.ForeColor = textcolor;

            destinationNameLabel.ForeColor = textcolor;
            pagesNameLabel.ForeColor = textcolor;
            copiesNameLabel.ForeColor = textcolor;
            colorPrintNameLabel.ForeColor = textcolor;


            textcolor = Color.FromArgb(136, 136, 136);

            destinationValueComboBoxClean.ForeColor = textcolor;
            pagesValueComboBoxClean.ForeColor = textcolor;
            copiesValueTextBox.ForeColor = textcolor;
            colorPrintValueComboBox.ForeColor = textcolor;

        }


        private void InitComboBoxAndTextBox()
        {
            destinationValueComboBoxClean.Items.Clear();
            int defaultIndex = 0;
            foreach (var item in Manager.GetAllPrinters(out defaultIndex))
            {
                destinationValueComboBoxClean.Items.Add(item);
            }
            destinationValueComboBoxClean.SelectedIndex = defaultIndex;

            pagesValueComboBoxClean.Items.Clear();
            pagesValueComboBoxClean.Items.Add("All");
            pagesValueComboBoxClean.SelectedIndex = 0;

            colorPrintValueComboBox.Items.Clear();
            foreach (var item in Enum.GetNames(typeof(PrinterColors)))
            {
                colorPrintValueComboBox.Items.Add(item);
            }
            colorPrintValueComboBox.SelectedIndex = 0;

            copiesValueTextBox.Text = "1";

        }


        private void printButtonPictureBox_Click(object sender, EventArgs e)
        {
            PrintData printerProperties = new PrintData();
            printerProperties.PrinterName = Convert.ToString(destinationValueComboBoxClean.SelectedItem);
            printerProperties.PrinterColor = (PrinterColors)colorPrintValueComboBox.SelectedIndex;
            uint copies = 0;
            if (uint.TryParse(copiesValueTextBox.Text, out copies))
                printerProperties.Copies = Math.Max(1, copies);
            else
                printerProperties.Copies = 1;

            StartPrint?.Invoke(printerProperties);
        }


        private void cancelButtonPictureBox_Click(object sender, EventArgs e)
        {
            CancelPrint?.Invoke();
        }

        private void copiesValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) )
                e.Handled = true;
        }

        #endregion
    }
}
