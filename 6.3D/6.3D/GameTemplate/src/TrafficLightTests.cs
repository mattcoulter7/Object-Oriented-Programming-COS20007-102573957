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