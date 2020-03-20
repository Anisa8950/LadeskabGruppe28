using NUnit.Framework;
using LadeskabLibrary;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NSubstitute.ReceivedExtensions;


namespace Ladeskab.Unit.Test
{
    public class DoorUnitTest
    {
        private Door _uut;
        private IDisplay _display;
        private ILogFile _logFile;
        private IRFReader _idSource;
        private UsbCharger _usbCharger;
        private ChargeControl _chargeControl;
        private StationControl _stationControl;


        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _logFile = Substitute.For<ILogFile>();
            _idSource = Substitute.For<IRFReader>();
            _usbCharger = Substitute.For<UsbCharger>();
            _uut = new Door();

            _chargeControl = Substitute.For<ChargeControl>(_usbCharger, _display);
            _stationControl = Substitute.For<StationControl>(_display, _uut, _logFile, _idSource, _chargeControl);
        }

        [Test]
        public void SetDoorStateOpen_HandelDoorOpenEventCalled_EventFired()
        {
            _uut.DoorOpenEvent += Raise.EventWith<DoorOpenEventArgs>(this, new DoorOpenEventArgs());
            _stationControl.Received().DoorOpen();
        }

        [Test]
        public void SetDoorStateClose_HandelDoorCloseEvent_EventFired()
        {
            _uut.DoorCloseEvent += Raise.EventWith<DoorCloseEventArgs>(this, new DoorCloseEventArgs());
            _stationControl.Received().DoorClosed();
        }
    }
}
