using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueSimulator
{
    class QueueingPerson
    {
        private int timeToCheckout;

        public QueueingPerson(int timeToCheckOut)
        {
            this.timeToCheckout = timeToCheckOut;
        }

        public bool decCheckOutTime()
        {
            timeToCheckout--;
            return timeToCheckout < 0;
        }
    }
}
