using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10270275_PRG2Assignment
{
    class DDJBFlight:Flight
    {
        public DDJBFlight(string fnum, string ori, string dest, DateTime expected, string status) : base(fnum, ori, dest, expected, status)
        {
        }

        public override double CalculateFees()
        {
            return 300 + 300;
        }
    }
}
