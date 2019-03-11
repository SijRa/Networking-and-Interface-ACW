using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_Server
{
    public class Request
    {
        public StreamReader streamReader;
        public StreamWriter streamWriter;

        public string name { get; set; }
        public string newLocation { get; set; }

        public string ProtocolCommand;
        public string ProtocolType;
        public string ProtocolVersion;

        public Request(NetworkStream NetworkStream)
        {
            streamReader = new StreamReader(Stream.Synchronized(NetworkStream));
            streamWriter = new StreamWriter(Stream.Synchronized(NetworkStream));
            ReadStream();
        }

        protected void ReadStream()
        {
            string firstLine = streamReader.ReadLine();//First line
            Console.WriteLine("SERVER: " + firstLine);
            if (Program.WindowMode == true)//CHECK IF WINDOW MODE
            {
                Program.MainForm.OutputMessage("First Line: " +firstLine);//UPDATE Connection TextBox
            }
            //PROCESS FIRST LINE HERE
            if (firstLine.Split(' ')[0] == "GET" || firstLine.Split(' ')[0] == "POST" || firstLine.Split(' ')[0] == "PUT")//HTTP REQUEST
            {
                ProtocolType = "HTTP";
                if (firstLine.Split(' ')[0] == "PUT")//HTTP 0.9
                {
                    ProtocolCommand = "POST";//Change PUT to POST
                }
                else
                {
                    ProtocolCommand = firstLine.Split(' ')[0];//SET ProtocolCommand
                    Console.WriteLine("SERVER: Protocol: " + ProtocolCommand);
                    if (Program.WindowMode == true)//CHECK IF WINDOW MODE
                    {
                        Program.MainForm.OutputMessage("Protocol" + ProtocolCommand);//UPDATE Connection TextBox
                    }
                }
                if (firstLine.Split('/').Length == 2)//HTTP 0.9
                {
                    ProtocolVersion = "0.9";
                }
                else//HTTP 1.0 AND HTTP 1.1
                {
                    string ProtocolToken = firstLine.Split(' ')[2].Trim();
                    ProtocolVersion = ProtocolToken.Split('/')[1].Trim();
                }
                ReadRestHTTP(firstLine);//READ REST OF HTTP MESSAGE
            }
            else//WHOIS REQUEST
            {
                ProtocolType = "WHOIS";
                name = firstLine.Split(' ')[0].Trim();
                ProtocolCommand = "GET";
                if (firstLine.Split(' ').Length > 1)
                {
                    ProtocolCommand = "POST";
                    newLocation = firstLine.Split(' ')[1].Trim();
                }
            }
            Response currentResponse = new Response(this);//Create a response object for response
        }

        protected void ReadRestHTTP(string firstLine)
        {
            switch (ProtocolVersion)
            {
                case "0.9":
                    name = firstLine.Split('/')[1].Trim();
                    if (ProtocolCommand == "POST")
                    {
                        while (!string.IsNullOrEmpty(streamReader.ReadLine()))
                        {
                            streamReader.ReadLine();
                        }
                        newLocation = streamReader.ReadLine().Trim();
                    }
                    break;
                case "1.0":
                    name = firstLine.Split(' ')[1].Split('/')[1].Trim();
                    if (ProtocolCommand == "POST")
                    {
                        if (!string.IsNullOrEmpty(streamReader.ReadLine()))
                        {
                            while (!string.IsNullOrEmpty(streamReader.ReadLine()))
                            {
                                Console.WriteLine(streamReader.ReadLine());
                            }
                        }
                        //streamReader.ReadLine();//EMPTY LINE
                        newLocation = streamReader.ReadLine().Trim();
                    }
                    break;
                case "1.1":
                    if (ProtocolCommand == "GET")
                    {
                        name = firstLine.Split(' ')[1].Split('=')[1];
                    }
                    else if (ProtocolCommand == "POST")
                    {
                        while (!string.IsNullOrEmpty(streamReader.ReadLine()))
                        {
                            streamReader.ReadLine();
                        }
                        //streamReader.ReadLine();//empty line
                        string lastLine = streamReader.ReadLine();
                        name = lastLine.Split('&')[0].Split('=')[1];
                        newLocation = lastLine.Split('&')[1].Split('=')[1];
                    }
                    break;
                default:
                    Console.WriteLine("SEVRER: Unsupported protocol version");
                    break;
            }
        }

        public void Output()//Message info
        {
            Console.WriteLine("SERVER: Protocol Command: " + ProtocolCommand);
            Console.WriteLine("SERVER: Protocol Type: " + ProtocolType);
            Console.WriteLine("SERVER: Protocol Version: " + ProtocolVersion);
            if (Program.WindowMode == true)//CHECK IF WINDOW MODE
            {
                Program.MainForm.OutputMessage("Protocol Command: " + ProtocolCommand);//UPDATE Connection TextBox
                Program.MainForm.OutputMessage("Protocol Type: " + ProtocolType);//UPDATE Connection TextBox
                Program.MainForm.OutputMessage("Protocol Version: " + ProtocolVersion);//UPDATE Connection TextBox
            }
        }
    }
}
