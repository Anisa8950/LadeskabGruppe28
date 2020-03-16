using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    interface IUsbCharger
    {
        event EventHandler<CurrentLevelEventArgs> CurrentLevelChanged;
        double CurrentValue { get; set; }
        bool Connected { get; set; }
        void StartCharging();

        void StopCharging();

    }
}
