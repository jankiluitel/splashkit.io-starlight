using System;
using SplashKitSDK;
using static SplashKitSDK.SplashKit;

const int ScreenWidth = 800;
const int ScreenHeight = 600;
const int WorldWidth = 2000;
const int WorldHeight = 1400;

const double PlayerSize = 40;
const double MovementSpeed = 5;

OpenWindow("Camera Follow Player", ScreenWidth, ScreenHeight);

double playerX = 380;
double playerY = 280;

while (!QuitRequested())
{
    ProcessEvents();

    if (KeyDown(KeyCode.LeftKey) || KeyDown(KeyCode.AKey))
        playerX -= MovementSpeed;

    if (KeyDown(KeyCode.RightKey) || KeyDown(KeyCode.DKey))
        playerX += MovementSpeed;

    if (KeyDown(KeyCode.UpKey) || KeyDown(KeyCode.WKey))
        playerY -= MovementSpeed;

    if (KeyDown(KeyCode.DownKey) || KeyDown(KeyCode.SKey))
        playerY += MovementSpeed;

    playerX = Math.Max(0, Math.Min(playerX, WorldWidth - PlayerSize));
    playerY = Math.Max(0, Math.Min(playerY, WorldHeight - PlayerSize));

    double cameraX =
        playerX + PlayerSize / 2 - ScreenWidth / 2.0;

    double cameraY =
        playerY + PlayerSize / 2 - ScreenHeight / 2.0;

    cameraX = Math.Max(0, Math.Min(cameraX, WorldWidth - ScreenWidth));
    cameraY = Math.Max(0, Math.Min(cameraY, WorldHeight - ScreenHeight));

    MoveCameraTo(cameraX, cameraY);

    ClearScreen(Color.White);

    for (int x = 0; x <= WorldWidth; x += 200)
        DrawLine(Color.LightGray, x, 0, x, WorldHeight);

    for (int y = 0; y <= WorldHeight; y += 200)
        DrawLine(Color.LightGray, 0, y, WorldWidth, y);

    DrawRectangle(Color.Black, 0, 0, WorldWidth, WorldHeight);

    FillRectangle(Color.SkyBlue, 700, 180, 430, 250);
    DrawText("Crystal Lake", Color.DarkBlue, 835, 290);

    FillRectangle(Color.Orange, 180, 160, 180, 130);
    FillTriangle(Color.Red, 160, 160, 380, 160, 270, 80);
    FillRectangle(Color.Brown, 245, 220, 50, 70);
    DrawText("Village House", Color.Black, 210, 305);

    FillRectangle(Color.Yellow, 1510, 900, 190, 140);
    FillTriangle(Color.DarkRed, 1490, 900, 1720, 900, 1605, 810);
    FillRectangle(Color.Brown, 1580, 970, 50, 70);
    DrawText("Forest Cabin", Color.Black, 1545, 1055);

    for (int x = 450; x <= 1750; x += 260)
    {
        FillRectangle(Color.Brown, x + 20, 650, 30, 80);
        FillCircle(Color.Green, x + 35, 630, 55);
    }

    FillCircle(Color.Gray, 1180, 250, 35);
    FillCircle(Color.DarkGray, 1260, 310, 45);
    FillCircle(Color.Gray, 1350, 235, 30);

    FillCircle(Color.Gold, 1810, 1220, 45);
    DrawCircle(Color.Black, 1810, 1220, 45);
    DrawText("GOAL", Color.Black, 1788, 1212);

    FillRectangle(
        Color.Blue,
        playerX,
        playerY,
        PlayerSize,
        PlayerSize
    );

    DrawRectangle(
        Color.Black,
        playerX,
        playerY,
        PlayerSize,
        PlayerSize
    );

    DrawText(
        "PLAYER",
        Color.Black,
        playerX - 7,
        playerY - 22
    );

    FillRectangle(
        Color.White,
        cameraX + 15,
        cameraY + 15,
        350,
        72
    );

    DrawRectangle(
        Color.Black,
        cameraX + 15,
        cameraY + 15,
        350,
        72
    );

    DrawText(
        "Use WASD or Arrow Keys to move",
        Color.Black,
        cameraX + 28,
        cameraY + 29
    );

    DrawText(
        "The camera follows the player",
        Color.Black,
        cameraX + 28,
        cameraY + 55
    );

    RefreshScreen(60);
}

CloseAllWindows();