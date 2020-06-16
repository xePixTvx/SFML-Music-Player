using SFML.Graphics;
using SFML.System;
using System;

namespace Core.UI.Controls
{
    class SpriteButton : ClickableBase
    {
        private Sprite shape;

        public SpriteButton(string texture_name, Action action = null)
        {
            Sprite construct_shape = new Sprite
            {
                Texture = Core.App.AsManager.getTexture(texture_name)
            };
            shape = construct_shape;
            ExecAction = action;
            Core.App.RenderSys.AddToRenderList(this);
        }

        public override void SetOrigin(Origin_Horizontal_Alignment h_align, Origin_Vertical_Alignment v_align)
        {
            Origin_H_Align = h_align;
            Origin_V_Align = v_align;
            float origin_h = (h_align == Origin_Horizontal_Alignment.CENTER) ? (shape.Texture.Size.X * (float)0.5) : (h_align == Origin_Horizontal_Alignment.RIGHT) ? shape.Texture.Size.X : 0;
            float origin_v = (v_align == Origin_Vertical_Alignment.CENTER) ? (shape.Texture.Size.Y * (float)0.5) : (v_align == Origin_Vertical_Alignment.BOTTOM) ? shape.Texture.Size.Y : 0;
            shape.Origin = new Vector2f(origin_h, origin_v);
        }

        public override void SetPosition(float x, float y)
        {
            Position = new Vector2f(x, y);
            shape.Position = Position;
        }

        public override void SetRotation(float rotation)
        {
            shape.Rotation = rotation;
        }

        public override void UpdateSelection()
        {
            IsSelected = (Utils.isHovered(shape)==true) ? true : false;

            if (IsSelected)//do it in Render()?????
            {
                shape.Color = new Color(255, 255, 255, 255);
            }
            else
            {
                shape.Color = new Color(255, 255, 255, 130);
            }
        }

        public override void Render()
        {
            if (IsVisible)
            {
                Core.App.window.Draw(shape);
            }
        }
    }
}
