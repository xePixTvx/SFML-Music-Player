using PIX_UI;
using PIX_UI.Graphics;
using PIX_UI.Graphics.Controls;
using PIX_UI.Graphics.Primitives;
using SFML.Graphics;
using SFML.System;

namespace music_app.GUI
{
    class VolumeMenu
    {
        private bool _Active;

        public bool Active
        {
            get { return _Active; }
            set
            {
                _Active = value;
                UpdateActiveState();
            }
        }

        public VolumeMenu(Vector2f Main_Pos)
        {
            new SpriteButton("Button_Volume_Minus", Alignment.RIGHT_BOTTOM, Main_Pos.X, Main_Pos.Y, "minus");
            App.GetElemByName("Button_Volume_Minus").RenderLayer = 2;

            new ProgressBar("Volume_Bar", 30, 200, Main_Pos.X - 23, Main_Pos.Y - 40, ProgressBarStyles.VERTICAL, new Color(138, 138, 138, 255), new Color(205, 205, 205, 255), 50);
            App.GetElemByName("Volume_Bar").RenderLayer = 2;

            new SimpleText("Volume_Progress_Text", Alignment.CENTER_CENTER, Main_Pos.X - 22, Main_Pos.Y - 255, new Color(255, 255, 255, 255), "sansC", 20, Text.Styles.Regular, "30%");
            App.GetElemByName("Volume_Progress_Text").RenderLayer = 2;

            new SpriteButton("Button_Volume_Plus", Alignment.RIGHT_BOTTOM, Main_Pos.X, Main_Pos.Y - 263, "plus");
            App.GetElemByName("Button_Volume_Plus").RenderLayer = 2;

            Active = false;
        }


        //Update Active/Visible
        private void UpdateActiveState()
        {
            App.GetElemByName("Button_Volume_Minus").IsActive = Active;
            App.GetElemByName("Volume_Bar").IsActive = Active;
            App.GetElemByName("Volume_Progress_Text").IsActive = Active;
            App.GetElemByName("Button_Volume_Plus").IsActive = Active;
        }



    }
}
