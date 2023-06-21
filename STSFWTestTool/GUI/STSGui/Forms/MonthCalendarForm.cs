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
    public partial class MonthCalendarForm : Form
    {

        #region Constructor / Control_Load

        public MonthCalendarForm()
        {
            InitializeComponent();
        }
        private void MonthCalendarForm_Load(object sender, EventArgs e)
        {
            this.Location = NeedLocation;
        }

        #endregion

        #region Public Properties

        public DateTime SelectedTime
        {
            get
            {
                return start;
            }
        }
        DateTime start = DateTime.MinValue;

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
        private static Point needLocation = new Point(0,0);

        #endregion

        #region Public Functions

        public void SetInitDateTime(DateTime initTime)
        {
            monthCalendar1.SetDate(initTime);
        }

        #endregion

        #region Private Functions

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            start = e.Start;
            this.Visible = false; ;

        }
        private void MonthCalendarForm_Deactivate(object sender, EventArgs e)
        {
            this.Visible = false; ;
        }
        private void MonthCalendarForm_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible)
                start = DateTime.MinValue;
        }

        #endregion
    }
}
