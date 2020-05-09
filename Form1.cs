using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotfolder2Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PreloadUIValues();
        }

        private void b_Start_Click(object sender, EventArgs e)
        {
            Logger logForm = new Logger();
            this.Hide();
            logForm.ShowDialog();
            this.Close();
        }

        private void b_databaseSearch_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Select a database (*.db) file";
                dialog.Filter = "Database files (*.db)|*.db";
                dialog.InitialDirectory = SettingsManager.GetDefaultDatabasePath();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SettingsManager.SetDatabase(dialog.FileName);
                    l_DatabasePath.Text = SettingsManager.GetDatabasePath();
                    tb_DatabasePath.Text = SettingsManager.GetDatabasePath();
                    tb_DatabasePath.ForeColor = Color.Black;
                    CheckStartConditions();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void b_openFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.ShowNewFolderButton = true;
                dialog.Description = "Select a folder to monitor";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SettingsManager.SetHotfolder(dialog.SelectedPath);
                    tb_hotfolderPath.Text = SettingsManager.GetHotfolder();
                    tb_hotfolderPath.ForeColor = Color.Black;
                    CheckStartConditions();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void b_addDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "Create a new database file";
                dialog.Filter = "Database files (*.db)|*.db";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SettingsManager.SetDatabase(dialog.FileName);
                    File.Create(dialog.FileName);
                    // TODO: Create actual file
                    // TODO: Set up database

                    CheckStartConditions();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void lv_ValidTypes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
                SettingsManager.AddFileType(e.Item.Text.ToLower());
            else
                SettingsManager.RemoveFileType(e.Item.Text.ToLower());

            CheckStartConditions();
        }

        private void PreloadUIValues()
        {
            // Fill in checkboxes
            foreach (var item in SettingsManager.GetAcceptedFileTypes())
            {
                if (lv_ValidTypes.Items.ContainsKey(item))
                    lv_ValidTypes.Items[item].Checked = true;
            }

            // Fill in databasepath
            var dataBasePath = SettingsManager.GetDatabasePath();
            if (String.IsNullOrEmpty(dataBasePath))
                tb_DatabasePath.Text = dataBasePath;
            
            // Check if we are ready to start
            CheckStartConditions();
        }

        private void CheckStartConditions()
        {
            bool hasAcceptedFileTypes = SettingsManager.GetAcceptedFileTypes() != null && !SettingsManager.GetAcceptedFileTypes()[0].Equals("");
            bool hasSelectedDatabase = (!string.IsNullOrEmpty(SettingsManager.GetDatabasePath()) && File.Exists(SettingsManager.GetDatabasePath()));
            bool hasSelectedHotfolder = (!string.IsNullOrEmpty(SettingsManager.GetHotfolder()) && Directory.Exists(SettingsManager.GetHotfolder()));
            if (hasAcceptedFileTypes)
            {
                l_imageStatus.ForeColor = Color.Black;
                l_imageStatus.Text = "Image type(s) selected";
            }
            else
            {
                l_imageStatus.ForeColor = Color.Red;
                l_imageStatus.Text = "No image type(s) seleced";
            }

            if (hasSelectedDatabase)
            {
                l_databaseStatus.ForeColor = Color.Black;
                l_databaseStatus.Text = "Database selected";
            }
            else
            {
                l_databaseStatus.ForeColor = Color.Red;
                l_databaseStatus.Text = "Database not selected";
            }

            if (hasSelectedHotfolder)
            {
                l_hotfolderStatus.ForeColor = Color.Black;
                l_hotfolderStatus.Text = "Hotfolder selected";
            }
            else
            {
                l_hotfolderStatus.ForeColor = Color.Red;
                l_hotfolderStatus.Text = "Hotfolder not selected";
            }

            if (hasSelectedDatabase && hasAcceptedFileTypes && hasSelectedHotfolder)
            {
                b_Start.Enabled = true;
                b_Start.BackColor = Color.Green;
                b_Start.ForeColor = Color.Black;
            } else
            {
                b_Start.Enabled = false;
                b_Start.BackColor = Color.LightGray;
                b_Start.ForeColor = Color.DarkGray;
            }
        }
    }
}
