namespace WinForm_Client
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.LabelName = new System.Windows.Forms.Label();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.TextBoxLocation = new System.Windows.Forms.TextBox();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.ListBoxProtocol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.CheckBoxSever = new System.Windows.Forms.CheckBox();
            this.RadioPost = new System.Windows.Forms.RadioButton();
            this.RadioGet = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxPort = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OutputTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ModuleLabel = new System.Windows.Forms.Label();
            this.ModuleNumberLabel = new System.Windows.Forms.Label();
            this.NameTab1Label = new System.Windows.Forms.Label();
            this.SettingsLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ButtonConsole = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(38, 90);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(35, 13);
            this.LabelName.TabIndex = 0;
            this.LabelName.Text = "Name";
            // 
            // TextBoxName
            // 
            this.TextBoxName.BackColor = System.Drawing.SystemColors.Window;
            this.TextBoxName.Location = new System.Drawing.Point(79, 87);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(100, 20);
            this.TextBoxName.TabIndex = 1;
            this.TextBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
            // 
            // LabelPassword
            // 
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.Location = new System.Drawing.Point(25, 122);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(48, 13);
            this.LabelPassword.TabIndex = 2;
            this.LabelPassword.Text = "Location";
            // 
            // TextBoxLocation
            // 
            this.TextBoxLocation.Location = new System.Drawing.Point(79, 119);
            this.TextBoxLocation.Name = "TextBoxLocation";
            this.TextBoxLocation.Size = new System.Drawing.Size(100, 20);
            this.TextBoxLocation.TabIndex = 3;
            this.TextBoxLocation.TextChanged += new System.EventHandler(this.TextBoxPassword_TextChanged);
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Location = new System.Drawing.Point(126, 182);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(75, 23);
            this.ButtonConnect.TabIndex = 4;
            this.ButtonConnect.Text = "Connect";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            this.ButtonConnect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // ListBoxProtocol
            // 
            this.ListBoxProtocol.BackColor = System.Drawing.SystemColors.Window;
            this.ListBoxProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListBoxProtocol.FormattingEnabled = true;
            this.ListBoxProtocol.Items.AddRange(new object[] {
            "WHOIS",
            "HTTP/0.9",
            "HTTP/1.0",
            "HTTP/1.1"});
            this.ListBoxProtocol.Location = new System.Drawing.Point(58, 52);
            this.ListBoxProtocol.Name = "ListBoxProtocol";
            this.ListBoxProtocol.Size = new System.Drawing.Size(121, 21);
            this.ListBoxProtocol.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Protocol";
            // 
            // TextBoxIP
            // 
            this.TextBoxIP.Enabled = false;
            this.TextBoxIP.Location = new System.Drawing.Point(21, 46);
            this.TextBoxIP.Name = "TextBoxIP";
            this.TextBoxIP.Size = new System.Drawing.Size(100, 20);
            this.TextBoxIP.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "IP Address";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ButtonSend);
            this.groupBox1.Controls.Add(this.CheckBoxSever);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.RadioPost);
            this.groupBox1.Controls.Add(this.ButtonConnect);
            this.groupBox1.Controls.Add(this.ListBoxProtocol);
            this.groupBox1.Controls.Add(this.RadioGet);
            this.groupBox1.Controls.Add(this.TextBoxLocation);
            this.groupBox1.Controls.Add(this.TextBoxName);
            this.groupBox1.Controls.Add(this.LabelPassword);
            this.groupBox1.Controls.Add(this.LabelName);
            this.groupBox1.Location = new System.Drawing.Point(16, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 219);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request Details";
            // 
            // ButtonSend
            // 
            this.ButtonSend.Location = new System.Drawing.Point(32, 182);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(75, 23);
            this.ButtonSend.TabIndex = 16;
            this.ButtonSend.Text = "Send";
            this.ButtonSend.UseVisualStyleBackColor = true;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // CheckBoxSever
            // 
            this.CheckBoxSever.AutoSize = true;
            this.CheckBoxSever.Location = new System.Drawing.Point(28, 154);
            this.CheckBoxSever.Name = "CheckBoxSever";
            this.CheckBoxSever.Size = new System.Drawing.Size(173, 17);
            this.CheckBoxSever.TabIndex = 15;
            this.CheckBoxSever.Text = "Change SERVER Connnection";
            this.CheckBoxSever.UseVisualStyleBackColor = true;
            this.CheckBoxSever.CheckedChanged += new System.EventHandler(this.CheckBoxSever_CheckedChanged);
            // 
            // RadioPost
            // 
            this.RadioPost.AutoSize = true;
            this.RadioPost.Location = new System.Drawing.Point(118, 24);
            this.RadioPost.Name = "RadioPost";
            this.RadioPost.Size = new System.Drawing.Size(113, 17);
            this.RadioPost.TabIndex = 14;
            this.RadioPost.TabStop = true;
            this.RadioPost.Text = "UPDATE Location";
            this.RadioPost.UseVisualStyleBackColor = true;
            this.RadioPost.CheckedChanged += new System.EventHandler(this.RadioPost_CheckedChanged);
            // 
            // RadioGet
            // 
            this.RadioGet.AutoSize = true;
            this.RadioGet.Location = new System.Drawing.Point(21, 24);
            this.RadioGet.Name = "RadioGet";
            this.RadioGet.Size = new System.Drawing.Size(91, 17);
            this.RadioGet.TabIndex = 13;
            this.RadioGet.TabStop = true;
            this.RadioGet.Text = "GET Location";
            this.RadioGet.UseVisualStyleBackColor = true;
            this.RadioGet.CheckedChanged += new System.EventHandler(this.RadioGet_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Port";
            // 
            // TextBoxPort
            // 
            this.TextBoxPort.Enabled = false;
            this.TextBoxPort.Location = new System.Drawing.Point(21, 88);
            this.TextBoxPort.Name = "TextBoxPort";
            this.TextBoxPort.Size = new System.Drawing.Size(100, 20);
            this.TextBoxPort.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TextBoxPort);
            this.groupBox2.Controls.Add(this.TextBoxIP);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(270, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 135);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Details";
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.OutputTextBox.Location = new System.Drawing.Point(270, 192);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.Size = new System.Drawing.Size(140, 117);
            this.OutputTextBox.TabIndex = 13;
            this.OutputTextBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(340, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "CLIENT";
            // 
            // ModuleLabel
            // 
            this.ModuleLabel.AutoSize = true;
            this.ModuleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModuleLabel.Location = new System.Drawing.Point(22, 14);
            this.ModuleLabel.Name = "ModuleLabel";
            this.ModuleLabel.Size = new System.Drawing.Size(284, 13);
            this.ModuleLabel.TabIndex = 15;
            this.ModuleLabel.Text = "NETWORKING AND USER INTERFACE DESIGN";
            // 
            // ModuleNumberLabel
            // 
            this.ModuleNumberLabel.AutoSize = true;
            this.ModuleNumberLabel.Location = new System.Drawing.Point(22, 25);
            this.ModuleNumberLabel.Name = "ModuleNumberLabel";
            this.ModuleNumberLabel.Size = new System.Drawing.Size(43, 13);
            this.ModuleNumberLabel.TabIndex = 16;
            this.ModuleNumberLabel.Text = "500081";
            // 
            // NameTab1Label
            // 
            this.NameTab1Label.AutoSize = true;
            this.NameTab1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTab1Label.Location = new System.Drawing.Point(335, 325);
            this.NameTab1Label.Name = "NameTab1Label";
            this.NameTab1Label.Size = new System.Drawing.Size(70, 13);
            this.NameTab1Label.TabIndex = 17;
            this.NameTab1Label.Text = "SIJAN RANA";
            // 
            // SettingsLabel
            // 
            this.SettingsLabel.AutoSize = true;
            this.SettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsLabel.Location = new System.Drawing.Point(338, 26);
            this.SettingsLabel.Name = "SettingsLabel";
            this.SettingsLabel.Size = new System.Drawing.Size(69, 13);
            this.SettingsLabel.TabIndex = 21;
            this.SettingsLabel.Text = "SETTINGS";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ButtonConsole);
            this.groupBox3.Location = new System.Drawing.Point(16, 267);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(239, 55);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Switch Mode";
            // 
            // ButtonConsole
            // 
            this.ButtonConsole.Location = new System.Drawing.Point(88, 19);
            this.ButtonConsole.Name = "ButtonConsole";
            this.ButtonConsole.Size = new System.Drawing.Size(75, 23);
            this.ButtonConsole.TabIndex = 0;
            this.ButtonConsole.Text = "Console";
            this.ButtonConsole.UseVisualStyleBackColor = true;
            this.ButtonConsole.Click += new System.EventHandler(this.ButtonConsole_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 346);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.SettingsLabel);
            this.Controls.Add(this.NameTab1Label);
            this.Controls.Add(this.ModuleNumberLabel);
            this.Controls.Add(this.ModuleLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientForm";
            this.Text = "Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.Label LabelPassword;
        private System.Windows.Forms.TextBox TextBoxLocation;
        private System.Windows.Forms.Button ButtonConnect;
        private System.Windows.Forms.ComboBox ListBoxProtocol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CheckBoxSever;
        private System.Windows.Forms.RadioButton RadioPost;
        private System.Windows.Forms.RadioButton RadioGet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxPort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox OutputTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ModuleLabel;
        private System.Windows.Forms.Label ModuleNumberLabel;
        private System.Windows.Forms.Label NameTab1Label;
        private System.Windows.Forms.Label SettingsLabel;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ButtonConsole;
    }
}

