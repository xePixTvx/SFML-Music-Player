using SFML.Graphics;
using SFML.System;
using Core.UI.Interfaces;

namespace Core.UI
{
    class SimpleText : IDrawableText<Text>
    {
        private Text Drawable_Elem;

        public SimpleText(Font font, Text.Styles style, uint size, Color color, string displayedText)
        {
            Text text = new Text
            {
                Font = font,
                Style = style,
                CharacterSize = size,
                FillColor = color,
            };
            Drawable_Elem = text;
            setText(displayedText);
            setOrigin();
            setPosition();
        }

        public Text getDrawable()
        {
            return Drawable_Elem;
        }

        public void DrawTo(RenderWindow window)
        {
            window.Draw(getDrawable());
        }

        public void setOrigin(string align_x = "left", string align_y = "top")
        {
            float x = (align_x == "center") ? (Drawable_Elem.GetGlobalBounds().Width * (float)0.5) : (align_x == "right") ? Drawable_Elem.GetGlobalBounds().Width : 0;
            float y = (align_y == "center") ? (Drawable_Elem.GetGlobalBounds().Height * (float)0.5) : (align_y == "bottom") ? Drawable_Elem.GetGlobalBounds().Height : 0;
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

        public void setText(string text="UNKNOWN STRING")
        {
            Drawable_Elem.DisplayedString = text;
            //Update origin & pos here???
        }
    }
}
