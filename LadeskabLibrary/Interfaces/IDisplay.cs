using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public interface IDisplay
    {
        string ConsoleString { get; set; }

        void PrintConnectMobile();
        void PrintScanRFID();
        void PrintConnectingError();
        void PrintOccupied();
        void PrintRFIDError();
        void PrintRemoveMobile();
        void PrintChargingError();
        void PrintChargingMobile();
        void PrintChargingComplete();
    }
}
