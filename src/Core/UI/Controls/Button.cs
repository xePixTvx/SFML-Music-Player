using SFML.Graphics;
using Core.UI.Interfaces;
using SFML.Window;

namespace Core.UI.Controls
{
    class Button : IClickableControl
    {
        private SimpleRect BG;

        public Button()
        {
            BG = new SimpleRect(200, 30, new Color(255, 0, 0, 255));
            BG.setOrigin("center", "center");
            BG.setPosition("center", "center");
        }


        public void DrawTo(RenderWindow window)
        {
            if(isHovered(window))
            {
                BG.getDrawable().FillColor = new Color(0, 255, 0, 255);
            }
            else
            {
                BG.getDrawable().FillColor = new Color(255, 0, 0, 255);
            }
            window.Draw(BG.getDrawable());
        }



        public bool isHovered(RenderWindow window)
        {
            if (BG.getDrawable().GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y) && window.HasFocus())
            {
                return true;
            }
            return false;
        }

    }
}
