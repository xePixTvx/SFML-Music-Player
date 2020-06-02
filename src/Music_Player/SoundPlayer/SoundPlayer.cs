using SFML.Audio;
using SFML.Graphics;

namespace music_player_app.Music_Player.SoundPlayer
{
    class SoundPlayer
    {
        private Sound sound;
        private SoundBuffer soundBuffer;
        private SoundPlayerUI UI;

        public SoundPlayer()
        {
            UI = new SoundPlayerUI();
            sound = new Sound();
        }


        public void LoadSound(string file)
        {
            soundBuffer = new SoundBuffer(file);
            sound.SoundBuffer = soundBuffer;
        }




        public enum PlayingStatusType
        {
            PLAY,
            PAUSE,
            STOP
        };

        public void SetStatus(PlayingStatusType status)
        {
            if(status == PlayingStatusType.PLAY)
            {
                sound.Play();
            }
            else if(status == PlayingStatusType.PAUSE)
            {
                sound.Pause();
            }
            else
            {
                sound.Stop();
            }
        }





        public void Update(RenderWindow window)
        {
            UI.Update(window);
        }



    }
}
