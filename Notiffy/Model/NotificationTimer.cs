using System.Timers;

namespace Notiffy.Model
{
    internal class NotificationTimer
    {

        private System.Timers.Timer _timer;

        public NotificationTimer()
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();
        }

        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            CheckNotifications();
        }

        private void CheckNotifications()
        {
            var notification = Program.NotificationManager.RetrieveNotification();
            if (notification != null)
            {
                Program.MainForm.ShowNotification(notification.Message);
            }
        }
    }
}
