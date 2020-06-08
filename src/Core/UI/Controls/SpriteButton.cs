using SFML.Graphics;
using Core.UI.Interfaces;
using SFML.Window;
using System;

namespace Core.UI.Controls
{
    class SpriteButton : IDrawable<SpriteButton>, IClickableControl
    {
        private SimpleSprite sprite;
        private bool isSelected;
        private Action action;
        public bool isActive { get; set; }
        public bool isVisible { get; set; }


        public SpriteButton(string texture_name = "default", string sp_Origin_Align = "center_center", string sp_Position_Align = "center_center", float BG_Position_X = 0, float BG_Position_Y = 0, Action button_action = null)
        {
            sprite = new SimpleSprite(texture_name);
            sprite.setPosition(sp_Origin_Align, sp_Position_Align, BG_Position_X, BG_Position_Y);
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
                    sprite.Drawable_Sprite.Color = new Color(255, 255, 255, 255);
                    isSelected = true;
                }
                else
                {
                    sprite.Drawable_Sprite.Color = new Color(255, 255, 255, 130);
                    isSelected = false;
                }

                if (isVisible)
                {
                    sprite.Render();
                }
            }
        }

        public void ExecuteAction()
        {
            if (action == null)
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
            if (sprite.Drawable_Sprite.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y) && window.HasFocus())
            {
                return true;
            }
            return false;
        }
    }
}
