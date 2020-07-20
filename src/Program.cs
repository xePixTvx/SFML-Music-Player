using System;

namespace music_app
{
    class Program
    {
        private static MusicApp MA;
        static void Main(string[] args)
        {
            MA = new MusicApp("data", "config.ini", "P!X's Music Player", 1200, 553);
            MA.Start();
        }
    }
}
