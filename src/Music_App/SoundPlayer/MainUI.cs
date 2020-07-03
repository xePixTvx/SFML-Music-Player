using Core.UI;
using Core.UI.Controls;
using SFML.System;
using SFML.Graphics;
using SFML.Audio;
using Core.UI.Primitives;
using System;

namespace music_player_app.Music_App.SoundPlayer
{
    class MainUI
    {
        private Sound Sound;
        private SpriteButton PLAY_PAUSE_BUTTON, STOP_BUTTON, NEXT_SONG_BUTTON, PREV_SONG_BUTTON, VOLUME_MENU_OPEN_BUTTON, VOLUME_MENU_MINUS_BUTTON, VOLUME_MENU_PLUS_BUTTON;
        private ProgressBar TimeLine, VOLUME_MENU_PROGRESS;
        private SimpleText TimeText, SongName, VOLUME_MENU_PROGRESS_TEXT;
        private bool _VolumeMenuOpened;
        private float CurrentVolume;

        public bool VolumeMenuOpened
        {
            get { return _VolumeMenuOpened; }
            set 
            {
                _VolumeMenuOpened = value;
                UpdateVolumeMenuVisibility();
            }
        }

        public MainUI(Sound sound, float currentVolume)
        {
            Sound = sound;
            CurrentVolume = currentVolume;

            Vector2f Buttons_CenterBottomPos = Utils.GetPosition(Position_Horizontal_Alignment.CENTER, Position_Vertical_Alignment.BOTTOM);
            Vector2f Buttons_RightBottomPos = Utils.GetPosition(Position_Horizontal_Alignment.RIGHT, Position_Vertical_Alignment.BOTTOM);

            #region Main UI Elems
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

            //Time Line
            TimeLine = new ProgressBar(600, 15, new Color(138, 138, 138, 255), new Color(205, 205, 205, 255), ProgressBarStyles.HORIZONTAL);
            Vector2f timeline_pos = Utils.GetPosition(Position_Horizontal_Alignment.CENTER, Position_Vertical_Alignment.BOTTOM);
            TimeLine.Position = new Vector2f(timeline_pos.X, timeline_pos.Y - 120);
            TimeLine.RenderLayer = 0;

            //Time Text
            TimeText = new SimpleText("sansC", Text.Styles.Regular, 20, new Color(255, 255, 255, 255), "0:00");
            TimeText.Origin_H_Align = Origin_Horizontal_Alignment.CENTER;
            TimeText.Origin_V_Align = Origin_Vertical_Alignment.BOTTOM;
            TimeText.Position = new Vector2f(Buttons_CenterBottomPos.X, Buttons_CenterBottomPos.Y - 80);
            TimeText.RenderLayer = 0;

            //Song Name
            SongName = new SimpleText("sansC", Text.Styles.Regular, 20, new Color(255, 255, 255, 255), "-");
            SongName.Origin_H_Align = Origin_Horizontal_Alignment.CENTER;
            SongName.Origin_V_Align = Origin_Vertical_Alignment.BOTTOM;
            SongName.Position = new Vector2f(Buttons_CenterBottomPos.X, Buttons_CenterBottomPos.Y - 140);
            SongName.RenderLayer = 0;
            #endregion Main UI Elems

            #region Volume Menu
            //Volume Menu Button
            VOLUME_MENU_OPEN_BUTTON = new SpriteButton("button_volume",Action_ToggleVolumeMenu);
            VOLUME_MENU_OPEN_BUTTON.Origin_H_Align = Origin_Horizontal_Alignment.RIGHT;
            VOLUME_MENU_OPEN_BUTTON.Origin_V_Align = Origin_Vertical_Alignment.BOTTOM;
            VOLUME_MENU_OPEN_BUTTON.Position = new Vector2f(Buttons_RightBottomPos.X - 15, Buttons_RightBottomPos.Y - 15);
            VOLUME_MENU_OPEN_BUTTON.RenderLayer = 0;

            //Volume Minus Button
            VOLUME_MENU_MINUS_BUTTON = new SpriteButton("minus",Action_DecreaseVolume);
            VOLUME_MENU_MINUS_BUTTON.Origin_H_Align = Origin_Horizontal_Alignment.RIGHT;
            VOLUME_MENU_MINUS_BUTTON.Origin_V_Align = Origin_Vertical_Alignment.BOTTOM;
            VOLUME_MENU_MINUS_BUTTON.Position = new Vector2f(Buttons_RightBottomPos.X - 15, Buttons_RightBottomPos.Y - 70);
            VOLUME_MENU_MINUS_BUTTON.RenderLayer = 0;

            //Volume Plus Button
            VOLUME_MENU_PLUS_BUTTON = new SpriteButton("plus",Action_IncreaseVolume);
            VOLUME_MENU_PLUS_BUTTON.Origin_H_Align = Origin_Horizontal_Alignment.RIGHT;
            VOLUME_MENU_PLUS_BUTTON.Origin_V_Align = Origin_Vertical_Alignment.BOTTOM;
            VOLUME_MENU_PLUS_BUTTON.Position = new Vector2f(Buttons_RightBottomPos.X - 15, Buttons_RightBottomPos.Y - 320);
            VOLUME_MENU_PLUS_BUTTON.RenderLayer = 0;

            //Volume Progressbar
            VOLUME_MENU_PROGRESS = new ProgressBar(15, 200, new Color(138, 138, 138, 255), new Color(205, 205, 205, 255), ProgressBarStyles.VERTICAL, CurrentVolume);
            Vector2f volProgress_pos = Utils.GetPosition(Position_Horizontal_Alignment.RIGHT, Position_Vertical_Alignment.BOTTOM);
            VOLUME_MENU_PROGRESS.Position = new Vector2f(volProgress_pos.X - 39, volProgress_pos.Y - 103);
            VOLUME_MENU_PROGRESS.RenderLayer = 0;

            //Volume Progress Text
            VOLUME_MENU_PROGRESS_TEXT = new SimpleText("sansC", Text.Styles.Regular, 20, new Color(255, 255, 255, 255), Convert.ToInt32(CurrentVolume) + "%");
            VOLUME_MENU_PROGRESS_TEXT.Origin_H_Align = Origin_Horizontal_Alignment.CENTER;
            VOLUME_MENU_PROGRESS_TEXT.Origin_V_Align = Origin_Vertical_Alignment.BOTTOM;
            VOLUME_MENU_PROGRESS_TEXT.Position = new Vector2f(Buttons_RightBottomPos.X - 35, Buttons_RightBottomPos.Y - 307);
            VOLUME_MENU_PROGRESS_TEXT.RenderLayer = 0;

            VolumeMenuOpened = false;
            #endregion Volume Menu
        }

