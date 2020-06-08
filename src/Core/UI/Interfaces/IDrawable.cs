using SFML.Graphics;

namespace Core.UI.Interfaces
{
    interface IDrawable<Type>
    {
        bool isActive { get; set; }
        bool isVisible { get; set; }
        void Render();
    }
}
