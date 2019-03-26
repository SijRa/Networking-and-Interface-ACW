using System;

namespace WinForm_Client
{
    public class Request
    {
        public Request()
        {
            if (!string.IsNullOrEmpty(Program.Name) && !string.IsNullOrEmpty(Program.NewLocation))
            {
                Program.ProtocolCommand = "POST";
            }
            else if (!string.IsNullOrEmpty(Program.Name))
            {
                Program.ProtocolCommand = "GET";
            }
            //WHOIS Request
            if (Program.ProtocolType != "HTTP")//NOT HTTP
            {
                if (!string.IsNullOrEmpty(Program.Name) && (!string.IsNullOrEmpty(Program.NewLocation)))//POST
                {
                    Program.ProtocolCommand = "POST";
                    Program.sw.Write(Program.Name + " " + Program.NewLocation + "\r" + "\n");
                }
                else if (!string.IsNullOrEmpty(Program.Name) && string.IsNullOrEmpty(Program.NewLocation))//GET
                {
                    Program.ProtocolCommand = "GET";
                    Program.sw.Write(Program.Name + "\r" + "\n");
                }
                else
                {
                    if (Program.WindowMode == true)
                    {
                        Program.MainForm.OutputMessage("ERROR: invalid arguments");
                    }
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
            if (Program.ProtocolVersion == "0.9")//HTTP 0.9
            {
                if (string.IsNullOrEmpty(Program.NewLocation))
                {
                    Program.sw.Write("GET" + " " + "/" + Program.Name + "\r" + "\n");
                }
                else
                {
                    Program.sw.Write("PUT" + " " + "/" + Program.Name + "\r" + "\n");
                    Program.sw.Write("\r" + "\n");
                    Program.sw.Write(Program.NewLocation + "\r" + "\n");
                }
            }
            else if (Program.ProtocolVersion == "1.0")//HTTP 1.0
            {
                if (string.IsNullOrEmpty(Program.NewLocation))
                {
                    Program.sw.Write("GET" + " " + "/" + "?" + Program.Name + " " + "HTTP/1.0" + "\r" + "\n");
                    Program.sw.Write("\r" + "\n");
                }
                else
                {
                    Program.sw.Write("POST" + " " + "/" + Program.Name + " " + "HTTP/1.0" + "\r" + "\n");
                    Program.sw.Write("Content-Length:" + " " + Program.NewLocation.Length.ToString() + "\r" + "\n");
                    Program.sw.Write("\r" + "\n");
                    Program.sw.Write(Program.NewLocation + "\r" + "\n");
                }
            }
            else if (Program.ProtocolVersion == "1.1")//HTTP 1.1
            {
                if (string.IsNullOrEmpty(Program.NewLocation))
                {
                    Program.sw.Write("GET" + " " + "/" + "?" + "name" + "=" + Program.Name + " " + "HTTP/1.1" + "\r" + "\n");
                    Program.sw.Write("Host:" + " " + Program.HostName + "\r" + "\n");
                    Program.sw.Write("\r" + "\n");
                }
                else
                {
                    Program.sw.Write("POST" + " " + "/" + " " + "HTTP/1.1" + "\r" + "\n");
                    Program.sw.Write("Host:" + " " + Program.HostName + "\r" + "\n");
                    Program.sw.Write("Content-Length:" + " " + (Program.Name.Length + Program.NewLocation.Length + 15).ToString() + "\r" + "\n");//15 extra characters include "name=", "&" and "location="
                    Program.sw.Write("\r" + "\n");
                    Program.sw.Write("name" + "=" + Program.Name + "&" + "location" + "=" + Program.NewLocation + "\r" + "\n");
                }
            }
            else
            {
                Console.WriteLine("ERROR: invalid HTTP version");
                if (Program.WindowMode == true)
                {
                    Program.MainForm.OutputMessage("ERROR: invalid HTTP version");
                }
            }
        }
    }
}
