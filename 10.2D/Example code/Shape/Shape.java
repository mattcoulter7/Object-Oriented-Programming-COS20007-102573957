public abstract class Shape {
    // private field
    private float _x;
    private float _y;

    // constructor
    public Shape(float x, float y) 
    {
        _x = x;
        _y = y;
    }
    // property field

    public float get_y() {
        return _y;
    }

    public void set_y(float _y) {
        this._y = _y;
    }

    public float get_x() {
        return _x;
    }

    public void set_x(float _x) {
        this._x = _x;
    }
    
    // methods
    public abstract void Draw(float x, float y);
}