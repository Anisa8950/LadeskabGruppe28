using System;
using NUnit.Framework;
using LadeskabLibrary;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NSubstitute.ReceivedExtensions;


namespace Ladeskab.Unit.Test
{
    [TestFixture]
    public class ChargeControlUnitTest
    {
        private ChargeControl _uut;
        private IDisplay _display;
        private IUsbCharger _usbCharger;



        [SetUp]
        public void Setup()
        {
            // arrange
            _display = Substitute.For<IDisplay>();
            _usbCharger = Substitute.For<IUsbCharger>();
            _uut = new ChargeControl(_usbCharger, _display);
        }

        #region UUT is subcribed to event test

        [TestCase(5)]
        [TestCase(50)]
        [TestCase(100)]

        public void CurrentChanged_DifferentArguments_CurrentValueIsCorrect(int newCurrent)
        {
            // Act: der bliver "raised an event"
            _usbCharger.CurrentLevelEvent += Raise.EventWith(new CurrentLevelEventArgs {Current = newCurrent});

            // Assert: Tjek for at currentvalue er blevet sat til den nye værdi efter: raise event
            Assert.That(_uut.CurrentValue, Is.EqualTo(newCurrent));
        }


        #endregion

        #region StartCharger()

        [TestCase(50)]
        [TestCase(100)]
        [TestCase(200)]

        public void StartCharger_CurrentBelow500AndOver5_PrintChargingMobileAndStartChargingIsCalled(double currentValue)
        {
            _uut.CurrentValue = currentValue;
            _uut.StartCharger();

            _usbCharger.Received(1).StartCharging();
            _display.Received(1).PrintChargingMobile();
            _display.Received(0).PrintChargingError();
        }

        [TestCase(550)]
        [TestCase(600)]
        [TestCase(650)]

        public void StartCharger_CurrentOver500_PrintChargingErrorIsCalled(double currentValue)
        {
            _uut.CurrentValue = currentValue;
            _uut.StartCharger();

            _display.Received(1).PrintChargingError();
        }


        #endregion

        #region IsConnected()

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-20)]
        public void IsConnected_CurrentBelowZero_ReturnFalse(double currentValue) 
        {
            _uut.CurrentValue = currentValue;
            _uut.IsConnected();
            Assert.That(_uut.IsConnected,Is.EqualTo(false));
        }

        [Test]
        public void IsConnected_CurrentIsZero_ReturnFalse()
        {
            _uut.CurrentValue = 0;
            _uut.IsConnected();
            Assert.That(_uut.IsConnected, Is.EqualTo(false));
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(20)]
        public void IsConnected_CurrentOverZero_ReturnTrue(double currentValue) 
        {
            _uut.CurrentValue = currentValue;
            _uut.IsConnected();
            Assert.That(_uut.IsConnected, Is.EqualTo(true));
        }

        #endregion

        #region StopCharger()

        [TestCase(1)]
        [TestCase(2.5)]
        [TestCase(3.5)]
        public void StopCharger_CurrentBetween0to5_ChargerIsStoppendAndDisplayPrints(double currentValue)
        {
            _uut.CurrentValue = currentValue;
            _uut.StopCharger();
            _usbCharger.Received(1).StopCharging();
            _display.Received(1).PrintChargingComplete();
        }

        #endregion



    }
}