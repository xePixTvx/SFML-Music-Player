using SFML.Audio;

namespace music_player_app.Music_App.SoundPlayer
{
    class AudioPlayer
    {
        //SFML Sound
        public Sound sf_sound;

        //SFML SoundBuffer
        private SoundBuffer sf_buffer;

        //UI
        private MainUI UI;

        public AudioPlayer()
        {
            sf_sound = new Sound();
            sf_sound.Volume = 30;

            UI = new MainUI(sf_sound, sf_sound.Volume);
        }

        public void LoadAudio(string file)
        {
            sf_buffer = new SoundBuffer(file);
            sf_sound.SoundBuffer = sf_buffer;
            UI.UpdateSongName(file);/////////////////////////////////UPDATE THIS
        }

        public void Update()
        {
            if (sf_sound.Status == SoundStatus.Playing)
            {
                UI.UpdatePlayingTime(sf_sound);
            }
        }
    }
}
