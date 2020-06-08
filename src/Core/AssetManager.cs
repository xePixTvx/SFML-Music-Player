using SFML.Graphics;
using System.Collections.Generic;
using Core.AssetTypes;

namespace Core
{
    public class AssetManager
    {
        List<FontAsset> FontList = new List<FontAsset>();
        List<TextureAsset> TextureList = new List<TextureAsset>();


        public AssetManager()
        {
            FontList.Clear();
            TextureList.Clear();
        }


        public enum AssetType
        {
            Font,
            Texture
        };

        public void Load(AssetType type, string filePath, string name)
        {
            if(type == AssetType.Font)
            {
                FontList.Add(new FontAsset(filePath, name));
            }
            else if(type == AssetType.Texture)
            {
                TextureList.Add(new TextureAsset(filePath, name));
            }
            else
            {
                Core.App.Log.Print("Tried to load a not supported AssetType!! --- Core.AssetManager.cs", LoggerType.ASSET);
            }
        }

        public Font getFont(string name)
        {
            if(name == "default")
            {
                return Core.App.default_font;
            }
            foreach(FontAsset _font in FontList)
            {
                if(_font.getName() == name)
                {
                    return _font.font;
                }
            }
            return Core.App.default_font;
        }

        public Texture getTexture(string name)
        {
            if (name == "default")
            {
                return Core.App.default_texture;
            }
            foreach (TextureAsset _texture in TextureList)
            {
                if (_texture.getName() == name)
                {
                    return _texture.texture;
                }
            }
            return Core.App.default_texture;
        }
    }
}
