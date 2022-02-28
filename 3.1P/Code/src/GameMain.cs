using System;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();

            Drawing DrawingTool = new Drawing();

            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                if (SwinGame.MouseClicked(MouseButton.RightButton))
                {
                    DrawingTool.SelectShapesAt(SwinGame.MousePosition());
                }
                //clicking adds new shape
                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                        DrawingTool.AddShape(new Shape(SwinGame.MousePosition()));
                }

                //space bar changes background colour
                if (SwinGame.KeyTyped(KeyCode.SpaceKey))
                {
                    DrawingTool.Background = SwinGame.RandomColor();
                }

                if (SwinGame.KeyTyped(KeyCode.DeleteKey) || SwinGame.KeyTyped(KeyCode.BackspaceKey))
                {
                    DrawingTool.DeselectShape();
                }

                //redraws all shaps in list _shapes
                DrawingTool.Draw();

                //Displays the framerate at 0,0
                SwinGame.DrawFramerate(0,0);
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }     
        }
    }
}