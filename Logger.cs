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
        delegate void UpdateLogCallback(string result);
        public Logger()
        {
            // TODO: Skapa database connection
            InitializeComponent();
            FolderWatcher.WrittenToDBEvent += OnWrittenToDBEvent;
            folderWatcher.WatchFolder();
        }

        private void OnWrittenToDBEvent(string result)
        {
            UpdateLog(result);
        }

        private void UpdateLog(string result)
        {
            if(lv_logwindow.InvokeRequired)
            {
                UpdateLogCallback callback = new UpdateLogCallback(UpdateLog);
                this.Invoke(callback, new object[] { result });
            } else
            {
                try
                {
                    if (lv_logwindow.Items.Count > 20)
                        lv_logwindow.Items.Remove(lv_logwindow.Items[0]);
                    lv_logwindow.Items.Add(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("UpdateLog method: " + ex.ToString());
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
