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
        private int NumberOfEvents;

        [SetUp]
        public void Setup()
        {
            _receivedEventArgs = null;
            NumberOfEvents = 0;

            _uut = new RFReader();
            _uut.scan(123456);

            _uut.IdDetectedEvent +=
                (o, args) =>
                {
                    _receivedEventArgs = args;
                    NumberOfEvents++;
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
        public void ScanId_IdSetToNewValue_CorrectNewIdReceived(int newId)
        {
            _uut.scan(newId);
            Assert.That(_receivedEventArgs.IdDetected, Is.EqualTo(newId));
        }

        [Test]
        public void ScanId_ThreeIdScanned_ThreeEventsTriggered()
        {
            _uut.scan(123456);
            _uut.scan(654321);
            _uut.scan(987654);
            Assert.That(NumberOfEvents, Is.EqualTo(3));
        }

        [Test]
        public void ScanId_MultipleIdScanned_CorrectNewId()
        {
            _uut.scan(123456);
            _uut.scan(654321);
            _uut.scan(987654);
            Assert.That(_receivedEventArgs.IdDetected, Is.EqualTo(987654));
        }
    }
}
