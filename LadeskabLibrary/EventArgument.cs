using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public class DoorOpenEventArgs : EventArgs
    {
    }

    public class DoorCloseEventArgs : EventArgs
    {
    }

    public class RFDetectedEventArgs
    {
        public int IdDetected { get; set; }
    }

    public class CurrentLevelEventArgs : EventArgs
    {
       // Value in mA (milliAmpere)
        public double Current { get; set; }

    }
}
