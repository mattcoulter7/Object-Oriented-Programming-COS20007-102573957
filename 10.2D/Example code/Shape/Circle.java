public class Circle extends Shape {
    // private field
    private float _radius;

    // constructor
    public Circle(float x, float y, float radius) {
        super(x, y);
        set_radius(radius);
    }

    public float get_radius() {
        return _radius;
    }

    public void set_radius(float _radius) {
        this._radius = _radius;
    }

    // methods
    @Override
    public void Draw(float x, float y)
    {
        //draw function here
    }
}