using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public interface ILogFile
    {
        void LogDoorLocked(string id);
        void LogDoorUnlocked(string id);
    }
}
