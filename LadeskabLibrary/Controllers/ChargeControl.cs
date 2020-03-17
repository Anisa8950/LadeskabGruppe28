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
        private IDisplay _display;
        public double CurrentValue { get; set; }

        public ChargeControl(IUsbCharger usbCharger, IDisplay display)
        {
            _usbCharger = usbCharger;
            _display = display;
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
            if (CurrentValue > 5 && CurrentValue <= 500) 
            {
                _display.PrintChargingMobile();
                _usbCharger.StartCharging(); 
            }
            else if(CurrentValue > 500)
            {
                _display.PrintChargingError();
            }
        }

        public void StopCharger()
        {
            if(CurrentValue > 0 && CurrentValue <= 5)
            {
                _display.PrintChargingComplete();
                _usbCharger.StopCharging();
            }  
        }
    }
}
