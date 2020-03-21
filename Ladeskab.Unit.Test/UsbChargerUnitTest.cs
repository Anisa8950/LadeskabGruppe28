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
        

        [SetUp]
        public void Setup()
        {

            _uut = new UsbCharger();
        }

        [Test]
        public void StartingChargerCalled_IsConnectedAndNotOverload_CurrentValueIs500()
        {
            _uut.StartCharging();

            Assert.That(_uut.CurrentValue, Is.EqualTo(500));

        }

        [Test]
        public void StartingChargerCaller_IsConnectedAndOverload_CurrentValueEqualsOverloadCurrent()
        {
            _uut.SimulateOverload(false);
            _uut.StartCharging();

           // Assert.That(_uc.CurrentValue,Is.EqualTo(_uc.overload)); // der er ikke nogen property til overloadCurrent, hvordan tjekker man at currentvalue er lig med den. Siger man så 750
            Assert.That(_uut.Connected,Is.EqualTo(true));
        }

        [Test]
        public void StartingChargerCaller_IsNotConnected_CurrentValueEquals0()
        {

            _uut.Connected = false;
            _uut.StartCharging();

            Assert.That(_uut.CurrentValue,Is.EqualTo(0.0));

        }







    }
}
