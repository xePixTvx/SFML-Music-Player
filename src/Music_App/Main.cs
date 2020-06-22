using System;
using System.IO;
using SFML.Window;
using Core;
using music_player_app.Music_App.SoundPlayer;

namespace music_player_app.Music_App
{
    class Main : App
    {
        private bool ShowDevCross = true;
        private Core.Debug.DebugCross DevCross;

        public static AudioPlayer Audio_Player;
        private MainUI Player_UI;

        public Main(string ConfigFileName, string WindowTitle, string ResourceFolderName) : base(ConfigFileName, WindowTitle, ResourceFolderName)
        {
            //Load Assets
            AsManager.Load(AssetManager.AssetType.Texture, "MAIN_BACKGROUND.jpg", "main_bg");
            AsManager.Load(AssetManager.AssetType.Texture, "texture_button_play.png", "button_play");
            AsManager.Load(AssetManager.AssetType.Texture, "texture_button_pause.png", "button_pause");
            AsManager.Load(AssetManager.AssetType.Texture, "texture_button_stop.png", "button_stop");
            AsManager.Load(AssetManager.AssetType.Texture, "texture_button_next.png", "button_next");
            AsManager.Load(AssetManager.AssetType.Texture, "texture_button_previous.png", "button_previous");
            AsManager.Load(AssetManager.AssetType.Texture, "texture_button_volume.png", "button_volume");
            AsManager.Load(AssetManager.AssetType.Texture, "texture_minus.png", "minus");
            AsManager.Load(AssetManager.AssetType.Texture, "texture_plus.png", "plus");

            //DEV Align/Positioning Cross Helper Thingy
            if (ShowDevCross)
            {
                DevCross = new Core.Debug.DebugCross();
            }


            Audio_Player = new AudioPlayer();
            Audio_Player.LoadAudio(Path.Combine(Environment.CurrentDirectory, "data", "test_song.ogg"));//Testing

            Player_UI = new MainUI();
        }


        protected override void Update()
        {
        }

        protected override void OnAppClosing()
        {
        }



        protected override void onKeyReleased(object sender, KeyEventArgs e)
        {
            if(e.Code == Keyboard.Key.Escape)
            {
                Exit();
            }
            if (e.Code == Keyboard.Key.A)
            {
            }
        }


        /* TEST FFT using MathNet.Numerics(for Fourier Forward) + System.Numerics(for Complex data)
        private static double[] FFT(double[] data)
        {
            double[] fft = new double[data.Length];
            Complex[] fftComplex = new Complex[data.Length];

            for (int i = 0; i < data.Length; i++)
                fftComplex[i] = new Complex(data[i], 0.0);

            Fourier.Forward(fftComplex);

            for (int i = 0; i < data.Length; i++)
                fft[i] = Math.Log10(fftComplex[i].Magnitude);

            return fft;
        }
        */

    }
}
