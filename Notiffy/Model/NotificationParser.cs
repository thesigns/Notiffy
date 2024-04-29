using System.Globalization;

namespace Notiffy.Model
{
    public class NotificationParser
    {
        public List<Notification?>? ParseNotifications(string source)
        {
            List<Notification?>? result = [];

            string[] lines = source.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            foreach (string line in lines)
            {
                if (line[0] == '#') continue;
                Notification? notification = ParseNotification(line);
                if (notification == null)
                {
                    return null;
                }
                result.Add(notification);
            }
            return result;
        }

        private Notification? ParseNotification(string source)
        {
            var parts = source.Split(' ', 4, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (parts.Count != 4)
            {
                return null;
            }
            var dateTime = ParseTime(parts[0] + " " + parts[1]);
            var weekedays = ParseWeekdays(parts[2]);
            if (dateTime == null || weekedays == null)
            {
                return null;
            }
            var message = parts[3];
            return new()
            {
                Notified = false,
                Time = (DateTime)dateTime,
                Weekdays = weekedays,
                Message = message
            };
        }

        private DateTime? ParseTime(string source)
        {
            if (DateTime.TryParseExact(source, "yyyy.MM.dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
            {
                return dateTime;
            }
            else
            {
                return null;
            }
        }

        private List<bool>? ParseWeekdays(string source)
        {
            List<bool> result = source.Select(c => c == '-' ? false : true).ToList();
            if (result.Count == 7)
            {
                return result;
            }
            return null;
        }

    }
}
