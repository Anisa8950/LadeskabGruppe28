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
        private IDisplay _display;
        private IDoor _door;
        private ILogFile _logFile;
        private IRFReader _idSource = new TestIdSource();
        //private IRFReader _idsource;
        private UsbCharger _usbCharger;


        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _door = Substitute.For<IDoor>();
            _logFile = Substitute.For<ILogFile>();
            _idSource = Substitute.For<IRFReader>();            
            _usbCharger = Substitute.For <UsbCharger>();

            ChargeControl _chargeControl = Substitute.For <ChargeControl>(_usbCharger, _display);
            StationControl _uut = new StationControl(_display, _door, _logFile, _idSource, _chargeControl);

        }


        [TestCase(123456)]
        [TestCase(654321)]
        [TestCase(987654)]
        public void RFIDChanged_DifferentArguments_CurrentRFIDIsCorrect(int newId)
        {
            //_idSource.IdDetectedEvent += Raise.EventWith(new RFDetectedEventArgs { IdDetected = newId });
            _idSource.scan(newId);
            Assert.That(_uut.CurrentId, Is.EqualTo(newId));  
        }

        internal class TestIdSource : IRFReader
        {
            public event EventHandler<RFDetectedEventArgs> IdDetectedEvent;
            public void scan(int id)
            {
                IdDetectedEvent?.Invoke
                    (this, new RFDetectedEventArgs() { IdDetected = id });
            }

        }
    }
}