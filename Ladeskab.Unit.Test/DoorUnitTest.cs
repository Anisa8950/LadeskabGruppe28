using System;
using NUnit.Framework;
using LadeskabLibrary;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NSubstitute.ReceivedExtensions;
using System.IO;


namespace Ladeskab.Unit.Test
{
    public class DoorUnitTest
    {
        private Door _uut;
        private IDisplay _display;
        private ILogFile _logFile;
        private IRFReader _idSource;
        private IUsbCharger _usbCharger;
        private ChargeControl _chargeControl;
        private StationControl _stationControl;
        public StringWriter stringWriter;


        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _logFile = Substitute.For<ILogFile>();
            _idSource = Substitute.For<IRFReader>();
            _usbCharger = Substitute.For<IUsbCharger>();
            _uut = new Door();

            _chargeControl = Substitute.For<ChargeControl>(_usbCharger, _display);
            _stationControl = Substitute.For<StationControl>(_display, _uut, _logFile, _idSource, _chargeControl);
        }

        [Test]
        public void SetDoorStateOpen_HandelDoorOpenEvent_EventFired()
        {
            _uut.SetDoorStateOpen();
            _stationControl.Received(1).DoorOpen();
        }

        [Test]
        public void SetDoorStateClose_HandelDoorCloseEvent_EventFired()
        {
            _uut.SetDoorStateClose();
            _stationControl.Received(1).DoorClosed();
        }

        [Test]
        public void UnlockedDoorCalled_Write()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                _uut.UnlockDoor();
            }

            Assert.That(stringWriter.ToString(), Is.EqualTo("Døren er ulåst\r\n"));
        }

        [Test]
        public void lockedDoorCalled_Write()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                _uut.LockDoor();
            }
            

            Assert.That(stringWriter.ToString(), Is.EqualTo("Døren er låst\r\n"));
        }

    }
}
