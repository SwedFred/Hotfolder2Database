using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotfolder2Database
{
    static class DatabaseManager
    {
        private static SqliteConnection connection;
        public static void CreateDatabase(string fileAndPath)
        {
            try
            {
                var file = File.Create(fileAndPath);
                file.Close();
                SettingsManager.SetDatabase(fileAndPath);
                using (connection = new SqliteConnection("Data Source=" + fileAndPath))
                {
                    string commandText = @"CREATE TABLE IF NOT EXISTS [ImageMetadata] (
                                    [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                    [Name] NVARCHAR(2048),
                                    [Dimensions] VARCHAR(64),
                                    [Depth] INTEGER,
                                    [Size] INTEGER)";
                    using (var command = new SqliteCommand(commandText, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void ConnectToDatabase(string fileAndPath)
        {
            try
            {
                connection = new SqliteConnection("Data Source=" + SettingsManager.GetDatabasePath());
                connection.Open();
            }
            catch (Exception ex)
            {

            }

        }

        public static void Disconnect()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public static string WriteEntry(string filepath)
        {
            try
            {
                //Name, Dimensions, Depth, Size
                Image image = Image.FromFile(filepath);
                string insertCommand = @"INSERT INTO [ImageMetadata] 
                                    (Name, Dimensions, Depth, Size) VALUES
                                    (" + Path.GetFileName(filepath) + ", \""
                                        + image.PhysicalDimension.ToString() + "\","
                                        + Image.GetPixelFormatSize(image.PixelFormat) + ")";
                using (var command = new SqliteCommand(insertCommand, connection))
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            DateTime now = DateTime.Now;
            string transactionData = now.ToString("dd HH:mm:ss") + " " + Path.GetFileName(filepath);
            return transactionData;
        }

        
    }
}
