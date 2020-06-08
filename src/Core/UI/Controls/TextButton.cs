using SFML.Graphics;
using Core.UI.Interfaces;
using SFML.Window;
using System;

namespace Core.UI.Controls
{
    class TextButton : IDrawable<TextButton>, IClickableControl
    {
        private SimpleRect BG;
        private SimpleText BText;
        private bool isSelected;
        private Action action;
        public bool isActive { get; set; }
        public bool isVisible { get; set; }


        public TextButton(string BG_Origin_Align = "center_center", string BG_Position_Align = "center_center", float BG_Position_X = 0, float BG_Position_Y = 0, Action button_action = null)
        {
            BG = new SimpleRect(200, 30, new Color(255, 0, 0, 255));
            BG.setPosition(BG_Origin_Align, BG_Position_Align, BG_Position_X, BG_Position_Y);
            action = button_action;

            isActive = true;
            isVisible = true;
        }

        public void Render()
        {
            if (isActive)
            {
                if (isHovered(Core.App.window))
                {
                    BG.Drawable_Rect.FillColor = new Color(0, 255, 0, 255);
                    isSelected = true;
                }
                else
                {
                    BG.Drawable_Rect.FillColor = new Color(255, 0, 0, 255);
                    isSelected = false;
                }

                if(isVisible)
                {
                    BG.Render();
                }
            }
        }

        public void ExecuteAction()
        {
            if(action==null)
            {
                Core.App.Log.Print("Button Action Not Defined!", LoggerType.ERROR);
                return;
            }
            action();
        }

        public bool IsSelected()
        {
            return isSelected;
        }

        private bool isHovered(RenderWindow window)
        {
            if (BG.Drawable_Rect.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y) && window.HasFocus())
            {
                return true;
            }
            return false;
        }

    }
}
