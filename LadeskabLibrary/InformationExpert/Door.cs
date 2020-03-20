using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public class Door: IDoor
    {
        public bool DoorState { get; set; }

        public event EventHandler<DoorOpenEventArgs> DoorOpenEvent;

        public event EventHandler<DoorCloseEventArgs> DoorCloseEvent;

        public void LockDoor()
        {
         Console.WriteLine("Døren er låst");
        }

        public void UnlockDoor()
        {
           Console.WriteLine("Døren er ulåst"); 
        }

        public void SetDoorStateOpen()
        {
            bool openDoor = true;
            OnDoorStateOpen(new DoorOpenEventArgs { DoorOpen = openDoor });
            DoorState = openDoor;
        }
        
        private void OnDoorStateOpen(DoorOpenEventArgs e)
        {
            DoorOpenEvent?.Invoke(this,e);
        }



        public void SetDoorStateClose()
        {
            bool closeDoor = false;
            OnDoorStateClose(new DoorCloseEventArgs { DoorClose = closeDoor });
            DoorState = closeDoor;
        }

        private void OnDoorStateClose(DoorCloseEventArgs e)
        {
            DoorCloseEvent?.Invoke(this, e);
        }
    }
}
