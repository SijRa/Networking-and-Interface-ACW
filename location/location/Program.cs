using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace location
{
    class Program
    {
        public static string hostName;

        public static string name;
        public static string newLocation;

        public static string ProtocolCommand;
        public static string ProtocolType;
        public static string ProtocolVersion;

        public static StreamReader sr;
        public static StreamWriter sw;

        public static TcpClient client;

        static void Main(string[] args)
        {
            try
            {
                name = null;
                newLocation = null;
                //uni address whois.net.dcs.hull.ac.uk
                hostName = "localhost";//Default host
                int port = 43;//Default port
                ProtocolType = "WHOIS";//Default protocol
                client = new TcpClient();
                if (args.Length != 0)//Check for user-entered connection settings
                {
                    string nameLocation = "";//String to contain name and location
                    for (int i = 0; i < args.Length; i++)
                    {
                        switch (args[i])
                        {
                            case "-h"://Host
                                hostName = args[i + 1];
                                args[i] = null;
                                args[i + 1] = null;
                                break;
                            case "-p"://Port number
                                port = int.Parse(args[i + 1]);
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
                            default:
                                if (args[i] != null)
                                {
                                    nameLocation += args[i].ToString() + " ";//string containing name and location separated by space
                                }
                                break;
                        }
                    }
                    name = nameLocation.Split(' ')[0].Trim();//Name extraction
                    if(nameLocation.Split(' ').Length > 1)
                    {
                        newLocation = nameLocation.Substring(name.Length).Trim();//Location extraction
                    }
                    if(string.IsNullOrEmpty(name))//Name needs to be provided whether GET or SET
                    {
                        throw new Exception("Name not provided as default argument");
                    }
                }
                else
                {
                    client.Connect(hostName, port);//Establish connection
                    OutputSettings();//Print current configuration
                    Console.WriteLine("Connected to " + hostName + "\n");
                    string userInput = Console.ReadLine().Trim();//Read user input and clear leading and trailing whitespace
                    if (userInput.Split(' ').Length > 1)//Check if location exists
                    {
                        newLocation = userInput.Split(' ')[1];//Set location
                    }
                    name = userInput.Split(' ')[0];//Set name
                }
                if(!client.Connected)
                {
                    client.Connect(hostName, port);//Connect if not connected
                }
                NetworkStream NetworkStream = client.GetStream();//NetworkStream to instantiate..
                //NetworkStream.ReadTimeout = 10000;
                //NetworkStream.WriteTimeout = 10000;
                sr = new StreamReader(NetworkStream);//Stream Reader
                sw = new StreamWriter(NetworkStream);//Stream Writer
                Request currentRequest = new Request();//CREATE REQUEST OBJECT
                //Console.Write("Press any key to continue . . .");//LOL
                client.Dispose();
                //Console.ReadKey();//PAUSE
            }
            catch(IOException)
            {
                Console.WriteLine("ERROR: StreamReader/Writer timed out");
            }
            catch(Exception e)
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
            if(ProtocolVersion != null)//Checks for value
            {
                Console.WriteLine("Protocol Version: " + ProtocolVersion);//Output version if it has a value
            }
        }
    }
}
