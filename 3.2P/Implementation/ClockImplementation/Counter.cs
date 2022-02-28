using System;
using System.Collections.Generic;
using System.Text;

namespace ClockImplementation
{
    public class Counter
    {
        private int _count = 0;
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        public void Increment()
        {
            _count += 1;
        }

        public void Reset()
        {
            _count = 0;
        }
    }
    
}
