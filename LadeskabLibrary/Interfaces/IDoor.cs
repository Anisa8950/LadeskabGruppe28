﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public interface IDoor
    {
        event EventHandler<DoorOpenEventArgs> DoorOpenEvent;
        event EventHandler<DoorCloseEventArgs> DoorCloseEvent;

        string ConsoleString { get; set; }

        void LockDoor();
        void UnlockDoor();
    }


}
