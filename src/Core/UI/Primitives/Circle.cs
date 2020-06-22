using SFML.Graphics;

namespace Core.UI.Primitives
{
    class Circle : RenderableBase
    {
        private CircleShape Shape;
        private float _Radius;

        public float Radius
        {
            get { return _Radius; }
            set
            {
                _Radius = value;
                NeedsUpdate = true;
            }
        }

        public Circle(float radius, Color RGBA)
        {
            Shape = new CircleShape
            {
                FillColor = RGBA
            };
            Radius = radius;
            Core.App.RenderSys.AddToRenderList(this);
        }

        public override void Update()
        {
            if (NeedsUpdate)
            {
                //Update Size
                Shape.Radius = Radius;

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
