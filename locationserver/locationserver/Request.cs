using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;


namespace locationserver
{
    public class Request
    {
        NetworkStream networkStream;

        protected string ProtocolCommand = null;
        protected string ProtocolType = null;
        protected string ProtocolVersion = null;

        public Request(NetworkStream networkStream)
        {
            this.networkStream = networkStream;
            StreamReader streamReader = new StreamReader(networkStream);
            ReadStream(streamReader);
        }

        public void ReadStream(StreamReader streamReader)
        {
            int tokenCount = 0;//Lines left to read
            string firstToken = streamReader.ReadLine();//First line
            Console.WriteLine("SERVER: " + firstToken);
            if(firstToken.Split('/')[0] != null)
            {
                ProtocolType = "HTTP";
                ProtocolCommand = firstToken.Split(' ')[0].Trim();//Protocol Command SET
                if(ProtocolCommand == "PUT")
                {
                    ProtocolCommand = "POST";//HTTP PUT --> POST
                }
                if(firstToken.Split('/')[2] != null)
                {
                    ProtocolVersion = firstToken.Split('/')[2].Trim();//Protocol Version SET
                    if(ProtocolVersion == "1.0")
                    {
                        Program.name = firstToken.Split(' ')[1].Split('/')[1];//HTTP 1.0 name SET
                    }
                }
                else
                {
                    ProtocolVersion = "0.9";
                    Program.name = firstToken.Split('/')[1].Trim();//HTTP 0.9 name SET
                }
            }
            else
            {
                ProtocolType = "WHOIS";
                if(firstToken.Split(' ')[1] != null)
                {
                    ProtocolCommand = "POST";
                    Program.newLocation = firstToken.Split(' ')[1];//WHOIS newLocation SET
                }
                else
                {
                    ProtocolCommand = "GET";
                }
                Program.name = firstToken.Split(' ')[0].Trim();//WHOIS name SET;
            }
            if(ProtocolVersion != null && ProtocolVersion != "0.9")
            {
                //Lines to be 'ignored'
                if(ProtocolCommand == "GET")
                {
                    if(ProtocolVersion == "1.0")
                    {
                        tokenCount = 1;//Additional line to be read
                    }
                    else if(ProtocolVersion == "1.1")
                    {
                        tokenCount = 2;//Two lines to be read
                    }
                    else
                    {
                        //PROTOCOL VERSION ERROR
                    }
                }
                else//POST
                {
                    if (ProtocolVersion == "1.0")
                    {
                        tokenCount = 2;//Additional line to be read
                    }
                    else if (ProtocolVersion == "1.1")
                    {
                        tokenCount = 3;//Two lines to be read
                    }
                    else
                    {
                        //PROTOCOL VERSION ERROR
                    }
                }
            }


            ///html 1.0 doesnt go through this point
            if(ProtocolType == "HTTP")
            {
                for (int i = 0; i < tokenCount; i++)//Tokens to be read
                {
                    streamReader.ReadLine();//SKIP LINES
                }
                if(ProtocolType == "POST")
                {

                    string lastLine = streamReader.ReadLine();
                    if (ProtocolVersion == "1.1")
                    {
                        Program.name = lastLine.Split('&')[0].Split('=')[1];//HTTP 1.1 name SET
                        Program.newLocation = lastLine.Split('&')[1].Split('=')[1];//HTTP 1.1 newLocation SET
                    }
                    else
                    {
                        Program.newLocation = lastLine.Trim();//HTTP 0.9 HTTP 1.0 newLocation SET
                    }
                }
            }
        }

    }
}
