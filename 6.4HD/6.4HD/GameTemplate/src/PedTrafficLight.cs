using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public class PedTrafficLight : TrafficLight
    {
        public PedTrafficLight(List<TrafficLight> trafficlights, float x, float y) : base(trafficlights, x, y)
        {
            Sprite.AddShape(new Rectangle(Color.Black, x, y, 20, 40));
            Sprite.AddShape(new Circle(Color.DarkGreen, X , Y - 9 , 8));
            Sprite.AddShape(new Circle(Color.Red, X, Y + 9, 8));
        }
        public override void SpawnMovingObject(int speed)
        {
            GetLowestCountPath().SpawnMovingObject(2);
        }
    }
}
