using SFML.Graphics;
using SFML.System;

namespace Core.UI.Primitives
{
    class Triangle : RenderableBase
    {
        private CircleShape shape;

        public Triangle(float size, float rotation, Color RGBA)
        {
            CircleShape construct_shape = new CircleShape(size, 3)
            {
                Rotation = rotation,
                FillColor = RGBA
            };
            shape = construct_shape;
            Core.App.RenderSys.AddToRenderList(this);
        }

        public override void SetOrigin(Origin_Horizontal_Alignment h_align, Origin_Vertical_Alignment v_align)
        {
            Origin_H_Align = h_align;
            Origin_V_Align = v_align;
            float origin_h = (h_align == Origin_Horizontal_Alignment.CENTER) ? shape.Radius : (h_align == Origin_Horizontal_Alignment.RIGHT) ? (shape.Radius * 2) : 0;
            float origin_v = (v_align == Origin_Vertical_Alignment.CENTER) ? shape.Radius : (v_align == Origin_Vertical_Alignment.BOTTOM) ? (shape.Radius * 2) : 0;
            shape.Origin = new Vector2f(origin_h, origin_v);
        }

        public override void SetPosition(float x, float y)
        {
            Position = new Vector2f(x, y);
            shape.Position = Position;
        }

        public override void SetRotation(float rotation)
        {
            shape.Rotation = rotation;
        }

        public void SetSize(float radius)
        {
            shape.Radius = radius;
            SetOrigin(Origin_H_Align, Origin_V_Align);
            SetPosition(Position.X, Position.Y);
        }

        public override void Render()
        {
            if (IsVisible)
            {
                Core.App.Window.Draw(shape);
            }
        }
    }
}
