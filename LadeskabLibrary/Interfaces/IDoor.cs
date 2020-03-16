using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    interface IDoor
    {

        bool PresentDoorState();
        event DoorStateChangedEvent();
        void LockDoor();
        void UnlockDoor();



    }
}
