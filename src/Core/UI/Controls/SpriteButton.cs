using SFML.Graphics;
using System;

namespace Core.UI.Controls
{
    class SpriteButton : ClickableBase
    {
        private Sprite Shape;
        private string _Texture_Name;

        public string Texture_Name
        {
            get { return _Texture_Name; }
            set
            {
                _Texture_Name = value;
                NeedsUpdate = true;
            }
        }

        public SpriteButton(string texture_name, Action action = null)
        {
            Shape = new Sprite();
            Texture_Name = texture_name;
            ExecAction = action;
            Core.App.RenderSys.AddToRenderList(this);
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

        public override void Update()
        {
            if (NeedsUpdate)
            {
                //Update Texture
                Shape.Texture = Core.App.AsManager.GetTexture(Texture_Name);

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
