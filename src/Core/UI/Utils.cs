using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Core.UI
{
    class Utils
    {
        public static Vector2f GetPosition(Horizontal_Alignment h_align = Horizontal_Alignment.CENTER, Vertical_Alignment v_align = Vertical_Alignment.CENTER)
        {
            uint screen_width = App.Setting_window_width;
            uint screen_height = App.Setting_window_height;
            float x = (h_align == Horizontal_Alignment.CENTER) ? (screen_width / 2) : (h_align == Horizontal_Alignment.RIGHT) ? screen_width : 0;
            float y = (v_align == Vertical_Alignment.CENTER) ? (screen_height / 2) : (v_align == Vertical_Alignment.BOTTOM) ? screen_height : 0;
            return new Vector2f(x, y);
        }

        public static bool IsHovered(Sprite sprite)
        {
            RenderWindow window = Core.App.Window;
            if (sprite.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y) && window.HasFocus())
            {
                return true;
            }
            return false;
        }
        public static bool IsHovered(RectangleShape rect)
        {
            RenderWindow window = Core.App.Window;
            if (rect.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y) && window.HasFocus())
            {
                return true;
            }
            return false;
        }

        public static Vector2f GetOriginPosition(RectangleShape Shape, Horizontal_Alignment h_align, Vertical_Alignment v_align)
        {
            Vector2f origin;
            origin.X = (h_align == Horizontal_Alignment.CENTER) ? (Shape.Size.X * (float)0.5) : (h_align == Horizontal_Alignment.RIGHT) ? Shape.Size.X : 0;
            origin.Y = (v_align == Vertical_Alignment.CENTER) ? (Shape.Size.Y * (float)0.5) : (v_align == Vertical_Alignment.BOTTOM) ? Shape.Size.Y : 0;
            return origin;
        }
        public static Vector2f GetOriginPosition(CircleShape Shape, Horizontal_Alignment h_align, Vertical_Alignment v_align)
        {
            Vector2f origin;
            origin.X = (h_align == Horizontal_Alignment.CENTER) ? Shape.Radius : (h_align == Horizontal_Alignment.RIGHT) ? (Shape.Radius * 2) : 0;
            origin.Y = (v_align == Vertical_Alignment.CENTER) ? Shape.Radius : (v_align == Vertical_Alignment.BOTTOM) ? (Shape.Radius * 2) : 0;
            return origin;
        }
        public static Vector2f GetOriginPosition(Sprite Shape, Horizontal_Alignment h_align, Vertical_Alignment v_align)
        {
            Vector2f origin;
            origin.X = (h_align == Horizontal_Alignment.CENTER) ? (Shape.Texture.Size.X * (float)0.5) : (h_align == Horizontal_Alignment.RIGHT) ? Shape.Texture.Size.X : 0;
            origin.Y = (v_align == Vertical_Alignment.CENTER) ? (Shape.Texture.Size.Y * (float)0.5) : (v_align == Vertical_Alignment.BOTTOM) ? Shape.Texture.Size.Y : 0;
            return origin;
        }
        public static Vector2f GetOriginPosition(Text Shape, Horizontal_Alignment h_align, Vertical_Alignment v_align)
        {
            Vector2f origin;
            origin.X = (h_align == Horizontal_Alignment.CENTER) ? (Shape.GetGlobalBounds().Width * (float)0.5) : (h_align == Horizontal_Alignment.RIGHT) ? Shape.GetGlobalBounds().Width : 0;
            origin.Y = (v_align == Vertical_Alignment.CENTER) ? (Shape.GetGlobalBounds().Height * (float)0.5) : (v_align == Vertical_Alignment.BOTTOM) ? Shape.GetGlobalBounds().Height : 0;
            return origin;
        }
    }
}
