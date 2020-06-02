using SFML.Graphics;
using System;
using System.IO;

namespace music_player_app.Music_Player
{
    class Assets
    {
        public static Texture Main_Background_Texture = new Texture(Path.Combine(Environment.CurrentDirectory, "data", "textures", "MAIN_BACKGROUND.jpg"));//Just a random testing picture atm
        public static Texture Button_Play_Texture = new Texture(Path.Combine(Environment.CurrentDirectory, "data", "textures", "texture_button_play.png"));//TEST
        public static Texture Button_Pause_Texture = new Texture(Path.Combine(Environment.CurrentDirectory, "data", "textures", "texture_button_pause.png"));//TEST
        public static Texture Button_Reload_Texture = new Texture(Path.Combine(Environment.CurrentDirectory, "data", "textures", "texture_button_reload.png"));//TEST
        public static Texture Button_Next_Texture = new Texture(Path.Combine(Environment.CurrentDirectory, "data", "textures", "texture_button_next.png"));//TEST
        public static Texture Button_Previous_Texture = new Texture(Path.Combine(Environment.CurrentDirectory, "data", "textures", "texture_button_previous.png"));//TEST
    }
}
