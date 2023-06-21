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
    public partial class SmallCheckBox : UserControl
    {
        #region Private Members

        private Bitmap checkedBitmap;
        private Bitmap uncheckedBitmap;

        #endregion

        #region Constructor / Load

        public SmallCheckBox()
        {
            InitializeComponent();
        }
        private void SmallCheckBox_Load(object sender, EventArgs e)
        {
            checkedBitmap = Properties.Resources.check_box_checked;
            uncheckedBitmap = Properties.Resources.check_box_unchecked;

            if (isChecked)
                checkBoxPictureBox.Image = checkedBitmap;
            else
                checkBoxPictureBox.Image = uncheckedBitmap;
        }
        #endregion

        #region Events

        public event Action<object, bool> CheckedChanged;

        #endregion

        #region Click Functions

        private void SmallCheckBox_Click(object sender, EventArgs e)
        {
            ButtonPictureBox.SoundPlay();
            Checked = !Checked;
            CheckedChanged?.Invoke(this, isChecked);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ButtonPictureBox.SoundPlay();
            Checked = !Checked;
            CheckedChanged?.Invoke(this, isChecked);
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
                if (value != isChecked)
                {
                    isChecked = value;
                    if (isChecked)
                        checkBoxPictureBox.Image = checkedBitmap;
                    else
                        checkBoxPictureBox.Image = uncheckedBitmap;

                }
            }
        }
        private bool isChecked = false;

        #endregion

        #endregion

    }
}
