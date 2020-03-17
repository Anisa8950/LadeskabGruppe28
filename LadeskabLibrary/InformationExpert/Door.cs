using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public class Door: IDoor
    {
        private bool PresentDoorState;

        public event EventHandler<DoorStateEventArgs> DoorStateChangedEvent;


        public void LockDoor()
        {
         
        }

        public void UnlockDoor()
        {
            
        }

        private void OnDoorStateChanged(DoorStateEventArgs e)
        {

            DoorStateChangedEvent?.Invoke(this,e);
        }

    }
}
