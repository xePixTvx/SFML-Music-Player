using SFML.Graphics;
using SFML.System;
using Core.UI.Interfaces;

namespace Core.UI
{
    class SimpleLine : IDrawable<VertexArray>
    {
        public VertexArray Drawable_Line { get; private set; }
        public bool isActive { get; set; }
        public bool isVisible { get; set; }

        //UNFINISHED!!!!!!!!!!!!!!!!!!
        public SimpleLine(Vector2f start, Vector2f end, Color start_RGBA, Color end_RGBA)
        {
            VertexArray line = new VertexArray(PrimitiveType.Lines,2);
            line[0] = new Vertex(start, start_RGBA);
            line[1] = new Vertex(end, end_RGBA);

            Drawable_Line = line;
            isActive = true;
            isVisible = true;
        }

        public void Render()
        {
            if (isActive)
            {
                if (isVisible)
                {
                    Core.App.window.Draw(Drawable_Line);
                }
            }
        }
    }
}
