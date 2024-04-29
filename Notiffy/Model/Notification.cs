namespace Notiffy.Model
{
    public class Notification
    {
        public bool Notified { get; set; }
        public DateTime Time { get; set; }
        public List<bool> Weekdays { get; set; } = Enumerable.Repeat(false, 7).ToList();
        public string Message { get; set; } = "";
    }
}
