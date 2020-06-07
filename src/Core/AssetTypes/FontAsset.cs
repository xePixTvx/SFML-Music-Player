using SFML.Graphics;
using System;

namespace Core.AssetTypes
{
    class FontAsset
    {
        private string Name;
        public Font font;

        public FontAsset(string path, string name)
        {
            Name = name;
            try
            {
                font = new Font(path);
                Core.App.Log.Print("Font: " + path + " Loaded as: " + name);
            }
            catch (Exception e)
            {
                Core.App.Log.Print("Failed to load Font: " + path, LoggerType.ERROR);
                Core.App.Log.Print(e.ToString(), LoggerType.ERROR);
                font = Core.App.default_font;
            }
        }

        public string getName()
        {
            return Name;
        }

        public Font getFont()
        {
            return font;
        }
    }
}
