using System;
using System.IO;
using SFML.Graphics;
using SFML.Window;
using Core;
using Core.UI;
using Core.UI.Controls;

namespace music_player_app.Music_Player
{
    class Main : App
    {
        private SimpleText FPS_TEXT;
        private SimpleSprite Main_Background;
        private SoundPlayer.SoundPlayer Audio;


        private TextButton test_button;

        public Main(string ConfigFileName, string WindowTitle) : base(ConfigFileName, WindowTitle)
        {
            FPS_TEXT = new SimpleText(default_font, Text.Styles.Regular, 14, new Color(255, 255, 255, 255), "FPS: ");
            FPS_TEXT.setPosition("left_top", "left_top");

            Main_Background = new SimpleSprite(Assets.Main_Background_Texture);
            Main_Background.setPosition("center_center", "center_center");

            Audio = new SoundPlayer.SoundPlayer();
            Audio.LoadSound(Path.Combine(Environment.CurrentDirectory, "data", "test_song.ogg"));


            test_button = new TextButton("left_center", "left_center", 20, 0, TestButtonAction);

        }


        protected override void Update()
        {
            if(setting_showFps)
            {
                FPS_TEXT.setText("FPS: " + getFPS() + " ------ " + getFrameTime() + " MS");
                window.Draw(FPS_TEXT.getDrawable());
            }

            //window.Draw(Main_Background.getDrawable());

            Audio.Update(window);

            test_button.DrawTo(window);
        }



        protected override void onKeyReleased(object sender, KeyEventArgs e)
        {
            if(e.Code == Keyboard.Key.Escape)
            {
                Exit();
            }
            if (e.Code == Keyboard.Key.A)
            {
                Audio.SetStatus(SoundPlayer.SoundPlayer.PlayingStatusType.PLAY);
            }
            if (e.Code == Keyboard.Key.S)
            {
                Audio.SetStatus(SoundPlayer.SoundPlayer.PlayingStatusType.PAUSE);
            }
            if (e.Code == Keyboard.Key.D)
            {
                Audio.SetStatus(SoundPlayer.SoundPlayer.PlayingStatusType.STOP);
            }
        }

        protected override void onMouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left)
            {
                if(test_button.IsSelected())
                {
                    test_button.ExecuteAction();
                }
            }
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
