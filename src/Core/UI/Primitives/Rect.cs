using SFML.Graphics;
using SFML.System;

namespace Core.UI.Primitives
{
    class Rect : RenderableBase
    {
        private RectangleShape shape;

        public Rect(float width, float height, Color RGBA)
        {
            RectangleShape construct_shape = new RectangleShape
            {
                Size = new Vector2f(width, height),
                FillColor = RGBA,
            };
            shape = construct_shape;
        }


        public override bool IsActive { get => base.IsActive; set => base.IsActive = value; }
        public override bool IsVisible { get => base.IsVisible; set => base.IsVisible = value; }
        public override int RenderLayer { get => base.RenderLayer; set => base.RenderLayer = value; }

        public override void SetOrigin()
        {
            //base.SetOrigin();
        }

        public override void SetPosition()
        {
            //base.SetPosition();
        }

        public override void Render()
        {
            Core.App.window.Draw(shape);
        }

    }
}
