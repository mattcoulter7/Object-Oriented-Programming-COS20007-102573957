using System;
using System.Collections.Generic;
using System.Text;

namespace ClockCSharp
{
    public class Counter
    {
        private int _value = 0;
        public Counter()
        {
        }

        public int Value { get => _value; set => _value = value; }

        public void Tick()
        {
            _value += 1;
        }

        public void Reset()
        {
            _value = 0;
        }
    }
}
