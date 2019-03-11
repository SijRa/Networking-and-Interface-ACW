namespace WinForm_Server
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ConsoleModeButton = new System.Windows.Forms.Button();
            this.OutputTextBox = new System.Windows.Forms.RichTextBox();
            this.NameTab1Label = new System.Windows.Forms.Label();
            this.ModuleNumberLabel = new System.Windows.Forms.Label();
            this.ModuleLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.IPAddressLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.ConnectionsLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RightTab1Label = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ServerDataListBox = new System.Windows.Forms.ListBox();
            this.SettingsLabel = new System.Windows.Forms.Label();
            this.NameTab2Label = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.IPAddressChangeLabel = new System.Windows.Forms.Label();
            this.PortNumberChangeLabel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.SERVER = new System.Windows.Forms.Label();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(339, 297);
            this.TabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.ConsoleModeButton);
            this.tabPage1.Controls.Add(this.OutputTextBox);
            this.tabPage1.Controls.Add(this.NameTab1Label);
            this.tabPage1.Controls.Add(this.ModuleNumberLabel);
            this.tabPage1.Controls.Add(this.ModuleLabel);
            this.tabPage1.Controls.Add(this.StatusLabel);
            this.tabPage1.Controls.Add(this.IPAddressLabel);
            this.tabPage1.Controls.Add(this.PortLabel);
            this.tabPage1.Controls.Add(this.ConnectionsLabel);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.RightTab1Label);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(331, 271);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Server";
            // 
            // ConsoleModeButton
            // 
            this.ConsoleModeButton.Location = new System.Drawing.Point(207, 204);
            this.ConsoleModeButton.Name = "ConsoleModeButton";
            this.ConsoleModeButton.Size = new System.Drawing.Size(92, 23);
            this.ConsoleModeButton.TabIndex = 11;
            this.ConsoleModeButton.Text = "Console Mode";
            this.ConsoleModeButton.UseVisualStyleBackColor = true;
            this.ConsoleModeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.BackColor = System.Drawing.Color.White;
            this.OutputTextBox.Location = new System.Drawing.Point(22, 65);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.Size = new System.Drawing.Size(141, 167);
            this.OutputTextBox.TabIndex = 10;
            this.OutputTextBox.Text = "";
            // 
            // NameTab1Label
            // 
            this.NameTab1Label.AutoSize = true;
            this.NameTab1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTab1Label.Location = new System.Drawing.Point(253, 250);
            this.NameTab1Label.Name = "NameTab1Label";
            this.NameTab1Label.Size = new System.Drawing.Size(70, 13);
            this.NameTab1Label.TabIndex = 9;
            this.NameTab1Label.Text = "SIJAN RANA";
            // 
            // ModuleNumberLabel
            // 
            this.ModuleNumberLabel.AutoSize = true;
            this.ModuleNumberLabel.Location = new System.Drawing.Point(19, 26);
            this.ModuleNumberLabel.Name = "ModuleNumberLabel";
            this.ModuleNumberLabel.Size = new System.Drawing.Size(43, 13);
            this.ModuleNumberLabel.TabIndex = 8;
            this.ModuleNumberLabel.Text = "500081";
            // 
            // ModuleLabel
            // 
            this.ModuleLabel.AutoSize = true;
            this.ModuleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModuleLabel.Location = new System.Drawing.Point(19, 13);
            this.ModuleLabel.Name = "ModuleLabel";
            this.ModuleLabel.Size = new System.Drawing.Size(284, 13);
            this.ModuleLabel.TabIndex = 7;
            this.ModuleLabel.Text = "NETWORKING AND USER INTERFACE DESIGN";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(196, 91);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(40, 13);
            this.StatusLabel.TabIndex = 5;
            this.StatusLabel.Text = "Status:";
            // 
            // IPAddressLabel
            // 
            this.IPAddressLabel.AutoSize = true;
            this.IPAddressLabel.Location = new System.Drawing.Point(196, 118);
            this.IPAddressLabel.Name = "IPAddressLabel";
            this.IPAddressLabel.Size = new System.Drawing.Size(61, 13);
            this.IPAddressLabel.TabIndex = 4;
            this.IPAddressLabel.Text = "IP Address:";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(196, 136);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(29, 13);
            this.PortLabel.TabIndex = 3;
            this.PortLabel.Text = "Port:";
            // 
            // ConnectionsLabel
            // 
            this.ConnectionsLabel.AutoSize = true;
            this.ConnectionsLabel.Location = new System.Drawing.Point(196, 72);
            this.ConnectionsLabel.Name = "ConnectionsLabel";
            this.ConnectionsLabel.Size = new System.Drawing.Size(69, 13);
            this.ConnectionsLabel.TabIndex = 2;
            this.ConnectionsLabel.Text = "Connections:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(10, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 193);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Log";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(173, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 108);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // RightTab1Label
            // 
            this.RightTab1Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RightTab1Label.Location = new System.Drawing.Point(193, 68);
            this.RightTab1Label.Name = "RightTab1Label";
            this.RightTab1Label.Size = new System.Drawing.Size(118, 92);
            this.RightTab1Label.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(183, 50);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(140, 123);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Information";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(196, 187);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(112, 48);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Change Mode";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.ServerDataListBox);
            this.tabPage2.Controls.Add(this.SettingsLabel);
            this.tabPage2.Controls.Add(this.NameTab2Label);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.SERVER);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(331, 271);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Others";
            // 
            // ServerDataListBox
            // 
            this.ServerDataListBox.FormattingEnabled = true;
            this.ServerDataListBox.Location = new System.Drawing.Point(59, 152);
            this.ServerDataListBox.Name = "ServerDataListBox";
            this.ServerDataListBox.Size = new System.Drawing.Size(161, 95);
            this.ServerDataListBox.TabIndex = 21;
            // 
            // SettingsLabel
            // 
            this.SettingsLabel.AutoSize = true;
            this.SettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsLabel.Location = new System.Drawing.Point(253, 29);
            this.SettingsLabel.Name = "SettingsLabel";
            this.SettingsLabel.Size = new System.Drawing.Size(69, 13);
            this.SettingsLabel.TabIndex = 20;
            this.SettingsLabel.Text = "SETTINGS";
            // 
            // NameTab2Label
            // 
            this.NameTab2Label.AutoSize = true;
            this.NameTab2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTab2Label.Location = new System.Drawing.Point(253, 250);
            this.NameTab2Label.Name = "NameTab2Label";
            this.NameTab2Label.Size = new System.Drawing.Size(70, 13);
            this.NameTab2Label.TabIndex = 10;
            this.NameTab2Label.Text = "SIJAN RANA";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.IPAddressChangeLabel);
            this.groupBox5.Controls.Add(this.PortNumberChangeLabel);
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Location = new System.Drawing.Point(40, 15);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(198, 113);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Server Configuration";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(91, 80);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Change";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // IPAddressChangeLabel
            // 
            this.IPAddressChangeLabel.AutoSize = true;
            this.IPAddressChangeLabel.Location = new System.Drawing.Point(14, 25);
            this.IPAddressChangeLabel.Name = "IPAddressChangeLabel";
            this.IPAddressChangeLabel.Size = new System.Drawing.Size(58, 13);
            this.IPAddressChangeLabel.TabIndex = 0;
            this.IPAddressChangeLabel.Text = "IP Address";
            // 
            // PortNumberChangeLabel
            // 
            this.PortNumberChangeLabel.AutoSize = true;
            this.PortNumberChangeLabel.Location = new System.Drawing.Point(6, 51);
            this.PortNumberChangeLabel.Name = "PortNumberChangeLabel";
            this.PortNumberChangeLabel.Size = new System.Drawing.Size(66, 13);
            this.PortNumberChangeLabel.TabIndex = 3;
            this.PortNumberChangeLabel.Text = "Port Number";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(78, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            // 
            // groupBox7
            // 
            this.groupBox7.Location = new System.Drawing.Point(45, 131);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(188, 129);
            this.groupBox7.TabIndex = 22;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Server Data";
            // 
            // SERVER
            // 
            this.SERVER.AutoSize = true;
            this.SERVER.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SERVER.Location = new System.Drawing.Point(253, 12);
            this.SERVER.Name = "SERVER";
            this.SERVER.Size = new System.Drawing.Size(69, 18);
            this.SERVER.TabIndex = 23;
            this.SERVER.Text = "SERVER";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 321);
            this.Controls.Add(this.TabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Server";
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label RightTab1Label;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label ConnectionsLabel;
        private System.Windows.Forms.Label IPAddressLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label PortNumberChangeLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label IPAddressChangeLabel;
        private System.Windows.Forms.Label ModuleLabel;
        private System.Windows.Forms.Label NameTab1Label;
        private System.Windows.Forms.Label ModuleNumberLabel;
        private System.Windows.Forms.Label NameTab2Label;
        private System.Windows.Forms.RichTextBox OutputTextBox;
        private System.Windows.Forms.Button ConsoleModeButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label SettingsLabel;
        private System.Windows.Forms.ListBox ServerDataListBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label SERVER;
        private System.Windows.Forms.Button button5;
    }
}

