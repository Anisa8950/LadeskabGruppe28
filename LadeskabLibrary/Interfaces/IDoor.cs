using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public interface IDoor
    {

        bool PresentDoorState { get; set; }
        event EventHandler<DoorStateEventArgs> DoorStateChangedEvent;

        void LockDoor();
        void UnlockDoor();



    }


}
