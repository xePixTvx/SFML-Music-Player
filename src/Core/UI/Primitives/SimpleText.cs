using SFML.Graphics;

namespace Core.UI.Primitives
{
    class SimpleText : RenderableBase
    {
        private Text Shape;
        private string _String;

        public string String
        {
            get { return _String; }
            set 
            {
                _String = value;
                NeedsUpdate = true;
            }
        }

        public SimpleText(string font_name, Text.Styles style, uint size, Color RGBA, string displayedText)
        {
            Shape = new Text
            {
                Font = Core.App.AsManager.GetFont(font_name),
                Style = style,
                CharacterSize = size,
                FillColor = RGBA,
            };
            String = displayedText;
            Core.App.RenderSys.AddToRenderList(this);
        }

        public override void Update()
        {
            if (NeedsUpdate)
            {
                //Update String
                Shape.DisplayedString = String;

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
