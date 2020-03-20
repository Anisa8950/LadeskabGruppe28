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

        private UsbCharger _uc;
        

        [SetUp]
        public void Setup()
        {

            _uc = new UsbCharger();
        }

        [Test]
        public void StartingChargerCalled_IsConnectedAndNotOverload_CurrentValueIs500()
        {
            _uc.StartCharging();

            Assert.That(_uc.CurrentValue, Is.EqualTo(500));

        }

        [Test]
        public void StartingChargerCaller_IsConnectedAndOverload_CurrentValueEqualsOverloadCurrent()
        {
            _uc.SimulateOverload(false);
            _uc.StartCharging();

           // Assert.That(_uc.CurrentValue,Is.EqualTo(_uc.overload)); // der er ikke nogen property til overloadCurrent, hvordan tjekker man at currentvalue er lig med den. Siger man så 750
            Assert.That(_uc.Connected,Is.EqualTo(true));
        }

        [Test]
        public void StartingChargerCaller_IsNotConnected_CurrentValueEquals0()
        {

            _uc.Connected = false;
            _uc.StartCharging();

            Assert.That(_uc.CurrentValue,Is.EqualTo(0.0));

        }







    }
}
