using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class PrintData
    {
        public string PrinterName { get; set; }

        public PrinterColors PrinterColor { get; set; }

        public uint Copies { get; set; }

        public Bitmap ReportBitmap
        {
            get;
            set;
        } = null;

}

    public enum PrinterColors
    {
        Black_and_White,
        Color
    }

}
