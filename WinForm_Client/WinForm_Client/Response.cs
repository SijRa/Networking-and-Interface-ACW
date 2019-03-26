using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_Client
{
    public class Response
    {
        public Response()
        {
            if (Program.ProtocolType == "HTTP")
            {
                ReadHTTP();
            }
            else
            {
                string serverResponse = Program.sr.ReadLine().Trim();//SERVER RESPONSE
                if (Program.ProtocolCommand == "GET")
                {
                    if (serverResponse != "ERROR: no entries found")
                    {
                        Console.WriteLine(Program.Name + " " + "is" + " " + serverResponse);
                        if(Program.WindowMode == true)
                        {
                            Program.MainForm.OutputMessage(Program.Name + " " + "is" + " " + serverResponse);
                        }
                    }
                    else
                    {
                        Console.WriteLine(serverResponse);
                        if (Program.WindowMode == true)
                        {
                            Program.MainForm.OutputMessage(serverResponse);
                        }
                    }
                }
                else if (Program.ProtocolCommand == "POST")
                {
                    if (serverResponse == "OK")//successfully updated location
                    {
                        Console.WriteLine(Program.Name + " " + "location changed to be" + " " + Program.NewLocation + "\r" + "\n");
                        if (Program.WindowMode == true)
                        {
                            Program.MainForm.OutputMessage(Program.Name + " " + "location changed to be" + " " + Program.NewLocation + "\r" + "\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ERROR: no entries found" + "\r" + "\n");
                        if (Program.WindowMode == true)
                        {
                            Program.MainForm.OutputMessage("ERROR: no entries found" + "\r" + "\n");
                        }
                    }
                }
            }
        }

        protected void ReadHTTP()
        {
            string firstLine = Program.sr.ReadLine();
            string serverCode = firstLine.Split(' ')[1].Trim();
            if (serverCode == "200")//"OK"
            {
                switch (Program.ProtocolVersion)
                {
                    case "0.9":
                        if (Program.ProtocolCommand == "GET")
                        {
                            while (string.IsNullOrEmpty(Program.sr.ReadLine()))
                            {
                                Program.sr.ReadLine();
                            }
                            Program.sr.ReadLine();//empty line
                            string retrievedLocation = Program.sr.ReadLine().Trim();
                            Console.WriteLine(Program.Name + " " + "is" + " " + retrievedLocation);
                            if (Program.WindowMode == true)
                            {
                                Program.MainForm.OutputMessage(Program.Name + " " + "is" + " " + retrievedLocation);
                            }

                        }
                        else if (Program.ProtocolCommand == "POST")
                        {
                            Console.WriteLine(Program.Name + " " + "location changed to be in" + " " + Program.NewLocation);
                            if (Program.WindowMode == true)
                            {
                                Program.MainForm.OutputMessage(Program.Name + " " + "location changed to be in" + " " + Program.NewLocation);
                            }
                        }
                        break;
                    case "1.0":
                        if (Program.ProtocolCommand == "GET")
                        {
                            while (string.IsNullOrEmpty(Program.sr.ReadLine()))
                            {
                                Program.sr.ReadLine();
                            }
                            Program.sr.ReadLine();//empty line
                            string retrievedLocation = Program.sr.ReadLine().Trim();
                            Console.WriteLine(Program.Name + " " + "is" + " " + retrievedLocation);
                            if (Program.WindowMode == true)
                            {
                                Program.MainForm.OutputMessage(Program.Name + " " + "is" + " " + retrievedLocation);
                            }

                        }
                        else if (Program.ProtocolCommand == "POST")
                        {
                            Console.WriteLine(Program.Name + " " + "location changed to be in" + " " + Program.NewLocation);
                            if (Program.WindowMode == true)
                            {
                                Program.MainForm.OutputMessage(Program.Name + " " + "location changed to be in" + " " + Program.NewLocation);
                            }
                        }
                        break;
                    case "1.1":
                        if (Program.ProtocolCommand == "GET")
                        {
                            while (string.IsNullOrEmpty(Program.sr.ReadLine()))
                            {
                                Program.sr.ReadLine();
                            }
                            Program.sr.ReadLine();//empty line
                            string retrievedLocation = Program.sr.ReadLine().Trim();
                            Console.WriteLine(Program.Name + " " + "is" + " " + retrievedLocation);
                            if (Program.WindowMode == true)
                            {
                                Program.MainForm.OutputMessage(Program.Name + " " + "is" + " " + retrievedLocation);
                            }
                        }
                        else if (Program.ProtocolCommand == "POST")
                        {
                            Console.WriteLine(Program.Name + " " + "location changed to be in" + " " + Program.NewLocation);
                            if (Program.WindowMode == true)
                            {
                                Program.MainForm.OutputMessage(Program.Name + " " + "location changed to be in" + " " + Program.NewLocation);
                            }
                        }
                        break;
                }
            }
            else if (serverCode == "404")//"Not Found"
            {
                Console.WriteLine("ERROR: no entries found");
                if (Program.WindowMode == true)
                {
                    Program.MainForm.OutputMessage("ERROR: no entries found");
                }
            }
            else if (serverCode == "301")
            {
                Console.WriteLine(firstLine);
                if (Program.WindowMode == true)
                {
                    Program.MainForm.OutputMessage("ERROR: no entries found");
                }
                while (!string.IsNullOrEmpty(Program.sr.ReadLine()))
                {
                    Console.WriteLine(Program.sr.ReadLine().ToString());
                }
                while (!string.IsNullOrEmpty(Program.sr.ReadLine()))
                {
                    Console.WriteLine(Program.sr.ReadLine().ToString());
                }
            }
        }
    }
}
