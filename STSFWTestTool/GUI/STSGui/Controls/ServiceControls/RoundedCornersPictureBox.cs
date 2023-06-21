using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STSGui
{
    public class RoundedCornersPictureBox : PictureBox
    {
        #region Property

        public int Radius
        {
            get;
            set;
        }
        public bool IsOverrideCreateParams
        {
            get => isOverrideCreateParams;
            set => isOverrideCreateParams = value;
        }
        private bool isOverrideCreateParams = false;

        #endregion

        #region Protected Override Functions

        protected override void OnResize(EventArgs e)
        {

            //if (this.DesignMode)
            //    return;
            if (Radius == 0)
                return;

            try
            {
                Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
                System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
                gp.AddArc(r.X, r.Y, Radius, Radius, 180, 90);
                gp.AddArc(r.X + r.Width - Radius, r.Y, Radius, Radius, 270, 90);
                gp.AddArc(r.X + r.Width - Radius, r.Y + r.Height - Radius, Radius, Radius, 0, 90);
                gp.AddArc(r.X, r.Y + r.Height - Radius, Radius, Radius, 90, 90);
                this.Region = new Region(gp);
            }
            catch (Exception ee)
            {

            }
            base.OnResize(e);
        }
        protected override void OnLocationChanged(EventArgs e)
        {
            if (this.Parent != null)
                this.Parent.Invalidate();
            base.OnLocationChanged(e);
            if (this.Parent != null)
                this.Parent.Invalidate();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (IsOverrideCreateParams)
                    cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            ButtonPictureBox.SoundPlay();
        }

        #endregion


        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    if (Radius == 0)
        //    {
        //        base.OnPaint(e);
        //        return;
        //    }

        //    try
        //    {
        //        Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
        //        System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
        //        gp.AddArc(r.X, r.Y, Radius, Radius, 180, 90);
        //        gp.AddArc(r.X + r.Width - Radius, r.Y, Radius, Radius, 270, 90);
        //        gp.AddArc(r.X + r.Width - Radius, r.Y + r.Height - Radius, Radius, Radius, 0, 90);
        //        gp.AddArc(r.X, r.Y + r.Height - Radius, Radius, Radius, 90, 90);
        //        this.Region = new Region(gp);

        //    }
        //    catch (Exception ee)
        //    {

        //    }
        //    base.OnPaint(e);
        //}

        protected override void OnPaintBackground(PaintEventArgs e)
        // Paint background with underlying graphics from other controls
        {

            base.OnPaintBackground(e);

//            return;
            Graphics g = e.Graphics;

            if (Parent != null)
            {
                // Take each control in turn
                int index = Parent.Controls.GetChildIndex(this);
                for (int i = Parent.Controls.Count - 1; i > index; i--)
                {
                    Control c = Parent.Controls[i];

                    // Check it's visible and overlaps this control
                    if (c.Bounds.IntersectsWith(Bounds) && c.Visible)
                    {
                        // Load appearance of underlying control and redraw it on this background
                        Bitmap bmp = new Bitmap(c.Width, c.Height, g);
                        c.DrawToBitmap(bmp, c.ClientRectangle);
                        g.TranslateTransform(c.Left - Left, c.Top - Top);
                        g.DrawImageUnscaled(bmp, Point.Empty);
                        g.TranslateTransform(Left - c.Left, Top - c.Top);
                        bmp.Dispose();
                    }
                }
            }
        }










        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    if (Radius == 0)
        //    {
        //        base.OnPaint(e);
        //        return;
        //    }

        //    try
        //    {
        //        Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
        //        System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
        //        gp.AddArc(r.X, r.Y, Radius, Radius, 180, 90);
        //        gp.AddArc(r.X + r.Width - Radius, r.Y, Radius, Radius, 270, 90);
        //        gp.AddArc(r.X + r.Width - Radius, r.Y + r.Height - Radius, Radius, Radius, 0, 90);
        //        gp.AddArc(r.X, r.Y + r.Height - Radius, Radius, Radius, 90, 90);
        //        this.Region = new Region(gp);

        //    }
        //    catch (Exception ee)
        //    {

        //    }
        //    base.OnPaint(e);
        //}

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    //            using (GraphicsPath gp = new GraphicsPath())
        //    //            {
        //    //                Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
        //    ////                System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
        //    //                int d = 50;
        //    //                gp.AddArc(r.X, r.Y, d, d, 180, 90);
        //    //                gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);
        //    //                gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
        //    //                gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);
        //    //                this.Region = new Region(gp);
        //    //                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        //    //                //gp.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
        //    //                //Region = new Region(gp);
        //    //                //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        //    //                //e.Graphics.DrawEllipse(new Pen(new SolidBrush(this.BackColor), 1), 0, 0, this.Width - 1, this.Height - 1);
        //    //            }

        //    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        //    //e.Graphics.Clear(panel1.Parent.BackColor);
        //    Control control = this;
        //    int radius = 60;
        //    using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
        //    {
        //        path.AddLine(radius, 0, control.Width - radius, 0);
        //        path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
        //        path.AddLine(control.Width, radius, control.Width, control.Height - radius);
        //        path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
        //        path.AddLine(control.Width - radius, control.Height, radius, control.Height);
        //        path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
        //        path.AddLine(0, control.Height - radius, 0, radius);
        //        path.AddArc(0, 0, radius, radius, 180, 90);
        //        Region = new Region(path);
        //        using (SolidBrush brush = new SolidBrush(control.BackColor))
        //        {
        //            e.Graphics.FillPath(brush, path);
        //        }
        //    }
        //    base.OnPaint(e);
        //}
    }
}
