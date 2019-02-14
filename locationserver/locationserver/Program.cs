using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace locationserver
{
    class Program
    {
        public static Dictionary<string, string> Location { get; set; }//Dictionary database

        public static string name;
        public static string newLocation;

        static void Main(string[] args)
        {
            Console.WriteLine("\n\nSERVER: Running Server...");
            RunServer();//Start running server
        }

        public static void RunServer()
        {
            TcpListener listener;
            Socket connection;
            NetworkStream socketStream;

            InitialiseLocationDictionary();///intialise dictionary with test data

            try
            {
                Console.WriteLine("\nSERVER: Listening...\n\n");
                listener = new TcpListener(IPAddress.Any, 43);
                listener.Start();//Start listening for client
                while (true)
                {
                    connection = listener.AcceptSocket();//Accepts client connection
                    socketStream = new NetworkStream(connection);
                    Console.WriteLine("\nSERVER: Connection Received");
                    DoRequest(socketStream);//PROCESS REQUEST BY CLIENT
                    socketStream.Close();
                    connection.Close();//Closes client connection
                    Console.WriteLine("SERVER: Connection Closed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\nSERVER: " + e.ToString());
            }
        }

        public static void DoRequest(NetworkStream socketStream)
        {
            try
            {
                socketStream.ReadTimeout = 1000;//READ TIMEOUT
                socketStream.WriteTimeout = 1000;//WRITE TIMEOUT

                Request currentRequest = new Request(socketStream);
                Console.WriteLine("name: " + name + " location: " + newLocation);
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
            Location = new Dictionary<string, string>();
            Location.Add("Sijan", "Cray Lab");
            Location.Add("cssbct", "RB-336");
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

            if (Location.ContainsKey(name))
            {
                Location.Remove(name);
                Location.Add(name, newLocation.Trim('"'));
                Console.WriteLine("SERVER: LOCATION Updated");
                return newLocation;
            }
            Console.WriteLine("SERVER: LOCATION NOT FOUND");
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
            if (Location.ContainsKey(name))
            {
                Console.WriteLine("SERVER: LOCATION Found");
                return Location[name];
            }
            Console.WriteLine("SERVER: LOCATION NOT FOUND");
            return null;
        }
    }
}
