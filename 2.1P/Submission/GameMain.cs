//References
//https://github.com/macite/swingame/blob/c4794ae73cd11e16c2f51f133e85c9c5425ced0e/CoreSDK/src/sgInput.pas#L126
//http://www.swingame.com/index.php/documentation/how-to/item/how-to-respond-to-mouse-click-and-position.html
//https://github.com/6942555/battleship/blob/master/c%23%20folder/C%23%20swingame/src/MenuController.cs
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

            //Declaring shape variable
            Shape myShape = new Shape();
            
            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);

                //Draws rectangle onto UI
                myShape.Draw();

                //Updates shape position to mouse position
                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.xCoord = SwinGame.MouseX();
                    myShape.yCoord = SwinGame.MouseY();
                }

                //Changes color of shape only when mouse hovers the shape
                if (myShape.PointInRect(SwinGame.MousePosition(),myShape.xCoord,myShape.yCoord, myShape.Width,myShape.Height))
                {
                    if (SwinGame.KeyTyped(KeyCode.SpaceKey))
                    {
                        myShape._Color = SwinGame.RandomColor();
                    }
                }

                //Displays the framerate at 0,0
                SwinGame.DrawFramerate(0,0);
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }     
        }
    }
}