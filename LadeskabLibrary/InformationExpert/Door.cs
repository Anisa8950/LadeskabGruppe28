using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public class Door: IDoor
    {
        public virtual event EventHandler<DoorOpenEventArgs> DoorOpenEvent;

        public virtual event EventHandler<DoorCloseEventArgs> DoorCloseEvent;

        public void LockDoor()
        {
            Console.WriteLine("Døren er låst");
        }

        public void UnlockDoor()
        {
            Console.WriteLine("Døren er ulåst");
        }



        public virtual void SetDoorStateOpen()
        {
            OnDoorStateOpen(new DoorOpenEventArgs {});
        }
        
        private void OnDoorStateOpen(DoorOpenEventArgs e)
        {
            DoorOpenEvent?.Invoke(this,e);
        }



        public virtual void SetDoorStateClose()
        {
            OnDoorStateClose(new DoorCloseEventArgs {});
        }

        private void OnDoorStateClose(DoorCloseEventArgs e)
        {
            DoorCloseEvent?.Invoke(this, e);
        }
    }
}
