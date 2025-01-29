using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10270275_PRG2Assignment
{
    class CFFTFlight:Flight
    {
        private double requestfee;

        public double requestFee
        {
            get { return requestfee; }
            set { requestfee = value; }
        }
        public CFFTFlight(string fnum, string ori, string dest, DateTime expected,string status ,double rfee) : base(fnum, ori, dest, expected,status)
        {
            requestFee = rfee;
        }

        public override double CalculateFees()
        {
            return 300 + requestFee;
        }
    }
}
