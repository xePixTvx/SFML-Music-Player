using SFML.Graphics;
using SFML.System;

namespace Core.UI.Primitives
{
    class SimpleText : RenderableBase
    {
        private Text Shape;

        public SimpleText(string font_name, Text.Styles style, uint size, Color RGBA, string displayedText)
        {
            Shape = new Text
            {
                Font = Core.App.AsManager.GetFont(font_name),
                Style = style,
                CharacterSize = size,
                FillColor = RGBA,
            };
            SetText(displayedText);
            Core.App.RenderSys.AddToRenderList(this);
        }

        public void SetText(string text = "UNKNOWN STRING")
        {
            Shape.DisplayedString = text;
            SetOrigin(Origin_H_Align, Origin_V_Align);
            SetPosition(Position.X, Position.Y);
        }

        public override void SetOrigin(Origin_Horizontal_Alignment h_align, Origin_Vertical_Alignment v_align)
        {
            Origin_H_Align = h_align;
            Origin_V_Align = v_align;
            float origin_h = (h_align == Origin_Horizontal_Alignment.CENTER) ? (Shape.GetGlobalBounds().Width * (float)0.5) : (h_align == Origin_Horizontal_Alignment.RIGHT) ? Shape.GetGlobalBounds().Width : 0;
            float origin_v = (v_align == Origin_Vertical_Alignment.CENTER) ? (Shape.GetGlobalBounds().Height * (float)0.5) : (v_align == Origin_Vertical_Alignment.BOTTOM) ? Shape.GetGlobalBounds().Height : 0;
            Shape.Origin = new Vector2f(origin_h, origin_v);
        }

        public override void SetPosition(float x, float y)
        {
            Position = new Vector2f(x, y);
            Shape.Position = Position;
        }

        public override void SetRotation(float rotation)
        {
            Shape.Rotation = rotation;
        }

        public override void Render()
        {
            if (IsVisible)
            {
                Core.App.Window.Draw(Shape);
            }
        }
    }
}
