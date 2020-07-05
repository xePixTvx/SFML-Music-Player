using SFML.System;
using SFML.Graphics;
using System;

namespace Core.UI.Controls
{
    class TextButton : ClickableBase
    {
        private RectangleShape BG_Shape;
        private Text B_Text;
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

        public TextButton(float width, float height, Color BG_RGBA, string font_name, Text.Styles style, uint size, Color RGBA, string displayedText, Action action = null)
        {
            BG_Shape = new RectangleShape
            {
                FillColor = BG_RGBA,
                Size = new Vector2f(width, height)
            };
            B_Text = new Text
            {
                Font = Core.App.AsManager.GetFont(font_name),
                Style = style,
                CharacterSize = size,
                FillColor = RGBA,
            };
            String = displayedText;

            ExecAction = action;
            Core.App.RenderSys.AddToRenderList(this);
        }

        public override void UpdateSelection()
        {
            IsSelected = (Utils.IsHovered(BG_Shape) == true) ? true : false;

            if (IsSelected)
            {
                BG_Shape.FillColor = new Color(255, 0, 0, 255);
            }
            else
            {
                BG_Shape.FillColor = new Color(255, 0, 0, 130);
            }
        }

        public override void Update()
        {
            if (NeedsUpdate)
            {
                //Update String
                B_Text.DisplayedString = String;

                //Update Origin
                BG_Shape.Origin = Utils.GetOriginPosition(BG_Shape, Origin_H_Align, Origin_V_Align);
                B_Text.Origin = Utils.GetOriginPosition(BG_Shape, Origin_H_Align, Origin_V_Align);

                //Update Position
                BG_Shape.Position = Position;
                B_Text.Position = Position;

                //Update Rotation
                BG_Shape.Rotation = Rotation;
                B_Text.Rotation = Rotation;

                NeedsUpdate = false;
            }
        }

        public override void Render()
        {
            if (IsVisible)
            {
                Core.App.Window.Draw(BG_Shape);
                Core.App.Window.Draw(B_Text);
            }
        }
    }
}
