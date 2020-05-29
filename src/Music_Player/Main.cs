using SFML.Graphics;
using SFML.Window;
using SFML.System;
using Core;
using Core.UI;

namespace music_player_app.Music_Player
{
    class Main : App
    {
        private SimpleText FPS_TEXT;

        private SimpleRect rect;
        private SimpleText text;
        private SimpleSprite sprite;
        private SimpleCircle circle;
        private SimpleTriangle triangle;
        private SimpleLine line;

        public Main(string ConfigFileName, string WindowTitle) : base(ConfigFileName, WindowTitle)
        {
            FPS_TEXT = new SimpleText(default_font, Text.Styles.Regular, 14, new Color(255, 255, 255, 255), "FPS: ");
            FPS_TEXT.setOrigin("left", "top");
            FPS_TEXT.setPosition("left", "top", 0, 0);

            rect = new SimpleRect(200, 200, new Color(255, 0, 0, 255));
            rect.setOrigin("center", "center");
            rect.setPosition("center", "center", 0, 0);

            text = new SimpleText(default_font, Text.Styles.Regular, 14, new Color(255, 255, 255, 255), "Hello World!\nHello World Line 2");
            text.setOrigin("center", "center");
            text.setPosition("center", "center", 0, 0);

            sprite = new SimpleSprite(default_texture);
            sprite.setOrigin("left", "bottom");
            sprite.setPosition("left", "bottom");

            circle = new SimpleCircle(60, new Color(0, 255, 0, 255));
            circle.setOrigin("right", "bottom");
            circle.setPosition("right", "bottom", -20, -20);

            triangle = new SimpleTriangle(60, 0, new Color(0, 255, 0, 255));
            triangle.setOrigin("right", "top");
            triangle.setPosition("right", "top", -20, 20);

            line = new SimpleLine(new Vector2f(20, 200), new Vector2f(400, 20), new Color(255, 0, 0, 255), new Color(0, 0, 255, 255));
        }


        protected override void Update()
        {
            if(setting_showFps)
            {
                FPS_TEXT.setText("FPS: " + getFPS() + " ------ " + getFrameTime() + " MS");
                window.Draw(FPS_TEXT.getDrawable());
            }
            window.Draw(rect.getDrawable());
            window.Draw(text.getDrawable());
            window.Draw(sprite.getDrawable());
            window.Draw(circle.getDrawable());
            window.Draw(triangle.getDrawable());
            window.Draw(line.getDrawable());
        }


        protected override void onKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.F)
            {
                Log.Print("F Pressed");
            }
        }

        protected override void onKeyReleased(object sender, KeyEventArgs e)
        {
            if(e.Code == Keyboard.Key.Escape)
            {
                Exit();
            }
        }

        protected override void onMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if(e.Button == Mouse.Button.Left)
            {
                Log.Print("LEFT Mouse Button Pressed");
            }
        }

        protected override void onMouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left)
            {
                Log.Print("LEFT Mouse Button Released");
            }
        }

    }
}
