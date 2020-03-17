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

        public void LogDoorLocked(string id)
        {
            using (StreamWriter sw = new StreamWriter("C:\\Users\\stefi\\source\\repos\\LadeskabGruppe28", true))
            {
                try
                {
                    sw.WriteLine(DateTime.Now + ": Skab låst med RFID: " + id);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }

        public void LogDoorUnlocked(string id)
        {
            using (StreamWriter sw = new StreamWriter(@"..\\..\\..\\LogFil.txt", true))
            {
                try
                {
                    sw.WriteLine(DateTime.Now + ": Skab låst op med RFID: " + id);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }
    }
}
