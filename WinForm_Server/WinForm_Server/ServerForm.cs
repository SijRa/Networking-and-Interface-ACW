using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace WinForm_Server
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
            Program.MainForm = this;
            Thread t = new Thread(StartServer);
            t.Start();
        }

        private void StartServer()
        {
            Server currentServer = new Server();
        }

        private void MainForm_Closing(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public void OutputMessage(string message)
        {
            //OutputTextBox.Text += (message + Environment.NewLine);
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
            //ConnectionsLabel.Text = "Connections: " + _Connections.ToString();
        }

        public void SetServerData(Dictionary<string,string> data)
        {
            ServerDataListBox.Invoke(new Action(() => ServerDataListBox.DataSource = data.ToList()));
            //ServerDataListBox.DataSource = data.ToList();
        }

        public void SetServerStatus(bool _isOnline)
        {
            if (_isOnline)
            {
                StatusLabel.Invoke(new Action(() => StatusLabel.Text = "Status: Online"));
                //StatusLabel.Text = "Status: Online";
            }
            else
            {
                StatusLabel.Invoke(new Action(() => StatusLabel.Text = "Status: Offline"));
                //StatusLabel.Text = "Status: Offline";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = Program.MainForm;
            form.ShowInTaskbar = false;
            form.Opacity = 0;
            Program.ShowConsole();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            string IP;
            string port;
            //textBox1.Invoke(new Action(() => IP = textBox1.Text));
            //textBox2.Invoke(new Action(() => port = textBox2.Text));
            IP = textBox1.Text;
            port = textBox2.Text;
            if (!string.IsNullOrEmpty(IP) && !string.IsNullOrEmpty(port))//When both have values
            {
                string path = "";
                path = Application.ExecutablePath;
                Process newInstance = new Process();
                newInstance.StartInfo.FileName = "locationserver.exe";
                newInstance.StartInfo.UseShellExecute = true;
                newInstance.StartInfo.Arguments = "-h" + IP + "-p" + port;
                newInstance.Start();
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Please enter the both IP address and port number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
