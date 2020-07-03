using SFML.Audio;

namespace music_player_app.Music_App.SoundPlayer
{
    class AudioPlayer
    {
        public Sound sf_sound;
        private SoundBuffer sf_buffer;

        //UI
        private MainUI UI;

        public AudioPlayer()
        {
            sf_sound = new Sound();
            sf_sound.Volume = 30;

            UI = new MainUI(sf_sound.Volume);
        }

        public void DisposeAudioPlayer()
        {
            sf_sound.Dispose();
            sf_buffer.Dispose();
        }

        #region Sound Buffer Stuff
        public bool IsAudioLoaded()
        {
            if(sf_sound.SoundBuffer != null)
            {
                return true;
            }
            return false;
        }

        public SoundBuffer GetLoadedAudioBuffer()
        {
            if(!IsAudioLoaded())
            {
                return null;
            }
            return sf_sound.SoundBuffer;
        }

        public void LoadAudio(string file)
        {
            sf_buffer = new SoundBuffer(file);
            sf_sound.SoundBuffer = sf_buffer;
            UI.UpdateSongName(file);/////////////////////////////////UPDATE THIS
        }
        #endregion Sound Buffer Stuff



        public void Update()
        {
            if (sf_sound.Status == SoundStatus.Playing)
            {
                UI.UpdatePlayingTime(sf_sound);
            }
        }


    }
}
