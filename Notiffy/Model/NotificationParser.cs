using System.Text.RegularExpressions;

namespace Notiffy.Model
{
    public class NotificationParser
    { 
        private const string NotificationPattern = @"^((\d{4}|\*)\.(\d{1,2}|\*)\.(\d{1,2}|\*) )?(([-+] |[-+]{7} ){0,2})((\d{1,2}|\*):(\d{1,2}|\*)) (.+)$";

        private const int GroupYear = 2;
        private const int GroupMonth = 3;
        private const int GroupDay = 4;
        private const int GroupWeekdays = 5;
        private const int GroupHour = 8;
        private const int GroupMinute = 9;
        private const int GroupMessage = 10;

        private static Regex NotificationRegex { get; set; } = new Regex(NotificationPattern, RegexOptions.Multiline);

        public List<Match> GetNotificationMatches(string source) {
            return NotificationRegex.Matches(source).ToList();
        }

        public List<Notification?>? ParseNotifications(string source)
        {
            List<Notification?>? result = [];
            foreach (var match in GetNotificationMatches(source))
            {
                Notification? notification = ParseNotification(match);
                result.Add(notification);
            }
            return result;
        }

        private Notification? ParseNotification(Match match)
        {
            Notification notification = new();

            notification.Year = match.Groups[GroupYear].Value == "*" | match.Groups[GroupYear].Value == "" ? -1 : int.Parse(match.Groups[GroupYear].Value);
            notification.Month = match.Groups[GroupMonth].Value == "*" | match.Groups[GroupMonth].Value == "" ? -1 : int.Parse(match.Groups[GroupMonth].Value);
            notification.Day = match.Groups[GroupDay].Value == "*" | match.Groups[GroupDay].Value == "" ? -1 : int.Parse(match.Groups[GroupDay].Value);

            var weekDays = match.Groups[GroupWeekdays].Value.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (weekDays.Count() == 0)
            {
                notification.WeekdaysOdd = Enumerable.Repeat(true, 7).ToList();
                notification.WeekdaysEven = Enumerable.Repeat(true, 7).ToList();
            }
            else if (weekDays.Count() == 1)
            {
                notification.WeekdaysOdd = ParseWeekdays(weekDays[0]) ?? Enumerable.Repeat(false, 7).ToList();
                notification.WeekdaysEven = notification.WeekdaysOdd;
            }
            else
            {
                notification.WeekdaysOdd = ParseWeekdays(weekDays[0]) ?? Enumerable.Repeat(false, 7).ToList();
                notification.WeekdaysEven = ParseWeekdays(weekDays[1]) ?? Enumerable.Repeat(false, 7).ToList();
            }

            notification.Hour = match.Groups[GroupHour].Value == "*" ? -1 : int.Parse(match.Groups[GroupHour].Value);
            notification.Minute = match.Groups[GroupMinute].Value == "*" ? -1 : int.Parse(match.Groups[GroupMinute].Value);
            notification.Message = match.Groups[GroupMessage].Value;

            return notification;
        }

        private List<bool>? ParseWeekdays(string source)
        {
            source = source.Trim();
            List<bool> result = source.Select(c => c == '-' ? false : true).ToList();
            if (result.Count == 7)
            {
                return result;
            } else if (result.Count == 1)
            {
                return Enumerable.Repeat(result[0], 7).ToList();
            }
            return null;
        }

    }
}
