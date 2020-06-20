/*
 *CURRENTLY WORKING ON:
 *                      Core.UI.Controls
 */
namespace music_player_app
{
    class Program
    {
        private static Music_App.Main player;
        static void Main(string[] args)
        {
            player = new Music_App.Main("dev_config.ini", "--- Test Window Title ---", "data");
            player.Start();
        }
    }
}
