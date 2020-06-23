using SFML.Graphics;
using SFML.System;

namespace Core.UI.Controls
{
    class ProgressBar : RenderableBase
    {
        private RectangleShape BG_Shape;
        private RectangleShape Fill_Shape;
        private int _Value;

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

        public int Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
                NeedsUpdate = true;
            }
        }

        public ProgressBar(float width, float height, Color BG_RGBA, Color Fill_RGBA, int value = 0)
        {
            BG_Shape = new RectangleShape
            {
                FillColor = BG_RGBA
            };
            Fill_Shape = new RectangleShape
            {
                FillColor = Fill_RGBA
            };
            Size = new Vector2f(width, height);
            Value = value;
            Core.App.RenderSys.AddToRenderList(this);
        }

        public override void Update()
        {
            if (NeedsUpdate)
            {
                //Update Size
                BG_Shape.Size = Size;
                Fill_Shape.Size = new Vector2f(Size.X - 50, Size.Y);

                //Update Origin
                BG_Shape.Origin = Utils.GetOriginPosition(BG_Shape, Origin_H_Align, Origin_V_Align);
                Fill_Shape.Origin = Utils.GetOriginPosition(Fill_Shape, Origin_Horizontal_Alignment.LEFT, Origin_V_Align);

                //Update Position
                BG_Shape.Position = Position;
                Fill_Shape.Position = new Vector2f(BG_Shape.Origin.X, Position.Y);

                //Update Rotation
                BG_Shape.Rotation = Rotation;
                Fill_Shape.Rotation = Rotation;

                NeedsUpdate = false;
            }
        }

        public override void Render()
        {
            if (IsVisible)
            {
                Core.App.Window.Draw(BG_Shape);
                Core.App.Window.Draw(Fill_Shape);
            }
        }
    }
}
