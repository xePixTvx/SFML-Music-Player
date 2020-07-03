/*
 *CURRENTLY WORKING ON:
 *                      
 *                      
 *                      
 *                      
 *                      
 *                      
 *                      Sans Culottes Font: http://www.myfont.de/fonts/infos/4908-Sans-Culottes.html
 *                      Main Background Image: https://www.pixiv.net/en/users/3468048
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
