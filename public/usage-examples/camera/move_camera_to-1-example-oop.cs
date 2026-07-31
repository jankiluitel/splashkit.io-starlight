using System;
using SplashKitSDK;

namespace CameraFollowPlayerExample
{
    public class Program
    {
        public static void Main()
        {
            const int screenWidth = 800;
            const int screenHeight = 600;
            const int worldWidth = 2000;
            const int worldHeight = 1400;

            const double playerSize = 40;
            const double movementSpeed = 5;

            SplashKit.OpenWindow(
                "Camera Follow Player",
                screenWidth,
                screenHeight
            );

            double playerX = 380;
            double playerY = 280;

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                if (
                    SplashKit.KeyDown(KeyCode.LeftKey) ||
                    SplashKit.KeyDown(KeyCode.AKey)
                )
                    playerX -= movementSpeed;

                if (
                    SplashKit.KeyDown(KeyCode.RightKey) ||
                    SplashKit.KeyDown(KeyCode.DKey)
                )
                    playerX += movementSpeed;

                if (
                    SplashKit.KeyDown(KeyCode.UpKey) ||
                    SplashKit.KeyDown(KeyCode.WKey)
                )
                    playerY -= movementSpeed;

                if (
                    SplashKit.KeyDown(KeyCode.DownKey) ||
                    SplashKit.KeyDown(KeyCode.SKey)
                )
                    playerY += movementSpeed;

                playerX = Math.Max(
                    0,
                    Math.Min(playerX, worldWidth - playerSize)
                );

                playerY = Math.Max(
                    0,
                    Math.Min(playerY, worldHeight - playerSize)
                );

                double cameraX =
                    playerX + playerSize / 2 - screenWidth / 2.0;

                double cameraY =
                    playerY + playerSize / 2 - screenHeight / 2.0;

                cameraX = Math.Max(
                    0,
                    Math.Min(cameraX, worldWidth - screenWidth)
                );

                cameraY = Math.Max(
                    0,
                    Math.Min(cameraY, worldHeight - screenHeight)
                );

                SplashKit.MoveCameraTo(cameraX, cameraY);

                SplashKit.ClearScreen(Color.White);

                for (int x = 0; x <= worldWidth; x += 200)
                {
                    SplashKit.DrawLine(
                        Color.LightGray,
                        x,
                        0,
                        x,
                        worldHeight
                    );
                }

                for (int y = 0; y <= worldHeight; y += 200)
                {
                    SplashKit.DrawLine(
                        Color.LightGray,
                        0,
                        y,
                        worldWidth,
                        y
                    );
                }

                SplashKit.DrawRectangle(
                    Color.Black,
                    0,
                    0,
                    worldWidth,
                    worldHeight
                );

                SplashKit.FillRectangle(
                    Color.SkyBlue,
                    700,
                    180,
                    430,
                    250
                );

                SplashKit.DrawText(
                    "Crystal Lake",
                    Color.DarkBlue,
                    835,
                    290
                );

                SplashKit.FillRectangle(
                    Color.Orange,
                    180,
                    160,
                    180,
                    130
                );

                SplashKit.FillTriangle(
                    Color.Red,
                    160,
                    160,
                    380,
                    160,
                    270,
                    80
                );

                SplashKit.FillRectangle(
                    Color.Brown,
                    245,
                    220,
                    50,
                    70
                );

                SplashKit.DrawText(
                    "Village House",
                    Color.Black,
                    210,
                    305
                );

                SplashKit.FillRectangle(
                    Color.Yellow,
                    1510,
                    900,
                    190,
                    140
                );

                SplashKit.FillTriangle(
                    Color.DarkRed,
                    1490,
                    900,
                    1720,
                    900,
                    1605,
                    810
                );

                SplashKit.FillRectangle(
                    Color.Brown,
                    1580,
                    970,
                    50,
                    70
                );

                SplashKit.DrawText(
                    "Forest Cabin",
                    Color.Black,
                    1545,
                    1055
                );

                for (int x = 450; x <= 1750; x += 260)
                {
                    SplashKit.FillRectangle(
                        Color.Brown,
                        x + 20,
                        650,
                        30,
                        80
                    );

                    SplashKit.FillCircle(
                        Color.Green,
                        x + 35,
                        630,
                        55
                    );
                }

                SplashKit.FillCircle(
                    Color.Gray,
                    1180,
                    250,
                    35
                );

                SplashKit.FillCircle(
                    Color.DarkGray,
                    1260,
                    310,
                    45
                );

                SplashKit.FillCircle(
                    Color.Gray,
                    1350,
                    235,
                    30
                );

                SplashKit.FillCircle(
                    Color.Gold,
                    1810,
                    1220,
                    45
                );

                SplashKit.DrawCircle(
                    Color.Black,
                    1810,
                    1220,
                    45
                );

                SplashKit.DrawText(
                    "GOAL",
                    Color.Black,
                    1788,
                    1212
                );

                SplashKit.FillRectangle(
                    Color.Blue,
                    playerX,
                    playerY,
                    playerSize,
                    playerSize
                );

                SplashKit.DrawRectangle(
                    Color.Black,
                    playerX,
                    playerY,
                    playerSize,
                    playerSize
                );

                SplashKit.DrawText(
                    "PLAYER",
                    Color.Black,
                    playerX - 7,
                    playerY - 22
                );

                SplashKit.FillRectangle(
                    Color.White,
                    cameraX + 15,
                    cameraY + 15,
                    350,
                    72
                );

                SplashKit.DrawRectangle(
                    Color.Black,
                    cameraX + 15,
                    cameraY + 15,
                    350,
                    72
                );

                SplashKit.DrawText(
                    "Use WASD or Arrow Keys to move",
                    Color.Black,
                    cameraX + 28,
                    cameraY + 29
                );

                SplashKit.DrawText(
                    "The camera follows the player",
                    Color.Black,
                    cameraX + 28,
                    cameraY + 55
                );

                SplashKit.RefreshScreen(60);
            }

            SplashKit.CloseAllWindows();
        }
    }
}