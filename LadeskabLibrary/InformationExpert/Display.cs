using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public class Display : IDisplay
    {
        public void PrintChargingComplete()
        {
            Console.WriteLine("Mobil er fuld opladt");
        }

        public void PrintChargingError()
        {
            Console.WriteLine("Fejl. Evt. kortslutning. Frakobel usb lader.");
        }

        public void PrintChargingMobile()
        {
            Console.WriteLine("Oplader mobil");
        }

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
            Console.WriteLine("Fjern mobiltelefon fra skab og luk døren");
        }

        public void PrintRFIDError()
        {
            Console.WriteLine("Forkert RFID tag");
        }

        public void PrintScanRFID()
        {
            Console.WriteLine("Indlæs RFID");
        }
    }
}
