using SFML.Audio;

namespace music_player_app.Music_Player.SoundPlayer
{
    class AudioPlayer
    {
        private Sound sf_player;

        public enum PlayingStatus
        {
            PLAY,
            PAUSE,
            STOP
        };




        public AudioPlayer()
        {
            sf_player = new Sound();
        }




        public bool IsAudioLoaded()
        {
            if(sf_player.SoundBuffer != null)
            {
                return true;
            }
            return false;
        }
        public SoundBuffer GetLoadedAudioBuffer()
        {
            return sf_player.SoundBuffer;
        }
        public void LoadAudio(string file)
        {
            SoundBuffer buffer = new SoundBuffer(file);
            sf_player.SoundBuffer = buffer;
        }






        public void SetPlayingStatus(PlayingStatus status)
        {
            if(!IsAudioLoaded())
            {
                return;
            }
            if (status == PlayingStatus.PLAY)
            {
                sf_player.Play();
            }
            else if (status == PlayingStatus.PAUSE)
            {
                sf_player.Pause();
            }
            else
            {
                sf_player.Stop();
            }
        }

        public PlayingStatus GetPlayingStatus()
        {
            if(!IsAudioLoaded())
            {
                return PlayingStatus.STOP;
            }
            if (sf_player.Status == SoundStatus.Playing)
            {
                return PlayingStatus.PLAY;
            }
            else if (sf_player.Status == SoundStatus.Paused)
            {
                return PlayingStatus.PAUSE;
            }
            else if (sf_player.Status == SoundStatus.Stopped)
            {
                return PlayingStatus.STOP;
            }
            SetPlayingStatus(PlayingStatus.STOP);
            return PlayingStatus.STOP;
        }
    }
}
