using PIX_UI;
using PIX_UI.Graphics;
using PIX_UI.Graphics.Controls;
using PIX_UI.Graphics.Primitives;
using SFML.Graphics;
using SFML.System;
using System;

namespace music_app.GUI
{
    class VolumeMenu
    {
        private bool _Active;
        private float _Volume;

        public bool Active
        {
            get { return _Active; }
            set
            {
                _Active = value;
                UpdateActiveState();
            }
        }

        public float Volume
        {
            get { return _Volume; }
            set
            {
                _Volume = (value > 100) ? 100 : (value < 0) ? 0 : value;
                UpdateVolume();
            }
        }

        public VolumeMenu(Vector2f Main_Pos)
        {
            new SpriteButton("Button_Volume_Minus", Alignment.RIGHT_BOTTOM, Main_Pos.X, Main_Pos.Y, "minus", Action_Decrease_Volume);
            App.GetElemByName("Button_Volume_Minus").RenderLayer = 2;

            new ProgressBar("Volume_Bar", 30, 200, Main_Pos.X - 23, Main_Pos.Y - 40, ProgressBarStyles.VERTICAL, new Color(138, 138, 138, 255), new Color(205, 205, 205, 255), 0);
            App.GetElemByName("Volume_Bar").RenderLayer = 2;

            new SimpleText("Volume_Progress_Text", Alignment.CENTER_CENTER, Main_Pos.X - 22, Main_Pos.Y - 255, new Color(255, 255, 255, 255), "sansC", 20, Text.Styles.Regular, "");
            App.GetElemByName("Volume_Progress_Text").RenderLayer = 2;

            new SpriteButton("Button_Volume_Plus", Alignment.RIGHT_BOTTOM, Main_Pos.X, Main_Pos.Y - 263, "plus", Action_Increase_Volume);
            App.GetElemByName("Button_Volume_Plus").RenderLayer = 2;

            Volume = 30;
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



        private void Action_Increase_Volume()
        {
            Volume += 5;
        }

        private void Action_Decrease_Volume()
        {
            Volume -= 5;
        }

        private void UpdateVolume()
        {
            SimpleText vol_info_text = App.GetElemByName("Volume_Progress_Text") as SimpleText;
            ProgressBar vol_progress_bar = App.GetElemByName("Volume_Bar") as ProgressBar;
            vol_info_text.String = Convert.ToInt32(Volume) + "%";
            vol_progress_bar.Value = Volume;
        }

    }
}
