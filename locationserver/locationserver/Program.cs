using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace locationserver
{
    class Program
    {
        static int ConnectionID;
        public static Dictionary<string, string> UserLocation { get; set; }//Dictionary database

        static void Main(string[] args)
        {
            Console.WriteLine("\n\nSERVER: Running Server...");
            RunServer();//Start running server
        }

        public static void RunServer()
        {
            TcpListener listener;
            Socket connection;

            InitialiseLocationDictionary();///intialise dictionary with test data
            ConnectionID = 0;//initialise connection ID

            try
            {
                Console.WriteLine("\nSERVER: Listening...\n\n");
                listener = new TcpListener(IPAddress.Any, 43);
                listener.Start();//Start listening for client
                while (true)
                {
                    connection = listener.AcceptSocket();//Accepts client connection
                    ConnectionID++;
                    Thread currentThread = new Thread(DoRequest);
                    currentThread.Start(connection);//Start thread to DoRequest
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\nSERVER: " + e.ToString());
            }
        }

        public static void DoRequest(object argument)
        {
            try
            {
                int threadId = ConnectionID;
                Console.WriteLine("\nSERVER: Connection(" + threadId + ") RECEIVED");
                Socket connection = (Socket)argument;
                NetworkStream socketStream = new NetworkStream(connection);
                //socketStream.ReadTimeout = 10000;//READ TIMEOUT
                //socketStream.WriteTimeout = 10000;//WRITE TIMEOUT
                while(!socketStream.DataAvailable)
                {
                    Thread.Sleep(1000);//thread sleeps until it receives data
                }
                Request currentRequest = new Request(socketStream);//Create request object to read request
                socketStream.Close();
                connection.Close();//Closes client connection
                ConnectionID--;
                Console.WriteLine("SERVER: Connection("  + threadId + ") CLOSED\n\n");
            }
            catch (Exception e)
            {
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
            //UserLocation.Add("554282", "Dover");
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
                return newLocation;
            }
            else
            {
                UserLocation.Add(name, newLocation);
                Console.WriteLine("SERVER: NAME: " + name + "\nSERVER: LOCATION: " + newLocation);
                return newLocation;
            }
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
                return UserLocation[name];
            }
            Console.WriteLine("SERVER: LOCATION NOT FOUND");
            return null;
        }
    }
}
