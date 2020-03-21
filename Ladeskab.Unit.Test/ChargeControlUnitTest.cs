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
            _uut=new ChargeControl(_usbCharger, _display);
        }



        [TestCase(5)]
        [TestCase(50)]
        [TestCase(100)]

        public void CurrentChanged_DifferentArguments_CurrentValueIsCorrect(int newCurrent)
        {
            // Act: der bliver "raised an event"
            //_usbCharger.CurrentLevelEvent += Raise.EventWith(new CurrentLevelEventArgs {Current = newCurrent});

            // Assert: check for at currentvalue er blevet sat til den nye værdi efter: raise event
            Assert.That(_uut.CurrentValue,Is.EqualTo(newCurrent));

           
        }

        [Test]
        public void StartChargerCalled_CurrentBelow500AndOver5_PrintChargingMobileAndStartChargingIsCalled()
        {
            //Flere testcases med currentvalue der får forskellige værdier
           
            _uut.CurrentValue = 50;
            _uut.StartCharger();

            _usbCharger.Received(1).StartCharging();
            _display.Received(1).PrintChargingMobile();

        }

        [Test]
        public void IsConnected_CurrentBelowZero_ReturnsFalse() // i tvivl om er rigtig
        {
            _uut.CurrentValue = -3;
            _uut.IsConnected();

            Assert.That(_uut.IsConnected,Is.EqualTo(false));

        }

      


        [Test]
        public void IsConnected_CurrentIsZero_ReturnsFalse() // i tvivl om er rigtig
        {
            _uut.CurrentValue = 0;
            _uut.IsConnected();

            Assert.That(_uut.IsConnected, Is.EqualTo(false));

        }

        [Test]
        public void IsConnected_CurrentOverZero_ReturnsTrue() // i tvivl om er rigtig
        {
            _uut.CurrentValue = 5;
            _uut.IsConnected();

            Assert.That(_uut.IsConnected, Is.EqualTo(true));

        }



        [Test]
        public void StopCharger_CurrentBelow5Ampere_ChargerIsStoppendAndDisplayPrints()
        {
            _uut.CurrentValue = 2.5;
            _uut.StopCharger();
            _usbCharger.Received(1).StopCharging();
            _display.Received(1).PrintChargingComplete();

        }


    }
}