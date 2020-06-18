using SFML.Audio;

namespace music_player_app.Music_Player.SoundPlayer
{
    class AudioPlayer
    {
        private Sound sf_sound;
        private SoundBuffer sf_buffer;

        public enum PlayingStatus
        {
            PLAY,
            PAUSE,
            STOP
        };




        public AudioPlayer()
        {
            sf_sound = new Sound();
        }


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
            return sf_sound.SoundBuffer;
        }
        public void LoadAudio(string file)
        {
            sf_buffer = new SoundBuffer(file);
            sf_sound.SoundBuffer = sf_buffer;
        }


        public void SetPlayingStatus(PlayingStatus status)
        {
            if(!IsAudioLoaded())
            {
                return;
            }
            if (status == PlayingStatus.PLAY)
            {
                sf_sound.Play();
            }
            else if (status == PlayingStatus.PAUSE)
            {
                sf_sound.Pause();
            }
            else
            {
                sf_sound.Stop();
            }
        }

        public PlayingStatus GetPlayingStatus()
        {
            if(!IsAudioLoaded())
            {
                return PlayingStatus.STOP;
            }
            if (sf_sound.Status == SoundStatus.Playing)
            {
                return PlayingStatus.PLAY;
            }
            else if (sf_sound.Status == SoundStatus.Paused)
            {
                return PlayingStatus.PAUSE;
            }
            else if (sf_sound.Status == SoundStatus.Stopped)
            {
                return PlayingStatus.STOP;
            }
            SetPlayingStatus(PlayingStatus.STOP);
            return PlayingStatus.STOP;
        }


    }
}
