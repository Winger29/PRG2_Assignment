using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10270275_PRG2Assignment
{
    class NORMFlight: Flight
    {
        public NORMFlight(string fnum,string ori,string dest,string status ,DateTime expected) : base(fnum,ori,dest,expected,status)
        { 
        }

        public override double CalculateFees()
        {
            return 300;
        }
    }
}
