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

        public Terminal(string terminalname, string terminalName, Dictionary<string, Airline> airlines, Dictionary<string, Flight> flights, Dictionary<string, BoardingGate> boardingGates, Dictionary<string, double> gateFees)
        {
            this.terminalname = terminalname;
            this.terminalName = terminalName;
            Airlines = airlines;
            Flights = flights;
            this.boardingGates = boardingGates;
            this.gateFees = gateFees;
        }
    }
}
