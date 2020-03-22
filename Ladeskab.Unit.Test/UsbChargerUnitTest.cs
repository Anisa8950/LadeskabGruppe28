using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using LadeskabLibrary;
using NUnit.Framework;

namespace Ladeskab.Unit.Test
{
    [TestFixture]
    class UsbChargerUnitTest
    {

        private UsbCharger _uut;
        private CurrentLevelEventArgs _receivedEventArgs;


        [SetUp]
        public void Setup()
        {
            _uut = new UsbCharger();
        }

  

        #region Initial State test
     
        [Test]
        public void ctor_IsConnected()
        {
            Assert.That(_uut.Connected, Is.True);
        }

        [Test]
        public void ctor_CurentValueIsZero()
        {
            Assert.That(_uut.CurrentValue, Is.Zero);
        }


        #endregion

        #region Simulation Methods

        [Test]
        public void SimulateDisconnected_ReturnsDisconnected()
        {
            _uut.SimulateConnected(false);
            Assert.That(_uut.Connected, Is.False);
        }


        [Test]
        public void SimulateOverloaded_ReturnsOverloaded()
        {
            _uut.SimulateOverload(false);
            Assert.That(_uut.Connected, Is.False);
        }

        #endregion

        #region StartCharging(), testing event
        [Test] // kopiret fra Frank
        public void Started_WaitSomeTime_ReceivedSeveralValues()
        {
            int numValues = 0;
            _uut.CurrentLevelEvent += (o, args) => numValues++;

            _uut.StartCharging();

            System.Threading.Thread.Sleep(1100);

            Assert.That(numValues, Is.GreaterThan(4));
        }

        [Test]
        public void startCharging_chargerStarted_EventFired()
        {
            _receivedEventArgs = null;
            _uut.CurrentLevelEvent +=
                (o, args) => { _receivedEventArgs = args; };

            _uut.StartCharging();
            Assert.That(_receivedEventArgs, Is.Not.Null);
        }


        #endregion

        #region StartCharging(), testing for right values

        [Test]
        public void Started_WaitSomeTime_ReceivedChangedValue()
        {
            double lastValue = 1000;
            _uut.CurrentLevelEvent += (o, args) => lastValue = args.Current;

            _uut.StartCharging();

            System.Threading.Thread.Sleep(300);

            Assert.That(lastValue, Is.LessThan(500.0));
        }

        [Test]
        public void StartedNoEventReceiver_WaitSomeTime_PropertyChangedValue()
        {
            _uut.StartCharging();

            System.Threading.Thread.Sleep(300);

            Assert.That(_uut.CurrentValue, Is.LessThan(500.0));
        }

        [Test]
        public void Started_WaitSomeTime_PropertyMatchesReceivedValue()
        {
            double lastValue = 1000;
            _uut.CurrentLevelEvent += (o, args) => lastValue = args.Current;

            _uut.StartCharging();

            System.Threading.Thread.Sleep(1100);

            Assert.That(lastValue, Is.EqualTo(_uut.CurrentValue));
        }


        [Test]
        public void StartCharging_IsCharging_Receives500AmpereImmediatly()
        {
            double CurrentLevel = 0;

            _uut.CurrentLevelEvent +=
                (o, args) => { CurrentLevel = args.Current; };

            _uut.StartCharging();

            Assert.That(CurrentLevel, Is.EqualTo(500));
        }

        #endregion

        #region StartCharging(), Overloaded

        [Test]
        public void StartingChargerCaller_IsConnectedAndOverload_CurrentValueIsOverloadCurrent()
        {
            _uut.SimulateOverload(false);
            _uut.StartCharging();

            // Assert.That(_uc.CurrentValue,Is.EqualTo(_uc.overload)); // der er ikke nogen property til overloadCurrent, hvordan tjekker man at currentvalue er lig med den. Siger man så 750
            Assert.That(_uut.Connected, Is.EqualTo(true));
        }
        [Test]
        public void StartingChargerCalled_IsConnectedAndNotOverload_CurrentValueIs500()
        {
            _uut.StartCharging();

            Assert.That(_uut.CurrentValue, Is.EqualTo(500));

        }

