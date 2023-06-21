using CommonLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STSGui
{
    public static class GuiUtils
    {
        #region MethodInvoker

        public static T InvokeIfRequired<T>(this Control control, Func<T> action)
        {
            if (control.InvokeRequired)
            {
                try
                {
                    object iarResult = control.Invoke(action);
                    return (T)iarResult;
                }
                catch (ThreadInterruptedException) { return Activator.CreateInstance<T>(); }
                catch (ObjectDisposedException) { return Activator.CreateInstance<T>(); }
            }
            else
            {
                return action();
            }
        }

        public static void InvokeIfRequired(this Control control, MethodInvoker action, bool bWait = false)
        {
            if (control.InvokeRequired)
            {
                try
                {
                    if (bWait)
                        control.Invoke(action, new object[] { control });
                    else
                        control.BeginInvoke(action, new object[] { control });
                }
                catch (ThreadInterruptedException) { }
                catch (ObjectDisposedException) { }
            }
            else
            {
                action();
            }
        }



        public static void ForAll<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (T item in sequence)
                action(item);
        }

        #endregion
        public static Bitmap Superimpose(Bitmap largeBmp, Bitmap smallBmp, int xExternalShift = 1, int yExternalShift = 0)
        {
            Graphics g = Graphics.FromImage(largeBmp);
            smallBmp.MakeTransparent();
            //int margin = 3;
            //int x = largeBmp.Width - smallBmp.Width - margin;
            //int y = largeBmp.Height - smallBmp.Height - margin;
            int x = (largeBmp.Width - smallBmp.Width) / 2 + xExternalShift;
            int y = (largeBmp.Height - smallBmp.Height) / 2 + yExternalShift;
            g.DrawImage(smallBmp, new Rectangle(x, y, smallBmp.Width,smallBmp.Height   ));
            return largeBmp;
        }

        public static Bitmap SuperimposeLeftRight(Bitmap leftBmp, Bitmap rightBmp, int xExternalRightShift = 0, int yExternalRightShift = 0)
        {
            int width = leftBmp.Width + rightBmp.Width + xExternalRightShift;
            int height = Math.Max(leftBmp.Height, rightBmp.Height);
            Bitmap newBitmap = new Bitmap(width, height);
            newBitmap.MakeTransparent();
            Graphics g = Graphics.FromImage(newBitmap);
            leftBmp.MakeTransparent();
            rightBmp.MakeTransparent();

            int yLeft = 0;
            int yRight = 0;
            int delta = Math.Abs((leftBmp.Height - rightBmp.Height) / 2);
            if (leftBmp.Height > rightBmp.Height)
                yRight = delta;
            else if (leftBmp.Height < rightBmp.Height)
                yLeft = delta;

            int xLeft = 0;
            g.DrawImage(leftBmp, new Point(xLeft, yLeft));

            int xRight = leftBmp.Width + xExternalRightShift;
            g.DrawImage(rightBmp, new Point(xRight, yRight));

            return newBitmap;
        }


        public static Bitmap SuperimposeTopBottom(Bitmap topBmp, Bitmap bottomBmp, int xExternalBottomShift = 0, int yExternalBottomShift = 0)
        {
            int height = topBmp.Height + bottomBmp.Height + yExternalBottomShift;
            int width = Math.Max(topBmp.Width, bottomBmp.Width);
            Bitmap newBitmap = new Bitmap(width, height);
            newBitmap.MakeTransparent();
            Graphics g = Graphics.FromImage(newBitmap);
            topBmp.MakeTransparent();
            bottomBmp.MakeTransparent();

            int xTop = 0;
            int xBottom = 0;
            int delta = Math.Abs((topBmp.Width - bottomBmp.Width) / 2);
            if (topBmp.Width > bottomBmp.Width)
                xBottom = delta;
            else if (topBmp.Width < bottomBmp.Width)
                xTop = delta;

            int yTop = 0;
            g.DrawImage(topBmp, new Point(xTop, yTop));

            int yBottom = topBmp.Height + yExternalBottomShift;
            g.DrawImage(bottomBmp, new Point(xBottom, yBottom));

            return newBitmap;
        }

        public static void SetNewLocation(Control control, Control container)
        {
            control.Location = new Point(control.Location.X - container.Location.X, control.Location.Y - container.Location.Y);
        }
        public static void SetControlInCenterVertical(Control c, Size fatherControlSize)
        {

            int newYpos = fatherControlSize.Height / 2 - c.Height / 2;
            c.Location = new Point(c.Location.X, newYpos);
        }
        public static void SetControlInCenterHorizonal(Control c, Size fatherControlSize)
        {
            int newXpos = fatherControlSize.Width / 2 - c.Width / 2;
            c.Location = new Point(newXpos, c.Location.Y);
        }
    }
}
