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
            _timer.Stop(); // Zatrzymaj timer, aby uniknąć nakładania się wywołań
            CheckNotifications();
            _timer.Start(); // Restart timer
        }

        private void CheckNotifications()
        {
            var notification = Program.NotificationManager.RetrieveNotification();
            if (notification != null)
            {
                // Wywołanie ShowNotification na wątku GUI
                Program.MainForm.Invoke(new Action(() => {
                    Program.MainForm.ShowNotification(notification.Message);
                }));
            }
        }
    }
}
