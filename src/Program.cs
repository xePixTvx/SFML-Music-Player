/*
 *LAST WORKED ON:
 *                  Simple Line --- Change Vertex stuff doenst really work :(
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
