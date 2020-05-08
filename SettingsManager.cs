using System;
using System.Collections.Generic;
using System.Configuration;
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
            ConfigurationManager.AppSettings["Hotfolder"] = value;
        }

        public static void SetDatabase(string value)
        {
            ConfigurationManager.AppSettings["SelectedDatabase"] = value;
        }

        public static bool AddFileType(string value)
        {
            bool wasSuccessful = false;
            try
            {
                var fileTypeList = ConfigurationManager.AppSettings["AcceptedFileTypes"].Split(',').ToList();
                if (!fileTypeList.Contains(value.ToLower()))
                {
                    if (fileTypeList.Count == 0)
                        ConfigurationManager.AppSettings["AcceptedFileTypes"] += value.ToLower();
                    else
                        ConfigurationManager.AppSettings["AcceptedFileTypes"] += ("," + value.ToLower());

                    wasSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                // TODO: Debugger
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
    }
}
