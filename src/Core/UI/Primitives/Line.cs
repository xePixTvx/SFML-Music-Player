using SFML.Graphics;
using SFML.System;

namespace Core.UI.Primitives
{
    class Line : RenderableBase
    {
        private VertexArray Shape;

        public Line(Vector2f start, Vector2f end, Color start_RGBA, Color end_RGBA)
        {
            Shape = new VertexArray(PrimitiveType.Lines, 2);
            Shape[0] = new Vertex(start, start_RGBA);
            Shape[1] = new Vertex(end, end_RGBA);
            Core.App.RenderSys.AddToRenderList(this);
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
