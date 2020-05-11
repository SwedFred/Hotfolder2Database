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
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
