using System.Media;

namespace Notiffy.View
{
    public partial class NotificationForm : Form
    {
        private System.Windows.Forms.Timer countdownTimer;
        private int countdownValue;

        public NotificationForm()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000;
            countdownTimer.Tick += new EventHandler(CountdownTimer_Tick);
        }

        public void ShowYourself(string message)
        {
            Visible = true;
            labelMessage.Text = message;
            TopMost = true;
            buttonOK.Enabled = false;
            countdownValue = 3;
            buttonOK.Text = countdownValue.ToString();
            countdownTimer.Start();
            SystemSounds.Beep.Play();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            countdownValue--;
            if (countdownValue > 0)
            {
                SystemSounds.Beep.Play();
                buttonOK.Text = countdownValue.ToString();
            }
            else
            {
                countdownTimer.Stop();
                buttonOK.Enabled = true;
                buttonOK.Text = "OK";
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
