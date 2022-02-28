public class Rectangle extends Shape {
    // private field
    private float _width;
    private float _height;

    // constructor
    public Rectangle(float x, float y, float width, float height) 
    {
        super(x,y);
        _width = width;
        _height = height;
    }

    public float get_height() {
        return _height;
    }

    public void set_height(float _height) {
        this._height = _height;
    }

    // property
    public float get_width() {
        return _width;
    }

    public void set_width(float _width) {
        this._width = _width;
    }

    // methods
    @Override
    public void Draw(float x, float y)
    {
        //draw function here
    }
}