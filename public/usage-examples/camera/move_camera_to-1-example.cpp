#include "splashkit.h"
#include <algorithm>
#include <string>

using namespace std;

int main()
{
    const int screen_width = 800;
    const int screen_height = 600;
    const int world_width = 2000;
    const int world_height = 1400;

    const double player_size = 40;
    const double movement_speed = 5;

    open_window("Camera Follow Player", screen_width, screen_height);

    double player_x = 380;
    double player_y = 280;

    while (!quit_requested())
    {
        process_events();

        // Move the player using the arrow keys or WASD.
        if (key_down(LEFT_KEY) || key_down(A_KEY))
        {
            player_x -= movement_speed;
        }

        if (key_down(RIGHT_KEY) || key_down(D_KEY))
        {
            player_x += movement_speed;
        }

        if (key_down(UP_KEY) || key_down(W_KEY))
        {
            player_y -= movement_speed;
        }

        if (key_down(DOWN_KEY) || key_down(S_KEY))
        {
            player_y += movement_speed;
        }

        // Keep the player inside the game world.
        player_x = max(
            0.0,
            min(player_x, static_cast<double>(world_width) - player_size)
        );

        player_y = max(
            0.0,
            min(player_y, static_cast<double>(world_height) - player_size)
        );

        // Calculate a camera position centred on the player.
        double camera_x =
            player_x + player_size / 2.0 - screen_width / 2.0;

        double camera_y =
            player_y + player_size / 2.0 - screen_height / 2.0;

        // Keep the camera inside the game world.
        camera_x = max(
            0.0,
            min(camera_x, static_cast<double>(world_width - screen_width))
        );

        camera_y = max(
            0.0,
            min(camera_y, static_cast<double>(world_height - screen_height))
        );

        // Move the camera to follow the player.
        move_camera_to(camera_x, camera_y);

        clear_screen(COLOR_WHITE);

        // Draw a grid to make camera movement easy to see.
        for (int x = 0; x <= world_width; x += 200)
        {
            draw_line(COLOR_LIGHT_GRAY, x, 0, x, world_height);
        }

        for (int y = 0; y <= world_height; y += 200)
        {
            draw_line(COLOR_LIGHT_GRAY, 0, y, world_width, y);
        }

        // Draw the game-world boundary.
        draw_rectangle(
            COLOR_BLACK,
            0,
            0,
            world_width,
            world_height
        );

        // Draw a lake.
        fill_rectangle(COLOR_SKY_BLUE, 700, 180, 430, 250);
        draw_text("Crystal Lake", COLOR_DARK_BLUE, 835, 290);

        // Draw two houses.
        fill_rectangle(COLOR_ORANGE, 180, 160, 180, 130);
        fill_triangle(
            COLOR_RED,
            160,
            160,
            380,
            160,
            270,
            80
        );
        fill_rectangle(COLOR_BROWN, 245, 220, 50, 70);
        draw_text("Village House", COLOR_BLACK, 210, 305);

        fill_rectangle(COLOR_YELLOW, 1510, 900, 190, 140);
        fill_triangle(
            COLOR_DARK_RED,
            1490,
            900,
            1720,
            900,
            1605,
            810
        );
        fill_rectangle(COLOR_BROWN, 1580, 970, 50, 70);
        draw_text("Forest Cabin", COLOR_BLACK, 1545, 1055);

        // Draw trees.
        for (int x = 450; x <= 1750; x += 260)
        {
            fill_rectangle(COLOR_BROWN, x + 20, 650, 30, 80);
            fill_circle(COLOR_GREEN, x + 35, 630, 55);
        }

        // Draw rocks.
        fill_circle(COLOR_GRAY, 1180, 250, 35);
        fill_circle(COLOR_DARK_GRAY, 1260, 310, 45);
        fill_circle(COLOR_GRAY, 1350, 235, 30);

        // Draw a destination marker.
        fill_circle(COLOR_GOLD, 1810, 1220, 45);
        draw_circle(COLOR_BLACK, 1810, 1220, 45);
        draw_text("GOAL", COLOR_BLACK, 1788, 1212);

        // Draw the player.
        fill_rectangle(
            COLOR_BLUE,
            player_x,
            player_y,
            player_size,
            player_size
        );

        draw_rectangle(
            COLOR_BLACK,
            player_x,
            player_y,
            player_size,
            player_size
        );

        draw_text(
            "PLAYER",
            COLOR_BLACK,
            player_x - 7,
            player_y - 22
        );

        // Add instructions relative to the current camera position so they
        // remain visible while the camera moves.
        fill_rectangle(
            COLOR_WHITE,
            camera_x + 15,
            camera_y + 15,
            330,
            62
        );

        draw_rectangle(
            COLOR_BLACK,
            camera_x + 15,
            camera_y + 15,
            330,
            62
        );

        draw_text(
            "Use WASD or Arrow Keys to move",
            COLOR_BLACK,
            camera_x + 28,
            camera_y + 29
        );

        draw_text(
            "The camera follows the player",
            COLOR_BLACK,
            camera_x + 28,
            camera_y + 52
        );

        refresh_screen(60);
    }

    close_all_windows();
    return 0;
}