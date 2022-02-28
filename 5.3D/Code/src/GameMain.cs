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
            Shape.RegisterShape("Rectangle", typeof(Rectangle));
            Shape.RegisterShape("Circle", typeof(Circle));
            Shape.RegisterShape("Line", typeof(Line));

            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();
            SwinGame.OpenAudio();

            //variable declarations
            String filename = "C:\\Users\\Matthew Coulter\\Desktop\\TestDrawing.txt";
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
                    Shape s = null;
                    if (kindToAdd == ShapeKind.Circle)
                    {
                        s = new Circle();
                        
                    }
                    else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        s = new Rectangle();
                    }
                    else if (kindToAdd == ShapeKind.Line)
                    {
                        s = new Line();
                    }
                    s.X = SwinGame.MouseX();
                    s.Y = SwinGame.MouseY();
                    DrawingTool.AddShape(s);
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
                if (SwinGame.KeyTyped(KeyCode.SKey))
                {
                    DrawingTool.Save(filename);
                }
                if (SwinGame.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        DrawingTool.Load(filename);
                    }
                    catch(Exception e)
                    {
                        Console.Error.WriteLine("Error Loading File: {0}",e.Message);
                    }
                    
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