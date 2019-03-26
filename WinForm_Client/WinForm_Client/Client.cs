using System;
using System.IO;
using System.Net.Sockets;

namespace WinForm_Client
{
    public class Client
    {
        public Client()
        {
            try
            {
                if (Program.WindowMode == false)
                {
                    if(Program.UserGivenDetails)
                    {
                        Connect();//Connect to sever
                        //ConsoleEnterDetails();//Allow user to enter details
                        Send();//Send data to server
                    }
                    else
                    {
                        Connect();
                        ConsoleEnterDetails();
                        Send();
                    }
                }
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

        public static void Connect()
        {
            Program.ClientTCP.Connect(Program.HostName, Program.PortNumber);//Establish connection
            //Console.WriteLine("Connected to " + Program.HostName + "\n");
            if(Program.WindowMode == true)
            {
                Program.MainForm.OutputMessage("Connected to " + Program.HostName);
            }
            //OutputSettings(Program.ProtocolType, Program.ProtocolVersion);//Print current configuration
            NetworkStream NetworkStream = Program.ClientTCP.GetStream();//NetworkStream to instantiate..
            //NetworkStream.WriteTimeout = 10000;
            //NetworkStream.WriteTimeout = 10000;
            Program.sr = new StreamReader(NetworkStream);//Stream Reader
            Program.sw = new StreamWriter(NetworkStream);//Stream Writer
        }

        public static void Send()
        {
            if (Program.ClientTCP.Connected)
            {
                Request request = new Request();
                CloseConnection();
            }
        }

        public static void ConsoleEnterDetails()
        {
            string userInput = Console.ReadLine().Trim();//Read user input and clear leading and trailing whitespace
            if (userInput.Split(' ').Length > 1)//Check if location exists
            {
                Program.NewLocation = userInput.Split(' ')[1];//Set location
            }
            Program.Name = userInput.Split(' ')[0];//Set name
        }

        public static void CloseConnection()
        {
            Program.ClientTCP.Close();
            Program.ClientTCP.Dispose();
        }
    }
}
