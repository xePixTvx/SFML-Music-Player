using SFML.Graphics;
using SFML.System;
using Core.UI.Interfaces;

namespace Core.UI
{
    class SimpleLine : IDrawable<VertexArray>
    {
        private VertexArray Drawable_Elem;

        //UNFINISHED!!!!!!!!!!!!!!!!!!
        public SimpleLine(Vector2f start, Vector2f end, Color start_RGBA, Color end_RGBA)
        {
            VertexArray line = new VertexArray(PrimitiveType.Lines,2);
            line[0] = new Vertex(start, start_RGBA);
            line[1] = new Vertex(end, end_RGBA);

            Drawable_Elem = line;
        }

        public VertexArray getDrawable()
        {
            return Drawable_Elem;
        }
    }
}
