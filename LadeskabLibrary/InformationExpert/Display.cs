using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public class Display : IDisplay
    {
        public string ConsoleString { get; set; }

        public void PrintChargingComplete()
        {
            ConsoleString = "Mobilelefon er fuld opladt";
            Console.WriteLine(ConsoleString);
        }

        public void PrintChargingError()
        {
            ConsoleString = "Fejl. Evt. kortslutning. Frakobel usb lader.";
            Console.WriteLine(ConsoleString);
        }

        public void PrintChargingMobile()
        {
            ConsoleString = "Oplader mobil";
            Console.WriteLine(ConsoleString);
        }

        public void PrintConnectingError()
        {
            ConsoleString = "Tilslutningsfejl.\r\n Tjek at mobiltelefon er tilsluttet korrekt";
            Console.WriteLine(ConsoleString);
        }

        public void PrintConnectMobile()
        {
            ConsoleString = "Tilslut mobiltelefon";
            Console.WriteLine(ConsoleString);
        }

        public void PrintOccupied()
        {
            ConsoleString = "Skabet er låst og din mobiltelefon lades. Brug dit RFID tag til at låse op.";
            Console.WriteLine(ConsoleString);
        }

        public void PrintRemoveMobile()
        {
            ConsoleString = "Fjern mobiltelefon fra skab og luk døren";
            Console.WriteLine(ConsoleString);
        }

        public void PrintRFIDError()
        {
            ConsoleString = "RFID fejl";
            Console.WriteLine(ConsoleString);
        }

        public void PrintScanRFID()
        {
            ConsoleString = "Indlæs RFID";
            Console.WriteLine(ConsoleString);
        }
    }
}
