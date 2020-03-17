using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public class ChargeControl
    {
        private IUsbCharger _usbCharger;
        public double CurrentValue { get; set; }
        public ChargeControl(IUsbCharger usbCharger)
        {
            _usbCharger = usbCharger;
            usbCharger.CurrentLevelEvent += HandleCurrentLevelChangedEvent;
        }

        private void HandleCurrentLevelChangedEvent(object sender, CurrentLevelEventArgs e)
        {
            CurrentValue = e.Current;
        }

        public bool IsConnected()
        {
            if (CurrentValue<=0)
            {
                return false;
            }
            else return true;
        }

        public void StartCharger()
        {
            _usbCharger.StartCharging();
        }

        public void StopCharger()
        {
            _usbCharger.StopCharging();
        }

    }
}
