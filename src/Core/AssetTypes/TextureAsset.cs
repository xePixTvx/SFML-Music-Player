using SFML.Graphics;
using System;
using System.IO;

namespace Core.AssetTypes
{
    class TextureAsset
    {
        private string Name;
        public Texture texture;

        public TextureAsset(string file, string name)
        {
            Name = name;
            try
            {
                texture = new Texture(Path.Combine(Core.App.ResourceFolder, Core.App.TextureFolder, file));
                Core.App.Log.Print("Texture: " + file + " Loaded as: " + name, LoggerType.ASSET);
            }
            catch (Exception e)
            {
                Core.App.Log.Print("Failed to load Texture: " + file, LoggerType.ASSET);
                Core.App.Log.Print(e.ToString(), LoggerType.ASSET);
                texture = Core.App.default_texture;
            }
        }

        public string getName()
        {
            return Name;
        }

        public Texture getTexture()
        {
            return texture;
        }
    }
}
