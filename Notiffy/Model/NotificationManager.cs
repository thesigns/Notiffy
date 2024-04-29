namespace Notiffy.Model
{
    public class NotificationManager
    {
        const string FilePath = "Notifications.txt";
        private List<Notification?> Notifications { get; set; } = [];

        public Notification? RetrieveNotification()
        {
            DateTime now = DateTime.Now;
            foreach (var notification in Notifications)
            {
                if (notification == null || notification.Notified)
                {
                    continue;
                }
                if (notification.Time.Hour == now.Hour && notification.Time.Minute == now.Minute)
                {
                    bool allWeekdaysFalse = !notification.Weekdays.Any(day => day);
                    if (allWeekdaysFalse)
                    {
                        if (notification.Time.Date == now.Date)
                        {
                            notification.Notified = true;
                            return notification;
                        }
                    }
                    else
                    {
                        int dayIndex = now.DayOfWeek == 0 ? 6 : (int)now.DayOfWeek - 1;
                        if (notification.Weekdays[dayIndex] && notification.Time < now)
                        {
                            notification.Notified = true;
                            return notification;
                        }
                    }
                }
            }
            return null;
        }

        public void SaveNotificationsSource(string source)
        {
            try
            {
                File.WriteAllText(FilePath, source);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving notifications: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string LoadNotificationsSource()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    return File.ReadAllText(FilePath);
                }
                else
                {
                    File.Create(FilePath).Dispose();
                    return string.Empty;
                }
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
