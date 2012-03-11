namespace Projectnettor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.systrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.systrayIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTask = new Projectnettor.EnterTextBox();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systrayIconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // systrayIcon
            // 
            this.systrayIcon.ContextMenuStrip = this.systrayIconContextMenu;
            this.systrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("systrayIcon.Icon")));
            this.systrayIcon.Text = "Projectnettor";
            this.systrayIcon.Visible = true;
            this.systrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconMouseDoubleClickHandler);
            // 
            // systrayIconContextMenu
            // 
            this.systrayIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showReportToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.systrayIconContextMenu.Name = "contextMenuStrip1";
            this.systrayIconContextMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // showReportToolStripMenuItem
            // 
            this.showReportToolStripMenuItem.Name = "showReportToolStripMenuItem";
            this.showReportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showReportToolStripMenuItem.Text = "Show report";
            this.showReportToolStripMenuItem.Click += new System.EventHandler(this.ShowReportToolStripMenuItemClickHandler);
            // 
            // txtTask
            // 
            this.txtTask.Location = new System.Drawing.Point(2, 2);
            this.txtTask.Name = "txtTask";
            this.txtTask.Size = new System.Drawing.Size(469, 20);
            this.txtTask.TabIndex = 0;
            this.txtTask.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTaskKeyDownHandler);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuClickHandler);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 24);
            this.Controls.Add(this.txtTask);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Add Task";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosingHandler);
            this.Load += new System.EventHandler(this.FormLoadHandler);
            this.systrayIconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EnterTextBox txtTask;
        private System.Windows.Forms.NotifyIcon systrayIcon;
        private System.Windows.Forms.ContextMenuStrip systrayIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem showReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

