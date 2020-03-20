using System;
using System.Collections.Generic;
using System.Text;
using LadeskabLibrary;
using NUnit.Framework;

namespace Ladeskab.Unit.Test
{
    [TestFixture]
    class UsbChargerUnitTest
    {

        private UsbCharger _uc;
        

        [SetUp]
        public void Setup()
        {

            _uc = new UsbCharger();
        }

        [Test]
        public void StartingCharger_()
        {

            //
            Assert.Pass();
        }




    }
}
