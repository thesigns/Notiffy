using Notiffy.Model;
using Notiffy.View;

namespace Notiffy
{
    internal static class Program
    {
        public static NotificationManager NotificationManager { get; set; } = new();
        public static NotificationParser NotificationParser { get; set; } = new();
        public static NotificationTimer NotificationTimer { get; set; } = new();
        public static MainForm MainForm { get; set; } = new();
        public static NotificationForm NotificationForm { get; set; } = new();

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(MainForm);
        }
    }
}