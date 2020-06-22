using SFML.Graphics;
using System.Collections.Generic;
using Core.AssetTypes;

namespace Core
{
    public class AssetManager
    {
        List<FontAsset> FontList = new List<FontAsset>();
        List<TextureAsset> TextureList = new List<TextureAsset>();

        public enum AssetType
        {
            Font,
            Texture
        };

        public AssetManager()
        {
            FontList.Clear();
            TextureList.Clear();
        }

        public void Load(AssetType type, string file, string name)
        {
            if(type == AssetType.Font)
            {
                FontList.Add(new FontAsset(file, name));
            }
            else if(type == AssetType.Texture)
            {
                TextureList.Add(new TextureAsset(file, name));
            }
            else
            {
                Core.App.Log.Print("Tried to load a not supported AssetType!! --- Core.AssetManager.cs", LoggerType.ASSET);
            }
        }

        public Font GetFont(string name)
        {
            if(name == "default")
            {
                return Core.App.default_font;
            }
            foreach(FontAsset _font in FontList)
            {
                if(_font.Name == name)
                {
                    return _font.Font;
                }
            }
            return Core.App.default_font;
        }

        public Texture GetTexture(string name)
        {
            if (name == "default")
            {
                return Core.App.default_texture;
            }
            foreach (TextureAsset _texture in TextureList)
            {
                if (_texture.Name == name)
                {
                    return _texture.Texture;
                }
            }
            return Core.App.default_texture;
        }
    }
}
