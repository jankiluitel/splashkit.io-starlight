from splashkit import *

SCREEN_WIDTH = 800
SCREEN_HEIGHT = 600
WORLD_WIDTH = 2000
WORLD_HEIGHT = 1400

PLAYER_SIZE = 40
MOVEMENT_SPEED = 5

SYSTEM_FONT = get_system_font()
NORMAL_FONT_SIZE = 18
SMALL_FONT_SIZE = 15

open_window("Camera Follow Player", SCREEN_WIDTH, SCREEN_HEIGHT)

player_x = 380.0
player_y = 280.0

while not quit_requested():
    process_events()

    # Move the player using WASD or the arrow keys.
    if key_down(KeyCode.left_key) or key_down(KeyCode.a_key):
        player_x -= MOVEMENT_SPEED

    if key_down(KeyCode.right_key) or key_down(KeyCode.d_key):
        player_x += MOVEMENT_SPEED

    if key_down(KeyCode.up_key) or key_down(KeyCode.w_key):
        player_y -= MOVEMENT_SPEED

    if key_down(KeyCode.down_key) or key_down(KeyCode.s_key):
        player_y += MOVEMENT_SPEED

    # Keep the player inside the world.
    player_x = max(
        0.0,
        min(player_x, WORLD_WIDTH - PLAYER_SIZE)
    )

    player_y = max(
        0.0,
        min(player_y, WORLD_HEIGHT - PLAYER_SIZE)
    )

    # Calculate a camera position centred on the player.
    camera_x = (
        player_x
        + PLAYER_SIZE / 2
        - SCREEN_WIDTH / 2
    )

    camera_y = (
        player_y
        + PLAYER_SIZE / 2
        - SCREEN_HEIGHT / 2
    )

    # Keep the camera within the world boundaries.
    camera_x = max(
        0.0,
        min(camera_x, WORLD_WIDTH - SCREEN_WIDTH)
    )

    camera_y = max(
        0.0,
        min(camera_y, WORLD_HEIGHT - SCREEN_HEIGHT)
    )

    # Move the camera so that it follows the player.
    move_camera_to(camera_x, camera_y)

    clear_screen(color_white())

    # Draw a grid to make camera movement easy to see.
    for x in range(0, WORLD_WIDTH + 1, 200):
        draw_line(
            color_light_gray(),
            x,
            0,
            x,
            WORLD_HEIGHT
        )

    for y in range(0, WORLD_HEIGHT + 1, 200):
        draw_line(
            color_light_gray(),
            0,
            y,
            WORLD_WIDTH,
            y
        )

    # Draw the world boundary.
    draw_rectangle(
        color_black(),
        0,
        0,
        WORLD_WIDTH,
        WORLD_HEIGHT
    )

    # Draw a lake.
    fill_rectangle(
        color_sky_blue(),
        700,
        180,
        430,
        250
    )

    draw_text(
        "Crystal Lake",
        color_dark_blue(),
        SYSTEM_FONT,
        NORMAL_FONT_SIZE,
        835,
        290
    )

    # Draw the village house.
    fill_rectangle(
        color_orange(),
        180,
        160,
        180,
        130
    )

    fill_triangle(
        color_red(),
        160,
        160,
        380,
        160,
        270,
        80
    )

    fill_rectangle(
        color_brown(),
        245,
        220,
        50,
        70
    )

    draw_text(
        "Village House",
        color_black(),
        SYSTEM_FONT,
        NORMAL_FONT_SIZE,
        210,
        305
    )

    # Draw the forest cabin.
    fill_rectangle(
        color_yellow(),
        1510,
        900,
        190,
        140
    )

    fill_triangle(
        color_dark_red(),
        1490,
        900,
        1720,
        900,
        1605,
        810
    )

    fill_rectangle(
        color_brown(),
        1580,
        970,
        50,
        70
    )

    draw_text(
        "Forest Cabin",
        color_black(),
        SYSTEM_FONT,
        NORMAL_FONT_SIZE,
        1545,
        1055
    )

    # Draw trees.
    for x in range(450, 1751, 260):
        fill_rectangle(
            color_brown(),
            x + 20,
            650,
            30,
            80
        )

        fill_circle(
            color_green(),
            x + 35,
            630,
            55
        )

    # Draw rocks.
    fill_circle(
        color_gray(),
        1180,
        250,
        35
    )

    fill_circle(
        color_dark_gray(),
        1260,
        310,
        45
    )

    fill_circle(
        color_gray(),
        1350,
        235,
        30
    )

    # Draw the destination marker.
    fill_circle(
        color_gold(),
        1810,
        1220,
        45
    )

    draw_circle(
        color_black(),
        1810,
        1220,
        45
    )

    draw_text(
        "GOAL",
        color_black(),
        SYSTEM_FONT,
        SMALL_FONT_SIZE,
        1788,
        1212
    )

    # Draw the player.
    fill_rectangle(
        color_blue(),
        player_x,
        player_y,
        PLAYER_SIZE,
        PLAYER_SIZE
    )

    draw_rectangle(
        color_black(),
        player_x,
        player_y,
        PLAYER_SIZE,
        PLAYER_SIZE
    )

    draw_text(
        "PLAYER",
        color_black(),
        SYSTEM_FONT,
        SMALL_FONT_SIZE,
        player_x - 7,
        player_y - 22
    )

    # Draw instructions relative to the camera so they remain visible.
    fill_rectangle(
        color_white(),
        camera_x + 15,
        camera_y + 15,
        350,
        72
    )

    draw_rectangle(
        color_black(),
        camera_x + 15,
        camera_y + 15,
        350,
        72
    )

    draw_text(
        "Use WASD or Arrow Keys to move",
        color_black(),
        SYSTEM_FONT,
        SMALL_FONT_SIZE,
        camera_x + 28,
        camera_y + 29
    )

    draw_text(
        "The camera follows the player",
        color_black(),
        SYSTEM_FONT,
        SMALL_FONT_SIZE,
        camera_x + 28,
        camera_y + 55
    )

    refresh_screen()

close_all_windows()