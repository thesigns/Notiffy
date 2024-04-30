namespace Notiffy.Model
{
    public class Notification
    {
        public DateTime NotifiedTime { get; set; } = new();
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public List<bool> WeekdaysOdd { get; set; } = Enumerable.Repeat(false, 7).ToList();
        public List<bool> WeekdaysEven { get; set; } = Enumerable.Repeat(false, 7).ToList();


        public bool Notified { get; set; }
        public DateTime Time { get; set; }
        public List<bool> Weekdays { get; set; } = Enumerable.Repeat(false, 7).ToList();

        public string Message { get; set; } = "";
    }
}
