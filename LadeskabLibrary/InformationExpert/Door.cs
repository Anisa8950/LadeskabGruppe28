using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public class Door: IDoor
    {
        public bool PresentDoorState { get; set; }

        public event EventHandler<DoorStateEventArgs> DoorStateChangedEvent;


        public void LockDoor()
        {
         Console.WriteLine("Døren er låst");
        }

        public void UnlockDoor()
        {
           Console.WriteLine("Døren er ulåst"); 
        }

        public void SetDoorState(bool newDoorState)
        {

            if (newDoorState!=PresentDoorState)
            {
                OnDoorStateChanged(new DoorStateEventArgs{DoorState = newDoorState});
                PresentDoorState = newDoorState;

            }
        }
        
        private void OnDoorStateChanged(DoorStateEventArgs e)
        {
            DoorStateChangedEvent?.Invoke(this,e);
        }

    }
}
