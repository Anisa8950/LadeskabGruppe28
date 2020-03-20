using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public class DoorOpenEventArgs
    {
    }

    public class DoorCloseEventArgs
    {
    }

    public class RFDetectedEventArgs : EventArgs
    {
        public int IdDetected { get; set; }
    }

    public class CurrentLevelEventArgs
    {
       // Value in mA (milliAmpere)
        public double Current { get; set; }

    }
}
