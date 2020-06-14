using SFML.Graphics;
using SFML.System;

namespace Core.UI.Primitives
{
    class Circle : RenderableBase
    {
        private CircleShape shape;

        public Circle(float radius, Color RGBA)
        {
            CircleShape construct_shape = new CircleShape
            {
                Radius = radius,
                FillColor = RGBA
            };
            shape = construct_shape;
            Core.App.RenderSys.AddToRenderList(this);
        }

        public override bool IsActive { get => base.IsActive; set => base.IsActive = value; }
        public override bool IsVisible { get => base.IsVisible; set => base.IsVisible = value; }
        public override int RenderLayer { get => base.RenderLayer; set => base.RenderLayer = value; }

        public override Origin_Horizontal_Alignment Origin_H_Align { get => base.Origin_H_Align; set => base.Origin_H_Align = value; }
        public override Origin_Vertical_Alignment Origin_V_Align { get => base.Origin_V_Align; set => base.Origin_V_Align = value; }
        public override Vector2f Position { get => base.Position; set => base.Position = value; }
        public override float Rotation { get => base.Rotation; set => base.Rotation = value; }

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

        public override void Render()
        {
            if (IsVisible)
            {
                Core.App.window.Draw(shape);
            }
        }
    }
}
