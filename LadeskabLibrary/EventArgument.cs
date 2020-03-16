using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public class DoorStateEventArgs
    {
    }

    public class RFDetectedEventArgs
    {
    }

    public class CurrentLevelEventArgs
    {
        public double Current { get; set; }

    }
}
