using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LadeskabLibrary;

namespace LadeskabGruppe28
{
    class Program
    {
        static void Main(string[] args)
        {
            LogFile test = new LogFile();
            test.LogDoorLocked("123");
            test.LogDoorUnlocked("321");
            Console.WriteLine("Thing");
        }
    }
}
