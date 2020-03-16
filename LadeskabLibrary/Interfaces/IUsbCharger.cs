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
        double CurrentValue { get; set; }
        bool Connected { get; set; }
        void StartCharging();

        void StopCharging();

    }
}
