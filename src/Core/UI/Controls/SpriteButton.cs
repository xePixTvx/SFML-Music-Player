using SFML.Graphics;
using SFML.System;
using System;

namespace Core.UI.Controls
{
    class SpriteButton : ClickableBase
    {
        private Sprite Shape;

        public SpriteButton(string texture_name, Action action = null)
        {
            Shape = new Sprite
            {
                Texture = Core.App.AsManager.GetTexture(texture_name)
            };
            ExecAction = action;
            Core.App.RenderSys.AddToRenderList(this);
        }

        public override void SetOrigin(Origin_Horizontal_Alignment h_align, Origin_Vertical_Alignment v_align)
        {
            Origin_H_Align = h_align;
            Origin_V_Align = v_align;
            float origin_h = (h_align == Origin_Horizontal_Alignment.CENTER) ? (Shape.Texture.Size.X * (float)0.5) : (h_align == Origin_Horizontal_Alignment.RIGHT) ? Shape.Texture.Size.X : 0;
            float origin_v = (v_align == Origin_Vertical_Alignment.CENTER) ? (Shape.Texture.Size.Y * (float)0.5) : (v_align == Origin_Vertical_Alignment.BOTTOM) ? Shape.Texture.Size.Y : 0;
            Shape.Origin = new Vector2f(origin_h, origin_v);
        }

        public override void SetPosition(float x, float y)
        {
            Position = new Vector2f(x, y);
            Shape.Position = Position;
        }

        public override void SetRotation(float rotation)
        {
            Shape.Rotation = rotation;
        }

        public override void UpdateSelection()
        {
            IsSelected = (Utils.IsHovered(Shape)==true) ? true : false;

            if (IsSelected)
            {
                Shape.Color = new Color(255, 255, 255, 255);
            }
            else
            {
                Shape.Color = new Color(255, 255, 255, 130);
            }
        }

        public void SetTexture(string texture_name)
        {
            Shape.Texture = Core.App.AsManager.GetTexture(texture_name);
            SetOrigin(Origin_H_Align, Origin_V_Align);
            SetPosition(Position.X, Position.Y);
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
