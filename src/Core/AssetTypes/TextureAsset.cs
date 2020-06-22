using SFML.Graphics;
using System;
using System.IO;

namespace Core.AssetTypes
{
    class TextureAsset
    {
        public string Name;
        public Texture Texture;

        public TextureAsset(string file, string name)
        {
            Name = name;
            try
            {
                Texture = new Texture(Path.Combine(Core.App.ResourceFolder, Core.App.TextureFolder, file));
                Core.App.Log.Print("Texture: " + file + " Loaded as: " + name, LoggerType.ASSET);
            }
            catch (Exception e)
            {
                Core.App.Log.Print("Failed to load Texture: " + file, LoggerType.ASSET);
                Core.App.Log.Print(e.ToString(), LoggerType.ASSET);
                Texture = Core.App.DefaultTexture;
            }
        }
    }
}
