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
    public class RoundedCornersPictureBoxForVideoStream : PictureBox
    {
        public int Radius
        {
            get;
            set;
        }
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
            catch(Exception ee)
            {

            }
            base.OnResize(e);
        }
        public bool IsOverrideCreateParams
        {
            get => isOverrideCreateParams;
            set => isOverrideCreateParams = value;
        }
        private bool isOverrideCreateParams = false;

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
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Radius == 0)
            {
                base.OnPaint(e);
                return;
            }

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
            base.OnPaint(e);
        }
    }
}
