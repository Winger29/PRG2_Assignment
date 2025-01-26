using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10270275_PRG2Assignment
{
    class Terminal
    {
        private string terminalname;

        public string terminalName
        {
            get { return terminalname; } 
            set {  terminalname = value; }
        }

        public Dictionary<string, Airline> Airlines = new Dictionary<string, Airline>();
        public Dictionary<string, Flight> Flights = new Dictionary<string, Flight>();
        public Dictionary<string, BoardingGate> boardingGates = new Dictionary<string, BoardingGate>();
        public Dictionary<string, double> gateFees = new Dictionary<string, double>();

        public Terminal(string tname)
        {
            terminalname = tname;
        }

        public bool AddAirline(Airline airline)
        {

        }
    }
}
