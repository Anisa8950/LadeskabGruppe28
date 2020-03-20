using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LadeskabLibrary;

namespace LadeskabGruppe28
{
    class Program
    {
        static void Main(string[] args)
        {
            // Assemble your system here from all the classes
            Display _display = new Display();
            Door _door = new Door();
            LogFile _logFile = new LogFile();
            RFReader _RFReader = new RFReader();
            UsbCharger _usbCharger = new UsbCharger();

            ChargeControl _chargeControl = new ChargeControl(_usbCharger, _display);
            StationControl _stationControl = new StationControl(_display, _door, _logFile, _RFReader, _chargeControl);
            

            bool finish = false;

            System.Console.WriteLine("Q: Quit ");
            System.Console.WriteLine("1: Open døren");
            System.Console.WriteLine("2: Tilslut telefonen");
            System.Console.WriteLine("3: Luk døren");
            System.Console.WriteLine("4: Indlæs RFID");
            do
            {                
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'Q':
                    case 'q':
                        finish = true;
                        break;

                    case '1':
                        _door.SetDoorStateOpen();
                        break;

                    case '2':
                        _chargeControl.CurrentValue = 1;
                        break;

                    case '3':
                        _door.SetDoorStateClose();
                        break;

                    case '4':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();

                        _stationControl.RfidDetected(Convert.ToInt32(idString));                        
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }
    }
}
