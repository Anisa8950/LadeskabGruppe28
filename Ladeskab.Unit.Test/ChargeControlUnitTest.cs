﻿using NUnit.Framework;
using LadeskabLibrary;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NSubstitute.ReceivedExtensions;


namespace Ladeskab.Unit.Test
{
   [TestFixture]
    public class ChargeControlUnitTest
    {
        private ChargeControl _cc;
        private IDisplay _display;
        private IUsbCharger _usbCharger;
        


        [SetUp]
        public void Setup()
        {
            // arrange
        
            _display = Substitute.For<IDisplay>();
            _usbCharger = Substitute.For<IUsbCharger>();
            _cc=new ChargeControl(_usbCharger, _display);
        }



        [TestCase(5)]
        [TestCase(50)]
        [TestCase(100)]

        public void CurrentChanged_DifferentArguments_CurrentValueIsCorrect(int newCurrent)
        {
            // Act: der bliver "raised an event"
            _usbCharger.CurrentLevelEvent += Raise.EventWith(new CurrentLevelEventArgs {Current = newCurrent});

            // Assert: check for at currentvalue er blevet sat til den nye værdi efter: raise event
            Assert.That(_cc.CurrentValue,Is.EqualTo(newCurrent));

           
        }

        [Test]
        public void StartChargerCalled_xx_PrintChargingMobileAndStartChargingIsCalled()
        {
            // husk undersøg hvordan currentvalue kan sættes til noget forskelligt i én test
            _cc.CurrentValue = 50;
            _cc.StartCharger();

            _usbCharger.Received(1).StartCharging();
            _display.Received(1).PrintChargingMobile();

        }

        [Test]
        public void Test3()
        {

            // test når startCharger kaldes med følgende forudsætninger: _charger er false, current er sat til fx 10
            // forventer at der bliver kaldt på startCharging som sætter currentvalue til 500 samt _charging til true 
            // - derudover tjekke at  _display.PrintChargingMobile(); bliver kaldt?

            Assert.Pass();

        }


    }
}