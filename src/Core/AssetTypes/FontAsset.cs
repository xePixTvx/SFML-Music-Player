using SFML.Graphics;
using System;
using System.IO;

namespace Core.AssetTypes
{
    class FontAsset
    {
        private string Name;
        public Font font;

        public FontAsset(string file, string name)
        {
            Name = name;
            try
            {
                font = new Font(Path.Combine(Core.App.ResourceFolder, Core.App.FontFolder, file));
                Core.App.Log.Print("Font: " + file + " Loaded as: " + name, LoggerType.ASSET);
            }
            catch (Exception e)
            {
                Core.App.Log.Print("Failed to load Font: " + file, LoggerType.ASSET);
                Core.App.Log.Print(e.ToString(), LoggerType.ASSET);
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
