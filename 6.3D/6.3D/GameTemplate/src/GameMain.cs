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
                        path.Draw();
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
