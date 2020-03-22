using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LadeskabLibrary
{
    public class LogFile : ILogFile
    {
        private string _path = "LadeskabLogFil.txt";

        public void LogDoorLocked(string id)
        {
            using (var writer = File.AppendText(_path))
            {
                writer.WriteLine(DateTime.Now + ";Skab låst med RFID;" + id);
            }
        }

        public void LogDoorUnlocked(string id)
        {
            using (var writer = File.AppendText(_path))
            {
                writer.WriteLine(DateTime.Now + ";Skab låst op med RFID;" + id);
            }
        }
    }
}
