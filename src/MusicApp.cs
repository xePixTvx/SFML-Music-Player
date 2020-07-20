using music_app.GUI;
using PIX_UI;
using PIX_UI.Graphics;
using PIX_UI.Graphics.Primitives;
using SFML.Window;

namespace music_app
{
    class MusicApp : App
    {
        private MainGUI Main_GUI;



        public MusicApp(string ResourceFolderName, string ConfigFileName, string WindowTitle, uint WindowWidth, uint WindowHeight) : base(ResourceFolderName, ConfigFileName, WindowTitle, WindowWidth, WindowHeight)
        {
            #region Load Assets

            //Textures
            AssetManager.Load(PIX_UI.Assets.AssetType.Texture, "MAIN_BACKGROUND.jpg", "main_bg");
            AssetManager.Load(PIX_UI.Assets.AssetType.Texture, "texture_button_play.png", "button_play");
            AssetManager.Load(PIX_UI.Assets.AssetType.Texture, "texture_button_pause.png", "button_pause");
            AssetManager.Load(PIX_UI.Assets.AssetType.Texture, "texture_button_stop.png", "button_stop");
            AssetManager.Load(PIX_UI.Assets.AssetType.Texture, "texture_button_next.png", "button_next");
            AssetManager.Load(PIX_UI.Assets.AssetType.Texture, "texture_button_previous.png", "button_previous");
            AssetManager.Load(PIX_UI.Assets.AssetType.Texture, "texture_button_volume.png", "button_volume");
            AssetManager.Load(PIX_UI.Assets.AssetType.Texture, "texture_minus.png", "minus");
            AssetManager.Load(PIX_UI.Assets.AssetType.Texture, "texture_plus.png", "plus");

            //Fonts
            AssetManager.Load(PIX_UI.Assets.AssetType.Font, "Sans_Culottes_By_K-Type.ttf", "sansC");

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
