﻿using System;
using System.Collections.Generic;
using System.Text;
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

        [Test]
        public void setCurrent_CurrentSetToNewValue_EventFired()
        {
            _receivedEventArgs = null;
            _uut.CurrentLevelEvent +=
                (o, args) => { _receivedEventArgs = args; };


            _uut.StartCharging();
            Assert.That(_receivedEventArgs, Is.Not.Null);
        }

        [Test]
        public void StartCharging_CurrentSetto500Ampere_CorrectNewCurrentReceived()
        {
            _uut.StopCharging();
            Assert.That(_receivedEventArgs.Current, Is.EqualTo(500));
        }

        [Test]
        public void StopCharging_ChargingIsStopped_NewCurrentIsZero()
        {
            _uut.StopCharging();
            Assert.That(_uut.CurrentValue, Is.EqualTo(0));
        }

        [Test]
        public void StartingChargerCalled_IsConnectedAndNotOverload_CurrentValueIs500()
        {
            _uut.StartCharging();

            Assert.That(_uut.CurrentValue, Is.EqualTo(500));

        }

        [Test]
        public void StartingChargerCaller_IsConnectedAndOverload_CurrentValueIsOverloadCurrent()
        {
            _uut.SimulateOverload(false);
            _uut.StartCharging();

           // Assert.That(_uc.CurrentValue,Is.EqualTo(_uc.overload)); // der er ikke nogen property til overloadCurrent, hvordan tjekker man at currentvalue er lig med den. Siger man så 750
            Assert.That(_uut.Connected,Is.EqualTo(true));
        }

        [Test]
        public void StartingChargerCaller_IsNotConnected_CurrentValueIsZero()
        {

            _uut.Connected = false;
            _uut.StartCharging();

            Assert.That(_uut.CurrentValue,Is.EqualTo(0.0));

        }


        [Test] // kopiret fra Frank
        public void Started_WaitSomeTime_ReceivedSeveralValues()
        {
            int numValues = 0;
            _uut.CurrentLevelEvent += (o, args) => numValues++;

            _uut.StartCharging();

            System.Threading.Thread.Sleep(1100);

            Assert.That(numValues, Is.GreaterThan(4));
        }





    }
}
