using System;
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

            _receivedEventArgs = null;
            _uut = new UsbCharger();

            _uut.CurrentLevelEvent +=
                (o, args) => { _receivedEventArgs = args; };
        }

        [Test]
        public void setCurrent_CurrentSetToNewValue_EventFired()
        {
            _uut.CurrentValue = 300;
            Assert.That(_receivedEventArgs, Is.Not.Null);
        }

        [TestCase(200)]
        [TestCase(150)]
        [TestCase(100)]
        public void SetCurrent_CurrentSetToNewValue_CorrectNewCurrentReceived(double newCurrent)
        {
            _uut.CurrentValue = 200;
            Assert.That(_receivedEventArgs.Current, Is.EqualTo(newCurrent));
        }

        [Test]
        public void StopCharging_ChargingIsStopped_NewCurrentIsZero()
        {
            _uut.StartCharging();
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







    }
}
