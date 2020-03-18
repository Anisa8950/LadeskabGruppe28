using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private int _oldId;
        private LadeskabState _state;

        private IDisplay _display;
        private IDoor _door;
        private ILogFile _logFile;
        private IRFReader _RFReader;        
        private IUsbCharger _charger;

        // Her mangler constructor
        public StationControl(IDisplay display, IDoor door, ILogFile logFile, IRFReader RFReader, IUsbCharger charger)
        {
            _display = display;
            _door = door;
            _logFile = logFile;
            _RFReader = RFReader;
            _charger = charger;
        }

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.Connected)
                    {
                        _door.LockDoor();
                        _charger.StartCharging();
                        _oldId = id;
                        _logFile.LogDoorLocked(Convert.ToString(id));
                        _display.PrintOccupied();
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        _display.PrintConnectingError();
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _charger.StopCharging();
                        _door.UnlockDoor();
                        _logFile.LogDoorUnlocked(Convert.ToString(id));
                        _display.PrintRemoveMobile();
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        _display.PrintRFIDError();
                    }

                    break;
            }
        }

        // Her mangler de andre trigger handlere
        public void DoorOpen()
        {
            if(_state==LadeskabState.Available)
            {
                _display.PrintConnectMobile();
            }
        }

        public void DoorClosed()
        {
            if (_state == LadeskabState.Available)
            {
                _display.PrintScanRFID();
            }
        }
    }
}
