using System;
using System.Threading;

namespace ClockImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock _clock = new Clock();
            do
            {
                _clock.Tick();
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine(_clock.ReturnTime());
                
            } while (Equals(_clock.ReturnTime(), "23:59:59") == false);                
        }
    }
}
