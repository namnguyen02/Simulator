using System;
using System.Windows.Forms;

namespace Simulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>        
        [STAThread]
        [Obsolete]
        static void Main(string[] args)
        {
            if (!(args is null))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {
                throw new ArgumentNullException(nameof(args));
            }
        }
    }
}
