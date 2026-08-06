using SplashKitSDK;

namespace TimerTicksExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow(
                "Timer Ticks Example",
                600,
                300
            );

            Timer myTimer = SplashKit.CreateTimer("example timer");
            SplashKit.StartTimer(myTimer);

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                SplashKit.ClearScreen(
                    SplashKit.ColorWhite()
                );

                SplashKit.DrawText(
                    "Elapsed milliseconds:",
                    SplashKit.ColorBlack(),
                    170,
                    100
                );

                SplashKit.DrawText(
                    SplashKit.TimerTicks(myTimer).ToString(),
                    SplashKit.ColorBlue(),
                    250,
                    150
                );

                SplashKit.RefreshScreen(60);
            }

            SplashKit.FreeTimer(myTimer);
            SplashKit.CloseAllWindows();
        }
    }
}