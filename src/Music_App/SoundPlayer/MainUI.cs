using Core.UI;
using Core.UI.Controls;
using SFML.System;

namespace music_player_app.Music_App.SoundPlayer
{
    class MainUI
    {
        private SpriteButton PLAY_PAUSE_BUTTON;
        private SpriteButton STOP_BUTTON;
        private SpriteButton NEXT_SONG_BUTTON;
        private SpriteButton PREV_SONG_BUTTON;

        private SpriteButton VOLUME_MENU_OPEN_BUTTON;

        public MainUI()
        {
            Vector2f Buttons_CenterBottomPos = Utils.GetPosition(Position_Horizontal_Alignment.CENTER, Position_Vertical_Alignment.BOTTOM);
            Vector2f Buttons_RightBottomPos = Utils.GetPosition(Position_Horizontal_Alignment.RIGHT, Position_Vertical_Alignment.BOTTOM);

            //Play/Pause Button
            PLAY_PAUSE_BUTTON = new SpriteButton("button_play", Action_PlayPause);
            PLAY_PAUSE_BUTTON.Origin_H_Align = Origin_Horizontal_Alignment.LEFT;
            PLAY_PAUSE_BUTTON.Origin_V_Align = Origin_Vertical_Alignment.BOTTOM;
            PLAY_PAUSE_BUTTON.Position = new Vector2f(Buttons_CenterBottomPos.X, Buttons_CenterBottomPos.Y - 15);
            PLAY_PAUSE_BUTTON.RenderLayer = 0;

            //Next Song Button
            NEXT_SONG_BUTTON = new SpriteButton("button_next");
            NEXT_SONG_BUTTON.Origin_H_Align = Origin_Horizontal_Alignment.LEFT;
            NEXT_SONG_BUTTON.Origin_V_Align = Origin_Vertical_Alignment.BOTTOM;
            NEXT_SONG_BUTTON.Position = new Vector2f(Buttons_CenterBottomPos.X + 100, Buttons_CenterBottomPos.Y - 15);
            NEXT_SONG_BUTTON.RenderLayer = 0;

            //Stop Button
            STOP_BUTTON = new SpriteButton("button_stop", Action_Stop);
            STOP_BUTTON.Origin_H_Align = Origin_Horizontal_Alignment.RIGHT;
            STOP_BUTTON.Origin_V_Align = Origin_Vertical_Alignment.BOTTOM;
            STOP_BUTTON.Position = new Vector2f(Buttons_CenterBottomPos.X, Buttons_CenterBottomPos.Y - 15);
            STOP_BUTTON.RenderLayer = 0;

            //Previous Song Button
            PREV_SONG_BUTTON = new SpriteButton("button_previous");
            PREV_SONG_BUTTON.Origin_H_Align = Origin_Horizontal_Alignment.RIGHT;
            PREV_SONG_BUTTON.Origin_V_Align = Origin_Vertical_Alignment.BOTTOM;
            PREV_SONG_BUTTON.Position = new Vector2f(Buttons_CenterBottomPos.X - 100, Buttons_CenterBottomPos.Y - 15);
            PREV_SONG_BUTTON.RenderLayer = 0;

            //Volume Menu Button
            VOLUME_MENU_OPEN_BUTTON = new SpriteButton("button_volume");//open a little popup volume slider
            VOLUME_MENU_OPEN_BUTTON.Origin_H_Align = Origin_Horizontal_Alignment.RIGHT;
            VOLUME_MENU_OPEN_BUTTON.Origin_V_Align = Origin_Vertical_Alignment.BOTTOM;
            VOLUME_MENU_OPEN_BUTTON.Position = new Vector2f(Buttons_RightBottomPos.X - 15, Buttons_RightBottomPos.Y - 15);
            VOLUME_MENU_OPEN_BUTTON.RenderLayer = 0;
        }




        #region Button Actions

        //Toggle Play/Pause Action
        private void Action_PlayPause()
        {
            AudioPlayer audio = Main.Audio_Player;
            if (audio.GetPlayingStatus() == AudioPlayer.PlayingStatus.PAUSE || audio.GetPlayingStatus() == AudioPlayer.PlayingStatus.STOP)
            {
                PLAY_PAUSE_BUTTON.Texture_Name = "button_pause";
                audio.SetPlayingStatus(AudioPlayer.PlayingStatus.PLAY);
            }
            else if (audio.GetPlayingStatus() == AudioPlayer.PlayingStatus.PLAY)
            {
                PLAY_PAUSE_BUTTON.Texture_Name = "button_play";
                audio.SetPlayingStatus(AudioPlayer.PlayingStatus.PAUSE);
            }
        }


        //Stop Song Action
        private void Action_Stop()
        {
            AudioPlayer audio = Main.Audio_Player;
            if (audio.GetPlayingStatus() == AudioPlayer.PlayingStatus.PLAY)
            {
                audio.SetPlayingStatus(AudioPlayer.PlayingStatus.STOP);
                PLAY_PAUSE_BUTTON.Texture_Name = "button_play";
            }
        }


        #endregion Button Actions




    }
}
