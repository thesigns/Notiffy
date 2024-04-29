using Notiffy.View;

namespace Notiffy
{
    internal static class Program
    {
        public static MainForm MainForm { get; set; } = new MainForm();

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(MainForm);
        }
    }
}