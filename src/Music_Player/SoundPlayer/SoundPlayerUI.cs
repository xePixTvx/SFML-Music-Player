using SFML.Graphics;
using Core.UI;


//Finish Button Stuff First!!!!!!!!!!!!!!!!!!!!!!!!!!!
namespace music_player_app.Music_Player.SoundPlayer
{
    class SoundPlayerUI
    {
        private SimpleSprite PlayPauseButton_Sprite;
        private SimpleSprite RestartButton_Sprite;
        private SimpleSprite NextButton_Sprite;
        private SimpleSprite PreviousButton_Sprite;

        public SoundPlayerUI()
        {
            PlayPauseButton_Sprite = new SimpleSprite(Assets.Button_Play_Texture);
            PlayPauseButton_Sprite.setPosition("center_bottom", "center_bottom", 20, -20);

            NextButton_Sprite = new SimpleSprite(Assets.Button_Next_Texture);
            NextButton_Sprite.setPosition("center_bottom", "center_bottom", 80, -20);


            RestartButton_Sprite = new SimpleSprite(Assets.Button_Reload_Texture);
            RestartButton_Sprite.setPosition("center_bottom", "center_bottom", -20, -20);

            PreviousButton_Sprite = new SimpleSprite(Assets.Button_Previous_Texture);
            PreviousButton_Sprite.setPosition("center_bottom", "center_bottom", -80, -20);
        }


        public void Update(RenderWindow window)
        {
            PlayPauseButton_Sprite.DrawTo(window);
            RestartButton_Sprite.DrawTo(window);
            NextButton_Sprite.DrawTo(window);
            PreviousButton_Sprite.DrawTo(window);
        }

    }
}
