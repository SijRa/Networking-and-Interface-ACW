using System;
using System.Windows.Forms;

namespace WinForm_Client
{
    public partial class ClientForm : Form
    {
        static int NumberOfTimesCheckClicked = 0;

        public ClientForm()
        {
            InitializeComponent();
            Program.MainForm = this;
            StartSelection();
        }

        public void OutputMessage(string message)
        {
            if(Program.WindowMode == true)
            {
                OutputTextBox.Text += message + Environment.NewLine;
            }
            else
            {
                Console.WriteLine(message);
            }
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (Program.HostName != TextBoxIP.Text && Program.PortNumber != int.Parse(TextBoxPort.Text))//Adjust to new changes
            {
                Program.ClientTCP.Close();//Close current connection
                Client newClient = new Client();//Start new connection
            }
            if (!Program.ClientTCP.Connected)//If not already connected
            {
                Client client = new Client();
            }
            else
            {
                MessageBox.Show("Hold up" + "\nThe client is already connected!", "Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void StartSelection()
        {
            RadioGet.Select();
            SetLabels();
            GETEnabled();//Default
            ListBoxProtocol.Text = "WHOIS";
        }

        private void SetLabels()
        {
            TextBoxIP.Text = Program.HostName;
            TextBoxPort.Text = Program.PortNumber.ToString();
        }

        private void GETEnabled()
        {
            TextBoxName.Enabled = true;
            TextBoxLocation.Enabled = false;
            Program.ProtocolCommand = "GET";
        }

        private void POSTEnabled()
        {
            TextBoxName.Enabled = true;
            TextBoxLocation.Enabled = true;
            Program.ProtocolCommand = "POST";
        }

        private bool IsServerTextBoxEanbled()
        {
            return TextBoxIP.Enabled && TextBoxPort.Enabled;
        }

        private void RadioGet_CheckedChanged(object sender, EventArgs e)
        {
            GETEnabled();
        }

        private void RadioPost_CheckedChanged(object sender, EventArgs e)
        {
            POSTEnabled();
        }

        private void CheckBoxSever_CheckedChanged(object sender, EventArgs e)
        {
            NumberOfTimesCheckClicked++;
            if (NumberOfTimesCheckClicked % 2 == 0)
            {
                TextBoxIP.Enabled = false;
                TextBoxPort.Enabled = false;
            }
            else
            {
                TextBoxIP.Enabled = true;
                TextBoxPort.Enabled = true;
            }
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            if (!Program.ClientTCP.Connected)
            {
                MessageBox.Show("Ya nearly there pal!" + "\nPlease make sure you're connected first", "Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Request request = new Request();
            }
        }

        private void ButtonConsole_Click(object sender, EventArgs e)
        {
            var form = Program.MainForm;
            form.ShowInTaskbar = false;
            form.Opacity = 0;
            ConsoleMethods.ShowConsoleWindow();
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            Program.Name = TextBoxName.Text;
        }

        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            Program.NewLocation = TextBoxLocation.Text;
        }
    }
}
