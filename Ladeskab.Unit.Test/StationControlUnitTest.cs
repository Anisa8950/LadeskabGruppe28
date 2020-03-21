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
            Assert.That(_uut.CurrentId, Is.EqualTo(newId));  
        }

        #region DoorOpenTest

        [Test]
        public void DoorOpen_DoorstateAvailable_DisplayCalled()
        {
            _door.DoorOpenEvent += Raise.EventWith<DoorOpenEventArgs>(this, new DoorOpenEventArgs());
            _display.Received().PrintConnectMobile();
        }


        [Test]
        public void DoorOpen_DoorstateDoorOpen_DisplayCalledOnce()
        {
            //Arrange
            _door.DoorOpenEvent += Raise.EventWith<DoorOpenEventArgs>(this, new DoorOpenEventArgs());

            _door.DoorOpenEvent += Raise.EventWith<DoorOpenEventArgs>(this, new DoorOpenEventArgs());
            _display.Received(1).PrintConnectMobile();
        }

        [Test]
        public void DoorOpen_DoorstateLocked_DisplayCalledOnce()
        {
            //Arrange
            _door.DoorOpenEvent += Raise.EventWith<DoorOpenEventArgs>(this, new DoorOpenEventArgs());
            _usbCharger.CurrentLevelEvent += Raise.EventWith<CurrentLevelEventArgs>(this, new CurrentLevelEventArgs() { Current = 1 });
            _door.DoorCloseEvent += Raise.EventWith<DoorCloseEventArgs>(this, new DoorCloseEventArgs());
            _idSource.IdDetectedEvent += Raise.EventWith<RFDetectedEventArgs>(this, new RFDetectedEventArgs() { IdDetected = 123 });

            _door.DoorOpenEvent += Raise.EventWith<DoorOpenEventArgs>(this, new DoorOpenEventArgs());
            _display.Received(1).PrintConnectMobile();
        }

        #endregion

        #region DoorCloseTest

        [Test]
        public void DoorClose_DoorstateAvailable_DisplayNotCalled()
        {
            _door.DoorCloseEvent += Raise.EventWith<DoorCloseEventArgs>(this, new DoorCloseEventArgs());
            _display.DidNotReceive().PrintScanRFID();
        }


        [Test]
        public void DoorClose_DoorstateDoorOpen_DisplayCalled()
        {
            //Arrange
            _door.DoorCloseEvent += Raise.EventWith<DoorCloseEventArgs>(this, new DoorCloseEventArgs());

            _door.DoorCloseEvent += Raise.EventWith<DoorCloseEventArgs>(this, new DoorCloseEventArgs());
            _display.Received(1).PrintScanRFID();
        }

        [Test]
        public void DoorClose_DoorstateLocked_DisplayCalledOnce()
        {
            //Arrange
            _door.DoorCloseEvent += Raise.EventWith<DoorCloseEventArgs>(this, new DoorCloseEventArgs());
            _usbCharger.CurrentLevelEvent += Raise.EventWith<CurrentLevelEventArgs>(this, new CurrentLevelEventArgs() { Current = 1 });
            _door.DoorCloseEvent += Raise.EventWith<DoorCloseEventArgs>(this, new DoorCloseEventArgs());
            _idSource.IdDetectedEvent += Raise.EventWith<RFDetectedEventArgs>(this, new RFDetectedEventArgs() { IdDetected = 123 });

            _door.DoorCloseEvent += Raise.EventWith<DoorCloseEventArgs>(this, new DoorCloseEventArgs());
            _display.Received(1).PrintScanRFID();
        }
        #endregion

        [Test]
        public void RFIdDetectedCalled_MobileConnectedAndStateAvaliable_DoorLockedChargerStart()
        {
            _usbCharger.CurrentLevelEvent += Raise.EventWith<CurrentLevelEventArgs>(this, new CurrentLevelEventArgs() { Current = 1 });
            _uut.RfidDetected(123456);

            _door.Received(1).LockDoor();
            _chargeControl.Received(1).StartCharger();
            _logFile.Received(1).LogDoorLocked("123456");
            _display.Received(1).PrintOccupied();

            _display.DidNotReceive().PrintConnectingError();
        }

        [Test]
        public void RFIdDetectedCalled_MobileConnectedAndStateLocked_DoorUnlockedChargerStop_sameID()
        {
            _usbCharger.CurrentLevelEvent += Raise.EventWith<CurrentLevelEventArgs>(this, new CurrentLevelEventArgs() { Current = 1 });
            _uut.RfidDetected(123456);

            _uut.RfidDetected(123456);
            _door.Received(1).UnlockDoor();
            _chargeControl.Received(1).StopCharger();
            _logFile.Received(1).LogDoorUnlocked("123456");
            _display.Received(1).PrintRemoveMobile();

            _display.DidNotReceive().PrintRFIDError();
        }

        public void RFIdDetectedCalled_MobileNotConnectedAndStateAvaliable_ConnectingError()
        {
            _usbCharger.CurrentLevelEvent += Raise.EventWith<CurrentLevelEventArgs>(this, new CurrentLevelEventArgs() { Current = 0 });
            _uut.RfidDetected(123456);

            _display.Received(1).PrintConnectingError();

            _door.DidNotReceive().LockDoor();
            _chargeControl.DidNotReceive().StartCharger();
            _logFile.DidNotReceive().LogDoorLocked("123456");
            _display.DidNotReceive().PrintOccupied();
        }

        



    }
}