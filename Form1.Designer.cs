namespace Hotfolder2Database
{
    partial class Form1
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("PNG");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("JPG");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("TIFF");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("BMP");
            this.b_Start = new System.Windows.Forms.Button();
            this.lv_ValidTypes = new System.Windows.Forms.ListView();
            this.l_ValidTypes = new System.Windows.Forms.Label();
            this.tb_DatabasePath = new System.Windows.Forms.TextBox();
            this.l_databaseStatus = new System.Windows.Forms.Label();
            this.b_addDatabase = new System.Windows.Forms.Button();
            this.pb_databaseStatus = new System.Windows.Forms.PictureBox();
            this.b_databaseSearch = new System.Windows.Forms.Button();
            this.l_DatabasePath = new System.Windows.Forms.Label();
            this.l_instruction = new System.Windows.Forms.Label();
            this.l_Title = new System.Windows.Forms.Label();
            this.l_imageStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_databaseStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // b_Start
            // 
            this.b_Start.BackColor = System.Drawing.Color.LightGray;
            this.b_Start.Enabled = false;
            this.b_Start.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Start.ForeColor = System.Drawing.Color.DarkGray;
            this.b_Start.Location = new System.Drawing.Point(506, 250);
            this.b_Start.Name = "b_Start";
            this.b_Start.Size = new System.Drawing.Size(155, 60);
            this.b_Start.TabIndex = 0;
            this.b_Start.Text = "Start";
            this.b_Start.UseVisualStyleBackColor = false;
            this.b_Start.Click += new System.EventHandler(this.b_Start_Click);
            // 
            // lv_ValidTypes
            // 
            this.lv_ValidTypes.CheckBoxes = true;
            this.lv_ValidTypes.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            listViewItem1.ToolTipText = "Uncompressed Web Format with Alpha channel";
            listViewItem2.StateImageIndex = 0;
            listViewItem2.ToolTipText = "Compressed image format";
            listViewItem3.StateImageIndex = 0;
            listViewItem3.ToolTipText = "Uncompressed image format";
            listViewItem4.StateImageIndex = 0;
            listViewItem4.ToolTipText = "Proprietary uncompressed image format";
            this.lv_ValidTypes.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.lv_ValidTypes.Location = new System.Drawing.Point(506, 49);
            this.lv_ValidTypes.Name = "lv_ValidTypes";
            this.lv_ValidTypes.Size = new System.Drawing.Size(155, 135);
            this.lv_ValidTypes.TabIndex = 1;
            this.lv_ValidTypes.UseCompatibleStateImageBehavior = false;
            this.lv_ValidTypes.View = System.Windows.Forms.View.List;
            this.lv_ValidTypes.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_ValidTypes_ItemChecked);
            // 
            // l_ValidTypes
            // 
            this.l_ValidTypes.AutoSize = true;
            this.l_ValidTypes.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_ValidTypes.Location = new System.Drawing.Point(503, 17);
            this.l_ValidTypes.Name = "l_ValidTypes";
            this.l_ValidTypes.Size = new System.Drawing.Size(85, 16);
            this.l_ValidTypes.TabIndex = 2;
            this.l_ValidTypes.Text = "Valid Types";
            // 
            // tb_DatabasePath
            // 
            this.tb_DatabasePath.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tb_DatabasePath.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tb_DatabasePath.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tb_DatabasePath.Location = new System.Drawing.Point(29, 203);
            this.tb_DatabasePath.Name = "tb_DatabasePath";
            this.tb_DatabasePath.ReadOnly = true;
            this.tb_DatabasePath.Size = new System.Drawing.Size(350, 22);
            this.tb_DatabasePath.TabIndex = 3;
            this.tb_DatabasePath.Text = "Search for an existing database or add a new one";
            // 
            // l_databaseStatus
            // 
            this.l_databaseStatus.AutoSize = true;
            this.l_databaseStatus.BackColor = System.Drawing.SystemColors.Control;
            this.l_databaseStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_databaseStatus.ForeColor = System.Drawing.Color.Red;
            this.l_databaseStatus.Location = new System.Drawing.Point(101, 260);
            this.l_databaseStatus.Name = "l_databaseStatus";
            this.l_databaseStatus.Size = new System.Drawing.Size(202, 23);
            this.l_databaseStatus.TabIndex = 5;
            this.l_databaseStatus.Text = "No database selected";
            // 
            // b_addDatabase
            // 
            this.b_addDatabase.BackgroundImage = global::Hotfolder2Database.Properties.Resources.database_add;
            this.b_addDatabase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.b_addDatabase.Location = new System.Drawing.Point(441, 189);
            this.b_addDatabase.Name = "b_addDatabase";
            this.b_addDatabase.Size = new System.Drawing.Size(50, 50);
            this.b_addDatabase.TabIndex = 6;
            this.b_addDatabase.UseVisualStyleBackColor = true;
            this.b_addDatabase.Click += new System.EventHandler(this.b_addDatabase_Click);
            // 
            // pb_databaseStatus
            // 
            this.pb_databaseStatus.Image = global::Hotfolder2Database.Properties.Resources.database_offline;
            this.pb_databaseStatus.Location = new System.Drawing.Point(29, 250);
            this.pb_databaseStatus.Name = "pb_databaseStatus";
            this.pb_databaseStatus.Size = new System.Drawing.Size(66, 62);
            this.pb_databaseStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_databaseStatus.TabIndex = 4;
            this.pb_databaseStatus.TabStop = false;
            // 
            // b_databaseSearch
            // 
            this.b_databaseSearch.BackgroundImage = global::Hotfolder2Database.Properties.Resources.database_search;
            this.b_databaseSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.b_databaseSearch.Location = new System.Drawing.Point(385, 189);
            this.b_databaseSearch.Name = "b_databaseSearch";
            this.b_databaseSearch.Size = new System.Drawing.Size(50, 50);
            this.b_databaseSearch.TabIndex = 7;
            this.b_databaseSearch.UseVisualStyleBackColor = true;
            this.b_databaseSearch.Click += new System.EventHandler(this.b_databaseSearch_Click);
            // 
            // l_DatabasePath
            // 
            this.l_DatabasePath.AutoSize = true;
            this.l_DatabasePath.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_DatabasePath.Location = new System.Drawing.Point(26, 184);
            this.l_DatabasePath.Name = "l_DatabasePath";
            this.l_DatabasePath.Size = new System.Drawing.Size(112, 16);
            this.l_DatabasePath.TabIndex = 8;
            this.l_DatabasePath.Text = "Database path:";
            // 
            // l_instruction
            // 
            this.l_instruction.Location = new System.Drawing.Point(29, 49);
            this.l_instruction.Name = "l_instruction";
            this.l_instruction.Size = new System.Drawing.Size(475, 100);
            this.l_instruction.TabIndex = 9;
            this.l_instruction.Text = "When started this program will monitor the selected folder for any image files ma" +
    "tching your selected valid types and enter metadata information into a SQLite da" +
    "tabase of your choice.";
            // 
            // l_Title
            // 
            this.l_Title.AutoSize = true;
            this.l_Title.BackColor = System.Drawing.SystemColors.ControlLight;
            this.l_Title.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Title.Location = new System.Drawing.Point(32, 17);
            this.l_Title.Name = "l_Title";
            this.l_Title.Size = new System.Drawing.Size(135, 19);
            this.l_Title.TabIndex = 10;
            this.l_Title.Text = "Img Meta-logger";
            // 
            // l_imageStatus
            // 
            this.l_imageStatus.AutoSize = true;
            this.l_imageStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_imageStatus.ForeColor = System.Drawing.Color.Red;
            this.l_imageStatus.Location = new System.Drawing.Point(101, 285);
            this.l_imageStatus.Name = "l_imageStatus";
            this.l_imageStatus.Size = new System.Drawing.Size(243, 23);
            this.l_imageStatus.TabIndex = 11;
            this.l_imageStatus.Text = "No Image type(s) selected";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 324);
            this.Controls.Add(this.l_imageStatus);
            this.Controls.Add(this.l_Title);
            this.Controls.Add(this.l_instruction);
            this.Controls.Add(this.l_DatabasePath);
            this.Controls.Add(this.b_databaseSearch);
            this.Controls.Add(this.b_addDatabase);
            this.Controls.Add(this.l_databaseStatus);
            this.Controls.Add(this.pb_databaseStatus);
            this.Controls.Add(this.tb_DatabasePath);
            this.Controls.Add(this.l_ValidTypes);
            this.Controls.Add(this.lv_ValidTypes);
            this.Controls.Add(this.b_Start);
            this.Name = "Form1";
            this.Text = "Hotfolder2Database";
            ((System.ComponentModel.ISupportInitialize)(this.pb_databaseStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_Start;
        private System.Windows.Forms.ListView lv_ValidTypes;
        private System.Windows.Forms.Label l_ValidTypes;
        private System.Windows.Forms.TextBox tb_DatabasePath;
        private System.Windows.Forms.PictureBox pb_databaseStatus;
        private System.Windows.Forms.Label l_databaseStatus;
        private System.Windows.Forms.Button b_addDatabase;
        private System.Windows.Forms.Button b_databaseSearch;
        private System.Windows.Forms.Label l_DatabasePath;
        private System.Windows.Forms.Label l_instruction;
        private System.Windows.Forms.Label l_Title;
        private System.Windows.Forms.Label l_imageStatus;
    }
}

