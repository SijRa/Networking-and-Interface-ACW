using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Server
{
    internal static class ConsoleMethods//Needed to start console application
    {
        [DllImport("kernel32.dll")]
        internal static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;

        public static void HideConsoleWindow()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
        }
    }

    static class Program
    {

        public static MainForm MainForm;

        public static bool WindowMode = false;
        public static string PortNumber;
        public static string IPAddress;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length != 0)//Check for startup arguments
            {
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "-w"://Win Forms
                            WindowMode = true;
                            break;
                        case "-ip"://IP Number
                            IPAddress = args[i + 1];
                            break;
                        case "-p"://Port Number
                            PortNumber = args[i + 1];
                            break;
                    }
                }
            }
            if(WindowMode == true)
            {
                ConsoleMethods.HideConsoleWindow();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {
                ConsoleMethods.AllocConsole();
                Server currentServer = new Server();
            }
        }
    }

    
}
