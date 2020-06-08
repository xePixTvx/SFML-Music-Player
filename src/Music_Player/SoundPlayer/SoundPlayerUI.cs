using SFML.Graphics;
using Core.UI.Controls;

namespace music_player_app.Music_Player.SoundPlayer
{
    class SoundPlayerUI
    {
        private SpriteButton PlayPauseButton;
        private SpriteButton RestartButton;
        private SpriteButton NextButton;
        private SpriteButton PreviousButton;

        public SoundPlayerUI()
        {
            PlayPauseButton = new SpriteButton("button_play", "center_bottom", "center_bottom", 20, -20);
            NextButton = new SpriteButton("button_next", "center_bottom", "center_bottom", 80, -20);
            RestartButton = new SpriteButton("button_reload", "center_bottom", "center_bottom", -20, -20);
            PreviousButton = new SpriteButton("button_previous", "center_bottom", "center_bottom", -80, -20);
        }


        public void Update(RenderWindow window)
        {
            PlayPauseButton.Render();
            RestartButton.Render();
            NextButton.Render();
            PreviousButton.Render();
        }

    }
}
