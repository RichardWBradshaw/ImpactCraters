namespace ImpactCraters
    {
    partial class ImpactCratersDialog
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
            {
            if (disposing && ( components != null ))
                {
                components.Dispose ();
                }
            base.Dispose (disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
            {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImpactCratersDialog));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.launchEarthImpactDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launcnGoogleMyMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.queryBuilderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutImpactCratersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayReferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayGoggleMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayEarthImpactDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(934, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.launchEarthImpactDatabaseToolStripMenuItem,
            this.launcnGoogleMyMapToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(352, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.Open_click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(352, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.Save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(349, 6);
            // 
            // launchEarthImpactDatabaseToolStripMenuItem
            // 
            this.launchEarthImpactDatabaseToolStripMenuItem.Name = "launchEarthImpactDatabaseToolStripMenuItem";
            this.launchEarthImpactDatabaseToolStripMenuItem.Size = new System.Drawing.Size(352, 22);
            this.launchEarthImpactDatabaseToolStripMenuItem.Text = "Launch http://www.passc.net/EarthImpactDatabase/";
            this.launchEarthImpactDatabaseToolStripMenuItem.Click += new System.EventHandler(this.launchEarthImpactDatabaseToolStripMenuItem_Click);
            // 
            // launcnGoogleMyMapToolStripMenuItem
            // 
            this.launcnGoogleMyMapToolStripMenuItem.Name = "launcnGoogleMyMapToolStripMenuItem";
            this.launcnGoogleMyMapToolStripMenuItem.Size = new System.Drawing.Size(352, 22);
            this.launcnGoogleMyMapToolStripMenuItem.Text = "Launch Google My Maps";
            this.launcnGoogleMyMapToolStripMenuItem.Click += new System.EventHandler(this.launchGoogleMyMapsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(349, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(352, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit_click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.queryBuilderToolStripMenuItem,
            this.displayReferencesToolStripMenuItem,
            this.displayGoggleMapToolStripMenuItem,
            this.displayEarthImpactDatabaseToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(47, 20);
            this.toolStripMenuItem1.Text = "Tools";
            // 
            // queryBuilderToolStripMenuItem
            // 
            this.queryBuilderToolStripMenuItem.Name = "queryBuilderToolStripMenuItem";
            this.queryBuilderToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.queryBuilderToolStripMenuItem.Text = "Query Builder...";
            this.queryBuilderToolStripMenuItem.Click += new System.EventHandler(this.Query_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutImpactCratersToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutImpactCratersToolStripMenuItem
            // 
            this.aboutImpactCratersToolStripMenuItem.Name = "aboutImpactCratersToolStripMenuItem";
            this.aboutImpactCratersToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.aboutImpactCratersToolStripMenuItem.Text = "About Impact Craters...";
            this.aboutImpactCratersToolStripMenuItem.Click += new System.EventHandler(this.About_click);
            // 
            // displayReferencesToolStripMenuItem
            // 
            this.displayReferencesToolStripMenuItem.Checked = true;
            this.displayReferencesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayReferencesToolStripMenuItem.Name = "displayReferencesToolStripMenuItem";
            this.displayReferencesToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.displayReferencesToolStripMenuItem.Text = "Display References...";
            this.displayReferencesToolStripMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // displayGoggleMapToolStripMenuItem
            // 
            this.displayGoggleMapToolStripMenuItem.Checked = true;
            this.displayGoggleMapToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayGoggleMapToolStripMenuItem.Name = "displayGoggleMapToolStripMenuItem";
            this.displayGoggleMapToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.displayGoggleMapToolStripMenuItem.Text = "Display Goggle Map...";
            this.displayGoggleMapToolStripMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // displayEarthImpactDatabaseToolStripMenuItem
            // 
            this.displayEarthImpactDatabaseToolStripMenuItem.Checked = false;
            this.displayEarthImpactDatabaseToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayEarthImpactDatabaseToolStripMenuItem.Name = "displayEarthImpactDatabaseToolStripMenuItem";
            this.displayEarthImpactDatabaseToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.displayEarthImpactDatabaseToolStripMenuItem.Text = "Display Earth Impact Database...";
            this.displayEarthImpactDatabaseToolStripMenuItem.Click += new System.EventHandler(this.MenuCheckBox_Click);
            // 
            // ImpactCratersDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 412);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ImpactCratersDialog";
            this.Text = "Impact Craters";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem queryBuilderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutImpactCratersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem launchEarthImpactDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launcnGoogleMyMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayReferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayGoggleMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayEarthImpactDatabaseToolStripMenuItem;
        }
    }

