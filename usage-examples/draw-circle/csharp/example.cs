// Draw a circle in the center of the screen
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        SplashKit.OpenWindow("Circle Example", 800, 600);

        while (!SplashKit.QuitRequested())
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen(Color.White);

            // Draw a circle at (400, 300) with radius 50
            SplashKit.DrawCircle(Color.Blue, 400, 300, 50);

            SplashKit.RefreshScreen();
        }
    }
}