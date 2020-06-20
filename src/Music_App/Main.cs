using System;
using System.IO;
using SFML.Window;
using SFML.Graphics;
using Core;
using Core.UI;
using Core.UI.Primitives;
using SFML.System;
using music_player_app.Music_App.SoundPlayer;

namespace music_player_app.Music_App
{
    class Main : App
    {
        private const bool ShowDevCross = true;


        private SimpleText FPS_TEXT;

        private Line dev_cross_horizontal_line;
        private Line dev_cross_vertical_line;

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

            //FPS Text
            FPS_TEXT = new SimpleText("default", Text.Styles.Regular, 14, new Color(255, 255, 255, 255), "FPS: ");
            FPS_TEXT.SetOrigin(Origin_Horizontal_Alignment.LEFT, Origin_Vertical_Alignment.TOP);
            Vector2f fps_main_pos = Utils.GetPosition(Position_Horizontal_Alignment.LEFT, Position_Vertical_Alignment.TOP);
            FPS_TEXT.SetPosition(fps_main_pos.X, fps_main_pos.Y);
            FPS_TEXT.RenderLayer = 999;//Render Last

            //DEV Align/Positioning Cross Helper Thingy
            if (ShowDevCross)
            {
                Vector2f dev_cross_h_pos_start = Utils.GetPosition(Position_Horizontal_Alignment.LEFT, Position_Vertical_Alignment.CENTER);
                Vector2f dev_cross_h_pos_end = Utils.GetPosition(Position_Horizontal_Alignment.RIGHT, Position_Vertical_Alignment.CENTER);
                dev_cross_horizontal_line = new Line(dev_cross_h_pos_start, dev_cross_h_pos_end, new Color(255, 0, 0, 255), new Color(255, 0, 0, 255));
                dev_cross_horizontal_line.RenderLayer = 999;
                Vector2f dev_cross_v_pos_start = Utils.GetPosition(Position_Horizontal_Alignment.CENTER, Position_Vertical_Alignment.TOP);
                Vector2f dev_cross_v_pos_end = Utils.GetPosition(Position_Horizontal_Alignment.CENTER, Position_Vertical_Alignment.BOTTOM);
                dev_cross_vertical_line = new Line(dev_cross_v_pos_start, dev_cross_v_pos_end, new Color(255, 0, 0, 255), new Color(255, 0, 0, 255));
                dev_cross_vertical_line.RenderLayer = 999;
            }


            Audio_Player = new AudioPlayer();
            Audio_Player.LoadAudio(Path.Combine(Environment.CurrentDirectory, "data", "test_song.ogg"));//Testing

            Player_UI = new MainUI();
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
