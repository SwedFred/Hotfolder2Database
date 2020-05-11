using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotfolder2Database
{
    static class SettingsManager
    {
        // Setters
        public static void SetHotfolder(string value)
        {
            if (Directory.Exists(value))
            {
                ConfigurationManager.AppSettings["Hotfolder"] = value;
                SetDefaultHotfolderPath(Path.GetDirectoryName(value));
            }
        }

        public static void SetDatabase(string value)
        {
            if (File.Exists(value))
            {
                ConfigurationManager.AppSettings["SelectedDatabase"] = value;
                SetDefaultDatabasePath(Path.GetDirectoryName(value));
            }
        }
        private static void SetDefaultHotfolderPath(string value)
        {
            ConfigurationManager.AppSettings["DefaultHotfolderPath"] = value;
        }

        private static void SetDefaultDatabasePath(string value)
        {
            ConfigurationManager.AppSettings["DefaultDatabasePath"] = value;
        }

        public static bool AddFileType(string value)
        {
            bool wasSuccessful = false;
            try
            {
                var fileTypeList = ConfigurationManager.AppSettings["AcceptedFileTypes"].Split(',').ToList();
                if (!fileTypeList.Contains(value.ToLower()))
                {
                    if (fileTypeList.Count <= 1 && fileTypeList[0] == "")
                        ConfigurationManager.AppSettings["AcceptedFileTypes"] += value.ToLower();
                    else
                        ConfigurationManager.AppSettings["AcceptedFileTypes"] += ("," + value.ToLower());

                    wasSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return wasSuccessful;
        }

        public static bool RemoveFileType(string value)
        {
            bool wasSuccessful = false;

            try
            {
                var fileTypeList = ConfigurationManager.AppSettings["AcceptedFileTypes"].Split(',').ToList();
                if (fileTypeList.Contains(value.ToLower()))
                {
                    if (fileTypeList.Count == 1)
                        ConfigurationManager.AppSettings["AcceptedFileTypes"] = ConfigurationManager.AppSettings["AcceptedFileTypes"].Replace(value.ToLower(), "");
                    else
                        ConfigurationManager.AppSettings["AcceptedFileTypes"] = ConfigurationManager.AppSettings["AcceptedFileTypes"].Replace("," + value.ToLower(), "");

                    wasSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                // TODO: Debugger
                Console.WriteLine(ex.ToString());
            }


            return wasSuccessful;
        }

        // Getters
        public static List<string> GetAcceptedFileTypes()
        {
            return ConfigurationManager.AppSettings["AcceptedFileTypes"].Split(',').ToList();
        }

        public static string GetDatabasePath()
        {
            return ConfigurationManager.AppSettings["SelectedDatabase"];
        }

        public static string GetHotfolder()
        {
            return ConfigurationManager.AppSettings["Hotfolder"];
        }

        public static string GetDefaultHotfolderPath()
        {
            return ConfigurationManager.AppSettings["DefaultHotfolderPath"];
        }

        public static string GetDefaultDatabasePath()
        {
            return ConfigurationManager.AppSettings["DefaultDatabasePath"];
        }
    }
}
