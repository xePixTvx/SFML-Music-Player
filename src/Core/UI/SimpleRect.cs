using SFML.Graphics;
using SFML.System;
using Core.UI.Interfaces;

namespace Core.UI
{
    class SimpleRect : IDrawable<RectangleShape>, IDrawableUI<RectangleShape>
    {
        public RectangleShape Drawable_Rect { get; private set; }
        public bool isActive { get; set; }
        public bool isVisible { get; set; }

        public SimpleRect(float width, float height, Color RGBA)
        {
            RectangleShape shape = new RectangleShape
            {
                Size = new Vector2f(width, height),
                FillColor = RGBA,
            };
            Drawable_Rect = shape;
            isActive = true;
            isVisible = true;
            setPosition();
        }

        public void Render()
        {
            if (isActive)
            {
                if (isVisible)
                {
                    Core.App.window.Draw(Drawable_Rect);
                }
            }
        }

        public void setPosition(string origin_align = "left_top", string position_align = "left_top", float x_pos=0, float y_pos=0)
        {
            //Origin
            float origin_x = (origin_align.Split('_')[0] == "center") ? (Drawable_Rect.Size.X * (float)0.5) : (origin_align.Split('_')[0] == "right") ? Drawable_Rect.Size.X : 0;
            float origin_y = (origin_align.Split('_')[1] == "center") ? (Drawable_Rect.Size.Y * (float)0.5) : (origin_align.Split('_')[1] == "bottom") ? Drawable_Rect.Size.Y : 0;
            Drawable_Rect.Origin = new Vector2f(origin_x, origin_y);

            //Position
            uint screen_width = App.setting_window_width;
            uint screen_height = App.setting_window_height;
            float x = (position_align.Split('_')[0] == "center") ? ((screen_width / 2) + x_pos) : (position_align.Split('_')[0] == "right") ? (screen_width + x_pos) : x_pos;
            float y = (position_align.Split('_')[1] == "center") ? ((screen_height / 2) + y_pos) : (position_align.Split('_')[1] == "bottom") ? (screen_height + y_pos) : y_pos;
            Drawable_Rect.Position = new Vector2f(x, y);
        }


        //add setSize func here????
    }
}
