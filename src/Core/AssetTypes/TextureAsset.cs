using SFML.Graphics;
using System;

namespace Core.AssetTypes
{
    class TextureAsset
    {
        private string Name;
        public Texture texture;

        public TextureAsset(string path, string name)
        {
            Name = name;
            try
            {
                texture = new Texture(path);
                Core.App.Log.Print("Texture: " + path + " Loaded as: " + name);
            }
            catch (Exception e)
            {
                Core.App.Log.Print("Failed to load Texture: " + path, LoggerType.ERROR);
                Core.App.Log.Print(e.ToString(), LoggerType.ERROR);
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
