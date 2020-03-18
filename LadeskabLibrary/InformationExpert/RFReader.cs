using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLibrary
{
    public class RFReader : IRFReader
    {
        public event EventHandler<RFDetectedEventArgs> IdDetectedEvent;
        
        public void scan(int id)
        {
            OnIdDetectedEvent(new RFDetectedEventArgs { IdDetected = id });
        }

        private void OnIdDetectedEvent(RFDetectedEventArgs e)
        {
            IdDetectedEvent?.Invoke(this, e);
        }
    }
}
