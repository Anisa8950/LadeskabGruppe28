using System.Collections.Generic;
using NUnit.Framework;
using LadeskabLibrary;
using NSubstitute;
using System.IO;


namespace Ladeskab.Unit.Test
{
    public class LogFileUnitTest
    {
        private LogFile _uut;
        private string _path = "LadeskabLogFil.txt";
        private string[] allLines;
        private string[] inputFields;


        [SetUp]
        public void Setup()
        {
            _uut = new LogFile();
        }

        [Test]
        public void LogDoorLockedCalled_CorretMessageAndID()
        {
            _uut.LogDoorLocked("123456");

            allLines = System.IO.File.ReadAllLines(_path);
            string lastLine = allLines[allLines.Length - 1];
            inputFields = lastLine.Split(';');
            string _logedmessage = inputFields[1];
            string _logedId = inputFields[2];

            Assert.That(_logedmessage, Is.EqualTo("Skab låst med RFID"));
            Assert.That(_logedId, Is.EqualTo("123456"));
        }

        [Test]
        public void LogDoorUnlockedCalled_CorretMessageAndID()
        {
            _uut.LogDoorUnlocked("123456");

            allLines = System.IO.File.ReadAllLines(_path);
            string lastLine = allLines[allLines.Length - 1];
            inputFields = lastLine.Split(';');
            string _logedmessage = inputFields[1];
            string _logedId = inputFields[2];

            Assert.That(_logedmessage, Is.EqualTo("Skab låst op med RFID"));
            Assert.That(_logedId, Is.EqualTo("123456"));
        }
    }
}
