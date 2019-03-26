using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace WinForm_Server
{
    public class Server
    {
        static int ConnectionID;
        public static Dictionary<string, string> UserLocation { get; set; }//Dictionary database

        public static bool serverRunning;

        public Server()
        {
            serverRunning = true;
            TcpListener listener;
            Socket connection;
            InitialiseLocationDictionary();///intialise dictionary with test data
            ConnectionID = 0;//initialise connection ID
            Console.WriteLine("\n\nSERVER: Running Server...");
            if (Program.WindowMode == true)//CHECK IF WINDOW MODE
            {
                Program.MainForm.OutputMessage("Running Server..");//UPDATE Connection TextBox
            }
            try
            {
                IPAddress iPAddress;
                int port;
                Console.WriteLine("\nSERVER: Listening...\n\n");
                if(Program.WindowMode == true)//CHECK IF WINDOW MODE
                {
                    Program.MainForm.OutputMessage("Listening..");//UPDATE Connection TextBox
                }
                if(Program.IPAddress != null)
                {
                    iPAddress = IPAddress.Parse(Program.IPAddress);//If IP address given by user
                }
                else
                {
                    iPAddress = IPAddress.Any;//Default
                }
                if(Program.PortNumber != null)
                {
                    port = int.Parse(Program.PortNumber);
                }
                else
                {
                    port = 43;
                }
                //set labels
                if (Program.WindowMode == true)
                {
                    //server labels
                    Program.MainForm.SetServerStatus(serverRunning);//SERVER RUNNING
                    Program.MainForm.SetConnectionNumber(ConnectionID);
                    Program.MainForm.SetPortNumber(port);//bool to separate port labels
                    Program.MainForm.SetIPAddress(iPAddress);//bool to separate ip labels
                }
                listener = new TcpListener(iPAddress, port);
                listener.Start();//Start listening for client
                while (true)
                {
                    connection = listener.AcceptSocket();//Accepts client connection
                    IncrementConnectionID();
                    Thread currentThread = new Thread(DoRequest);
                    currentThread.Start(connection);//Start thread to DoRequest
                }
            }
            catch (Exception e)
            {
                if(Program.WindowMode == true)
                {
                    MessageBox.Show("ERROR: " + e.ToString() + "\nPlease restart","Server",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                Console.WriteLine("\n\nSERVER: " + e.ToString());
                Console.ReadLine();
            }
        }
        
        public static void IncrementConnectionID()
        {
            ConnectionID++;
            if(Program.WindowMode == true)
            {
                Program.MainForm.SetConnectionNumber(ConnectionID);
            }
        }

        public static void DecrementConnectionID()
        {
            ConnectionID--;
            if(Program.WindowMode == true)
            {
                Program.MainForm.SetConnectionNumber(ConnectionID);
            }
        }

        public static void DoRequest(object argument)
        {
            try
            {
                int threadId = ConnectionID;
                Console.WriteLine("\nSERVER: Connection(" + threadId + ") RECEIVED");
                if (Program.WindowMode == true)//CHECK IF WINDOW MODE
                {
                    Program.MainForm.OutputMessage("Connection(" + threadId + ") RECEIVED");//UPDATE Connection TextBox
                }
                Socket connection = (Socket)argument;
                NetworkStream socketStream = new NetworkStream(connection);
                ///socketStream.ReadTimeout = 1000;//READ TIMEOUT
                ///socketStream.WriteTimeout = 1000;//WRITE TIMEOUT
                while (!socketStream.DataAvailable)
                {
                    Thread.Sleep(1000);//thread sleeps until it receives data
                }
                Request currentRequest = new Request(socketStream);//Create request object to read request
                socketStream.Close();
                connection.Close();//Closes client connection
                DecrementConnectionID();
                Console.WriteLine("SERVER: Connection(" + threadId + ") CLOSED\n\n");
                if (Program.WindowMode == true)//CHECK IF WINDOW MODE
                {
                    Program.MainForm.OutputMessage("Connection(" + threadId + ") CLOSED");//UPDATE output textbox
                }
            }
            catch (Exception e)
            {
                if(Program.WindowMode == true)
                {
                    MessageBox.Show("ERROR: " + e.ToString() + "\nPlease restart", "Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Console.WriteLine("\n\nSERVER: Something went very wrong\nSERVER: " + e.ToString());
            }
        }

        /// <summary>
        /// Creates Location dictionary
        /// </summary>
        public static void InitialiseLocationDictionary()
        {
            UserLocation = new Dictionary<string, string>();
            UserLocation.Add("Sijan", "Cray Lab");
            UserLocation.Add("cssbct", "RB-336");
            if (Program.WindowMode == true)
            {
                Program.MainForm.SetServerData(UserLocation);
            }
        }

        /// <summary>
        /// Updates location from dictionary using name
        /// </summary>
        /// <param name="name">Dictionary key</param>
        /// <param name="newLocation">Dictionary value</param>
        /// <returns>New location</returns>
        public static string UpdateLocation(string name, string newLocation)
        {
            //UPDATE
            if (UserLocation.ContainsKey(name))
            {
                UserLocation.Remove(name);
                UserLocation.Add(name, newLocation.Trim('"'));
                Console.WriteLine("SERVER: LOCATION Updated");
                if (Program.WindowMode == true)//CHECK IF WINDOW MODE
                {
                    Program.MainForm.OutputMessage("LOCATION Updated");//UPDATE output textbox
                }
                return newLocation;
            }
            Console.WriteLine("SERVER: LOCATION NOT FOUND");
            if (Program.WindowMode == true)//CHECK IF WINDOW MODE
            {
                Program.MainForm.OutputMessage("LOCATION NOT FOUND");//UPDATE output textbox
            }
            if (Program.WindowMode == true)//CHECK IF WINDOW MODE
            {
                Program.MainForm.SetServerData(UserLocation);//Update ServerData
            }
            return null;
        }

        /// <summary>
        /// Retrieves location from dictionary using name
        /// </summary>
        /// <param name="name">Dictionary key</param>
        /// <returns>Retrieved location</returns>
        public static string RetrieveLocation(string name)
        {
            //LOOK_UP
            if (UserLocation.ContainsKey(name))
            {
                Console.WriteLine("SERVER: LOCATION Found");
                if (Program.WindowMode == true)//CHECK IF WINDOW MODE
                {
                    Program.MainForm.OutputMessage("LOCATION Found");//UPDATE output textbox
                }
                return UserLocation[name];
            }
            Console.WriteLine("SERVER: LOCATION NOT FOUND");
            if (Program.WindowMode == true)//CHECK IF WINDOW MODE
            {
                Program.MainForm.OutputMessage("LOCATION NOT FOUND");//UPDATE output textbox
            }
            if (Program.WindowMode == true)//CHECK IF WINDOW MODE
            {
                Program.MainForm.SetServerData(UserLocation);//Update ServerData
            }
            return null;
        }
    }
}