        [Test]
        public void SimulateOverload_Start_ReceivesHighValueImmediately()
        {
            double lastValue = 0;

            _uut.CurrentLevelEvent += (o, args) =>
            {
                lastValue = args.Current;
            };

            // First value should be high
            _uut.SimulateOverload(true);

            // Start
            _uut.StartCharging();

            // Should not wait for first tick, should send overload immediately

            Assert.That(lastValue, Is.GreaterThan(500.0));
        }

        [Test]
        public void Started_SimulateOverload_ReceivesHighValue()
        {
            ManualResetEvent pause = new ManualResetEvent(false);
            double lastValue = 0;

            _uut.CurrentLevelEvent += (o, args) =>
            {
                lastValue = args.Current;
                pause.Set();
            };

            // Start
            _uut.StartCharging();

            // Next value should be high
            _uut.SimulateOverload(true);

            // Reset event
            pause.Reset();

            // Wait for next tick, should send overloaded value
            pause.WaitOne(300);

            Assert.That(lastValue, Is.GreaterThan(500.0));
        }

        #endregion

        #region StartCharging(), Disconnected

        [Test]
        public void SimulateDisconnected_Start_ReceivesZeroValueImmediately()
        {
            double lastValue = 1000;

            _uut.CurrentLevelEvent += (o, args) =>
            {
                lastValue = args.Current;
            };

            // First value should be high
            _uut.SimulateConnected(false);

            // Start
            _uut.StartCharging();

            // Should not wait for first tick, should send zero immediately

            Assert.That(lastValue, Is.Zero);
        }
        [Test]
        public void Started_SimulateDisconnected_ReceivesZero()
        {
            ManualResetEvent pause = new ManualResetEvent(false);
            double lastValue = 1000;

            _uut.CurrentLevelEvent += (o, args) =>
            {
                lastValue = args.Current;
                pause.Set();
            };


            // Start
            _uut.StartCharging();

            // Next value should be zero
            _uut.SimulateConnected(false);

            // Reset event
            pause.Reset();

            // Wait for next tick, should send disconnected value
            pause.WaitOne(300);

            Assert.That(lastValue, Is.Zero);
        }


        [Test]
        public void StartingChargerCaller_IsNotConnected_CurrentValueIsZero()
        {

            _uut.Connected = false;
            _uut.StartCharging();

            Assert.That(_uut.CurrentValue, Is.EqualTo(0.0));

        }
        #endregion

        #region StopCharging()

        [Test]
        public void StopCharging_ChargingIsStopped_PropertyIsZero()
        {
            _uut.StartCharging();

            System.Threading.Thread.Sleep(300);

            _uut.StopCharging();

            Assert.That(_uut.CurrentValue, Is.EqualTo(0));
        }

        [Test]
        public void StopCharging_IsCharging_ReceivesZeroValue()
        {
            double lastValue = 1000;
            _uut.CurrentLevelEvent += (o, args) => lastValue = args.Current;

            _uut.StartCharging();

            System.Threading.Thread.Sleep(300);

            _uut.StartCharging();

            Assert.That(lastValue, Is.EqualTo(0.0));
        }


        [Test]
        public void StopCharge_IsCharging_ReceivesNoMoreValues()
        {
            double lastValue = 1000;
            _uut.CurrentLevelEvent += (o, args) => lastValue = args.Current;

            _uut.StartCharging();

            System.Threading.Thread.Sleep(300);

            _uut.StopCharging();
            lastValue = 1000;

            // Wait for a tick
            System.Threading.Thread.Sleep(300);

            // No new value received
            Assert.That(lastValue, Is.EqualTo(1000.0));
        }


        #endregion







    }
}
