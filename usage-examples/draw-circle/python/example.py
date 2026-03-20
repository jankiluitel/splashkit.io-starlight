# Draw a circle in the center of the screen
from splashkit import *

open_window("Circle Example", 800, 600)

while not quit_requested():
    process_events()
    clear_screen(COLOR_WHITE)

    # Draw a circle at (400, 300) with radius 50
    draw_circle(COLOR_BLUE, 400, 300, 50)

    refresh_screen()
    