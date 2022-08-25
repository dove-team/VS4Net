using System;
using System.Threading;
using System.Windows.Forms;

namespace VS4Net
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var mutex = new Mutex(true, "VS4Net", out bool isCreated))
            {
                if (isCreated)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
                else
                    Application.Exit();
            }
        }
    }
}