using System;
using System.IO;
using SFML.Window;
using Core;
using Core.UI.Primitives;
using music_player_app.Music_App.SoundPlayer;
using Core.UI.Controls;

using SFML.System;
using SFML.Graphics;
using Core.UI;

namespace music_player_app.Music_App
{
    class Main : App
    {
        private SimpleSprite MainBg;
        public static AudioPlayer Audio_Player;

        private TextButton tButton;

        public Main(string ConfigFileName, string WindowTitle, string ResourceFolderName) : base(ConfigFileName, WindowTitle, ResourceFolderName)
        {
            #region Load Assets
            //Textures
            AsManager.Load(AssetManager.AssetType.Texture, "MAIN_BACKGROUND.jpg", "main_bg");
            AsManager.Load(AssetManager.AssetType.Texture, "texture_button_play.png", "button_play");
            AsManager.Load(AssetManager.AssetType.Texture, "texture_button_pause.png", "button_pause");
            AsManager.Load(AssetManager.AssetType.Texture, "texture_button_stop.png", "button_stop");
            AsManager.Load(AssetManager.AssetType.Texture, "texture_button_next.png", "button_next");
            AsManager.Load(AssetManager.AssetType.Texture, "texture_button_previous.png", "button_previous");
            AsManager.Load(AssetManager.AssetType.Texture, "texture_button_volume.png", "button_volume");
            AsManager.Load(AssetManager.AssetType.Texture, "texture_minus.png", "minus");
            AsManager.Load(AssetManager.AssetType.Texture, "texture_plus.png", "plus");

            //Fonts
            AsManager.Load(AssetManager.AssetType.Font, "Sans_Culottes_By_K-Type.ttf", "sansC");
            #endregion Load Assets

            //Main Background
            MainBg = new SimpleSprite("main_bg");

            //Audio Player
            Audio_Player = new AudioPlayer();
            Audio_Player.LoadAudio(Path.Combine(Environment.CurrentDirectory, "data", "test_song.ogg"));//Testing


            tButton = new TextButton(400, 50, new Color(255, 0, 0, 255), "default", Text.Styles.Regular, 16, new Color(255, 255, 255, 255), "Test Button YAY!");
            tButton.Origin_H_Align = Horizontal_Alignment.CENTER;
            tButton.Origin_V_Align = Vertical_Alignment.CENTER;
            Vector2f test_pos = Utils.GetPosition(Horizontal_Alignment.CENTER, Vertical_Alignment.CENTER);
            tButton.Position = test_pos;
        }


        protected override void Update()
        {
            Audio_Player.Update();
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
