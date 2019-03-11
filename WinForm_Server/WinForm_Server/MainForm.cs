using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net;

namespace WinForm_Server
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Program.MainForm = this;
            Thread serverThread = new Thread(StartServer);
            serverThread.Start();
        }

        public void StartServer()
        {
            Server currentServer = new Server();//Start server class
        }

        private void MainForm_Closing(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public void OutputMessage(string message)
        {
            //OutputTextBox.AppendText(Environment.NewLine + message);
            OutputTextBox.Invoke(new Action(() => OutputTextBox.Text += message + Environment.NewLine));
        }

        public void SetIPAddress(IPAddress _ipAddress)
        {
            IPAddressLabel.Invoke(new Action(() => IPAddressLabel.Text = "IP Address: " + _ipAddress.ToString()));
            //IPAddressLabel.Text = "IP Address: " + _ipAddress.ToString();
        }

        public void SetPortNumber(int _PortNumber)
        {
            PortLabel.Invoke(new Action(() => PortLabel.Text = "Port: " + _PortNumber.ToString()));
            //PortLabel.Text = "Port Number: " + _PortNumber.ToString();
        }

        public void SetConnectionNumber(int _Connections)
        {
            ConnectionsLabel.Invoke(new Action(() => ConnectionsLabel.Text = "Connections: " + _Connections.ToString()));
        }

        public void SetServerStatus(bool _isOnline)
        {
            if(_isOnline)
            {
                StatusLabel.Invoke(new Action(() => StatusLabel.Text = "Status: Online"));
            }
            else
            {
                StatusLabel.Invoke(new Action(() => StatusLabel.Text = "Status: Offline"));
            }
        }
    }
}
