using SFML.Graphics;
using SFML.System;

namespace Core.UI.Primitives
{
    class Circle : RenderableBase
    {
        private CircleShape Shape;

        public Circle(float radius, Color RGBA)
        {
            Shape = new CircleShape
            {
                Radius = radius,
                FillColor = RGBA
            };
            Core.App.RenderSys.AddToRenderList(this);
        }

        public override void SetOrigin(Origin_Horizontal_Alignment h_align, Origin_Vertical_Alignment v_align)
        {
            Origin_H_Align = h_align;
            Origin_V_Align = v_align;
            float origin_h = (h_align == Origin_Horizontal_Alignment.CENTER) ? Shape.Radius : (h_align == Origin_Horizontal_Alignment.RIGHT) ? (Shape.Radius * 2) : 0;
            float origin_v = (v_align == Origin_Vertical_Alignment.CENTER) ? Shape.Radius : (v_align == Origin_Vertical_Alignment.BOTTOM) ? (Shape.Radius * 2) : 0;
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

        public void SetSize(float radius)
        {
            Shape.Radius = radius;
            SetOrigin(Origin_H_Align, Origin_V_Align);
            SetPosition(Position.X, Position.Y);
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
