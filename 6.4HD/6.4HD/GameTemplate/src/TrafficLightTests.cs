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
            TrafficLight trafficlight1 = new CarTrafficLight(TrafficLights, 125, 125);
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
            TrafficLight trafficlight1 = new CarTrafficLight(TrafficLights, 100, 100);
            Path line = new Path(trafficlight1, 300, 600, 300, 0, 300);
            line.SpawnMovingObject(2);
            line.MovingObjects[0].X = 300;
            line.MovingObjects[0].Y = 200;
            line.SpawnMovingObject(2);
            line.MovingObjects[1].X = 300;
            line.MovingObjects[1].Y = 159;
            Assert.IsTrue(line.MovingObjects[1].ObjectInFront());
        }

        [Test]
        public void CarInFrontOneCarOnly()
        {

            List<TrafficLight> TrafficLights = new List<TrafficLight>();//contains all the trafficlights in the game
            TrafficLight trafficlight1 = new CarTrafficLight(TrafficLights, 100, 100);
            Path line = new Path(trafficlight1, 300, 600, 300, 0, 300);
            line.SpawnMovingObject(2);
            line.MovingObjects[0].X = 300;
            line.MovingObjects[0].Y = 200;
            Assert.IsFalse(line.MovingObjects[0].ObjectInFront());
        }
        [Test]
        public void VariableAngleInsteadOfStaticAngle()
        {
            List<TrafficLight> TrafficLights = new List<TrafficLight>();//contains all the trafficlights in the game
            TrafficLight trafficlight1 = new CarTrafficLight(TrafficLights, 100, 100);
            Path line = new Path(trafficlight1, 300, 600, 300, 0, 300);
            line.SpawnMovingObject(2);
        }
        [Test]
        public void SpawnMovingObjectSpawns1()
        {
            List<TrafficLight> TrafficLights = new List<TrafficLight>();//contains all the trafficlights in the game
            TrafficLight trafficlight1 = new CarTrafficLight(TrafficLights, 100, 100);
            Path line = new Path(trafficlight1, 300, 600, 300, 0, 300);
            line.SpawnMovingObject(2);
            Assert.AreEqual(line.MovingObjects.Count, 1);
        }
        [Test]
        public void AddPathAdds1()
        {

            List<TrafficLight> TrafficLights = new List<TrafficLight>();//contains all the trafficlights in the game
            TrafficLight trafficlight1 = new CarTrafficLight(TrafficLights, 100, 100);
            new Path(trafficlight1, 300, 600, 0, 600, 300);
            Assert.AreEqual(trafficlight1.Paths.Count, 1);
        }
        [Test]
        public void ObjectPoolGoesTo9()
        {
            List<TrafficLight> TrafficLights = new List<TrafficLight>();
            new CarTrafficLight(TrafficLights, 155, 109);
            new Path(TrafficLights[0], 225, 600, 225, 0, 450);
            new Path(TrafficLights[0], 225, 600, 225, 0, 450);
            TrafficLights[0].Paths[0].SpawnMovingObject(2);

            Assert.AreEqual(TrafficLights[0].Paths[0].MovingObjectsPool.MovingObjects.Count, 9);
        }
        [Test]
        public void ObjectPoolGoesBackTo10()
        {
            List<TrafficLight> TrafficLights = new List<TrafficLight>();
            new CarTrafficLight(TrafficLights, 155, 109);
            new Path(TrafficLights[0], 225, 600, 225, 0, 450);
            new Path(TrafficLights[0], 225, 600, 225, 0, 450);
            TrafficLights[0].Paths[0].SpawnMovingObject(2);
            TrafficLights[0].Paths[0].MovingObjects[0].LeaveIntersection();
            Assert.AreEqual(TrafficLights[0].Paths[0].MovingObjectsPool.MovingObjects.Count, 10);
        }
        [Test]
        public void IndexOfMovingObjectNoPoolListResets()
        {
            List<TrafficLight> TrafficLights = new List<TrafficLight>();
            new CarTrafficLight(TrafficLights, 155, 109);
            new Path(TrafficLights[0], 225, 600, 225, 0, 450);
            new Path(TrafficLights[0], 225, 600, 225, 0, 450);
            TrafficLights[0].Paths[0].SpawnMovingObject(2);
            TrafficLights[0].Paths[0].MovingObjects[0].LeaveIntersection();
            TrafficLights[0].Paths[0].SpawnMovingObject(2);
            Assert.AreEqual(TrafficLights[0].Paths[0].MovingObjects[0].GetIndex(), 0);
        }
        //although this and the above test may look silly because we are using the index to get the car, 
        //the point is to prove that the next car added has the index of 0 and not 1 when there is only 1 
        //car. Because there is no Index out of range exception, the tests are sufficient.
        [Test]
        public void IndexOfMovingObjectNoPoolListResetsWithMultipleCars()
        {
            List<TrafficLight> TrafficLights = new List<TrafficLight>();
            new CarTrafficLight(TrafficLights, 155, 109);
            new Path(TrafficLights[0], 225, 600, 225, 0, 450);
            new Path(TrafficLights[0], 225, 600, 225, 0, 450);
            TrafficLights[0].Paths[0].SpawnMovingObject(2);
            TrafficLights[0].Paths[0].MovingObjects[0].LeaveIntersection();
            TrafficLights[0].Paths[0].SpawnMovingObject(2);
            TrafficLights[0].Paths[0].SpawnMovingObject(2);
            Assert.AreEqual(TrafficLights[0].Paths[0].MovingObjects[1].GetIndex(), 1);
        }

        [Test]
        public void PointCrossedFunctions()
        {
            List<TrafficLight> TrafficLights = new List<TrafficLight>();
            new CarTrafficLight(TrafficLights, 155, 109);
            new Path(TrafficLights[0], 225, 0, 225, 600, 225);
            TrafficLights[0].Paths[0].SpawnMovingObject(2);
            var car = TrafficLights[0].Paths[0].MovingObjects[0];
            car.Y = 250;
            Assert.IsTrue(car.PointCrossed(car.GetPath.Stop));
        }

        [Test]
        public void GetsAngry()
        {
            List<TrafficLight> TrafficLights = new List<TrafficLight>();
            new CarTrafficLight(TrafficLights, 155, 109);
            new Path(TrafficLights[0], 225, 0, 225, 600, 225);
            TrafficLights[0].Paths[0].SpawnMovingObject(2);
            var car = TrafficLights[0].Paths[0].MovingObjects[0];
            car.Rage();
            Assert.AreEqual(car.Color, Color.Red);
        }

        [Test]
        public void ReachesZeroReturnsTrue()
        {
            List<TrafficLight> TrafficLights = new List<TrafficLight>();
            new CarTrafficLight(TrafficLights, 155, 109);
            new Path(TrafficLights[0], 225, 0, 225, 600, 225);
            TrafficLights[0].Paths[0].SpawnMovingObject(2);
            var car = TrafficLights[0].Paths[0].MovingObjects[0];
            car.AngerTimer.CurrentTime = 0;
            Assert.IsTrue(car.AngerTimer.ReachesZero());
        }


    }
}