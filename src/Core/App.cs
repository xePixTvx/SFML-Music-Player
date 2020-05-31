﻿using System;
using System.IO;
using Core.Config;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Core
{
    public abstract class App
    {
        /*[DllImport("kernel32.dll")]
        static extern bool FreeConsole();*/

        //Config/Setting
        public static ConfigFile Config;
        public static bool setting_ShowLogInConsole;
        public static UInt32 setting_window_width;
        public static UInt32 setting_window_height;
        public static Styles setting_window_style;
        public static bool setting_showFps;
        public static bool setting_backupLogFiles;

        //Logger
        public static Logger Log;

        //Window
        public RenderWindow window;
        public static VideoMode window_size { get; private set; }
        public bool isActive { get; private set; } = false;
        private Color window_background_color;

        //Frame Time/Rate
        private Clock frameTimeClock;
        private uint frameRateLimit = 60;
        private float frameTime;

        //App Update
        protected abstract void Update();

        //Default Assets
        public static Font default_font { get; private set; }
        public static Texture default_texture { get; private set; }

        protected App(string _ConfigFileName, string window_title)
        {
            //Config/Setting Stuff
            Config = new ConfigFile(_ConfigFileName);
            setting_ShowLogInConsole = (Config.getConfigSetting("MAIN", "ShowLogInConsole", "false") == "true") ? true : false;
            setting_window_width = Convert.ToUInt32(Config.getConfigSetting("MAIN", "window_width", "800"));
            setting_window_height = Convert.ToUInt32(Config.getConfigSetting("MAIN", "window_height", "600"));
            setting_showFps = (Config.getConfigSetting("MAIN", "showFps", "false") == "true") ? true : false;
            setting_window_style = Styles.Close;
            setting_backupLogFiles = (Config.getConfigSetting("MAIN", "backupLogFiles", "true") == "true") ? true : false;

            Log = new Logger(setting_ShowLogInConsole, setting_backupLogFiles);
            window_background_color = new Color(0, 0, 0);
            window_size = new VideoMode(setting_window_width, setting_window_height);
            InitWindow(window_title, setting_window_style);
            LoadDefaultAssets();
        }

        public void Start()
        {
            Log.Print("Start Main Loop");
            isActive = true;
            MainLoop();
            //FreeConsole();
        }
        public void Exit()
        {
            Log.Print("Exit App");
            Log.Print("---------- Music_Player EXIT ----------");
            isActive = false;
            Log.LoggerDispose();
            window.Close();
        }



        #region Init Window Stuff
        private void InitWindow(string title, Styles style)
        {
            Log.Print("Init Window");
            window = new RenderWindow(window_size, title, style);
            window.SetVerticalSyncEnabled(false);
            window.SetFramerateLimit(frameRateLimit);
            InitWindowEventHandlers();
        }

        private void InitWindowEventHandlers()
        {
            Log.Print("Init Event Handlers");
            window.Closed += (_, __) => Exit();
            window.LostFocus += (_, __) => Log.Print("Lost Focus");
            window.GainedFocus += (_, __) => Log.Print("Gained Focus");
            window.MouseButtonReleased += new EventHandler<MouseButtonEventArgs>(onMouseButtonReleased);
            window.MouseButtonPressed += new EventHandler<MouseButtonEventArgs>(onMouseButtonPressed);
            window.KeyReleased += new EventHandler<KeyEventArgs>(onKeyReleased);
            window.KeyPressed += new EventHandler<KeyEventArgs>(onKeyPressed);
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
            frameTimeClock = new Clock();
            while (isActive)
            {
                window.DispatchEvents();
                window.Clear(window_background_color);
                Update();
                window.Display();
                frameTime = frameTimeClock.Restart().AsMilliseconds();
            }
        }
        #endregion


        #region Frame Time/Rate
        public float getFrameTime()
        {
            return frameTime;
        }
        public uint getFPS()
        {
            uint fps = frameRateLimit * ((uint)frameTime * frameRateLimit) / 1000;
            return fps;
        }
        #endregion


        #region Default Assets
        private void LoadDefaultAssets()
        {
            //Default Font
            try
            {
                default_font = new Font(Path.Combine("data", "fonts", "default.ttf"));
                Log.Print("Default Font Loaded");
            }
            catch (Exception e)
            {
                Log.Print(e.Message, LoggerType.ERROR);
            }

            //Default Texture
            try
            {
                default_texture = new Texture(Path.Combine("data", "textures", "default.png"));
                default_texture.Repeated = true;
                Log.Print("Default Texture Loaded");
            }
            catch (Exception e)
            {
                Log.Print(e.Message, LoggerType.ERROR);
            }
        }
        #endregion

    }
}