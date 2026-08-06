#include "splashkit.h"

int main()
{
    open_window("Timer Ticks Example", 600, 300);

    timer my_timer = create_timer("example timer");
    start_timer(my_timer);

    while (!quit_requested())
    {
        process_events();

        clear_screen(COLOR_WHITE);

        draw_text(
            "Elapsed milliseconds:",
            COLOR_BLACK,
            170,
            100
        );

        draw_text(
            std::to_string(timer_ticks(my_timer)),
            COLOR_BLUE,
            250,
            150
        );

        refresh_screen(60);
    }

    free_timer(my_timer);
    close_all_windows();

    return 0;
}