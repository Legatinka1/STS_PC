using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STSGui
{
    [Serializable]
    public partial class SmallRadioButton : UserControl
    {
        #region Private Members

        List<SmallRadioButton> partners = new List<SmallRadioButton>();

        #endregion

        #region Constructor / Load

        public SmallRadioButton()
        {
            InitializeComponent();
        }

        private void SmallRadioButton_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            radioButtonPictureBox.Visible = isChecked;
        }

        #endregion

        #region Events

        public event Action<object,bool> CheckedChanged;

        #endregion

        #region Public Functions

        public void AddPartner(SmallRadioButton part)
        {
            if (this.DesignMode)
                return;
            if (part == this || partners.Contains(part))
                return;

            partners.Add(part);
        }

        public void RemovePartner(SmallRadioButton part)
        {
            if (this.DesignMode)
                return;
            if (part == this)
                return;

            partners.Remove(part);

        }

        public void ClearPartners()
        {
            if (this.DesignMode)
                return;
            partners.Clear();
        }

        #endregion

        #region Click Functions

        private void radioButtonPictureBox_Click(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            ButtonPictureBox.SoundPlay();
            if (Checked)
                return;

            Checked = !Checked;
            foreach (var item in partners)
            {
                if (item != this)
                    item.Checked = !Checked;
            }
            //CheckedChanged?.Invoke(this, isChecked);
        }

        private void SmallRadioButton_Click(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            ButtonPictureBox.SoundPlay();
            if (Checked)
                return;

            Checked = !Checked;
            foreach (var item in partners)
            {
                if (item != this)
                    item.Checked = !Checked;
            }
            //CheckedChanged?.Invoke(this, isChecked);
        }

        #endregion

        #region Property

        #region Checked

        public bool Checked
        {
            get
            {
                return isChecked;
            }
            set
            {
                if(value!= isChecked)
                {
                    isChecked = value;
                    if (this.DesignMode)
                        return;
                    radioButtonPictureBox.Visible = isChecked;
                    CheckedChanged?.Invoke(this, isChecked);
                }
            }
        }
        private bool isChecked = false;

        #endregion


        //#region Partners

        //public List<SmallRadioButton> Partners
        //{
        //    get
        //    {
        //        return partners;
        //    }
        //    set
        //    {
        //        if (this.DesignMode)
        //            return;
        //        if (value != null)
        //        {
        //            partners.Clear();
        //            foreach (var item in value)
        //            {
        //                AddPartner(item);
        //            }
        //            partners = value;
        //        }
        //    }
        //}

        //#endregion

        #endregion

    }
}
