using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STSGui
{
    public class RoundedCornersPanel : Panel
    {
        public int Radius
        {
            get
            {
                return radius;
            }
            set
            {
 //               if(radius!=value)
                {
                    radius = value;
                    OnResizeImpl();
                }
            }
        }
        private int radius = 0;
        protected override void OnResize(EventArgs e)
        {
            OnResizeImpl();
            base.OnResize(e);
        }

        private void OnResizeImpl()
        {
            if (Radius == 0)
                return;

            //if (this.DesignMode)
            //    return;
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
        }
    }
}
