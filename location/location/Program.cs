using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace location
{
    class Program
    {
        static string name;
        static string location;

        static string ProtocolCommand;
        static string ProtocolType;
        static string ProtocolVersion;

        static void Main(string[] args)
        {
            try
            {
                string name = null;
                string location = null;
                string hostName = "whois.net.dcs.hull.ac.uk";//Default host
                int port = 43;//Default port
                ProtocolType = "WHOIS";//Default protocol
                TcpClient client = new TcpClient();
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
                    name = nameLocation.Split(' ')[0];//Name extraction
                    location = nameLocation.Split(' ')[1];//Location extraction
                    if(string.IsNullOrEmpty(name))//Name needs to be provided whether GET or SET
                    {
                        throw new Exception("Name not provided as default argument");
                    }
                }
                client.Connect(hostName, port);//Establish connection
                Console.WriteLine("Connected to " + hostName);
                OutputSettings();//Print current configuration
                string userInput = Console.ReadLine().Trim();//Read user input and clear leading and trailing whitespace
                if(!string.IsNullOrEmpty(userInput.Split(' ')[1]))//Check if location exists
                {
                    location = userInput.Split(' ')[1];//Set location
                }
                name = userInput.Split(' ')[0];//Set name
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void OutputSettings()
        {
            Console.WriteLine("Protcol Type: " + ProtocolType);
            if(ProtocolVersion != null)//Checks for value
            {
                Console.WriteLine("Protocol Version: " + ProtocolVersion);//Output version if it has a value
            }
            Console.WriteLine("\n");//Double line skip
        }
    }
}
