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


        public TextButton(string BG_Origin_Align = "center_center", string BG_Position_Align = "center_center", float BG_Position_X = 0, float BG_Position_Y = 0, Action button_action = null, string text_font = "default", uint text_size = 10, Text.Styles text_style = Text.Styles.Regular, string text_align = "center_center", string text_string = "")
        {
            BG = new SimpleRect(200, 30, new Color(255, 0, 0, 255));
            BG.setPosition(BG_Origin_Align, BG_Position_Align, BG_Position_X, BG_Position_Y);
            action = button_action;

            BText = new SimpleText(text_font, text_style, text_size, new Color(255, 255, 255, 255), text_string);
            //BText.setPosition(BG_Origin_Align, BG_Position_Align, BG_Position_X, BG_Position_Y);
            //setTextPosition(text_align);

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
                    //BText.Render();
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

        private void setTextPosition(string text_align)
        {
            string x_align = text_align.Split('_')[0];
            string y_align = text_align.Split('_')[1];
            float x = 0;
            float y = 0;

            if(y_align == "center")
            {

            }



            BText.setPosition(x_align + "_" + y_align, x_align + "_" + y_align);

        }

    }
}

