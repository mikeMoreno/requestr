namespace Requestr
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.treeCollections = new System.Windows.Forms.TreeView();
            this.treeCollectionsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.collectionTreeClone = new System.Windows.Forms.ToolStripMenuItem();
            this.collectionTreeDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.collectionTreeRename = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabsRequests = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.treeCollectionsContextMenu.SuspendLayout();
            this.tabsRequests.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(971, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewRequest,
            this.btnImport,
            this.btnExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // btnNewRequest
            // 
            this.btnNewRequest.Name = "btnNewRequest";
            this.btnNewRequest.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.btnNewRequest.Size = new System.Drawing.Size(180, 22);
            this.btnNewRequest.Text = "New";
            this.btnNewRequest.Click += new System.EventHandler(this.BtnNewRequest_Click);
            // 
            // btnImport
            // 
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(180, 22);
            this.btnImport.Text = "Import...";
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(180, 22);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // treeCollections
            // 
            this.treeCollections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeCollections.ContextMenuStrip = this.treeCollectionsContextMenu;
            this.treeCollections.Location = new System.Drawing.Point(0, 27);
            this.treeCollections.Name = "treeCollections";
            this.treeCollections.Size = new System.Drawing.Size(217, 434);
            this.treeCollections.TabIndex = 1;
            this.treeCollections.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeCollections_NodeMouseClick);
            this.treeCollections.DoubleClick += new System.EventHandler(this.TreeCollections_DoubleClick);
            // 
            // treeCollectionsContextMenu
            // 
            this.treeCollectionsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collectionTreeClone,
            this.collectionTreeDelete,
            this.collectionTreeRename});
            this.treeCollectionsContextMenu.Name = "treeCollectionsContextMenu";
            this.treeCollectionsContextMenu.Size = new System.Drawing.Size(118, 70);
            // 
            // collectionTreeClone
            // 
            this.collectionTreeClone.Name = "collectionTreeClone";
            this.collectionTreeClone.Size = new System.Drawing.Size(117, 22);
            this.collectionTreeClone.Text = "Clone";
            this.collectionTreeClone.Click += new System.EventHandler(this.CollectionTreeClone_Click);
            // 
            // collectionTreeDelete
            // 
            this.collectionTreeDelete.Name = "collectionTreeDelete";
            this.collectionTreeDelete.Size = new System.Drawing.Size(117, 22);
            this.collectionTreeDelete.Text = "Delete";
            this.collectionTreeDelete.Click += new System.EventHandler(this.CollectionTreeDelete_Click);
            // 
            // collectionTreeRename
            // 
            this.collectionTreeRename.Name = "collectionTreeRename";
            this.collectionTreeRename.Size = new System.Drawing.Size(117, 22);
            this.collectionTreeRename.Text = "Rename";
            this.collectionTreeRename.Click += new System.EventHandler(this.CollectionTreeRename_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(749, 406);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabsRequests
            // 
            this.tabsRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabsRequests.Controls.Add(this.tabPage1);
            this.tabsRequests.Location = new System.Drawing.Point(214, 27);
            this.tabsRequests.Name = "tabsRequests";
            this.tabsRequests.SelectedIndex = 0;
            this.tabsRequests.Size = new System.Drawing.Size(757, 434);
            this.tabsRequests.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 461);
            this.Controls.Add(this.tabsRequests);
            this.Controls.Add(this.treeCollections);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Requestr";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.treeCollectionsContextMenu.ResumeLayout(false);
            this.tabsRequests.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem btnImport;
        private ToolStripMenuItem btnExit;
        private TreeView treeCollections;
        private TabPage tabPage1;
        private TabControl tabsRequests;
        private ToolStripMenuItem btnNewRequest;
        private ContextMenuStrip treeCollectionsContextMenu;
        private ToolStripMenuItem collectionTreeDelete;
        private ToolStripMenuItem collectionTreeRename;
        private ToolStripMenuItem collectionTreeClone;
    }
}