using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10270275_PRG2Assignment
{
    abstract class Flight
    {
        private string flightnumber;
        private string origin;
        private string destination;
        private DateTime expectedtime;
        private string status;

        public string FlightNumber 
        { 
            get { return flightnumber; } 
            set { flightnumber = value; }
        }

        public string Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        public DateTime expectedTime
        {
            get { return expectedtime; }
            set { expectedtime = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public Flight(string Fnum, string Ori, string Dest, DateTime expectedtime, string status)
        {
            FlightNumber = Fnum;
            Origin = Ori;
            Destination = Dest; 
            expectedTime = expectedtime;
            Status = status;
        }

        public abstract double CalculateFees();
    }
}
