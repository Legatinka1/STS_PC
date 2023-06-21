using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class MonthlyTest
    {
        public MonthlyTest()
        {

        }

        public MonthlyTest(int spiro, int gass, int dlco)
        {
            Spirometria = spiro;
            GassFlow = gass;
            DLCO = dlco;
        }

        public MonthlyTest(MonthlyTest other)
        {
            Spirometria = other.Spirometria;
            GassFlow = other.GassFlow;
            DLCO = other.DLCO;
        }

        public int Spirometria
        {
            get;
            set;
        }

        public int GassFlow
        {
            get;
            set;
        }

        public int DLCO
        {
            get;
            set;
        }

        public int GetSum()
        {
            return Spirometria + GassFlow + DLCO;
        }
    }
}
