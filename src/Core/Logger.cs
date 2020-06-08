using System;
using System.IO;

namespace Core
{
    public enum LoggerType
    {
        MAIN,
        ASSET,
        ERROR
    };

    public class Logger
    {
        private static StreamWriter Writer_Main;
        private static StreamWriter Writer_Error;
        private static StreamWriter Writer_Asset;
        private static bool UseConsole;
        private static bool backUpFullLogs;
        private static long MaxFileSize = 800000;

        public Logger(bool _UseConsole, bool _backUpFullLogs)
        {
            UseConsole = _UseConsole;
            backUpFullLogs = _backUpFullLogs;
            string LogDirectory = Path.Combine(Environment.CurrentDirectory, "Music_Player_LOGS");
            string LogBackupDirectory = Path.Combine(Environment.CurrentDirectory, "Music_Player_LOGS" , "BACKUPS");
            string MainLogFile = Path.Combine(LogDirectory, "main_log.txt");
            string ErrorLogFile = Path.Combine(LogDirectory, "error_log.txt");
            string AssetLogFile = Path.Combine(LogDirectory, "asset_log.txt");
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }
            if (!Directory.Exists(LogBackupDirectory))
            {
                Directory.CreateDirectory(LogBackupDirectory);
            }
            ClearLogFileIfNeeded(MainLogFile, LogBackupDirectory);
            ClearLogFileIfNeeded(ErrorLogFile, LogBackupDirectory);
            ClearLogFileIfNeeded(AssetLogFile, LogBackupDirectory);
            Writer_Main = new StreamWriter(MainLogFile, true);
            Writer_Error = new StreamWriter(ErrorLogFile, true);
            Writer_Asset = new StreamWriter(AssetLogFile, true);
            Print("---------- Music_Player INIT ----------");
        }

        public void LoggerDispose()
        {
            Writer_Main.Dispose();
            Writer_Error.Dispose();
            Writer_Asset.Dispose();
        }

        public void Print(string text, LoggerType TYPE = LoggerType.MAIN)
        {
            DateTime dateTime = DateTime.Now;
            if (TYPE == LoggerType.MAIN)
            {
                if (UseConsole)
                {
                    Console.WriteLine("Music_Player: " + text);
                }
                Writer_Main.WriteLine("[" + dateTime + "]Music_Player: " + text);
                Writer_Main.Flush();
            }
            else if(TYPE == LoggerType.ASSET)
            {
                if (UseConsole)
                {
                    Console.WriteLine("Music_Player ASSET: " + text);
                }
                Writer_Asset.WriteLine("[" + dateTime + "]Music_Player ASSET: " + text);
                Writer_Asset.Flush();
            }
            else
            {
                if (UseConsole)
                {
                    Console.WriteLine("Music_Player ERROR: " + text);
                }
                Writer_Error.WriteLine("[" + dateTime + "]Music_Player ERROR: " + text);
                Writer_Error.Flush();
            }
        }


        private void ClearLogFileIfNeeded(string file, string backUpDir)
        {
            if (File.Exists(file))
            {
                if (getFileSize(file) >= MaxFileSize)
                {
                    if (backUpFullLogs)
                    {
                        int directorySize = Directory.GetFiles(backUpDir).Length;
                        string backUpStartName = (file.Contains("main")) ? "main" : (file.Contains("error")) ? "error" : "asset";
                        File.Copy(file, Path.Combine(backUpDir, backUpStartName + "_BACKUP_" + directorySize + ".txt"));
                    }
                    File.Delete(file);
                    Console.WriteLine("Music_Player: Cleared Log File: " + file);
                }
            }
        }
        private long getFileSize(string filename)
        {
            FileInfo file = new FileInfo(filename);
            return file.Length;
        }


    }
}
