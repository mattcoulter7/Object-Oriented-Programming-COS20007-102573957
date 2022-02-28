using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficController
{
    public class Controller
    {
        private int _score = 0;
        private List<TrafficLight> _trafficLights = new List<TrafficLight>();
        private List<MovingObject> _moving = new List<MovingObject>();

        public Controller()
        {
            InitialiseTrafficLights();
            InitialisePaths();
            InitialiseMovingCollection();
        }

        public List<MovingObject> GetMoving { get => _moving; }
        public List<TrafficLight> GetTrafficLights { get => _trafficLights; }
        public int Score { get => _score; set => _score = value; }

        public void InitialisePaths()
        {
            // Car traffic light 0
            new Path(_trafficLights[0], 225, 600, 225, 0, 450);
            new Path(_trafficLights[0], 275, 600, 275, 0, 450);

            // Car traffic light 1
            new Path(_trafficLights[1], 0, 225, 600, 225, 150);
            new Path(_trafficLights[1], 0, 275, 600, 275, 150);

            // Car traffic light 2
            new Path(_trafficLights[2], 600, 325, 0, 325, 450);
            new Path(_trafficLights[2], 600, 375, 0, 375, 450);

            // Car traffic light 3
            new Path(_trafficLights[3], 325, 0, 325, 600, 150);
            new Path(_trafficLights[3], 375, 0, 375, 600, 150);

            // Ped traffic light 4
            new Path(_trafficLights[4], 200, 600, 200, 0, 400);
            new Path(_trafficLights[4], 200, 0, 200, 600, 200);
            // Ped traffic light 4
            new Path(_trafficLights[5], 0, 200, 600, 200, 200);
            new Path(_trafficLights[5], 600, 200, 0, 200, 400);
            // Ped traffic light 4
            new Path(_trafficLights[6], 400, 0, 400, 600, 200);
            new Path(_trafficLights[6], 400, 600, 400, 0, 400);
            // Ped traffic light 4
            new Path(_trafficLights[7], 0, 400, 600, 400, 200);
            new Path(_trafficLights[7], 600, 400, 0, 400, 400);
        }
        public void InitialiseTrafficLights()
        {
            new CarTrafficLight(_trafficLights, 155, 109);
            new CarTrafficLight(_trafficLights, 475, 139);
            new CarTrafficLight(_trafficLights, 125, 461);
            new CarTrafficLight(_trafficLights, 445, 491);

            new PedTrafficLight(_trafficLights, 185, 127);
            new PedTrafficLight(_trafficLights, 445, 157);
            new PedTrafficLight(_trafficLights, 155, 443);
            new PedTrafficLight(_trafficLights, 415, 473);
        }

        public void InitialiseMovingCollection()
        {
            foreach (TrafficLight t in _trafficLights)
            {
                foreach (Path p in t.Paths)
                {
                    List<MovingObject> temp = p.MovingObjectsPool.MovingObjects.ToList();
                    foreach (MovingObject i in temp)
                    {
                        _moving.Add(i as MovingObject);
                    }
                    
                }
            } 
        }
    }
}
