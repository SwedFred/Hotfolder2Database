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
    public class FolderWatcher : IObservable<object>
    {
        SqliteConnection sqliteConnection;
        List<IObserver<object>> observers;
        FileSystemWatcher watcher;
        List<string> filters;

        public FolderWatcher()
        {
            observers = new List<IObserver<object>>();
            watcher = new FileSystemWatcher();
            filters = ConfigurationManager.AppSettings["AcceptedFileTypes"].Split(',').ToList();
            var db = ConfigurationManager.AppSettings["SelectedDatabase"];
            sqliteConnection = new SqliteConnection("Data Source = " + db + "; " + "Cache = Private");  //Creates a new database if given a name which doesn't already exist
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        void WatchFolder()
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

        private static void OnCreated(object source, FileSystemEventArgs eventArgs)
        {
            // TODO: Apply processing and move file
            var successDirectory = SettingsManager.GetHotfolder() + "/successful/";
            var failDirectory = SettingsManager.GetHotfolder() + "/failed/";
            var newfile = eventArgs.FullPath;
            string result;

            if (!Directory.Exists(successDirectory))
                Directory.CreateDirectory(successDirectory);
            if (!Directory.Exists(failDirectory))
                Directory.CreateDirectory(failDirectory);
            result = DatabaseManager.WriteEntry(newfile);
            if (result != null)
                File.Move(newfile, successDirectory + Path.GetFileName(newfile));
            else
                File.Move(newfile, failDirectory + Path.GetFileName(newfile));

        }

        public IDisposable Subscribe(IObserver<object> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }
    }
}
