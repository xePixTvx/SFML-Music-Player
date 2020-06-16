using System;
using System.IO;
using SFML.Window;
using SFML.Graphics;
using Core;
using Core.UI;
using Core.UI.Primitives;
using SFML.System;

namespace music_player_app.Music_Player
{
    class Main : App
    {
        private SimpleText FPS_TEXT;

        public Main(string ConfigFileName, string WindowTitle) : base(ConfigFileName, WindowTitle)
        {
            //Load Assets
            AsManager.Load(AssetManager.AssetType.Texture, Path.Combine(Environment.CurrentDirectory, "data", "textures", "MAIN_BACKGROUND.jpg"), "main_bg");
            AsManager.Load(AssetManager.AssetType.Texture, Path.Combine(Environment.CurrentDirectory, "data", "textures", "texture_button_play.png"), "button_play");
            AsManager.Load(AssetManager.AssetType.Texture, Path.Combine(Environment.CurrentDirectory, "data", "textures", "texture_button_pause.png"), "button_pause");
            AsManager.Load(AssetManager.AssetType.Texture, Path.Combine(Environment.CurrentDirectory, "data", "textures", "texture_button_reload.png"), "button_reload");
            AsManager.Load(AssetManager.AssetType.Texture, Path.Combine(Environment.CurrentDirectory, "data", "textures", "texture_button_next.png"), "button_next");
            AsManager.Load(AssetManager.AssetType.Texture, Path.Combine(Environment.CurrentDirectory, "data", "textures", "texture_button_previous.png"), "button_previous");

            //FPS Text
            FPS_TEXT = new SimpleText("default", Text.Styles.Regular, 14, new Color(255, 255, 255, 255), "FPS: ");
            FPS_TEXT.SetOrigin(Origin_Horizontal_Alignment.LEFT, Origin_Vertical_Alignment.TOP);
            Vector2f fps_main_pos = Utils.GetPosition(Position_Horizontal_Alignment.LEFT, Position_Vertical_Alignment.TOP);
            FPS_TEXT.SetPosition(fps_main_pos.X, fps_main_pos.Y);
            FPS_TEXT.RenderLayer = 999;//Render Last
        }


        protected override void Update()
        {
            if (setting_showFps)
            {
                FPS_TEXT.SetText("FPS: " + getFPS() + " ------ " + getFrameTime() + " MS");
            }
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
