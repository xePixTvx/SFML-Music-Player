using SFML.Graphics;
using Core.UI.Controls;
using System.Collections.Generic;
using Core.UI;

namespace music_player_app.Music_Player.SoundPlayer
{
    class SoundPlayerUI
    {
        private SpriteButton PlayPauseButton;
        private SpriteButton RestartButton;
        private SpriteButton NextButton;
        private SpriteButton PreviousButton;

        public List<SpriteButton> ButtonList = new List<SpriteButton>();

        public SoundPlayerUI()
        {
            ButtonList.Clear();

            PlayPauseButton = new SpriteButton("button_play", "center_bottom", "center_bottom", 30, -20);
            ButtonList.Add(PlayPauseButton);

            RestartButton = new SpriteButton("button_reload", "center_bottom", "center_bottom", -30, -20);
            ButtonList.Add(RestartButton);

            NextButton = new SpriteButton("button_next", "center_bottom", "center_bottom", 90, -20);
            ButtonList.Add(NextButton);

            PreviousButton = new SpriteButton("button_previous", "center_bottom", "center_bottom", -90, -20);
            ButtonList.Add(PreviousButton);
        }

        public void Update(RenderWindow window)
        {
            foreach(SpriteButton button in ButtonList)
            {
                button.Render();
            }
        }

    }
}
