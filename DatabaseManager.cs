using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
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
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = @"CREATE TABLE IF NOT EXISTS [ImageMetadata] (
                            [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            [Name] NVARCHAR(2048),
                            [Dimensions] VARCHAR(64),
                            [Depth] INTEGER,
                            [Size] INTEGER)";
                        connection.Open();
                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT * FROM [ImageMetadata]";
                        var reader = command.ExecuteReader();
                        Console.WriteLine(reader.ToString());
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("CreateDatabase method: " + ex.ToString());
            }
        }

        public static void ConnectToDatabase()
        {
            try
            {
                connection = new SqliteConnection("Data Source=" + SettingsManager.GetDatabasePath());
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ConnectToDatabaseMethod: " + ex.ToString());
            }

        }

        public static void Disconnect()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public static string WriteEntry(string filepath)
        {
            if (!File.Exists(filepath))
                return "";

            try
            {
                Image image = Image.FromFile(filepath);
                var file = File.OpenRead(filepath);
                var fileSizeInBytes = file.Length;
                file.Close();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [ImageMetadata] (Name, Dimensions, Depth, Size) VALUES (@FileName, @Resolution, @Format, @Size)";
                    command.Parameters.Add("@FileName", Microsoft.Data.Sqlite.SqliteType.Text).Value = Path.GetFileName(filepath);
                    command.Parameters.Add("@Resolution", SqliteType.Text).Value = image.Size.ToString();
                    command.Parameters.Add("@Format", SqliteType.Integer).Value = Image.GetPixelFormatSize(image.PixelFormat);
                    command.Parameters.Add("@Size", SqliteType.Integer).Value = fileSizeInBytes;

                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("WriteEntry method fail: " + ex.ToString());
            }

            DateTime now = DateTime.Now;
            string transactionData = now.DayOfWeek + " " + now.ToString("HH:mm:ss") + " " + Path.GetFileName(filepath);
            return transactionData;
        }
    }
}
