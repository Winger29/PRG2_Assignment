using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10270275_PRG2Assignment
{
    class BoardingGate
    {
        private string gatename;
        private bool supportscfft;
        private bool supportsddjb;
        private bool supportslwtt;

        public Flight flight { get; set; }

        public string gateName
        {
            get { return gatename; }
            set { gatename = value; }
        }

        public bool supportsCFFT
        {
            get { return supportscfft; }
            set { supportscfft = value; }
        }

        public bool supportsDDJB
        {
            get { return supportsddjb; }
            set { supportsddjb = value; }
        }

        public bool supportsLWTT
        {
            get { return  supportsLWTT; }
            set { supportsLWTT = value; }
        }

        public BoardingGate(Flight flight, string Gname, bool cfft, bool ddjb, bool lwtt)
        {
            Flight = flight;
            gateName = Gname;
            supportsCFFT = cfft;
            supportsDDJB = ddjb;
            supportsLWTT = lwtt;
            
        }
    }
}
