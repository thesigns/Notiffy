using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

namespace Notiffy.Model
{
    public class NotificationManager
    {
        const string FilePath = "Resources\\Notifications.txt";
        private List<Notification?> Notifications { get; set; } = [];

        public Notification? RetrieveNotification()
        {
            DateTime now = DateTime.Now;
            foreach (var notification in Notifications)
            {

                if (notification == null || (now - notification.NotifiedTime).TotalSeconds <= 60 )
                {
                    continue;
                }

                if (notification.Year != now.Year && notification.Year != -1) continue;
                if (notification.Month != now.Month && notification.Month != -1) continue;
                if (notification.Day != now.Day && notification.Day != -1) continue;
                if (notification.Hour != now.Hour && notification.Hour != -1) continue;
                if (notification.Minute != now.Minute && notification.Minute != -1) continue;

                Calendar calendar = CultureInfo.CurrentCulture.Calendar;
                DayOfWeek firstDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
                CalendarWeekRule weekRule = CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule;
                int weekOfYear = calendar.GetWeekOfYear(now, weekRule, firstDayOfWeek);

                int dayIndex = now.DayOfWeek == 0 ? 6 : (int)now.DayOfWeek - 1;
                if (weekOfYear % 2 == 1)
                {
                    if (!notification.WeekdaysOdd[dayIndex]) continue;
                }
                else
                {
                    if (!notification.WeekdaysEven[dayIndex]) continue;
                }

                notification.NotifiedTime = now;
                return notification;

                //if (notification == null || notification.Notified)
                //{
                //    continue;
                //}
                //if (notification.Time.Hour == now.Hour && notification.Time.Minute == now.Minute)
                //{
                //    bool allWeekdaysFalse = !notification.Weekdays.Any(day => day);
                //    if (allWeekdaysFalse)
                //    {
                //        if (notification.Time.Date == now.Date)
                //        {
                //            notification.Notified = true;
                //            return notification;
                //        }
                //    }
                //    else
                //    {
                //        int dayIndex = now.DayOfWeek == 0 ? 6 : (int)now.DayOfWeek - 1;
                //        if (notification.Weekdays[dayIndex] && notification.Time < now)
                //        {
                //            notification.Notified = true;
                //            return notification;
                //        }
                //    }
                //}





            }
            return null;
        }

        public void UpdateNotifications(string source) {


            Notifications = Program.NotificationParser.ParseNotifications(source) ?? [];
            SaveNotifications(source);
        }

        public void SaveNotifications(string source)
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

        public string LoadNotifications()
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
