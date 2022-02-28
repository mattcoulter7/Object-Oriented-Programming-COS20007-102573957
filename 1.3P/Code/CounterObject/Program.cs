using System;

namespace CounterObject
{
    class Program
    {
        static void Main()
        {
            //local variables
            Counter[] myCounters = new Counter[3];
            int i;

            //step 1
            myCounters[0] = new Counter("Counter 1");

            //step 2
            myCounters[1] = new Counter("Counter 2");

            //step 3
            myCounters[2] = myCounters[0];

            //step 3
            for (i = 0;  i <= 4; i++)
            {
                //step 4
                myCounters[0].Increment();
            }

            //step 5
            for (i = 0; i <= 9; i++)
            {
                //step 6
                myCounters[1].Increment();
            }

            //step 7
            PrintCounters(myCounters);

            //step 10
            myCounters[2].Reset();

            //step 11
            PrintCounters(myCounters);

        }

    static void PrintCounters(Counter[] counters)
        {
            foreach (Counter c in counters)
            {
                Console.WriteLine("Value {0} is {1}",c.Name,c.Value);
            }
        }
        
    }
}
