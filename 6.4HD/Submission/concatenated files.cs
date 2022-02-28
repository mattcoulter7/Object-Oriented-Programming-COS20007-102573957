using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SwinGameSDK;
using static SwinGameSDK.SwinGame; // requires mcs version 4+, 
// using SwinGameSDK.SwinGame; // requires mcs version 4+, 

namespace TrafficController
{
    public class GameMain
    {
        public static void Main()
        {
            //Open the game window
            OpenGraphicsWindow("GameMain", 600, 600);
            //ShowSwinGameSplashScreen();

            //private field
            double Score = 0;
            double SpawnVehicleTimer = 4 * 60; //timer that spawns moving objects
            double NewSpawnVehicleTimer = SpawnVehicleTimer; //the timer is reset to this one it reaches 0
            List<MovingObject> MovingObjects = new List<MovingObject>();//contains all movingobjects in the game
            List<TrafficLight> TrafficLights = new List<TrafficLight>();//contains all the trafficlights in the game
            //traffic light 0
            new TrafficLight(TrafficLights,150, 110); //185,185
            new Path(TrafficLights[0], 185 + 46 - 15, 600, 185 + 46 - 15, 0, 150, 415);
            new Path(TrafficLights[0],185 + 46 * 2 - 15, 600, 185 + 46 * 2 - 15, 0, 150, 415);
            //traffic light 1
            new TrafficLight(TrafficLights, 415, 110);//440,185
            new Path(TrafficLights[1],0, 185 + 46 - 15, 600, 185 + 46 - 15, 155, 110);
            new Path(TrafficLights[1],0, 185 + 46 * 2 - 15, 600, 185 + 46 * 2 - 15, 155, 110);
            //traffic light 2
            new TrafficLight(TrafficLights, 150, 415);//185,490
            new Path(TrafficLights[2],600, 185 + 46 * 3 - 15, 0, 185 + 46 * 3 - 15, 415, 415);
            new Path(TrafficLights[2],600, 185 + 46 * 4 - 15, 0, 185 + 46 * 4 - 15, 415, 415);
            //traffic light 3
            new TrafficLight(TrafficLights, 415, 415);//440,490
            new Path(TrafficLights[3],185 + 46 * 3 - 15, 0, 185 + 46 * 3 - 15, 600, 415, 155);
            new Path(TrafficLights[3],185 + 46 * 4 - 15, 0, 185 + 46 * 4 - 15, 600, 415, 155);

            //Run the game loop
            while (false == WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                ProcessEvents();
                //Clear the screen and draw the framerate
                ClearScreen(Color.White);

                
                SpawnVehicleTimer -= 1; //ticks timer until spawning moving object
                if (SpawnVehicleTimer == 0) //when the soawning vehicle timer finishes
                {
                    int rnd = new Random().Next(0, TrafficLights.Count);//generates a random index for the trafficlight
                    TrafficLights[rnd].SpawnCar();//spawns a car at that random trafficlight
                    NewSpawnVehicleTimer = Math.Ceiling(0.92 * NewSpawnVehicleTimer);//updates the timer being reset to to shorter time
                    SpawnVehicleTimer = NewSpawnVehicleTimer;//resets timer to above value. THis way spawning times become faster and faster
                }

                foreach (TrafficLight trafficlight in TrafficLights)
                {
                    trafficlight.Draw();//draws all the trafficlights
                    foreach (Path path in trafficlight.Paths)
                    {
                        //path.Draw();
                        foreach (MovingObject movingobject in path.MovingObjects)
                        {
                            if (movingobject.Visible())
                            {
                                MovingObjects.Add(movingobject);//adds vehicles that may collide into movingobjects list
                            }
                            movingobject.Draw(); //draws all the vehicles
                            movingobject.Move();//updates the positions of car
                            movingobject.TestCrash(MovingObjects);//checks if car has crashed
                            if (!movingobject.AngerState)//if not angry
                            {
                                movingobject.TickAngerTimer();//ticks timer until angry
                            }
                            if (movingobject.AtPoint(movingobject.Path.Trafficlight.Container[0].X, movingobject.Path.Trafficlight.Container[0].Y))
                            {
                                Score += Math.Floor(movingobject.GetScore());
                            }
                            
                        }
                    }

                    //updates the trafficlight state when it is clicked
                    if (MouseClicked(MouseButton.LeftButton))
                    {
                        if (trafficlight.MouseIn(MousePosition()))
                        {
                            trafficlight.UpdateState();
                        }
                    }

                }

                MovingObjects.Clear();//clears the array of moving objects so those that are out of frame can be dismissed


                //display framerate
                DrawFramerate(0, 0);
                DrawText("Score: " + Score.ToString(), Color.Black, 500, 0);

                //Draw onto the screen
                RefreshScreen(60);

            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficController
{
    public abstract class GameObject
    {
        //private field
        private List<Shape> _container = new List<Shape>();
        private float _x;
        private float _y;
        //preoprty
        public List<Shape> Container { get => _container; set => _container = value; }
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }

        //constructor
        public GameObject(float x, float y)
        {
            _x = x;
            _y = y;
        }
        //methods
        public void Draw()
        {
            foreach (Shape shape in Container)
            {
                shape.Draw();
            }
        }
        public abstract int? GetIndex();

    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public class TrafficLight : GameObject
    {
        //private field
        private bool _state = false;
        private List<Path> _paths = new List<Path>();
        private List<TrafficLight> _trafficlights;

        //property
        public bool State { get => _state; set => _state = value; }
        public List<Path> Paths { get => _paths; set => _paths = value; }
        public List<TrafficLight> Trafficlights { get => _trafficlights; set => _trafficlights = value; }

        //contructor
        public TrafficLight(List<TrafficLight> trafficlights, float x, float y) : base(x,y)
        {
            _trafficlights = trafficlights;
            _trafficlights.Add(this);
            Container.Add(new Rectangle(Color.Black,X,Y,35,75));
            Container.Add(new Circle(Color.DarkGreen, X + 17, Y + 17, 13));
            Container.Add(new Circle(Color.Red, X + 17, Y + 57, 13));

        }

        //methods
        public void UpdateState()
        {
            if (_state == false)
            {
                _state = true;
                Container[1].Color = Color.LawnGreen;
                Container[2].Color = Color.DarkRed;
            }
            else if (_state == true)
            {
                _state = false;
                Container[1].Color = Color.DarkGreen;
                Container[2].Color = Color.Red;
            }
            ExtraFunctions.PlaySound("trafficlight");
        }

        public bool MouseIn(Point2D pt)
        {
            return Container[0].MouseIn(pt);
        }
        public void SpawnCar()
        {
            int pathnum;
            if (_paths[0].MovingObjects.Count >= _paths[1].MovingObjects.Count)
            {
                pathnum = 1;
            }
            else
            {
                pathnum = 0;
            }
            _paths[pathnum].SpawnMovingObject(Color.Blue);
        }
        public override int? GetIndex()
        {
            foreach (TrafficLight t in _trafficlights)
            {
                if (t == this)
                {
                    return _trafficlights.IndexOf(this);
                }
            }
            return null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public class Path : GameObject
    {
        //Private Field
        private List<MovingObject> _movingobjects = new List<MovingObject>();
        private float _stopx;
        private float _stopy;
        private double _direction;
        private TrafficLight _trafficlight;

        //Property Field
        public List<MovingObject> MovingObjects { get => _movingobjects; set => _movingobjects = value; }
        public float StopX { get => _stopx; set => _stopx = value; }
        public float StopY { get => _stopy; set => _stopy = value; }
        public double Direction { get => _direction; set => _direction = value; }
        public TrafficLight Trafficlight { get => _trafficlight; set => _trafficlight = value; }

        //Constructor
        public Path(TrafficLight trafficlight,float x, float y, float x2, float y2,float stopx,float stopy) : base(x,y)
        {
            _direction = ExtraFunctions.angleOf(X, Y, x2, y2);
            _trafficlight = trafficlight;
            _trafficlight.Paths.Add(this);
            _stopx = stopx;
            _stopy = stopy;
            CreateRoad();
        }

        public void CreateRoad()
        {
            if (_direction == Math.PI / 2)
            {
                Container.Add(new Rectangle(Color.Black, X, Y, 51, 600));
            }
            else if (_direction == -Math.PI / 2)
            {
                Container.Add(new Rectangle(Color.Black, X, Y, 51, -600));
            }
            else if (_direction == Math.PI)
            {
                Container.Add(new Rectangle(Color.Black, X, Y, -600, 51));
            }
            else if (_direction == 0)
            {
                Container.Add(new Rectangle(Color.Black, X, Y, 600, 51));
            }
        }
        
        //Methods
        public void SpawnMovingObject(Color color)
        {
            new MovingObject(this, color, X, Y);
        }
        public override int? GetIndex()
        {
            foreach (Path p in _trafficlight.Paths)
            {
                if (p == this)
                {
                    return _trafficlight.Paths.IndexOf(this);
                }
            }
            return null;
        }
    }
}
using SwinGameSDK;
using System;
using System.Collections.Generic;

namespace TrafficController
{
    public class MovingObject : GameObject
    {
        
        
        //Private Field
        private int _speed = 2;//changes the speed the object moves
        private double _angertimer; //determines how long until objects becomes angry
        private bool _angerstate = false;//once anger timer ends, the angerstate is updated to true
        private Path _path;//a reference to the path that contains this object
        private bool _crashed;

        //Property Field
        public int Speed { get => _speed; set => _speed = value; }
        public double AngerTimer { get => _angertimer; set => _angertimer = value; }
        public bool AngerState { get => _angerstate; set => _angerstate = value; }
        public Path Path { get => _path; set => _path = value; }
        public bool Crashed { get => _crashed; set => _crashed = value; }

        //Constructor
        public MovingObject(Path path,Color color, float x, float y) : base(x, y)
        {
            _angertimer = ExtraFunctions.RandomNumberBetween(6,30) * 60;//generates amount of seconds between 15 and 100
            _path = path;//path reference is assigned
            _path.MovingObjects.Add(this);//add object to the path
            Container.Add(new Rectangle(color, X, Y, 30, 30));//the car rectangle is added to the container

        }

        //Methods

        //moves the car in appropriate direction under given conditions
        public void Move()
        {
            for (int i=0;i<_speed;i++)//changes the speed, this method is necessary to ensure no pixels are skipped
            {
                if (!AtRedLight() && !CarInFront() || //car stops at red light when light is red, car stop if car is in front
                    _angerstate && AtRedLight()) //car drives when angry at red light
                {
                    Container[0].X += Convert.ToSingle(Math.Cos(_path.Direction));
                    Container[0].Y += Convert.ToSingle(Math.Sin(_path.Direction));
                }
            }
        }

        public bool AtRedLight()
        {
            if (!_path.Trafficlight.State && AtPoint(_path.StopX, _path.StopY))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //determines if the vehicle is at the red light
        public bool AtPoint(float x, float y)
        {
            //Red Light
            if (_path.Direction == Math.PI || _path.Direction == 0)//positioned is determined by x for horizontal moving objects
            {
                if (Container[0].X == x)//if the trafficlight is red and theyre at the stop point
                {
                    return true;
                }
                return false;
            }
            else if (_path.Direction == -Math.PI/2 || _path.Direction == Math.PI/2)//positioned is determined by y for vertical moving objects
            {
                if (Container[0].Y == y)//if the trafficlight is red and theyre at the stop point
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        //determines if the object has crossed the red light stop point
        public bool PointCrossed(float x, float y)
        {
            switch(_path.Direction)
            {
                case 0:
                {
                        if (Container[0].X > x) //in front of stop point
                        {
                            return true;
                        }
                        return false;
                }
                case Math.PI / 2:
                {
                        if (Container[0].Y > y) //in front of stop point
                        {
                            return true;
                        }
                        return false;
                }
                case Math.PI:
                {
                        if (Container[0].X < x) //in front of stop point
                        {
                            return true;
                        }
                        return false;
                }
                case -Math.PI / 2:
                {
                        if (Container[0].Y < y) //in front of stop point
                        {
                            return true;
                        }
                        return false;
                }
                default:
                {
                        return false;
                }
            }
            
        }

        //
        public bool CarInFront()
        {
            if (GetIndex() != 0) //means there is at least one car in front
            {
                switch (_path.Direction)//directions is necessary as for the car to be behind another car, the condition is dependent on direction
                {
                    case 0:
                        {
                            if (MovingObjectInFront().Container[0].X - Container[0].X <= 40)//has gap of 10px between vehicles
                            {
                                return true;
                            }
                            return false;
                        }
                    case Math.PI / 2:
                        {
                            if (Container[0].Y - MovingObjectInFront().Container[0].Y >= -40)//has gap of 10px between vehicles
                            {
                                return true;
                            }
                            return false;
                        }
                    case Math.PI:
                        {
                            if (MovingObjectInFront().Container[0].X - Container[0].X >= -40)//has gap of 10px between vehicles
                            {
                                return true;
                            }
                            return false;
                        }
                    case -Math.PI / 2:
                        {
                            if (Container[0].Y - MovingObjectInFront().Container[0].Y <= 40)//has gap of 10px between vehicles
                            {
                                return true;
                            }
                            return false;
                        }
                    default:
                        {
                            return false;
                        }
                }
                
            }
            return false; //first vehicle always moves
        }

        //returns vehicle in front of current car
        //used stop stop the vehicle behind the other vehicle
        public MovingObject MovingObjectInFront()
        {
            return _path.MovingObjects[GetIndex() - 1 ?? default];
        }

        
        //ticks down the anger timer
        public void TickAngerTimer()
        {
            if (!PointCrossed(_path.StopX, _path.StopY))//red light point
            { 
                _angertimer -= 1;
            }
              
            if (_angertimer == 0)//once the timer ends
            {
                UpdateAngerState();// the anger state is updated
            }

        }
        public void UpdateAngerState()
        {
            if (!_angerstate)
            {
                ExtraFunctions.PlaySound("angery");
                _angertimer -= 1;//stops the angerstate from continuing to update
                Container[0].Color = Color.Red;
                _speed = 4;//angry cars drive faster
                _angerstate = true;
            }
            else if (_angerstate)
            {
                _angerstate = false;
                Container[0].Color = Color.Blue;
            }
        }

        //determines if two objects have collided
        public void TestCrash(List<MovingObject> HorizontalMovingObjects)
        {
            foreach (MovingObject movingobject in HorizontalMovingObjects)//this object intersection is tested with every single movingobject
            {
                if (this != movingobject) //can't crash into itself
                {
                    foreach (Rectangle rect in Container)//converts from shape into rectangle
                    {
                        if (rect.Intersects(movingobject.Container[0] as Rectangle)) //if their rectangle intersect
                        {
                            Crash(movingobject);//call crash if crash occurs
                        }
                    }
                }
                
            }
        }

        public double GetScore()
        {
            if(!_angerstate)
            {
                return _angertimer/60;
            }
            else if (_angerstate)
            {
                return -50;
            }
            return 0;
        }

        //determines whether object is within the intersection, for memory saving
        public bool Visible()
        {
            if (Container[0].X >= 185 && Container[0]. Y >= 185 && Container[0].X <= 440 && Container[0].Y <= 490)
            {
                return true;
            }
            return false;
        }

        public void Crash(MovingObject movingobject)
        {
            if (!_crashed)
            {
                ExtraFunctions.PlaySound("crash");
                Container[0].Color = Color.Orange;
                movingobject.Container[0].Color = Color.Orange;
                Stop();//stops current vehicle
                movingobject.Stop();// stop crashed into vehicle
                _crashed = true;
            }
            
        }

        //stop the vehicle
        public void Stop()
        {
            _speed = 0;
        }
        //returns index of this vehicle in path list
        public override int? GetIndex()
        {
            foreach(MovingObject m in _path.MovingObjects)
            {
                if (m == this)
                {
                    return _path.MovingObjects.IndexOf(this);
                }
            }
            return null;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public abstract class Shape
    {
        //Private field
        private Color _color;
        private float _x;
        private float _y;
        //Property
        public Color Color { get => _color; set => _color = value; }
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }

        //Contructor
        public Shape(Color color, float x, float y)
        {
            _color = color;
            X = x;
            Y = y;
        }
        //Methods
        public abstract void Draw();
        public abstract bool MouseIn(Point2D pt);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public class Rectangle : Shape
    {
        //private field
        private float _width;
        private float _height;


        //property
        public float Width { get => _width;}
        public float Height { get => _height;}

        public Rectangle(Color color, float x, float y,float width,float height) : base(color,x,y)
        {
            _width = width;
            _height = height;
        }

        public override void Draw()
        {
            SwinGame.FillRectangle(Color,X, Y, _width,_height);
        }
        public override bool MouseIn(Point2D pt)
        {
            return SwinGame.PointInRect(pt, X, Y, _width, _height);
        }
        public bool Intersects(Rectangle rect2)
        {
            //top left
            if (rect2.X - X >= 0 && rect2.X - X <= _width &&
            rect2.Y - Y >= 0 && rect2.Y - Y <= _height)
            {
                return true;
            }

            //top right
            if (X - rect2.X >= 0 && X - rect2.X <= _width &&
            rect2.Y - Y >= 0 && rect2.Y - Y <= _height)
            {
                return true;
            }

            //bottom left
            if (rect2.X - X >= 0 && rect2.X - X <= _width &&
            Y - rect2.Y >= 0 && Y - rect2.Y <= _height)
            {
                return true;
            }

            //bottom right
            if (X - rect2.X >= 0 && X - rect2.X <= _width &&
            Y - rect2.Y >= 0 && Y - rect2.Y <= _height)
            {
                return true;
            }
            return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public class Circle : Shape
    {
        //private field
        private float _radius;

        //property
        public float Radius { get => _radius; set => _radius = value; }
        
        //contructor
        public Circle(Color color,float x,float y,float radius) : base(color,x,y)
        {
            _radius = radius;
        }

        //methods
        public override void Draw()
        {
            SwinGame.FillCircle(Color, X, Y, _radius);
        }
        public override bool MouseIn(Point2D pt)
        {
            return SwinGame.PointInCircle(pt, X, Y, _radius);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public class Line : Shape
    {
        //private field
        private float _x2;
        private float _y2;
        //property
        public float X2 { get => _x2; set => _x2 = value; }
        public float Y2 { get => _y2; set => _y2 = value; }

        //contructor
        public Line(Color color, float x, float y,float x2,float y2) : base(color,x,y)
        {
            _x2 = x2;
            _y2 = y2;
        }



        //methods
        public override void Draw()
        {
            SwinGame.DrawLine(Color,X,Y,_x2,_y2);
        }
        public override bool MouseIn(Point2D pt)
        {
            return SwinGame.PointOnLine(pt, X, Y, _x2, _y2);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public class ExtraFunctions
    {
        public static double angleOf(float x1, float y1, float x2, float y2)
        {
            float xDiff = x2 - x1;
            float yDiff = y2 - y1;
            return Math.Atan2(yDiff, xDiff);
        }

        public static int RandomNumberBetween(int x, int y)
        {
            Random rnd = new Random();
            return rnd.Next(x, y);
        }
        public static void PlaySound(string sound)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Resources\sounds\" + sound + ".wav");
            player.Play();
        }
    }
}
using NUnit.Framework;
using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace TrafficController
{
    [TestFixture]
    public class SwinTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MouseInTrafficLight()
        {

            List<TrafficLight> TrafficLights = new List<TrafficLight>();//contains all the trafficlights in the game
            TrafficLight trafficlight1 = new TrafficLight(TrafficLights,100, 100);
            trafficlight1.Draw();
            Point2D pt = new Point2D();
            pt.X = 125;
            pt.Y = 125;
            Assert.IsTrue(trafficlight1.MouseIn(pt));
        }

        [Test]
        public void CarInFront()
        {
            List<TrafficLight> TrafficLights = new List<TrafficLight>();//contains all the trafficlights in the game
            TrafficLight trafficlight1 = new TrafficLight(TrafficLights, 100, 100);
            Path line = new Path(trafficlight1,300, 600, 300, 0, 300, 200);
            line.SpawnMovingObject(Color.Black);
            line.MovingObjects[0].Container[0].X = 300;
            line.MovingObjects[0].Container[0].Y = 200;
            line.SpawnMovingObject(Color.Black);
            line.MovingObjects[1].Container[0].X = 300;
            line.MovingObjects[1].Container[0].Y = 159;
            Assert.IsTrue(line.MovingObjects[1].CarInFront());
        }

        [Test]
        public void CarInFrontOneCarOnly()
        {

            List<TrafficLight> TrafficLights = new List<TrafficLight>();//contains all the trafficlights in the game
            TrafficLight trafficlight1 = new TrafficLight(TrafficLights, 100, 100);
            Path line = new Path(trafficlight1,300, 600, 300, 0, 300, 200);
            line.SpawnMovingObject(Color.Black);
            line.MovingObjects[0].Container[0].X = 300;
            line.MovingObjects[0].Container[0].Y = 200;
            Assert.IsFalse(line.MovingObjects[0].CarInFront());
        }
        [Test]
        public void VariableAngleInsteadOfStaticAngle()
        {
            List<TrafficLight> TrafficLights = new List<TrafficLight>();//contains all the trafficlights in the game
            TrafficLight trafficlight1 = new TrafficLight(TrafficLights, 100, 100);
            Path line = new Path(trafficlight1,300, 600, 300, 0, 300, 200);
            line.SpawnMovingObject(Color.Black);
        }
        [Test]
        public void SpawnMovingObjectSpawns1()
        {
            List<TrafficLight> TrafficLights = new List<TrafficLight>();//contains all the trafficlights in the game
            TrafficLight trafficlight1 = new TrafficLight(TrafficLights, 100, 100);
            Path line = new Path(trafficlight1,300, 600, 300, 0, 300, 200);
            line.SpawnMovingObject(Color.Black);
            Assert.AreEqual(line.MovingObjects.Count, 1);
        }
        [Test]
        public void AddPathAdds1()
        {

            List<TrafficLight> TrafficLights = new List<TrafficLight>();//contains all the trafficlights in the game
            TrafficLight trafficlight1 = new TrafficLight(TrafficLights, 100, 100);
            new Path(trafficlight1,300, 600, 0, 600, 300, 200);
            Assert.AreEqual(trafficlight1.Paths.Count, 1);
        }
        [Test]
        public void RectangleIntersectionTL()
        {
            Rectangle rectangle1 = new Rectangle(Color.Blue, 180, 180, 50, 50);
            Rectangle rectangle2 = new Rectangle(Color.Blue, 200, 200, 50, 50);
            
            Assert.IsTrue(rectangle1.Intersects(rectangle2));
        }
        [Test]
        public void RectangleIntersectionTR()
        {
            Rectangle rectangle1 = new Rectangle(Color.Blue, 220, 180, 50, 50);
            Rectangle rectangle2 = new Rectangle(Color.Blue, 200, 200, 50, 50);

            Assert.IsTrue(rectangle1.Intersects(rectangle2));
        }
        [Test]
        public void RectangleIntersectionBL()
        {
            Rectangle rectangle1 = new Rectangle(Color.Blue, 180, 220, 50, 50);
            Rectangle rectangle2 = new Rectangle(Color.Blue, 200, 200, 50, 50);

            Assert.IsTrue(rectangle1.Intersects(rectangle2));
        }
        [Test]
        public void RectangleIntersectionBR()
        {
            Rectangle rectangle1 = new Rectangle(Color.Blue, 220, 220, 50, 50);
            Rectangle rectangle2 = new Rectangle(Color.Blue, 200, 200, 50, 50);

            Assert.IsTrue(rectangle1.Intersects(rectangle2));
        }
        [Test]
        public void RectangleInsideRectangleIntersects()
        {
            Rectangle rectangle1 = new Rectangle(Color.Blue, 200, 200, 50, 50);
            Rectangle rectangle2 = new Rectangle(Color.Blue, 150, 150, 100, 100);

            Assert.IsTrue(rectangle1.Intersects(rectangle2));
        }

    }
}