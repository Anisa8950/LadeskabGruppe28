using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public class Door: IDoor
    {
        public string ConsoleString { get; set; }

        public virtual event EventHandler<DoorOpenEventArgs> DoorOpenEvent;

        public virtual event EventHandler<DoorCloseEventArgs> DoorCloseEvent;

        public void LockDoor()
        {
            ConsoleString = "Døren er låst";
            Console.WriteLine(ConsoleString);
        }

        public void UnlockDoor()
        {
            ConsoleString = "Døren er ulåst";
            Console.WriteLine(ConsoleString); 
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
