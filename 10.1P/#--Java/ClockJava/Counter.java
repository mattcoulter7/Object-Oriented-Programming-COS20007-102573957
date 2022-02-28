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