        public void UpdateSongName(string name)
        {
            SongName.String = name;
        }

        public void UpdatePlayingTime(Sound sound)
        {
            float duration_ms = sound.SoundBuffer.Duration.AsMilliseconds();
            int minutes = (int)sound.PlayingOffset.AsSeconds() / 60;
            int seconds = (int)sound.PlayingOffset.AsSeconds();
            float millisec = sound.PlayingOffset.AsMilliseconds();

            //Update Time Text
            TimeText.String = ((seconds - (60 * minutes)) < 10) ? (minutes + ":0" + (seconds - (60 * minutes))) : (minutes + ":" + (seconds - (60 * minutes)));

            //Update Time Line
            TimeLine.Value = millisec / (duration_ms / 100);
        }

        private void UpdateVolumeMenuVisibility()
        {
            VOLUME_MENU_MINUS_BUTTON.IsActive = VolumeMenuOpened;
            VOLUME_MENU_PLUS_BUTTON.IsActive = VolumeMenuOpened;
            VOLUME_MENU_PROGRESS.IsActive = VolumeMenuOpened;
            VOLUME_MENU_PROGRESS_TEXT.IsActive = VolumeMenuOpened;
        }

        private void UpdateVolume()
        {
            CurrentVolume = (CurrentVolume > 100) ? 100 : (CurrentVolume < 0) ? 0 : CurrentVolume;
            Sound.Volume = CurrentVolume;
            VOLUME_MENU_PROGRESS.Value = CurrentVolume;
            VOLUME_MENU_PROGRESS_TEXT.String = Convert.ToInt32(CurrentVolume) + "%";
        }

        #region Button Actions
        //Toggle Play/Pause Action
        private void Action_PlayPause()
        {
            if (Sound.Status == SoundStatus.Paused || Sound.Status == SoundStatus.Stopped)
            {
                PLAY_PAUSE_BUTTON.Texture_Name = "button_pause";
                Sound.Play();
            }
            else if (Sound.Status == SoundStatus.Playing)
            {
                PLAY_PAUSE_BUTTON.Texture_Name = "button_play";
                Sound.Pause();
            }
        }

        //Stop Song Action
        private void Action_Stop()
        {
            if (Sound.Status == SoundStatus.Playing)
            {
                Sound.Stop();
                PLAY_PAUSE_BUTTON.Texture_Name = "button_play";
                UpdatePlayingTime(Sound);
            }
        }

        //Show/Hide Volume Menu
        private void Action_ToggleVolumeMenu()
        {
            VolumeMenuOpened = (!VolumeMenuOpened) ? true : false;
        }

        //Increase/Decrease Volume
        private void Action_IncreaseVolume()
        {
            CurrentVolume += 5;
            UpdateVolume();
        }
        private void Action_DecreaseVolume()
        {
            CurrentVolume -= 5;
            UpdateVolume();
        }
        #endregion Button Actions
    }
}
