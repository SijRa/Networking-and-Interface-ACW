using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinForm_Client
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

        public static void ShowConsoleWindow()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_SHOW);
        }
    }

    static class Program
    {
        public static ClientForm MainForm;

        public static bool WindowMode = false;

        public static string HostName;
        public static int PortNumber;

        public static string Name;
        public static string NewLocation;

        public static string ProtocolCommand;
        public static string ProtocolType;
        public static string ProtocolVersion;

        public static bool UserGivenDetails = false;

        public static StreamReader sr;
        public static StreamWriter sw;

        public static TcpClient ClientTCP;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Name = null;
                NewLocation = null;
                //uni address whois.net.dcs.hull.ac.uk
                HostName = "localhost";//Default host
                PortNumber = 43;//Default port
                ProtocolType = "WHOIS";//Default protocol
                ClientTCP = new TcpClient();
                if (args.Length != 0)//Check for user-entered connection settings
                {
                    string nameLocation = "";//String to contain name and location
                    for (int i = 0; i < args.Length; i++)
                    {
                        switch (args[i])
                        {
                            case "-h"://Host
                                HostName = args[i + 1];
                                args[i] = null;
                                args[i + 1] = null;
                                break;
                            case "-p"://Port number
                                PortNumber = int.Parse(args[i + 1]);
                                args[i] = null;
                                args[i + 1] = null;
                                break;
                            case "-h9"://HTTP 0.9
                                ProtocolType = "HTTP";
                                ProtocolVersion = "0.9";
                                args[i] = null;
                                break;
                            case "-h0"://HTTP 1.0
                                ProtocolType = "HTTP";
                                ProtocolVersion = "1.0";
                                args[i] = null;
                                break;
                            case "-h1"://HTTP 1.1
                                ProtocolType = "HTTP";
                                ProtocolVersion = "1.1";
                                args[i] = null;
                                break;
                            case "-w"://Windowed Mode
                                WindowMode = true;
                                break;
                            default:
                                if (args[i] != null)
                                {
                                    if (args[i] != "-w")//Ignore
                                    {
                                        UserGivenDetails = true;
                                        nameLocation += args[i].ToString() + " ";//string containing name and location separated by space
                                    }
                                }
                                break;
                        }
                    }
                    if (!string.IsNullOrEmpty(nameLocation))//Only do this if string is not empty
                    {
                        Name = nameLocation.Split(' ')[0].Trim();//Name extraction
                        if (nameLocation.Split(' ').Length > 1)
                        {
                            NewLocation = nameLocation.Substring(Name.Length).Trim();//Location extraction
                        }
                        if (string.IsNullOrEmpty(Name))//Name needs to be provided whether GET or SET
                        {
                            throw new Exception("Name not provided as default argument");
                        }
                    }
                }
                if (WindowMode == true)
                {
                    ConsoleMethods.HideConsoleWindow();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new ClientForm());
                }
                Client client = new Client();
            }
            catch (IOException)
            {
                Console.WriteLine("ERROR: StreamReader/Writer timed out");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                //Console.ReadKey();//PAUSE
            }
        }

        static void OutputSettings()
        {
            Console.WriteLine("Protcol Type: " + ProtocolType);
            if (ProtocolVersion != null)//Checks for value
            {
                Console.WriteLine("Protocol Version: " + ProtocolVersion);//Output version if it has a value
            }
        }

        static void ShowConsole()
        {
            ConsoleMethods.ShowConsoleWindow();
        }
    }
}
