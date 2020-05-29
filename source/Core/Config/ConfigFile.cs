using System;
using System.IO;

namespace Core.Config
{
    public class ConfigFile
    {
        private static string FileName;
        private static IniFile Ini;

        public ConfigFile(string _fileName)
        {
            FileName = _fileName;
            string FileDirectory = Path.Combine(Environment.CurrentDirectory, "data", "config");
            if (!Directory.Exists(FileDirectory))
            {
                Directory.CreateDirectory(FileDirectory);
            }
            Ini = new IniFile(Path.Combine(FileDirectory, FileName));
        }

        public string getConfigSetting(string section, string key, string default_value)
        {
            string setting = Ini.IniReadValue(section, key);
            if (setting == "")
            {
                setting = default_value;
                setConfigSetting(section, key, default_value);
            }
            return setting;
        }
        public void setConfigSetting(string section, string key, string value)
        {
            Ini.IniWriteValue(section, key, value);
        }
    }
}
