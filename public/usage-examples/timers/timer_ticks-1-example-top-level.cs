using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Timer Ticks Example", 600, 300);

SplashKitSDK.Timer myTimer = CreateTimer("example timer");
StartTimer(myTimer);

while (!QuitRequested())
{
    ProcessEvents();

    ClearScreen(ColorWhite());

    DrawText(
        "Elapsed milliseconds:",
        ColorBlack(),
        170,
        100
    );

    DrawText(
        TimerTicks(myTimer).ToString(),
        ColorBlue(),
        250,
        150
    );

    RefreshScreen(60);
}

FreeTimer(myTimer);
CloseAllWindows();