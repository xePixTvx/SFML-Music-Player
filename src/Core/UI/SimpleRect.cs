using SFML.Graphics;
using SFML.System;
using Core.UI.Interfaces;

namespace Core.UI
{
    class SimpleRect : IDrawableUI<RectangleShape>
    {
        private RectangleShape Drawable_Elem;

        public SimpleRect(float width, float height, Color RGBA)
        {
            RectangleShape shape = new RectangleShape
            {
                Size = new Vector2f(width, height),
                FillColor = RGBA,
            };
            Drawable_Elem = shape;
            setOrigin();
            setPosition();
        }

        public RectangleShape getDrawable()
        {
            return Drawable_Elem;
        }


        public void setOrigin(string align_x="left", string align_y="top")
        {
            float x = (align_x == "center") ? (Drawable_Elem.Size.X * (float)0.5) : (align_x == "right") ? Drawable_Elem.Size.X : 0;
            float y = (align_y == "center") ? (Drawable_Elem.Size.Y * (float)0.5) : (align_y == "bottom") ? Drawable_Elem.Size.Y : 0;
            Drawable_Elem.Origin = new Vector2f(x, y);
        }

        public void setPosition(string align_x="left", string align_y="top", float x_pos=0, float y_pos=0)
        {
            uint screen_width = App.setting_window_width;
            uint screen_height = App.setting_window_height;
            float x = (align_x == "center") ? ((screen_width / 2) + x_pos) : (align_x == "right") ? (screen_width + x_pos) : x_pos;
            float y = (align_y == "center") ? ((screen_height / 2) + y_pos) : (align_y == "bottom") ? (screen_height + y_pos) : y_pos;
            Drawable_Elem.Position = new Vector2f(x, y);
        }


        //add setSize func here????
    }
}
