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
        private ChargeControl cc;
        private IDisplay _display;
        private IUsbCharger _usbCharger;
        private CurrentLevelEventArgs _revivedEventArgs;


        [SetUp]
        public void Setup()
        {
            // arrange
        
            _display = Substitute.For<IDisplay>();
            _usbCharger = Substitute.For<IUsbCharger>();
            cc=new ChargeControl(_usbCharger, _display);
        }


        [Test]
        public void Test1()
        {
            // event source testes: UsbCharger
            //  teste at ved ændret currentvalue vil eventet blive kaldt

            
            Assert.Pass();

        }


        [Test]
        public void Test2()
        {
            Assert.Pass();

        }

        [Test]
        public void Test3()
        {
            Assert.Pass();

        }


    }
}