/*
 *CURRENTLY WORKING ON:
 *                      Core.UI.Controls
 *                      Core.UI overall SetSize stuff
 */
namespace music_player_app
{
    class Program
    {
        private static Music_Player.Main player;
        static void Main(string[] args)
        {
            player = new Music_Player.Main("dev_config.ini", "--- Test Window Title ---", "data");
            player.Start();
        }
    }
}
