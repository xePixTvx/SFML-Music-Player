using SFML.Graphics;

namespace Core.UI.Primitives
{
    class SimpleSprite : RenderableBase
    {
        private Sprite Shape;

        public SimpleSprite(string texture_name)
        {
            Shape = new Sprite
            {
                Texture = Core.App.AsManager.GetTexture(texture_name)
            };
            Core.App.RenderSys.AddToRenderList(this);
        }
        
        public override void Update()
        {
            if (NeedsUpdate)
            {
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
