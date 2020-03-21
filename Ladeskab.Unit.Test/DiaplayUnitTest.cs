using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using LadeskabLibrary;


namespace Ladeskab.Unit.Test
{
    [TestFixture]
    public class DiaplayUnitTest
    {
        private Display _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new Display();
        }

        [Test]
        public void PrintChargingComplete_CorrectString()
        {
            _uut.PrintChargingComplete();
            Assert.That(_uut.ConsoleString, Is.EqualTo("Mobilelefon er fuld opladt"));
            
        }

        [Test]
        public void PrintChargingError_CorrectString()
        {
            _uut.PrintChargingError();
            Assert.That(_uut.ConsoleString, Is.EqualTo("Fejl. Evt. kortslutning. Frakobel usb lader."));
        }

        [Test]
        public void PrintChargingMobile_CorrectString()
        {
            _uut.PrintChargingMobile();
            Assert.That(_uut.ConsoleString, Is.EqualTo("Oplader mobil"));
        }

        [Test]
        public void PrintConnectingError_CorrectString()
        {
            _uut.PrintConnectingError();
            Assert.That(_uut.ConsoleString,
                Is.EqualTo("Tilslutningsfejl.\r\n Tjek at mobiltelefon er tilsluttet korrekt"));
        }

        [Test]
        public void PrintConnectMobile_CorrectString()
        {
            _uut.PrintConnectMobile();
            Assert.That(_uut.ConsoleString, Is.EqualTo("Tilslut mobiltelefon"));
        }

        [Test]
        public void PrintOccupied_CorrectString()
        {
            _uut.PrintOccupied();
            Assert.That(_uut.ConsoleString, Is.EqualTo("Skabet er låst og din mobiltelefon lades. Brug dit RFID tag til at låse op."));
        }

        [Test]
        public void PrintRemoveMobile_CorrectString()
        {
            _uut.PrintRemoveMobile();
            Assert.That(_uut.ConsoleString, Is.EqualTo("Fjern mobiltelefon fra skab og luk døren"));
        }

        [Test]
        public void PrintRFIDError_CorrectString()
        {
            _uut.PrintRFIDError();
            Assert.That(_uut.ConsoleString, Is.EqualTo("Forkert RFID tag"));
        }

        [Test]
        public void PrintScanRFID_CorrectString()
        {
            _uut.PrintScanRFID();
            Assert.That(_uut.ConsoleString, Is.EqualTo("Indlæs RFID"));
        }
    }
}
