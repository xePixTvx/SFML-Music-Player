/*
 *LAST WORKED ON:
 *                  Core.UI.Controls.Button + Core.UI.Interfaces.IClickableControl
 *                  Asset Loading
 */
namespace music_player_app
{
    class Program
    {
        private static Music_Player.Main player;
        static void Main(string[] args)
        {
            player = new Music_Player.Main("dev_config.ini", "--- Test Window Title ---");
            player.Start();
        }
    }
}
