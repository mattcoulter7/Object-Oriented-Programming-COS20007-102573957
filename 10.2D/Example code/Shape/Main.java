import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main() {
        List<Shape> shapes = new ArrayList<>();
        
        shapes.add(new Rectangle(0,0,50,100));
        shapes.add(new Circle(100,100,20));

        for (Shape shape : shapes)
        {
            shape.Draw(shape.get_x(),shape.get_y());
        }
        
    }
}



