using SFML.Graphics;
using SFML.System;
using System;


//Works but i dont like it so i still consider it UNFINISHED

namespace Core.UI.Controls
{
    class ProgressBar : RenderableBase
    {
        private RectangleShape BG_Shape;
        private RectangleShape Fill_Shape;
        private float _Value;
        private Vector2f _Size;
        private ProgressBarStyles _Style;

        public Vector2f Size
        {
            get { return _Size; }
            set
            {
                _Size = value;
                NeedsUpdate = true;
            }
        }

        public float Value
        {
            get { return _Value; }
            set
            {
                _Value = (value > 100) ? 100 : (value < 0) ? 0 : value;
                NeedsUpdate = true;
            }
        }

        public ProgressBarStyles Style
        {
            get { return _Style; }
            private set
            {
                _Style = value;
                NeedsUpdate = true;
            }
        }

        public ProgressBar(float width, float height, Color BG_RGBA, Color Fill_RGBA, ProgressBarStyles ProgressbarStyle = ProgressBarStyles.HORIZONTAL, float value = 0)
        {
            BG_Shape = new RectangleShape
            {
                FillColor = BG_RGBA
            };
            Fill_Shape = new RectangleShape
            {
                FillColor = Fill_RGBA
            };
            Style = ProgressbarStyle;
            Size = new Vector2f(width, height);
            Value = value;
            Core.App.RenderSys.AddToRenderList(this);
        }

        public override void Update()
        {
            if (NeedsUpdate)
            {
                //Update BG Size
                BG_Shape.Size = Size;

                //Update Fill Size depending on Value
                if (Style == ProgressBarStyles.HORIZONTAL)
                {
                    float fill_size_x = (Size.X / 100) * Value;
                    Fill_Shape.Size = new Vector2f(fill_size_x, Size.Y);

                    //Update Origin
                    BG_Shape.Origin = Utils.GetOriginPosition(BG_Shape, Origin_Horizontal_Alignment.CENTER, Origin_Vertical_Alignment.CENTER);
                    Fill_Shape.Origin = Utils.GetOriginPosition(Fill_Shape, Origin_Horizontal_Alignment.LEFT, Origin_Vertical_Alignment.CENTER);

                    //Update Position
                    BG_Shape.Position = Position;
                    Fill_Shape.Position = new Vector2f(BG_Shape.Origin.X, Position.Y);
                }
                else if(Style == ProgressBarStyles.VERTICAL)
                {
                    float fill_size_y = (Size.Y / 100) * Value;
                    Fill_Shape.Size = new Vector2f(Size.X, fill_size_y);

                    //Update Origin
                    BG_Shape.Origin = Utils.GetOriginPosition(BG_Shape, Origin_Horizontal_Alignment.CENTER, Origin_Vertical_Alignment.BOTTOM);
                    Fill_Shape.Origin = Utils.GetOriginPosition(Fill_Shape, Origin_Horizontal_Alignment.CENTER, Origin_Vertical_Alignment.BOTTOM);

                    //Update Position
                    BG_Shape.Position = Position;
                    Fill_Shape.Position = new Vector2f(BG_Shape.Position.X, BG_Shape.Position.Y);
                }
                else
                {
                    Style = ProgressBarStyles.HORIZONTAL;
                }

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
