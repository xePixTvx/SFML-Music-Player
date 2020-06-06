using SFML.Graphics;
using SFML.System;
using Core.UI.Interfaces;

namespace Core.UI
{
    class SimpleCircle : IDrawableUI<CircleShape>
    {
        private CircleShape Drawable_Elem;

        public SimpleCircle(float radius, Color color)
        {
            CircleShape circle = new CircleShape
            {
                Radius = radius,
                FillColor = color
            };
            Drawable_Elem = circle;
            setPosition();
        }

        public CircleShape getDrawable()
        {
            return Drawable_Elem;
        }

        public void DrawTo(RenderWindow window)
        {
            window.Draw(getDrawable());
        }

        public void setPosition(string origin_align = "left_top", string position_align = "left_top", float x_pos = 0, float y_pos = 0)
        {
            //Origin
            float origin_x = (origin_align.Split('_')[0] == "center") ? Drawable_Elem.Radius : (origin_align.Split('_')[0] == "right") ? (Drawable_Elem.Radius * 2) : 0;
            float origin_y = (origin_align.Split('_')[1] == "center") ? Drawable_Elem.Radius : (origin_align.Split('_')[1] == "bottom") ? (Drawable_Elem.Radius * 2) : 0;
            Drawable_Elem.Origin = new Vector2f(origin_x, origin_y);

            //Position
            uint screen_width = App.setting_window_width;
            uint screen_height = App.setting_window_height;
            float x = (position_align.Split('_')[0] == "center") ? ((screen_width / 2) + x_pos) : (position_align.Split('_')[0] == "right") ? (screen_width + x_pos) : x_pos;
            float y = (position_align.Split('_')[1] == "center") ? ((screen_height / 2) + y_pos) : (position_align.Split('_')[1] == "bottom") ? (screen_height + y_pos) : y_pos;
            Drawable_Elem.Position = new Vector2f(x, y);
        }
    }
}
