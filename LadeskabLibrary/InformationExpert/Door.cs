using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public class Door: IDoor
    {
        public bool DoorNowOpend { get; set; }
        public bool DoorNowClosed { get; set; }

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

        public void SetDoorStateOpen(bool newDoorState)
        {
            OnDoorStateOpen(new DoorOpenEventArgs { DoorOpen = newDoorState });
            DoorNowOpend = newDoorState;
        }
        
        private void OnDoorStateOpen(DoorOpenEventArgs e)
        {
            DoorOpenEvent?.Invoke(this,e);
        }



        public void SetDoorStateClose(bool newDoorState)
        {
            OnDoorStateClose(new DoorCloseEventArgs { DoorClose = newDoorState });
            DoorNowClosed = newDoorState;
        }

        private void OnDoorStateClose(DoorCloseEventArgs e)
        {
            DoorCloseEvent?.Invoke(this, e);
        }
    }
}
