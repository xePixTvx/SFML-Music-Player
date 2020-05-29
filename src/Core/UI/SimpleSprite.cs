using SFML.Graphics;
using SFML.System;
using Core.UI.Interfaces;

namespace Core.UI
{
    class SimpleSprite : IDrawableUI<Sprite>
    {
        private Sprite Drawable_Elem;

        public SimpleSprite(Texture texture)
        {
            Sprite sprite = new Sprite
            {
                Texture = texture
            };
            Drawable_Elem = sprite;
            setOrigin();
            setPosition();
        }

        public Sprite getDrawable()
        {
            return Drawable_Elem;
        }

        public void setOrigin(string align_x = "left", string align_y = "top")
        {
            float x = (align_x == "center") ? (Drawable_Elem.Texture.Size.X * (float)0.5) : (align_x == "right") ? Drawable_Elem.Texture.Size.X : 0;
            float y = (align_y == "center") ? (Drawable_Elem.Texture.Size.Y * (float)0.5) : (align_y == "bottom") ? Drawable_Elem.Texture.Size.Y : 0;
            Drawable_Elem.Origin = new Vector2f(x, y);
        }

        public void setPosition(string align_x = "left", string align_y = "top", float x_pos = 0, float y_pos = 0)
        {
            uint screen_width = App.setting_window_width;
            uint screen_height = App.setting_window_height;
            float x = (align_x == "center") ? ((screen_width / 2) + x_pos) : (align_x == "right") ? (screen_width + x_pos) : x_pos;
            float y = (align_y == "center") ? ((screen_height / 2) + y_pos) : (align_y == "bottom") ? (screen_height + y_pos) : y_pos;
            Drawable_Elem.Position = new Vector2f(x, y);
        }
    }
}
