using NUnit.Framework;
using LadeskabLibrary;
using NSubstitute;

namespace Ladeskab.Unit.Test
{
    public class StationControlUnitTest
    {
        StationControl _uut;

        [SetUp]
        public void Setup()
        {
            Display _display = Substitute.For<Display>();
            Door _door = Substitute.For<Door>();
            LogFile _logFile = Substitute.For <LogFile>();
            RFReader _RFReader = Substitute.For <RFReader>();
            UsbCharger _usbCharger = Substitute.For <UsbCharger>();

            ChargeControl _chargeControl = Substitute.For <ChargeControl>(_usbCharger, _display);
            StationControl _uut = new StationControl(_display, _door, _logFile, _RFReader, _chargeControl);

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}