using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STSGui
{
    public class ComboBoxClean : ComboBox
    {
        #region Constructor

        public ComboBoxClean()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            DrawMode = DrawMode.OwnerDrawFixed;
        }

        #endregion

        #region Protected Override Functions

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Color textColor = e.ForeColor;

            if ((e.State & DrawItemState.Focus) != DrawItemState.Focus)
                e.DrawBackground();
            else
                textColor = this.ForeColor;// Color.Black;

            e.DrawFocusRectangle();
            var index = e.Index;
            if (index < 0 || index >= Items.Count) return;
            var item = Items[index];

            string text = (item == null) ? "(null)" : item.ToString();
            using (var brush = new SolidBrush(textColor))
            {
                Rectangle rect = e.Bounds;
                rect.Inflate(2,0);
                rect.Width += 5;
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                //e.Graphics.DrawString(text, Font, brush, e.Bounds);
                e.Graphics.DrawString(text, Font, brush, rect);
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            ButtonPictureBox.SoundPlay();

        }
        protected override void OnSelectionChangeCommitted(EventArgs e)
        {
            base.OnSelectionChangeCommitted(e);
            ButtonPictureBox.SoundPlay();
        }

        #endregion
    }
}
