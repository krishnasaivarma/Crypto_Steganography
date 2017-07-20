namespace WindowsFormsApplication2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.eNCODEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dECODEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rSAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBOUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eNCODEToolStripMenuItem,
            this.dECODEToolStripMenuItem,
            this.rSAToolStripMenuItem,
            this.aBOUTToolStripMenuItem,
            this.hELPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(439, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // eNCODEToolStripMenuItem
            // 
            this.eNCODEToolStripMenuItem.Name = "eNCODEToolStripMenuItem";
            this.eNCODEToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.eNCODEToolStripMenuItem.Text = "ENCODE";
            this.eNCODEToolStripMenuItem.Click += new System.EventHandler(this.eNCODEToolStripMenuItem_Click);
            // 
            // dECODEToolStripMenuItem
            // 
            this.dECODEToolStripMenuItem.Name = "dECODEToolStripMenuItem";
            this.dECODEToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.dECODEToolStripMenuItem.Text = "DECODE";
            this.dECODEToolStripMenuItem.Click += new System.EventHandler(this.dECODEToolStripMenuItem_Click);
            // 
            // rSAToolStripMenuItem
            // 
            this.rSAToolStripMenuItem.Name = "rSAToolStripMenuItem";
            this.rSAToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.rSAToolStripMenuItem.Text = "R.S.A";
            this.rSAToolStripMenuItem.Click += new System.EventHandler(this.rSAToolStripMenuItem_Click);
            // 
            // aBOUTToolStripMenuItem
            // 
            this.aBOUTToolStripMenuItem.Name = "aBOUTToolStripMenuItem";
            this.aBOUTToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.aBOUTToolStripMenuItem.Text = "ABOUT";
            this.aBOUTToolStripMenuItem.Click += new System.EventHandler(this.aBOUTToolStripMenuItem_Click);
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.hELPToolStripMenuItem.Text = "HELP";
            this.hELPToolStripMenuItem.Click += new System.EventHandler(this.hELPToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 245);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eNCODEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dECODEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rSAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBOUTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
    }
}

