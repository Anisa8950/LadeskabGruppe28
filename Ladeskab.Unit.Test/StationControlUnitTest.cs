using NUnit.Framework;
using LadeskabLibrary;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NSubstitute.ReceivedExtensions;
using System;

namespace Ladeskab.Unit.Test
{
    [TestFixture]
    public class StationControlUnitTest
    {
        private StationControl _uut;
        private ChargeControl _chargeControl;
        private IDisplay _display;
        private IDoor _door;
        private ILogFile _logFile;
        private IRFReader _idSource;
        private UsbCharger _usbCharger;


        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _door = Substitute.For<IDoor>();
            _logFile = Substitute.For<ILogFile>();
            _idSource = Substitute.For<IRFReader>();            
            _usbCharger = Substitute.For <UsbCharger>();

            _chargeControl = Substitute.For <ChargeControl>(_usbCharger, _display);
            _uut = new StationControl(_display, _door, _logFile, _idSource, _chargeControl); 
        }


        [TestCase(123456)]
        [TestCase(654321)]
        [TestCase(987654)]
        public void RFIDChanged_DifferentArguments_CurrentRFIDIsCorrect(int newId)
        {
            _idSource.IdDetectedEvent += Raise.EventWith<RFDetectedEventArgs>(this, new RFDetectedEventArgs() { IdDetected = newId });
            //_idSource.scan(newId);
            Assert.That(_uut.CurrentId, Is.EqualTo(newId));  
        }

        
    }
}