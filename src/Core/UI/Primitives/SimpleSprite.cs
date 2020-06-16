using SFML.Graphics;
using SFML.System;

namespace Core.UI.Primitives
{
    class SimpleSprite : RenderableBase
    {
        private Sprite shape;

        public SimpleSprite(string texture_name)
        {
            Sprite construct_shape = new Sprite
            {
                Texture = Core.App.AsManager.getTexture(texture_name)
            };
            shape = construct_shape;
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

        public override void Render()
        {
            if (IsVisible)
            {
                Core.App.window.Draw(shape);
            }
        }
    }
}
