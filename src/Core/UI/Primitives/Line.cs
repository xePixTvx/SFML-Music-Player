using SFML.Graphics;
using SFML.System;

namespace Core.UI.Primitives
{
    class Line : RenderableBase
    {
        private VertexArray shape;

        public Line(Vector2f start, Vector2f end, Color start_RGBA, Color end_RGBA)
        {
            VertexArray construct_shape = new VertexArray(PrimitiveType.Lines, 2);
            construct_shape[0] = new Vertex(start, start_RGBA);
            construct_shape[1] = new Vertex(end, end_RGBA);
            shape = construct_shape;
            Core.App.RenderSys.AddToRenderList(this);
        }

        public override bool IsActive { get => base.IsActive; set => base.IsActive = value; }
        public override bool IsVisible { get => base.IsVisible; set => base.IsVisible = value; }
        public override int RenderLayer { get => base.RenderLayer; set => base.RenderLayer = value; }

        public override void Render()
        {
            if (IsVisible)
            {
                Core.App.window.Draw(shape);
            }
        }
    }
}
