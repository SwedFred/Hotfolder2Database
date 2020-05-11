using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotfolder2Database
{
    public partial class Logger : Form
    {
        FolderWatcher folderWatcher = new FolderWatcher();
        public Logger()
        {
            // TODO: Skapa database connection
            InitializeComponent();
            FolderWatcher.WrittenToDBEvent += OnWrittenToDBEvent;
            folderWatcher.WatchFolder();
        }

        private void OnWrittenToDBEvent(string result)
        {
            try
            {
                if (lv_logwindow.Items.Count > 20)
                    lv_logwindow.Items.Remove(lv_logwindow.Items[0]);
                lv_logwindow.Items.Add(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
