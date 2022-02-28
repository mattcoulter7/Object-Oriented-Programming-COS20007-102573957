public class Main{
    public static void main(String args[]) throws InterruptedException
    {
        Counter secs = new Counter();
        Counter mins = new Counter();
        Counter hours = new Counter();

        while (true)
        {
            clearScreen();
            System.out.println(String.format("%02d", hours.getCount()) + ":" + String.format("%02d", mins.getCount()) + ":" + String.format("%02d", secs.getCount()));
            Thread.sleep(1000);
            secs.Tick();
            if (secs.getCount() == 60)
            {
                secs.Reset();
                mins.Tick();
            }
            if (mins.getCount() == 60)
            {
                mins.Reset();
                hours.Tick();
            }
            if (hours.getCount() == 24)
            {
                hours.Reset();
            }
        }
    }

    public static void clearScreen() {  
        for(int i = 0; i < 50; i++) {
            System.out.println();
          } 
    }
}

public class Counter{
    private int _count = 0;

    public void setCount(int value)
    {
        _count = value;
    }

    public int getCount()
    {
        return _count;
    }

    public Counter()
    {

    }
    public void Tick()
    {
        _count += 1;
    }
    public void Reset()
    {
        _count = 0;
    }
}