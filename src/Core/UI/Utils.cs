using Core.UI.Interfaces;
using SFML.System;

namespace Core.UI
{
    class Utils
    {
        public static Vector2f GetPosition(Position_Horizontal_Alignment h_align = Position_Horizontal_Alignment.CENTER, Position_Vertical_Alignment v_align = Position_Vertical_Alignment.CENTER)
        {
            uint screen_width = App.setting_window_width;
            uint screen_height = App.setting_window_height;
            float x = (h_align == Position_Horizontal_Alignment.CENTER) ? (screen_width / 2) : (h_align == Position_Horizontal_Alignment.RIGHT) ? screen_width : 0;
            float y = (v_align == Position_Vertical_Alignment.CENTER) ? (screen_height / 2) : (v_align == Position_Vertical_Alignment.BOTTOM) ? screen_height : 0;
            return new Vector2f(x, y);
        }
    }
}
