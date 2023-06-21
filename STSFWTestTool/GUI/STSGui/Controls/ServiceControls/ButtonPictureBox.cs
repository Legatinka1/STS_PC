using CommonLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STSGui
{
    public class ButtonPictureBox : PictureBox
    {
        #region Events
        public event Action OnTouchDown;
        public event Action OnTouchUp;
        #endregion

        #region Private Members

        Rectangle mouseActivRect = new Rectangle();
        bool isEnter = false;

        #endregion

        #region Constructor

        public ButtonPictureBox() : base()
        {
            mouseActivRect = this.ClientRectangle;
            mouseActivRect.Inflate(xInflateMouseRect, yInflateMouseRect);
            UpdateEnableStatusImage();
            this.ControlRemoved += ButtonPictureBox_ControlRemoved;
            this.ControlAdded += ButtonPictureBox_ControlAdded;
            UpdateEnableStatusImage();
        }

        #endregion

        #region Sound

        #region Events

        public static event Action OnSoundPlay;

        #endregion

        #region Public Static Functions

        public static void SoundPlay()
        {
            OnSoundPlay?.Invoke();
        }
        #endregion

        #endregion

        #region Public Functions

        public void RefreshImage()
        {
            if (NormalImage != null)
            {
                this.Image = NormalImage;

            }
          


        }
        public void UnsubscrubeFromControlMouseEvents(Control control)
        {
            if (control == null)
                return;
            try
            {
                control.MouseDown -= Control_MouseDown;
                control.MouseUp -= Control_MouseUp;
                control.MouseEnter -= Control_MouseEnter;
                control.MouseLeave -= Control_MouseLeave;
                control.MouseClick -= Control_MouseClick;
            }
            catch (Exception ee)
            {

            }

        }

        //public void SetUnFocus()
        //{
        //    UpdateEnableStatusImage();
        //    Invalidate();
        //}

        #endregion

        #region Property

        [Bindable(true)]
        [Localizable(true)]
        [IODescriptionAttribute("PictureBoxImageDescr")]
        public Image MouseDownImage { get; set; }

        [Bindable(true)]
        [Localizable(true)]
        [IODescriptionAttribute("PictureBoxImageDescr")]
        public Image MouseOverImage { get; set; }

        [Bindable(true)]
        [Localizable(true)]
        [IODescriptionAttribute("PictureBoxImageDescr")]
        public Image NormalImage
        {
            get
            {
                return normalImage;
            }
            set
            {
                normalImage = value;
                UpdateEnableStatusImage();
            }
        }
        private Image normalImage = null;

        [Bindable(true)]
        [Localizable(true)]
        [IODescriptionAttribute("PictureBoxImageDescr")]
        public Image DisableImage
        {
            get
            {
                return disableImage;
            }
            set
            {
                disableImage = value;
                UpdateEnableStatusImage();
            }
        }
        private Image disableImage = null;

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Color TextColor
        {
            get
            {
                return textColor;
            }
            set
            {
                textColor = value;
            }
        }
        public Color textColor = Color.Black;

        [Bindable(true)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text { get; set; }


        [Bindable(true)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Font TextFont
        {
            get
            {
                return textFont;
            }
            set
            {
                textFont = value;
            }
        }
        private Font textFont = DefaultFont;

        [Bindable(true)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public int XTextOffset
        {
            get
            {
                return xTextOffset;
            }
            set
            {
                xTextOffset = value;
            }
        }
        private int xTextOffset = 0;

        [Bindable(true)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public int YTextOffset
        {
            get
            {
                return yTextOffset;
            }
            set
            {
                yTextOffset = value;
            }
        }
        private int yTextOffset = 0;

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
            }
        }
        private Color disableTextColor = Color.Black;

        [Bindable(true)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public bool IsTextColorMouseChanged
        {
            get
            {
                return isTextColorMouseChanged;
            }
            set
            {
                isTextColorMouseChanged = value;
            }
        }
        private bool isTextColorMouseChanged = false;


        [Bindable(true)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(typeof(int), "0")]
        public int InflateMouseRect_X
        {
            get
            {
                return xInflateMouseRect;
            }
            set
            {
                xInflateMouseRect = value;
                try
                {
                    mouseActivRect = this.ClientRectangle;
                    mouseActivRect.Inflate(xInflateMouseRect, yInflateMouseRect);
                }
                catch (Exception ee)
                {

                }
            }
        }
        private int xInflateMouseRect = 0;

        [Bindable(true)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(typeof(int), "0")]
        public int InflateMouseRect_Y
        {
            get
            {
                return yInflateMouseRect;
            }
            set
            {
                yInflateMouseRect = value;
                try
                {
                    mouseActivRect = this.ClientRectangle;
                    mouseActivRect.Inflate(xInflateMouseRect, yInflateMouseRect);
                }
                catch (Exception ee)
                {

                }
            }
        }
        private int yInflateMouseRect = 0;
        #endregion

        #region Protected Override Functions

        protected override void OnPaint(PaintEventArgs pe)
        {
            //if(enabled)
            base.OnPaint(pe);
            if (string.IsNullOrEmpty(Text))
                return;

            SolidBrush blackSolidBrush = new SolidBrush(TextColor);
            SizeF stringSize = pe.Graphics.MeasureString(Text, TextFont);
            int x = 0, y = 0;
            x = (int)(((float)ClientRectangle.Width - stringSize.Width) / 2) + xTextOffset;
            y = (int)(((float)ClientRectangle.Height - stringSize.Height) / 2) + yTextOffset;
            pe.Graphics.DrawString(Text, TextFont, blackSolidBrush, x, y);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            //if (this.Name== "patientsRightTopPictureBox")
            //{
            //    Console.WriteLine("Mouse Down");
            //}
            if (this.Enabled)
                SoundPlay();

            base.OnMouseDown(e);
            //           if (xInflateMouseRect != 0 || yInflateMouseRect != 0)
            {
                Point coordinates = new Point(e.X, e.Y);// this.PointToClient(Cursor.Position);
                //StringBuilder sb = new StringBuilder();
                //sb.AppendLine();
                //sb.AppendLine("In OnMouseUp:");
                //sb.AppendLine($"mouseActivRect: {mouseActivRect.X},{mouseActivRect.Y},{mouseActivRect.Width},{mouseActivRect.Height}");
                //sb.AppendLine($"coordinates: {coordinates.X},{coordinates.Y}");

                //LoggerWrapper.Log(LogLevel.Debug, sb.ToString());
                if (!mouseActivRect.Contains(coordinates))
                    return;
            }
            if (this.Enabled)
            {
                if (MouseDownImage != null)
                {
                    this.Image = MouseDownImage;
                }
              

            }
           


            if (IsTextColorMouseChanged)
            {
                if (this.Enabled)
                    this.textColor = MouseDownTextColor;
                else
                    this.textColor = DisableTextColor;
            }

            foreach (Control item in this.Controls)
            {
                if (item.GetType() == typeof(LabelExtended))
                {
                    ((LabelExtended)item).PurentMouseDown();
                }
            }
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            //if (this.Name == "patientsRightTopPictureBox")
            //{
            //    Console.WriteLine("Mouse up");
            //}
            //           if (this.Enabled)
            base.OnMouseUp(e);
            bool res = true;
            //           if (xInflateMouseRect != 0 || yInflateMouseRect != 0)
            {
                Point coordinates = new Point(e.X, e.Y); // this.PointToClient(Cursor.Position);
                //StringBuilder sb = new StringBuilder();
                //sb.AppendLine();
                //sb.AppendLine("In OnMouseUp:");
                //sb.AppendLine($"mouseActivRect: {mouseActivRect.X},{mouseActivRect.Y},{mouseActivRect.Width},{mouseActivRect.Height}");
                //sb.AppendLine($"coordinates: {coordinates.X},{coordinates.Y}");

                //LoggerWrapper.Log(LogLevel.Debug, sb.ToString());
                if (!mouseActivRect.Contains(coordinates))
                    return;
                res = this.ClientRectangle.Contains(this.PointToClient(Cursor.Position));
            }

            //if (this.Enabled && MouseOverImage != null && res)
            //    this.Image = MouseOverImage;
            //else
            UpdateEnableStatusImage();

            if (IsTextColorMouseChanged)
            {
                if (this.Enabled)
                    this.textColor = MouseOverTextColor;// NormalTextColor;
                else
                    this.textColor = DisableTextColor;
            }
            foreach (Control item in this.Controls)
            {
                if (item.GetType() == typeof(LabelExtended))
                {
                    ((LabelExtended)item).PurentMouseUp();
                }
            }
            Invalidate();

        }

        protected override void OnMouseEnter(EventArgs e)
        {
            // if (this.Name == "patientsRightTopPictureBox")
            //{
            //     Console.WriteLine("Mouse Enter");

            // }
            //          if (this.Enabled)
            base.OnMouseEnter(e);
            //            if (xInflateMouseRect != 0 || yInflateMouseRect != 0)
            {
                Point coordinates =  this.PointToClient(Cursor.Position);
                //StringBuilder sb = new StringBuilder();
                //sb.AppendLine();
                //sb.AppendLine("In OnMouseEnter:");
                //sb.AppendLine($"mouseActivRect: {mouseActivRect.X},{mouseActivRect.Y},{mouseActivRect.Width},{mouseActivRect.Height}");
                //sb.AppendLine($"coordinates: {coordinates.X},{coordinates.Y}");

                //LoggerWrapper.Log(LogLevel.Debug, sb.ToString());
                if (!mouseActivRect.Contains(coordinates))
                    return;
            }
            isEnter = true;
            if (this.Enabled && MouseOverImage != null)
            {
                this.Image = MouseOverImage;
            }
           

            if (IsTextColorMouseChanged)
            {
                if (this.Enabled)
                    this.textColor = MouseOverTextColor;
                else
                    this.textColor = DisableTextColor;
            }

            foreach (Control item in this.Controls)
            {
                if (item.GetType() == typeof(LabelExtended))
                {
                    ((LabelExtended)item).PurentMouseEnter();
                }
            }
            Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            //if (this.Name == "patientsRightTopPictureBox")
            //{
            //    Console.WriteLine("Mouse Move");
            //}

            base.OnMouseMove(e);
            //            if (xInflateMouseRect != 0 || yInflateMouseRect != 0)
            {
                if (!mouseActivRect.Contains(e.Location))
                {
                    if (isEnter)
                        OnMouseLeave((EventArgs)e);
                }
                else
                {
                    if (!isEnter)
                        OnMouseEnter((EventArgs)e);

                }
            }
            //if (!mouseActivRect.Contains(e.Location) && isEnter)
            //    OnMouseLeave((EventArgs)e);

        }

        protected override void OnMouseLeave(EventArgs e)
        {
            //Point coordinates = this.PointToClient(Cursor.Position);
            //if (!mouseActivRect.Contains(coordinates))
            //    return;
            //          if (this.Enabled)
            isEnter = false;
            base.OnMouseLeave(e);
            UpdateEnableStatusImage();

            if (IsTextColorMouseChanged)
            {
                if (this.Enabled)
                    this.textColor = NormalTextColor;
                else
                    this.textColor = DisableTextColor;
            }
            foreach (Control item in this.Controls)
            {
                if (item.GetType() == typeof(LabelExtended))
                {
                    ((LabelExtended)item).PurentMouseLeave();
                }
            }
            Invalidate();

        }

        protected override void OnClick(EventArgs e)
        {
            //           if (xInflateMouseRect != 0 || yInflateMouseRect != 0)
            {
                Point coordinates = this.PointToClient(Cursor.Position);
                //StringBuilder sb = new StringBuilder();
                //sb.AppendLine();
                //sb.AppendLine("In OnClick:");
                //sb.AppendLine($"mouseActivRect: {mouseActivRect.X},{mouseActivRect.Y},{mouseActivRect.Width},{mouseActivRect.Height}");
                //sb.AppendLine($"coordinates: {coordinates.X},{coordinates.Y}");

                //LoggerWrapper.Log(LogLevel.Debug, sb.ToString());
                if (!mouseActivRect.Contains(coordinates))
                    return;
            }
            //           if (this.Enabled)
            //MessageBox.Show($" In OnClick");
            base.OnClick(e);
            foreach (Control item in this.Controls)
            {
                if (item.GetType() == typeof(LabelExtended))
                {
                    ((LabelExtended)item).PurentMouseUp();
                }
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            UpdateEnableStatusImage();
            if (IsTextColorMouseChanged)
            {
                if (this.Enabled)
                    this.textColor = NormalTextColor;
                else
                    this.textColor = DisableTextColor;
            }
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (this.Visible)
            {
                Point mousePoint = this.PointToClient(Cursor.Position);
                if (!this.ClientRectangle.Contains(mousePoint))
                {
                    UpdateEnableStatusImage();
                    //Invalidate();
                }
                mouseActivRect = this.ClientRectangle;
                mouseActivRect.Inflate(xInflateMouseRect, yInflateMouseRect);

            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            mouseActivRect = this.ClientRectangle;
            mouseActivRect.Inflate(xInflateMouseRect, yInflateMouseRect);
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            mouseActivRect = this.ClientRectangle;
            mouseActivRect.Inflate(xInflateMouseRect, yInflateMouseRect);
        }
        #endregion

        #region Private Functions

        private void UpdateEnableStatusImage()
        {
            if (this.Enabled)
            {
                //Point mousePoint = this.PointToClient(Cursor.Position);
                //if (this.ClientRectangle.Contains(mousePoint))
                //{
                //    if (MouseOverImage != null)
                //        this.Image = MouseOverImage;

                //}
                //else
                //{
                //    if (NormalImage != null)
                //        this.Image = NormalImage;
                //}
                this.Image = NormalImage;

            }
            else
            {
                if (DisableImage != null)
                {
                    this.Image = DisableImage;
                }

            }
        }

        private void ButtonPictureBox_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.MouseDown += Control_MouseDown;
            e.Control.MouseUp += Control_MouseUp;
            e.Control.MouseEnter += Control_MouseEnter;
            e.Control.MouseLeave += Control_MouseLeave;
            e.Control.MouseClick += Control_MouseClick;
        }

        private void ButtonPictureBox_ControlRemoved(object sender, ControlEventArgs e)
        {
            try
            {
                e.Control.MouseDown -= Control_MouseDown;
                e.Control.MouseUp -= Control_MouseUp;
                e.Control.MouseEnter -= Control_MouseEnter;
                e.Control.MouseLeave -= Control_MouseLeave;
                e.Control.MouseClick -= Control_MouseClick;
            }
            catch (Exception ee)
            {

            }
        }

        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void Control_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void UpdateEnableStatusTextColor()
        {
            if (IsTextColorMouseChanged)
            {
                if (this.Enabled)
                    this.textColor = NormalTextColor;
                else
                    this.textColor = DisableTextColor;
            }
        }
        #endregion

    }
}
