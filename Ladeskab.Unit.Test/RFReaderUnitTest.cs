using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using LadeskabLibrary;

namespace Ladeskab.Unit.Test
{
    [TestFixture]
    public class RFReaderUnitTest
    {
        private RFReader _uut;
        private RFDetectedEventArgs _receivedEventArgs;

        [SetUp]
        public void Setup()
        {
            _receivedEventArgs = null;

            _uut = new RFReader();
            _uut.scan(123456);

            _uut.IdDetectedEvent +=
                (o, args) =>
                {
                    _receivedEventArgs = args;
                };
        }

        [Test]
        public void ScanId_IdSetToNewValue_EventFired()
        {
            _uut.scan(654321);
            Assert.That(_receivedEventArgs, Is.Not.Null);
        }

        [TestCase(123456)]
        [TestCase(654321)]
        [TestCase(987654)]
        public void ScanId_IdSetToNewValue_CorrectNewIdReceived(int id)
        {
            _uut.scan(id);
            Assert.That(_receivedEventArgs.IdDetected, Is.EqualTo(id));
        }
    }
}
