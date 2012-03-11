namespace Projectnettor
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    using Logic;

    public partial class Form1 : Form
    {
        private readonly TaskManager taskManager;
        private readonly GlobalHotkey hotKey;
        private string tempFilePath;

        public Form1()
        {
            InitializeComponent();
            taskManager = new TaskManager();
            hotKey = new GlobalHotkey(0x0001 + 0x0002, Keys.P, this); // ctrl + alt + P
        }

        private void TxtTaskKeyDownHandler(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                taskManager.AddTask(txtTask.Text);
                txtTask.Clear();
                this.Hide();
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                txtTask.Clear();
                this.Hide();
            }
        }

        private void FormLoadHandler(object sender, System.EventArgs e)
        {
            if (!hotKey.Register())
            {
                MessageBox.Show("Hotkey failed to register!");
            }

            tempFilePath = Path.GetTempFileName();
        }

        private void FormClosingHandler(object sender, FormClosingEventArgs e)
        {
            if (!hotKey.Unregister())
            {
                MessageBox.Show("Hotkey failed to unregister!");
            }

            try
            {
                File.Delete(tempFilePath);
            }
            catch (Exception)
            {
                MessageBox.Show("There was a problem while removing temporary file.\r\nThe file was not removed.");
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == GlobalHotkey.HotKeyMessageId)
            {
                HandleHotkey();
            }

            base.WndProc(ref m);
        }


        private void NotifyIconMouseDoubleClickHandler(object sender, MouseEventArgs e)
        {
            BringBackTheForm();
        }

        private void HandleHotkey()
        {
            BringBackTheForm();
        }

        private void BringBackTheForm()
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void ShowReportInNotepad()
        {
            string report = taskManager.GetReport();
            File.WriteAllText(tempFilePath, report);
            Process.Start("notepad.exe", tempFilePath);
        }

        private void ShowReportToolStripMenuItemClickHandler(object sender, EventArgs e)
        {
            ShowReportInNotepad();
        }

        private void AboutToolStripMenuClickHandler(object sender, EventArgs e)
        {
            MessageBox.Show("Projecnettor\r\nAuthor: Piotr Benetkiewicz <piotr@ais.pl>\r\nAll rights reserved.");
        }
    }
}
