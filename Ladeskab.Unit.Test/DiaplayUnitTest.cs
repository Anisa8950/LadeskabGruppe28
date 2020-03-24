using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using LadeskabLibrary;
using System.IO;


namespace Ladeskab.Unit.Test
{
    [TestFixture]
    public class DiaplayUnitTest
    {
        private Display _uut;
        public StringWriter stringWriter;

        [SetUp]
        public void Setup()
        {
            _uut = new Display();
        }

        [Test]
        public void PrintChargingComplete_CorrectString()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                _uut.PrintChargingComplete();
            }
            Assert.That(stringWriter.ToString(), Is.EqualTo("Mobilelefon er fuld opladt\r\n"));
        }

        [Test]
        public void PrintChargingError_CorrectString()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                _uut.PrintChargingError();
            }
            
            Assert.That(stringWriter.ToString(), Is.EqualTo("Fejl. Evt. kortslutning. Frakobel usb lader.\r\n"));
        }

        [Test]
        public void PrintChargingMobile_CorrectString()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                _uut.PrintChargingMobile();
            }
            
            Assert.That(stringWriter.ToString(), Is.EqualTo("Oplader mobil\r\n"));
        }

        [Test]
        public void PrintConnectingError_CorrectString()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                _uut.PrintConnectingError();
            }
            
            Assert.That(stringWriter.ToString(),
                Is.EqualTo("Tilslutningsfejl.\r\n Tjek at mobiltelefon er tilsluttet korrekt\r\n"));
        }

        [Test]
        public void PrintConnectMobile_CorrectString()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                _uut.PrintConnectMobile();
            }
            
            Assert.That(stringWriter.ToString(), Is.EqualTo("Tilslut mobiltelefon\r\n"));
        }

        [Test]
        public void PrintOccupied_CorrectString()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                _uut.PrintOccupied();
            }
            
            Assert.That(stringWriter.ToString(), Is.EqualTo("Skabet er låst og din mobiltelefon lades. Brug dit RFID tag til at låse op.\r\n"));
        }

        [Test]
        public void PrintRemoveMobile_CorrectString()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                _uut.PrintRemoveMobile();
            }
            Assert.That(stringWriter.ToString(), Is.EqualTo("Fjern mobiltelefon fra skab og luk døren\r\n"));
        }

        [Test]
        public void PrintRFIDError_CorrectString()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                _uut.PrintRFIDError();
            }
            
            Assert.That(stringWriter.ToString(), Is.EqualTo("RFID fejl\r\n"));
        }

        [Test]
        public void PrintScanRFID_CorrectString()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                _uut.PrintScanRFID();
            }
            
            Assert.That(stringWriter.ToString(), Is.EqualTo("Indlæs RFID\r\n"));
        }
    }
}
