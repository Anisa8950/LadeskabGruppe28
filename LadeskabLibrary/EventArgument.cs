using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public class DoorOpenEventArgs
    {
        public bool DoorOpen { set; get; }
    }

    public class DoorCloseEventArgs
    {
        public bool DoorClose { set; get; }

    }

    public class RFDetectedEventArgs
    {
        public int IdDetected { get; set; }
    }

    public class CurrentLevelEventArgs
    {
       // Value in mA (milliAmpere)
        public double Current { get; set; }

    }
}
