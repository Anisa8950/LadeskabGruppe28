using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public interface IRFReader
    {
        event EventHandler<RFDetectedEventArgs> IdDetectedEvent;
        void scan(int id);
    }
}
