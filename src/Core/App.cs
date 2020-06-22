using System;
using System.IO;
using Core.Config;
using Core.UI;
using Core.UI.Primitives;
using Core.UI.Interfaces;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Core
{
    public abstract class App
    {
        //Resource Folder
        public static string ResourceFolder { get; private set; }
        public static string FontFolder = "fonts";
        public static string TextureFolder = "textures";

        //Config/Setting
        public static ConfigFile Config;
        public static bool Setting_ShowLogInConsole;
        public static UInt32 Setting_window_width;
        public static UInt32 Setting_window_height;
        public static Styles Setting_window_style;
        public static bool Setting_showFps;
        public static bool Setting_backupLogFiles;

        //FPS Text
        private SimpleText FPS_TEXT;

        //Logger
        public static Logger Log;

        //Asset Manager
        public static AssetManager AsManager;

        //Render System
        public static RenderSystem RenderSys;

        //Window
        public static RenderWindow Window { get; private set; }
        public static VideoMode WindowSize { get; private set; }
        public bool IsActive { get; private set; } = false;
        private Color WindowBackgroundColor;

        //Frame Time/Rate
        private Clock FrameTimeClock;
        private uint FrameRateLimit = 60;
        private float FrameTime;

        //App Update
        protected abstract void Update();

        //On App Close
        protected abstract void OnAppClosing();

        //Default Assets
        private bool DefaultAssetLoadFailed = false;
        public static Font DefaultFont { get; private set; }
        public static Texture DefaultTexture { get; private set; }

        protected App(string _ConfigFileName, string window_title, string ResourceFolderName)
        {
            ResourceFolder = Path.Combine(Environment.CurrentDirectory, ResourceFolderName);

            //Config/Setting Stuff
            Config = new ConfigFile(_ConfigFileName);
            Setting_ShowLogInConsole = (Config.GetConfigSetting("MAIN", "ShowLogInConsole", "false") == "true") ? true : false;
            Setting_window_width = Convert.ToUInt32(Config.GetConfigSetting("MAIN", "window_width", "800"));//lock it???
            Setting_window_height = Convert.ToUInt32(Config.GetConfigSetting("MAIN", "window_height", "600"));//lock it???
            Setting_showFps = (Config.GetConfigSetting("MAIN", "showFps", "false") == "true") ? true : false;
            Setting_window_style = Styles.Close;
            Setting_backupLogFiles = (Config.GetConfigSetting("MAIN", "backupLogFiles", "true") == "true") ? true : false;

            Log = new Logger(Setting_ShowLogInConsole, Setting_backupLogFiles);
            WindowBackgroundColor = new Color(0, 0, 0);
            WindowSize = new VideoMode(Setting_window_width, Setting_window_height);
            InitWindow(window_title, Setting_window_style);
            AsManager = new AssetManager();
            if (!LoadDefaultAssets())
            {
                Log.Print("DefaultAssetLoadFailed == true", LoggerType.ERROR);
                DefaultAssetLoadFailed = true;
            }

            RenderSys = new RenderSystem();

            //Create FPS Text
            FPS_TEXT = new SimpleText("default", Text.Styles.Regular, 14, new Color(255, 255, 255, 255), "FPS: ");
            FPS_TEXT.Origin_H_Align = Origin_Horizontal_Alignment.LEFT;
            FPS_TEXT.Origin_V_Align = Origin_Vertical_Alignment.TOP;
            Vector2f fps_main_pos = Utils.GetPosition(Position_Horizontal_Alignment.LEFT, Position_Vertical_Alignment.TOP);
            FPS_TEXT.Position = new Vector2f(fps_main_pos.X, fps_main_pos.Y);
            FPS_TEXT.RenderLayer = 999;//Render Last
            if (!Setting_showFps)
            {
                FPS_TEXT.IsActive = false;
            }
        }

        public void Start()
        {
            Log.Print("Start Main Loop");
            IsActive = true;
            MainLoop();
            //FreeConsole();
        }
        public void Exit()
        {
            OnAppClosing();
            Log.Print("Exit App");
            Log.Print("---------- Music_Player EXIT ----------");
            IsActive = false;
            Log.LoggerDispose();
            Window.Close();
        }



        #region Init Window Stuff
        private void InitWindow(string title, Styles style)
        {
            Log.Print("Init Window");
            Window = new RenderWindow(WindowSize, title, style);
            Window.SetVerticalSyncEnabled(false);
            Window.SetFramerateLimit(FrameRateLimit);
            InitWindowEventHandlers();
        }

        private void InitWindowEventHandlers()
        {
            Log.Print("Init Event Handlers");
            Window.Closed += (_, __) => Exit();
            Window.LostFocus += (_, __) => Log.Print("Lost Focus");
            Window.GainedFocus += (_, __) => Log.Print("Gained Focus");
            Window.MouseButtonReleased += new EventHandler<MouseButtonEventArgs>(onMouseButtonReleased_ClickableElems);
            Window.MouseButtonReleased += new EventHandler<MouseButtonEventArgs>(onMouseButtonReleased);
            Window.MouseButtonPressed += new EventHandler<MouseButtonEventArgs>(onMouseButtonPressed);
            Window.KeyReleased += new EventHandler<KeyEventArgs>(onKeyReleased);
            Window.KeyPressed += new EventHandler<KeyEventArgs>(onKeyPressed);
        }
        private void onMouseButtonReleased_ClickableElems(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left)
            {
                foreach (IRenderable elem in RenderSys.GetRenderList())
                {
                    if (elem.IsActive && elem is IClickable clickElem)
                    {
                        if (clickElem.IsSelected)
                        {
                            clickElem.ExecuteAction();
                        }
                    }
                }
            }
        }
        protected virtual void onMouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            //Log.Print("Mouse Button " + e.Button + " Released"); 
        }
        protected virtual void onMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            //Log.Print("Mouse Button " + e.Button + " Pressed"); 
        }
        protected virtual void onKeyReleased(object sender, KeyEventArgs e)
        {
            //Log.Print("Key " + e.Code + " Released"); 
        }
        protected virtual void onKeyPressed(object sender, KeyEventArgs e)
        {
            //Log.Print("Key " + e.Code + " Pressed"); 
        }
        #endregion


        #region Main Loop
        private void MainLoop()
        {
            FrameTimeClock = new Clock();
            while (IsActive)
            {
                Window.DispatchEvents();
                Window.Clear(WindowBackgroundColor);

                //Update FPS Text
                if (Setting_showFps && FPS_TEXT.IsActive)
                {
                    FPS_TEXT.String = "FPS: " + GetFPS() + " ------ " + GetFrameTime() + " MS";
                }

                Update();
                RenderSys.Render();
                Window.Display();
                FrameTime = FrameTimeClock.Restart().AsMilliseconds();
                if(DefaultAssetLoadFailed)
                {
                    Exit();
                }
            }
        }
        #endregion


        #region Frame Time/Rate
        public float GetFrameTime()
        {
            return FrameTime;
        }
        public uint GetFPS()
        {
            uint fps = FrameRateLimit * ((uint)FrameTime * FrameRateLimit) / 1000;
            return fps;
        }
        #endregion


        #region Default Assets
        private bool LoadDefaultAssets()
        {
            //Default Font
            try
            {
                DefaultFont = new Font(Path.Combine(ResourceFolder, FontFolder, "default.ttf"));
                Log.Print("Default Font Loaded");
            }
            catch (Exception e)
            {
                Log.Print(e.Message, LoggerType.ERROR);
                return false;
            }

            //Default Texture
            try
            {
                DefaultTexture = new Texture(Path.Combine(ResourceFolder, TextureFolder, "default.png"));
                DefaultTexture.Repeated = true;
                Log.Print("Default Texture Loaded");
            }
            catch (Exception e)
            {
                Log.Print(e.Message, LoggerType.ERROR);
                return false;
            }
            return true;
        }
        #endregion

    }
}
