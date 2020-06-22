using SFML.Graphics;
using SFML.System;

namespace Core.UI.Primitives
{
    class Rect : RenderableBase
    {
        private RectangleShape Shape;
        private Vector2f _Size;

        public Vector2f Size
        {
            get { return _Size; }
            set 
            { 
                _Size = value;
                NeedsUpdate = true;
            }
        }

        public Rect(float width, float height, Color RGBA)
        {
            Shape = new RectangleShape
            {
                FillColor = RGBA
            };
            Size = new Vector2f(width, height);
            Core.App.RenderSys.AddToRenderList(this);
        }

        public override void Update()
        {
            if (NeedsUpdate)
            {
                //Update Size
                Shape.Size = Size;

                //Update Origin
                Shape.Origin = Utils.GetOriginPosition(Shape, Origin_H_Align, Origin_V_Align);

                //Update Position
                Shape.Position = Position;

                //Update Rotation
                Shape.Rotation = Rotation;

                NeedsUpdate = false;
            }
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
