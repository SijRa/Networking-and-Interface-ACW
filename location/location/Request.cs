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
    public class Request
    {
        public Request()
        {
            if(!string.IsNullOrEmpty(Program.name)&&!string.IsNullOrEmpty(Program.newLocation))
            {
                Program.ProtocolCommand = "POST";
            }
            else if(!string.IsNullOrEmpty(Program.name))
            {
                Program.ProtocolCommand = "GET";
            }
            //WHOIS Request
            if(Program.ProtocolType != "HTTP")//NOT HTTP
            {
                if (!string.IsNullOrEmpty(Program.name) && (!string.IsNullOrEmpty(Program.newLocation)))//POST
                {
                    Program.ProtocolCommand = "POST";
                    Program.sw.Write(Program.name + " " + Program.newLocation + "\r" + "\n");
                }
                else if (!string.IsNullOrEmpty(Program.name) && string.IsNullOrEmpty(Program.newLocation))//GET
                {
                    Program.ProtocolCommand = "GET";
                    Program.sw.Write(Program.name + "\r" + "\n");
                }
                else
                {
                    Console.WriteLine("ERROR: invalid arguments");
                }
            }
            else
            {
                //HTTP Request
                SendHTTP();
            }
            Program.sw.Flush();
            Response currentResponse = new Response();//CREATE RESPONSE OBJECT
        }

        protected void SendHTTP()
        {
            if(Program.ProtocolVersion == "0.9")//HTTP 0.9
            {
                if(string.IsNullOrEmpty(Program.newLocation))
                {
                    Program.sw.Write("GET" + " " + "/" + Program.name + "\r" + "\n");
                }
                else
                {
                    Program.sw.Write("PUT" + " " + "/" + Program.name + "\r" + "\n");
                    Program.sw.Write("\r" + "\n");
                    Program.sw.Write(Program.newLocation + "\r" + "\n");
                }
            }
            else if(Program.ProtocolVersion == "1.0")//HTTP 1.0
            {
                if (string.IsNullOrEmpty(Program.newLocation))
                {
                    Program.sw.Write("GET" + " " + "/" + "?" + Program.name + " " + "HTTP/1.0" + "\r" + "\n");
                    Program.sw.Write("\r" + "\n");
                }
                else
                {
                    Program.sw.Write("POST" + " " + "/" + Program.name + " " + "HTTP/1.0" + "\r" + "\n");
                    Program.sw.Write("Content-Length:" + " " + "0" + "\r" + "\n");
                    Program.sw.Write("\r" + "\n");
                    Program.sw.Write(Program.newLocation + "\r" + "\n");
                }
            }
            else if(Program.ProtocolVersion == "1.1")//HTTP 1.1
            {
                if (string.IsNullOrEmpty(Program.newLocation))
                {
                    Program.sw.Write("GET" + " " + "/" + "?" + "name" + "=" + Program.name + " " + "HTTP/1.1" + "\r" + "\n");
                    Program.sw.Write("Host:" + " " + Program.hostName + "\r" + "\n");
                    Program.sw.Write("\r" + "\n");
                }
                else
                {
                    Program.sw.Write("POST" + " " + "/" + " " + "HTTP/1.1" + "\r" + "\n");
                    Program.sw.Write("Host:" + " " + Program.hostName + "\r" + "\n");
                    Program.sw.Write("Content-Length:" + " " + "0" + "\r" + "\n");
                    Program.sw.Write("\r" + "\n");
                    Program.sw.Write("name" + "=" + Program.name + "&" + "location" + "=" + Program.newLocation + "\r" + "\n");
                }
            }
            else
            {
                Console.WriteLine("ERROR: invalid HTTP version");
            }
        }
    }
}
