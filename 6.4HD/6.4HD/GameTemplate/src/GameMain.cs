using SwinGameSDK;
using System;
using System.Collections.Generic;
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
            ShowSwinGameSplashScreen();

            RecursiveTimer SpawnVehicleTimer = new RecursiveTimer(4,0.92);
            Controller c = new Controller();

            //Run the game loop
            while (false == WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                ProcessEvents();
                //Clear the screen and draw the framerate
                ClearScreen(Color.White);

                SpawnVehicleTimer.Tick();
                if (SpawnVehicleTimer.ReachesZero())
                {
                    SpawnVehicleTimer.Update();
                    int rnd = new Random().Next(0, c.GetTrafficLights.Count);//generates a random index for the trafficlight
                    c.GetTrafficLights[rnd].SpawnMovingObject(Convert.ToInt32(Math.Ceiling(120 / SpawnVehicleTimer.CurrentTime)));//spawns a car at that random trafficlight
                }

                //object loops
                foreach (TrafficLight t in c.GetTrafficLights)
                {
                    t.Draw();//draws all the trafficlights
                    foreach (Path p in t.Paths)
                    {
                        p.Draw();
                        
                        for (int i = p.MovingObjects.Count - 1; i >= 0; i--) //list run into reverse because items are being taken out of it during iteration
                        {
                            var m = p.MovingObjects[i];
                            
                            m.Draw(); //draws all the vehicles
                            m.Move();//updates the positions of movingobjects

                            if (m is Car) //only cars can crash into other objects
                            {
                                m.TestCrash(c.GetMoving);//checks if car has crashed
                            }

                            if (m.AngerTimer.State)
                            {
                                m.AngerTimer.Tick();
                                if (!m.CheckAngerTimerCondition())
                                {
                                    m.AngerTimer.StopTimer();
                                }
                                if (m.AngerTimer.ReachesZero())
                                {
                                    m.AngerTimer.Update();
                                    m.Rage();
                                }
                            }
                            if (m.Active && !m.Within(0,0,600,600) && m.PointCrossed(m.GetPath.Stop) && m.GetPath.MovingObjects.Contains(m))
                            {
                                c.Score += m.UpdateScore();
                                m.LeaveIntersection();
                            }

                            if (MouseClicked(MouseButton.LeftButton))
                            {
                                if (m.Sprite.Container[0].PointIn(MousePosition()))
                                {
                                    t.UpdateState();
                                }
                            }
                        }

                    }

                    //updates the trafficlight state when it is clicked
                    if (MouseClicked(MouseButton.LeftButton))
                    {
                        if (t.MouseIn(MousePosition()))
                        {
                            t.UpdateState();
                        }
                    }

                }

                //display framerate
                DrawFramerate(0, 0);
                DrawText("Score: " + c.Score.ToString(), Color.Black, 500, 0);

                //Draw onto the screen
                RefreshScreen(60);
            }
        }
    }
}
