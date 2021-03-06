﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public interface IUsbCharger
    {
        event EventHandler<CurrentLevelEventArgs> CurrentLevelEvent;
       
        // The current current value 
        double CurrentValue { get; }
        bool Connected { get; }
        void StartCharging();

        void StopCharging();

    }
}
