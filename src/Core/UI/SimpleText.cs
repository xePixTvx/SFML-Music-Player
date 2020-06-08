using SFML.Graphics;
using SFML.System;
using Core.UI.Interfaces;

namespace Core.UI
{
    class SimpleText : IDrawable<Text>, IDrawableUI<Text>, IDrawableText<Text>
    {
        public Text Drawable_Text { get; private set; }
        public bool isActive { get; set; }
        public bool isVisible { get; set; }

        public SimpleText(string font_name, Text.Styles style, uint size, Color color, string displayedText)
        {
            Text text = new Text
            {
                Font = Core.App.AsManager.getFont(font_name),
                Style = style,
                CharacterSize = size,
                FillColor = color,
            };
            Drawable_Text = text;
            isActive = true;
            isVisible = true;
            setText(displayedText);
            setPosition();
        }

        public void Render()
        {
            if (isActive)
            {
                if (isVisible)
                {
                    Core.App.window.Draw(Drawable_Text);
                }
            }
        }

        public void setPosition(string origin_align = "left_top", string position_align = "left_top", float x_pos = 0, float y_pos = 0)
        {
            //Origin
            float origin_x = (origin_align.Split('_')[0] == "center") ? (Drawable_Text.GetGlobalBounds().Width * (float)0.5) : (origin_align.Split('_')[0] == "right") ? Drawable_Text.GetGlobalBounds().Width : 0;
            float origin_y = (origin_align.Split('_')[1] == "center") ? (Drawable_Text.GetGlobalBounds().Height * (float)0.5) : (origin_align.Split('_')[1] == "bottom") ? Drawable_Text.GetGlobalBounds().Height : 0;
            Drawable_Text.Origin = new Vector2f(origin_x, origin_y);

            //Position
            uint screen_width = App.setting_window_width;
            uint screen_height = App.setting_window_height;
            float x = (position_align.Split('_')[0] == "center") ? ((screen_width / 2) + x_pos) : (position_align.Split('_')[0] == "right") ? (screen_width + x_pos) : x_pos;
            float y = (position_align.Split('_')[1] == "center") ? ((screen_height / 2) + y_pos) : (position_align.Split('_')[1] == "bottom") ? (screen_height + y_pos) : y_pos;
            Drawable_Text.Position = new Vector2f(x, y);
        }

        public void setText(string text="UNKNOWN STRING")
        {
            Drawable_Text.DisplayedString = text;
            //Update origin & pos here???
        }
    }
}
