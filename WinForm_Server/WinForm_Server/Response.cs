using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_Server
{
    public class Response
    {
        protected StreamWriter streamWriter;

        public string ProtocolCommand;
        public string ProtocolType;
        public string ProtocolVersion;

        public Response(Request currentRequest)
        {
            ProtocolCommand = currentRequest.ProtocolCommand;
            ProtocolType = currentRequest.ProtocolType;
            ProtocolVersion = currentRequest.ProtocolVersion;

            streamWriter = currentRequest.streamWriter;

            if (ProtocolType == "HTTP")
            {
                SendHTTP(currentRequest.name, currentRequest.newLocation);
            }
            else
            {
                SendWHOIS(currentRequest.name, currentRequest.newLocation);
            }

            streamWriter.Flush();
        }

        protected void SendWHOIS(string name, string newLocation)
        {
            Console.WriteLine("SERVER: Creating WHOIS Response");
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(newLocation))//POST
            {
                string updatedLocation = Server.UpdateLocation(name, newLocation);//UPDATE LOCATION
                if (!string.IsNullOrEmpty(updatedLocation))//New location returned if updated successfully
                {
                    streamWriter.Write("OK" + "\r" + "\n");
                }
                else
                {
                    streamWriter.Write("ERROR: No entries" + "\r" + "\n");
                }
            }
            else if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(newLocation))//GET
            {
                string retrievedLocation = Server.RetrieveLocation(name);//GET Location
                if (!string.IsNullOrEmpty(retrievedLocation))//New location returned
                {
                    streamWriter.Write(retrievedLocation + "\r" + "\n");
                }
                else
                {
                    streamWriter.Write("ERROR: No entries" + "\r" + "\n");
                }
            }
            else
            {
                Console.WriteLine("SERVER: Response NOT SENT");
            }
            Console.WriteLine("SERVER: Response SENT");
        }

        protected void SendHTTP(string name, string newLocation)
        {
            Console.WriteLine("SERVER: Creating HTTP Response");
            switch (ProtocolVersion)
            {
                case "0.9":
                    if (ProtocolCommand == "GET")
                    {
                        string retrievedLocation = Server.RetrieveLocation(name);
                        if (!string.IsNullOrEmpty(retrievedLocation))
                        {
                            streamWriter.Write("HTTP/0.9" + " " + "200" + " " + "OK" + "\r" + "\n");
                            streamWriter.Write("Content-Type:" + " " + "text/plain" + "\r" + "\n");
                            streamWriter.Write("\r" + "\n");
                            streamWriter.Write(retrievedLocation + "\n");
                        }
                        else
                        {
                            //not found
                            streamWriter.Write("HTTP/1.0" + " " + "404" + " " + "Not" + " " + "Found" + "\r" + "\n");
                            streamWriter.Write("Content-Type:" + " " + "text/plain" + "\r" + "\n");
                            streamWriter.Write("\r" + "\n");
                        }
                    }
                    else if (ProtocolCommand == "POST")
                    {
                        string updatedLocation = Server.UpdateLocation(name, newLocation);
                        if (!string.IsNullOrEmpty(updatedLocation))
                        {
                            streamWriter.Write("HTTP/0.9" + " " + "200" + " " + "OK" + "\r" + "\n");
                            streamWriter.Write("Content-Type:" + " " + "text/plain" + "\r" + "\n");
                            streamWriter.Write("\r" + "\n");
                        }
                        else
                        {
                            //not found
                            streamWriter.Write("HTTP/1.0" + " " + "404" + " " + "Not" + " " + "Found" + "\r" + "\n");
                            streamWriter.Write("Content-Type:" + " " + "text/plain" + "\r" + "\n");
                            streamWriter.Write("\r" + "\n");
                        }
                    }
                    break;
                case "1.0":
                    if (ProtocolCommand == "GET")
                    {
                        string retrievedLocation = Server.RetrieveLocation(name);
                        if (!string.IsNullOrEmpty(retrievedLocation))
                        {
                            streamWriter.Write("HTTP/1.0" + " " + "200" + " " + "OK" + "\r" + "\n");
                            streamWriter.Write("Content-Type:" + " " + "text/plain" + "\r" + "\n");
                            streamWriter.Write("\r" + "\n");
                            streamWriter.Write(retrievedLocation + "\r" + "\n");
                        }
                        else
                        {
                            //not found
                            streamWriter.Write("HTTP/1.0" + " " + "404" + " " + "Not" + " " + "Found" + "\r" + "\n");
                            streamWriter.Write("Content-Type:" + " " + "text/plain" + "\r" + "\n");
                            streamWriter.Write("\r" + "\n");
                        }
                    }
                    else if (ProtocolCommand == "POST")
                    {
                        string updatedLocation = Server.UpdateLocation(name, newLocation);
                        if (!string.IsNullOrEmpty(updatedLocation))
                        {
                            streamWriter.Write("HTTP/1.0" + " " + "200" + " " + "OK" + "\r" + "\n");
                            streamWriter.Write("Content-Type:" + " " + "text/plain" + "\r" + "\n");
                            streamWriter.Write("\r" + "\n");
                        }
                        else
                        {
                            //not found
                            streamWriter.Write("HTTP/1.0" + " " + "404" + " " + "Not" + " " + "Found" + "\r" + "\n");
                            streamWriter.Write("Content-Type:" + " " + "text/plain" + "\r" + "\n");
                            streamWriter.Write("\r" + "\n");
                        }
                    }
                    break;
                case "1.1":
                    if (ProtocolCommand == "GET")
                    {
                        string retrievedLocation = Server.RetrieveLocation(name);
                        if (!string.IsNullOrEmpty(retrievedLocation))
                        {
                            streamWriter.Write("HTTP/1.1" + " " + "200" + " " + "OK" + "\r" + "\n");
                            streamWriter.Write("Content-Type:" + " " + "text/plain" + "\r" + "\n");
                            streamWriter.Write("\r" + "\n");
                            streamWriter.Write(retrievedLocation + "\r" + "\n");
                        }
                        else
                        {
                            //not found
                            streamWriter.Write("HTTP/1.1" + " " + "404" + " " + "Not" + " " + "Found" + "\n");
                            streamWriter.Write("Content-Type:" + " " + "text/plain" + "\n");
                            streamWriter.Write("\n");
                        }
                    }
                    else if (ProtocolCommand == "POST")
                    {
                        string updatedLocation = Server.UpdateLocation(name, newLocation);
                        if (!string.IsNullOrEmpty(updatedLocation))
                        {
                            streamWriter.Write("HTTP/1.1" + " " + "200" + " " + "OK" + "\r" + "\n");
                            streamWriter.Write("Content-Type:" + " " + "text/plain" + "\r" + "\n");
                            streamWriter.Write("\r" + "\n");
                        }
                        else
                        {
                            //not found
                            streamWriter.Write("HTTP/1.1" + " " + "404" + " " + "Not" + " " + "Found" + "\n");
                            streamWriter.Write("Content-Type:" + " " + "text/plain" + "\n");
                            streamWriter.Write("\n");
                        }
                    }
                    break;
            }
            streamWriter.Flush();
        }
    }
}
