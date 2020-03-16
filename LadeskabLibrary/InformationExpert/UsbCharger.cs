﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LadeskabLibrary
{
    public class UsbCharger : IUsbCharger
    {
        // Constants
        private const double MaxCurrent = 500.0; // mA
        private const double FullyChargedCurrent = 2.5; // mA
        private const double OverloadCurrent = 750; // mA
        private const int ChargeTimeMinutes = 20; // minutes
        private const int CurrentTickInterval = 250; // ms

        public event EventHandler<CurrentLevelEventArgs> CurrentLevelEvent;

        // The current current value 
        public double CurrentValue { get; set; }
        public bool Connected { get; set; }

        private bool _overload;
        private bool _charging;
        private System.Timers.Timer _timer;
        private int _ticksSinceStart;

        public UsbCharger()
        {
            CurrentValue = 0.0;
            Connected = true;
            _overload = false;

            _timer = new System.Timers.Timer();
            _timer.Enabled = false;
            _timer.Interval = CurrentTickInterval;
            _timer.Elapsed += TimerOnElapsed;
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            // Only execute if charging
            if (_charging)
            {
                _ticksSinceStart++;
                if (Connected && !_overload)
                {
                    double newValue = MaxCurrent -
                                      _ticksSinceStart * (MaxCurrent - FullyChargedCurrent) / (ChargeTimeMinutes * 60 * 1000 / CurrentTickInterval);
                    CurrentValue = Math.Max(newValue, FullyChargedCurrent);
                }
                else if (Connected && _overload)
                {
                    CurrentValue = OverloadCurrent;
                }
                else if (!Connected)
                {
                    CurrentValue = 0.0;
                }

                OnNewCurrent();
            }
        }

        public void SimulateConnected(bool connected)
        {
            Connected = connected;
        }

        public void SimulateOverload(bool overload)
        {
            _overload = overload;
        }


        public void StartCharging()
        {
            // Ignore if already charging
            if (!_charging)
            {
                if (Connected && !_overload)
                {
                    CurrentValue = 500;
                }
                else if (Connected && _overload)
                {
                    CurrentValue = OverloadCurrent;
                }
                else if (!Connected)
                {
                    CurrentValue = 0.0;
                }

                OnNewCurrent();
                _ticksSinceStart = 0;

                _charging = true;

                _timer.Start();
            }
        }

        public void StopCharging()
        {
            _timer.Stop();

            CurrentValue = 0.0;
            OnNewCurrent();

            _charging = false;
        }

        private void OnNewCurrent()
        {
            CurrentLevelEvent?.Invoke(this, new CurrentLevelEventArgs() {CurrentLevel = this.CurrentValue});
        }
    }
}
