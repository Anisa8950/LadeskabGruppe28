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
        private ChargeControl cc;
        private IDisplay _display;
        private IUsbCharger _usbCharger;


        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _usbCharger = Substitute.For<IUsbCharger>();

            cc=new ChargeControl(_usbCharger, _display);
        }


        [Test]
        public void Test1()
        {
            Assert.Pass();

        }
    }
}