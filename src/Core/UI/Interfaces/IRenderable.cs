using SFML.System;

namespace Core.UI.Interfaces
{
    public interface IRenderable
    {
        bool IsActive { get; set; }
        bool IsVisible { get; set; }
        int RenderLayer { get; set; }
        bool NeedsUpdate { get; set; }
        Horizontal_Alignment Origin_H_Align { get; set; }
        Vertical_Alignment Origin_V_Align { get; set; }
        Vector2f Position { get; set; }
        float Rotation { get; set; }
        void Update();
        void Render();
    }
}
