using System.Diagnostics;

namespace TweakMaker
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
#if DEBUG
            Debug.AutoFlush = true;
#endif
            Application.Run(new FormMain());
        }
    }
}