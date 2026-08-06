from splashkit import *

open_window("Timer Ticks Example", 600, 300)

my_timer = create_timer("example timer")
start_timer(my_timer)

while not quit_requested():
    process_events()

    clear_screen(color_white())

    draw_text_no_font_no_size(
        "Elapsed milliseconds:",
        color_black(),
        170,
        100
    )

    draw_text_no_font_no_size(
        str(timer_ticks(my_timer)),
        color_blue(),
        250,
        150
    )

    refresh_screen_with_target_fps(60)

free_timer(my_timer)
close_all_windows()