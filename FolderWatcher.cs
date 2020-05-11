using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;


namespace Hotfolder2Database
{
    /*
        Listens to the user-selected folder to see if any files has been passed into it.
        If a file is of a correct type then enter the information into our database
    */
    public class FolderWatcher
    {
        public static event Action<string> WrittenToDBEvent;
        public static FileSystemWatcher watcher = new FileSystemWatcher();

        public FolderWatcher()
        {
            var db = ConfigurationManager.AppSettings["SelectedDatabase"];
            var successDirectory = SettingsManager.GetHotfolder() + "/successful/";
            var failDirectory = SettingsManager.GetHotfolder() + "/failed/";
            if (!Directory.Exists(successDirectory))
                Directory.CreateDirectory(successDirectory);
            if (!Directory.Exists(failDirectory))
                Directory.CreateDirectory(failDirectory);
            DatabaseManager.ConnectToDatabase();
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void WatchFolder()
        {
                var path = ConfigurationManager.AppSettings["Hotfolder"];
                if (path != null && Directory.Exists(path))
                    watcher.Path = ConfigurationManager.AppSettings["Hotfolder"];
                else
                    throw new Exception("The program couldn't find the directory \"" + path + "\"");
            
                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
                watcher.Created += OnCreated;
                watcher.Renamed += OnCreated;
                watcher.IncludeSubdirectories = false;
                watcher.EnableRaisingEvents = true;
        }

        public void UnWatchFolder()
        {
            watcher.EnableRaisingEvents = false;
            watcher.Dispose();
        }

        private static void OnCreated(object source, FileSystemEventArgs eventArgs)
        {
            // TODO: Apply processing and move file
            var successDirectory = SettingsManager.GetHotfolder() + "/successful/";
            var failDirectory = SettingsManager.GetHotfolder() + "/failed/";
            var newfile = eventArgs.FullPath;
            var filters = ConfigurationManager.AppSettings["AcceptedFileTypes"].Split(',').ToList();

            foreach (var filter in filters)
            {
                if (Path.GetExtension(newfile).Remove(0,1) == filter)                                       //Filter out the leading dot in the extension name
                {
                    try
                    {
                        var result = DatabaseManager.WriteEntry(newfile);
                        if (!string.IsNullOrEmpty(result))
                            File.Copy(newfile, successDirectory + Path.GetFileName(newfile));
                        else
                            File.Copy(newfile, failDirectory + Path.GetFileName(newfile));
                        WrittenToDBEvent?.Invoke(result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("OnCreated method: " + ex.ToString());
                    }
                }
            }
        }


    }
}
