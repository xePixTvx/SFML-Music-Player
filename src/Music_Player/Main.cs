using System;
using System.IO;
using SFML.Window;
using SFML.Graphics;
using Core;
using Core.UI.Primitives;

namespace music_player_app.Music_Player
{
    class Main : App
    {
        private Rect TestRect;

        public Main(string ConfigFileName, string WindowTitle) : base(ConfigFileName, WindowTitle)
        {
            //Load Assets
            AsManager.Load(AssetManager.AssetType.Texture, Path.Combine(Environment.CurrentDirectory, "data", "textures", "MAIN_BACKGROUND.jpg"), "main_bg");
            AsManager.Load(AssetManager.AssetType.Texture, Path.Combine(Environment.CurrentDirectory, "data", "textures", "texture_button_play.png"), "button_play");
            AsManager.Load(AssetManager.AssetType.Texture, Path.Combine(Environment.CurrentDirectory, "data", "textures", "texture_button_pause.png"), "button_pause");
            AsManager.Load(AssetManager.AssetType.Texture, Path.Combine(Environment.CurrentDirectory, "data", "textures", "texture_button_reload.png"), "button_reload");
            AsManager.Load(AssetManager.AssetType.Texture, Path.Combine(Environment.CurrentDirectory, "data", "textures", "texture_button_next.png"), "button_next");
            AsManager.Load(AssetManager.AssetType.Texture, Path.Combine(Environment.CurrentDirectory, "data", "textures", "texture_button_previous.png"), "button_previous");



            //FPS_TEXT = new SimpleText("default", Text.Styles.Regular, 14, new Color(255, 255, 255, 255), "FPS: ");
            //FPS_TEXT.setPosition("left_top", "left_top");



            TestRect = new Rect(200, 40, new Color(255, 0, 0, 255));


        }


        protected override void Update()
        {
            /*if(setting_showFps)
            {
                FPS_TEXT.setText("FPS: " + getFPS() + " ------ " + getFrameTime() + " MS");
                FPS_TEXT.Render();
            }*/

            TestRect.Render();
        }



        protected override void onKeyReleased(object sender, KeyEventArgs e)
        {
            if(e.Code == Keyboard.Key.Escape)
            {
                Exit();
            }
            if (e.Code == Keyboard.Key.A)
            {
                //Log.Print("TEST: " + TestRect.IsActive.ToString());
                //Audio.SetStatus(SoundPlayer.SoundPlayer.PlayingStatusType.PLAY);
            }
        }

        protected override void onMouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
        }

        private void TestButtonAction()
        {
            Exit();
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
