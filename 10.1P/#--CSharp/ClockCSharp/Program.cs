using System;
using System.Threading;

namespace ClockCSharp
{
    public class Program
    {
        static void Main()
        {
            Counter secs = new Counter();
            Counter mins = new Counter();
            Counter hours = new Counter();

            while (true)
            {
                Console.WriteLine("{0}:{1}:{2}", hours.Value, mins.Value, secs.Value);
                Thread.Sleep(1);

                secs.Tick();
                if (secs.Value == 60)
                {
                    secs.Reset();
                    mins.Tick();
                }
                if (mins.Value == 60)
                {
                    mins.Reset();
                    hours.Tick();
                }
                if (hours.Value == 24)
                {
                    hours.Reset();
                }

                Console.Clear();
            }
        }
    }
}
