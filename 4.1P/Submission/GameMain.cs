using SwinGameSDK;
using System;

namespace MyGame
{
    public class GameMain
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();
            SwinGame.OpenAudio();

            //variable declarations
            Drawing DrawingTool = new Drawing();
            ShapeKind kindToAdd = new ShapeKind();
            kindToAdd = ShapeKind.Circle;

            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                if (SwinGame.MouseClicked(MouseButton.RightButton))
                {
                    DrawingTool.SelectShapesAt(SwinGame.MousePosition());
                }
                //changing shape
                if (SwinGame.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SwinGame.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if (SwinGame.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }
                //clicking adds new shape
                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                    if (kindToAdd == ShapeKind.Circle)
                    {
                        Circle newCircle = new Circle();
                        newCircle.X = SwinGame.MouseX();
                        newCircle.Y = SwinGame.MouseY();
                        DrawingTool.AddShape(newCircle);
                    }
                    else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        Rectangle newRectangle = new Rectangle();
                        newRectangle.X = SwinGame.MouseX();
                        newRectangle.Y = SwinGame.MouseY();
                        DrawingTool.AddShape(newRectangle);
                    }
                    else if (kindToAdd == ShapeKind.Line)
                    {
                        Line newLine = new Line();
                        newLine.X = SwinGame.MouseX();
                        newLine.Y = SwinGame.MouseY();
                        newLine.X2 = newLine.X + Convert.ToSingle(newLine.Length * Math.Cos(newLine.Angle));
                        newLine.Y2 = newLine.Y + Convert.ToSingle(newLine.Length * Math.Sin(newLine.Angle));
                        DrawingTool.AddShape(newLine);
                    }
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