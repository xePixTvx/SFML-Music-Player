namespace Core.UI.Interfaces
{
    interface IRenderable
    {
        bool IsActive { get; set; }
        bool IsVisible { get; set; }
        void Render();
    }
}
