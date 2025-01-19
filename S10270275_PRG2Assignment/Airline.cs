using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10270275_PRG2Assignment
{
    class Airline
    {
        private string name;
        private string code;
        private Dictionary<string, Flight> flights;

        public string Name
        {
            get {  return name; }
            set { name = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public Dictionary<string, Flight> Flights = new Dictionary<string, Flight>();

        public Airline(string name, string code)
        {

        }
    }
}
