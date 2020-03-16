using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public class Display : IDisplay
    {
        public void PrintConnectingError()
        {
            Console.WriteLine("Tilslutningsfejl.\r\n Tjek at mobiltelefon er tilsluttet korrekt");
        }

        public void PrintConnectMobile()
        {
            Console.WriteLine("Tilslut mobiltelefon");
        }

        public void PrintOccupied()
        {
            Console.WriteLine("Ladeskab er optaget");
        }

        public void PrintRemoveMobile()
        {
            Console.WriteLine("Fjern mobiltelefon");
        }

        public void PrintRFIDError()
        {
            Console.WriteLine("RFID fejl");
        }

        public void PrintScanRFID()
        {
            Console.WriteLine("Indlæs RFID");
        }
    }
}
