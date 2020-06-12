namespace Core.UI.Interfaces
{
    interface IRenderable
    {
        bool IsActive { get; set; }
        bool IsVisible { get; set; }
        int RenderLayer { get; set; }
        void SetOrigin();
        void SetPosition();
        void Render();
    }
}
