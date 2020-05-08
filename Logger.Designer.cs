namespace Hotfolder2Database
{
    partial class Logger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "hej detta är en ganska lång text, men inte vansinnigt lång",
            "korv",
            "pizza",
            "superjättelång text som borde ta upp minst en hel rad och kanske lite till!"}, -1);
            this.lv_logwindow = new System.Windows.Forms.ListView();
            this.l_DatabaseName = new System.Windows.Forms.Label();
            this.b_ExitProgram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lv_logwindow
            // 
            this.lv_logwindow.FullRowSelect = true;
            this.lv_logwindow.HideSelection = false;
            listViewItem1.Checked = true;
            listViewItem1.StateImageIndex = 1;
            this.lv_logwindow.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lv_logwindow.Location = new System.Drawing.Point(12, 46);
            this.lv_logwindow.Name = "lv_logwindow";
            this.lv_logwindow.Size = new System.Drawing.Size(661, 304);
            this.lv_logwindow.TabIndex = 0;
            this.lv_logwindow.TileSize = new System.Drawing.Size(500, 36);
            this.lv_logwindow.UseCompatibleStateImageBehavior = false;
            this.lv_logwindow.View = System.Windows.Forms.View.Tile;
            this.lv_logwindow.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // l_DatabaseName
            // 
            this.l_DatabaseName.AutoSize = true;
            this.l_DatabaseName.Location = new System.Drawing.Point(13, 13);
            this.l_DatabaseName.Name = "l_DatabaseName";
            this.l_DatabaseName.Size = new System.Drawing.Size(46, 17);
            this.l_DatabaseName.TabIndex = 1;
            this.l_DatabaseName.Text = "label1";
            // 
            // b_ExitProgram
            // 
            this.b_ExitProgram.Location = new System.Drawing.Point(267, 375);
            this.b_ExitProgram.Name = "b_ExitProgram";
            this.b_ExitProgram.Size = new System.Drawing.Size(144, 54);
            this.b_ExitProgram.TabIndex = 2;
            this.b_ExitProgram.Text = "button1";
            this.b_ExitProgram.UseVisualStyleBackColor = true;
            // 
            // Logger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 459);
            this.Controls.Add(this.b_ExitProgram);
            this.Controls.Add(this.l_DatabaseName);
            this.Controls.Add(this.lv_logwindow);
            this.Name = "Logger";
            this.Text = "Logger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_logwindow;
        private System.Windows.Forms.Label l_DatabaseName;
        private System.Windows.Forms.Button b_ExitProgram;
    }
}