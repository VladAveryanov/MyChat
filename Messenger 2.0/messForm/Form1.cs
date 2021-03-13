using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace messForm
{
    public partial class Form1 : Form
    {
        private Connection client;
        public bool IsConnected = false;

        public Form1()
        {
            InitializeComponent();

            this.FormClosing += Form1_FormClosing;

            client = new Connection();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsConnected)
            {
                client.Disconnect();
            }
        }

        private void Do() 
        {
            while (IsConnected)
            {
                string msg = client.RecieveMessage();
                listBoxMessages.Items.Add(msg);
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (buttonConnect.Text == "Подключиться")
            {
                client.Connect();

                IsConnected = true;
                client.Name = clientName.Text;
                buttonConnect.Text = "Отключиться";

                Task task1 = new Task(Do);
                task1.Start();

            }
            else
            {
                client.Disconnect();
                IsConnected = false;
                buttonConnect.Text = "Подключиться";
            }
        }

        private void sendMsgButton_Click(object sender, EventArgs e)
        {
            string msg = DateTime.Now.ToString() + " " + client.Name + ":" + " " + messagePanel.Text;
            client.SendMessage(msg);
            listBoxMessages.Items.Add(msg);
            messagePanel.Clear();
        }

        private void clientName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void messagePanel_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
