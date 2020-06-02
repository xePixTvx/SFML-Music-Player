using SFML.Graphics;

namespace Core.UI.Interfaces
{
    interface IDrawable<Type>
    {
        Type getDrawable();
        void DrawTo(RenderWindow window);
    }
}
