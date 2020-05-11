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
            this.lv_logwindow = new System.Windows.Forms.ListView();
            this.l_DatabaseName = new System.Windows.Forms.Label();
            this.b_ExitProgram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lv_logwindow
            // 
            this.lv_logwindow.FullRowSelect = true;
            this.lv_logwindow.HideSelection = false;
            this.lv_logwindow.LabelWrap = false;
            this.lv_logwindow.Location = new System.Drawing.Point(12, 46);
            this.lv_logwindow.MultiSelect = false;
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
            this.l_DatabaseName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_DatabaseName.Location = new System.Drawing.Point(13, 13);
            this.l_DatabaseName.Name = "l_DatabaseName";
            this.l_DatabaseName.Size = new System.Drawing.Size(189, 18);
            this.l_DatabaseName.TabIndex = 1;
            this.l_DatabaseName.Text = "Actively logging hotfolder";
            // 
            // b_ExitProgram
            // 
            this.b_ExitProgram.BackColor = System.Drawing.Color.Red;
            this.b_ExitProgram.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_ExitProgram.Location = new System.Drawing.Point(267, 375);
            this.b_ExitProgram.Name = "b_ExitProgram";
            this.b_ExitProgram.Size = new System.Drawing.Size(144, 54);
            this.b_ExitProgram.TabIndex = 2;
            this.b_ExitProgram.Text = "Exit";
            this.b_ExitProgram.UseVisualStyleBackColor = false;
            this.b_ExitProgram.Click += new System.EventHandler(this.b_ExitProgram_Click);
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
            this.Text = "Hotfolder2Database Logger ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label l_DatabaseName;
        private System.Windows.Forms.Button b_ExitProgram;
        private System.Windows.Forms.ListView lv_logwindow;
    }
}