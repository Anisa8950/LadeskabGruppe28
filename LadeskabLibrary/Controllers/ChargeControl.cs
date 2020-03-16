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
        public ChargeControl(IUsbCharger usbCharger)
        {
            _usbCharger = usbCharger;
        }

        public bool IsConnected()
        {
            if (_usbCharger.Connected)
            {
                return true;
            }
            else return false;
        }

        public void StartCharger()
        {

        }

        public void StopCharger()
        {

        }

    }
}
