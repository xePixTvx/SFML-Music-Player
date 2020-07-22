using PIX_UI;
using PIX_UI.Graphics;
using PIX_UI.Graphics.Primitives;
using PIX_UI.Assets;
using SFML.Window;

using music_app.GUI;

namespace music_app
{
    class MusicApp : App
    {
        private MainGUI Main_GUI;



        public MusicApp(string ResourceFolderName, string ConfigFileName, string WindowTitle, uint WindowWidth, uint WindowHeight) : base(ResourceFolderName, ConfigFileName, WindowTitle, WindowWidth, WindowHeight)
        {
            #region Load Assets

            //Textures
            AssetManager.Load(AssetType.Texture, "MAIN_BACKGROUND.jpg", "main_bg");
            AssetManager.Load(AssetType.Texture, "texture_button_play.png", "button_play");
            AssetManager.Load(AssetType.Texture, "texture_button_pause.png", "button_pause");
            AssetManager.Load(AssetType.Texture, "texture_button_stop.png", "button_stop");
            AssetManager.Load(AssetType.Texture, "texture_button_next.png", "button_next");
            AssetManager.Load(AssetType.Texture, "texture_button_previous.png", "button_previous");
            AssetManager.Load(AssetType.Texture, "texture_button_volume.png", "button_volume");
            AssetManager.Load(AssetType.Texture, "texture_minus.png", "minus");
            AssetManager.Load(AssetType.Texture, "texture_plus.png", "plus");
            AssetManager.Load(AssetType.Texture, "texture_button_songlist.png", "button_songlist");
            AssetManager.Load(AssetType.Texture, "texture_arrow_up.png", "arrow_up");
            AssetManager.Load(AssetType.Texture, "texture_arrow_down.png", "arrow_down");
            AssetManager.Load(AssetType.Texture, "texture_arrow_left.png", "arrow_left");
            AssetManager.Load(AssetType.Texture, "texture_arrow_right.png", "arrow_right");

            //Fonts
            AssetManager.Load(AssetType.Font, "Sans_Culottes_By_K-Type.ttf", "sansC");

            #endregion Load Assets

            //Main BG
            new SimpleSprite("Main_BG", Alignment.LEFT_TOP, 0, 0, "main_bg");
            GetElemByName("Main_BG").RenderLayer = 0;

            //Main Gui
            Main_GUI = new MainGUI();
        }

        protected override void AppUpdate()
        {
        }

        protected override void OnAppClosing()
        {
        }

        protected override void OnKeyReleased(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {
                Exit();
            }
        }
    }
}
