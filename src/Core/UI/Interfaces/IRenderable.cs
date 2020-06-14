using SFML.System;

namespace Core.UI.Interfaces
{
    public interface IRenderable
    {
        bool IsActive { get; set; }
        bool IsVisible { get; set; }
        int RenderLayer { get; set; }
        Origin_Horizontal_Alignment Origin_H_Align { get; set; }
        Origin_Vertical_Alignment Origin_V_Align { get; set; }
        void SetOrigin(Origin_Horizontal_Alignment h_align, Origin_Vertical_Alignment v_align);
        Vector2f Position { get; set; }
        void SetPosition(float x, float y);
        float Rotation { get; set; }
        void SetRotation(float rotation);
        void Render();
    }
}
