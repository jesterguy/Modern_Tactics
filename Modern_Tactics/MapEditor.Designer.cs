namespace Modern_Tactics
{
    partial class MapEditor
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
			this.openGLControl1 = new SharpGL.OpenGLControl();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mapSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tileSetEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openGLControl2 = new SharpGL.OpenGLControl();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.openGLControl2)).BeginInit();
			this.SuspendLayout();
			// 
			// openGLControl1
			// 
			this.openGLControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.openGLControl1.BitDepth = 32;
			this.openGLControl1.DrawFPS = true;
			this.openGLControl1.FrameRate = 20;
			this.openGLControl1.Location = new System.Drawing.Point(0, 27);
			this.openGLControl1.Name = "openGLControl1";
			this.openGLControl1.RenderContextType = SharpGL.RenderContextType.FBO;
			this.openGLControl1.Size = new System.Drawing.Size(461, 526);
			this.openGLControl1.TabIndex = 0;
			this.openGLControl1.Load += new System.EventHandler(this.openGLControl1_Load);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.tileSetEditorToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(661, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.loadToolStripMenuItem.Text = "Load";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveToolStripMenuItem.Text = "Save";
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapSizeToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// mapSizeToolStripMenuItem
			// 
			this.mapSizeToolStripMenuItem.Name = "mapSizeToolStripMenuItem";
			this.mapSizeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.mapSizeToolStripMenuItem.Text = "Map Size";
			// 
			// tileSetEditorToolStripMenuItem
			// 
			this.tileSetEditorToolStripMenuItem.Name = "tileSetEditorToolStripMenuItem";
			this.tileSetEditorToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
			this.tileSetEditorToolStripMenuItem.Text = "Tile Set Editor";
			this.tileSetEditorToolStripMenuItem.Click += new System.EventHandler(this.tileSetEditorToolStripMenuItem_Click);
			// 
			// openGLControl2
			// 
			this.openGLControl2.BitDepth = 24;
			this.openGLControl2.DrawFPS = false;
			this.openGLControl2.FrameRate = 20;
			this.openGLControl2.Location = new System.Drawing.Point(467, 189);
			this.openGLControl2.Name = "openGLControl2";
			this.openGLControl2.RenderContextType = SharpGL.RenderContextType.DIBSection;
			this.openGLControl2.Size = new System.Drawing.Size(182, 364);
			this.openGLControl2.TabIndex = 2;
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.newToolStripMenuItem.Text = "New";
			// 
			// MapEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(661, 565);
			this.Controls.Add(this.openGLControl2);
			this.Controls.Add(this.openGLControl1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MapEditor";
			this.Text = "MapEditor";
			((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.openGLControl2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileSetEditorToolStripMenuItem;
        private SharpGL.OpenGLControl openGLControl2;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    }
}