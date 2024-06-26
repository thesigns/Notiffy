﻿using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Notiffy.View
{
    public partial class MainForm : Form
    {

        private NotifyIcon notifyIcon;

        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                notifyIcon.Visible = true;
            }
        }

        public void ShowNotification(string message)
        {
            NotificationForm nf = new();
            nf.ShowYourself(message);
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        public void SuspendDrawing()
        {
            SendMessage(richTextBoxNotification.Handle, WM_SETREDRAW, false, 0);
        }

        public void ResumeDrawing()
        {
            SendMessage(richTextBoxNotification.Handle, WM_SETREDRAW, true, 0);
            richTextBoxNotification.Refresh();
        }

        public void ColorizeNotificationTextBox()
        {
            int cursorPosition = richTextBoxNotification.SelectionStart;
            SuspendDrawing();
            richTextBoxNotification.SuspendLayout();
            richTextBoxNotification.SelectAll();
            richTextBoxNotification.SelectionColor = Color.DimGray;
            richTextBoxNotification.SelectionFont = new Font(richTextBoxNotification.Font, FontStyle.Regular);
            foreach (var match in Program.NotificationParser.GetNotificationMatches(richTextBoxNotification.Text))
            {
                var str = "Count: " + match.Groups.Count + "\n";
                for (var i = 0; i < match.Groups.Count; i++)
                {
                    str += i + ": " + match.Groups[i].Value + "\n";
                }

                richTextBoxNotification.Select(match.Index, match.Length);
                richTextBoxNotification.SelectionColor = Color.Green;
                richTextBoxNotification.SelectionFont = new Font(richTextBoxNotification.Font, FontStyle.Bold);
            }
            richTextBoxNotification.SelectionStart = cursorPosition;
            richTextBoxNotification.SelectionLength = 0;
            richTextBoxNotification.ResumeLayout();
            ResumeDrawing();
        }

        private void richTextBoxNotification_TextChanged(object sender, EventArgs e)
        {
            ColorizeNotificationTextBox();
            Program.NotificationManager.UpdateNotifications(richTextBoxNotification.Text);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Icon;
            notifyIcon.Text = "Notiffy";
            notifyIcon.Click += NotifyIcon_Click;

            string text = Program.NotificationManager.LoadNotifications();
            richTextBoxNotification.Text = text;
            richTextBoxNotification.SelectionStart = 0;
            richTextBoxNotification.SelectionLength = 0;
        }

        private void NotifyIcon_Click(object? sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }
    }
}
