using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STSGui
{
    public class LabelExtended : Label
    {

        #region Constructor

        public LabelExtended():base()
        {
            UpdateEnableStatusTextColor();
            UpdateEnableStatusTextColor();
        }

        #endregion

        #region Public Functions

        public void PurentMouseEnter()
        {
            if (this.Enabled)
                this.ForeColor = MouseOverTextColor;
        }
        public void PurentMouseLeave()
        {
            UpdateEnableStatusTextColor();
        }
        public void PurentMouseDown()
        {
            this.ForeColor = MouseDownTextColor;
        }
        public void PurentMouseUp()
        {
            UpdateEnableStatusTextColor();
        }

        #endregion

        #region Property

        [Bindable(true)]
        [Localizable(true)]
        [IODescriptionAttribute("MouseDownTextColorDescr")]
        public Color MouseDownTextColor { get; set; }

        [Bindable(true)]
        [Localizable(true)]
        [IODescriptionAttribute("MouseOverTextColorDescr")]
        public Color MouseOverTextColor { get; set; }

        [Bindable(true)]
        [Localizable(true)]
        [IODescriptionAttribute("NormalTextColorDescr")]
        public Color NormalTextColor
        {
            get
            {
                return normalTextColor;
            }
            set
            {
                normalTextColor = value;
                UpdateEnableStatusTextColor();
            }
        }
        private Color normalTextColor = Color.Black;

        [Bindable(true)]
        [Localizable(true)]
        [IODescriptionAttribute("DisableTextColorDescr")]
        public Color DisableTextColor
        {
            get
            {
                return disableTextColor;
            }
            set
            {
                disableTextColor = value;
                UpdateEnableStatusTextColor();
            }
        }
        private Color disableTextColor = Color.Black;

        #endregion

        #region Protected Override Functions

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.Enabled)
                this.ForeColor = MouseDownTextColor;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
 //           if (this.Enabled)
                base.OnMouseUp(e);

            //bool res = this.ClientRectangle.Contains(this.PointToClient(Cursor.Position));

            //if (this.Enabled && res)
            //    this.ForeColor = MouseOverTextColor;
            //else
                UpdateEnableStatusTextColor();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
  //          if (this.Enabled)
                base.OnMouseEnter(e);
            if (this.Enabled)
                this.ForeColor = MouseOverTextColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
  //          if (this.Enabled)
                base.OnMouseLeave(e);
            UpdateEnableStatusTextColor();

        }

        protected override void OnClick(EventArgs e)
        {
 //           if (this.Enabled)
                base.OnClick(e);
            UpdateEnableStatusTextColor();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            UpdateEnableStatusTextColor();
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if(this.Visible)
            {
                Point mousePoint = this.PointToClient(Cursor.Position);
                if(!this.ClientRectangle.Contains(mousePoint))
                {
                    UpdateEnableStatusTextColor();
                    //Invalidate();
                }
            }
        }

        #endregion

        #region Private Functions

        private void UpdateEnableStatusTextColor()
        {
            if (this.Enabled)
                this.ForeColor = NormalTextColor;
            else
                this.ForeColor = DisableTextColor;
        }

        #endregion

    }
}
