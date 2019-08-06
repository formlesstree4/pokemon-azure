using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mercury.Classes;
using Phoenix.Client;
using Phoenix.Client.EventArgs;

namespace MercuryClientTestProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Client _client = new Client();

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Log(string data)
        {
            listBox1.Items.Add(data);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _client = new Client();
            _client.Connect("127.0.0.1", 2500);
            _client.DataReceived += ClientOnDataReceived;
            _client.ConnectionEstablished += ClientOnConnectionEstablished;
            _client.Disconnected += ClientOnDisconnected;
            _client.Exception += ClientOnException;
        }

        private void ClientOnException(object sender, PhoenixClientExceptionEventArgs phoenixClientExceptionEventArgs)
        {
            Log("exception");
            Log(phoenixClientExceptionEventArgs.Exception.ToString());
            _client.DataReceived -= ClientOnDataReceived;
            _client.ConnectionEstablished -= ClientOnConnectionEstablished;
            _client.Disconnected -= ClientOnDisconnected;
            _client.Exception -= ClientOnException;
        }

        private void ClientOnDisconnected(object sender, EventArgs eventArgs)
        {
            Log("disconnected :(");
            _client.DataReceived -= ClientOnDataReceived;
            _client.ConnectionEstablished -= ClientOnConnectionEstablished;
            _client.Disconnected -= ClientOnDisconnected;
            _client.Exception -= ClientOnException;
        }

        private void ClientOnConnectionEstablished(object sender, EventArgs eventArgs)
        {
            Log("connected...");
        }

        private void ClientOnDataReceived(object sender, PhoenixClientDataReceievedEventArgs phoenixClientDataReceievedEventArgs)
        {
            Log("got data..");
            switch (phoenixClientDataReceievedEventArgs.Data[0])
            {
                case Mercury.Constants.ResponseHeader:

                    var resp = new Response();
                    resp.Initialize(phoenixClientDataReceievedEventArgs.Data);

                    switch(resp.Resp)
                    {
                        case Responses.Connected:
                            Log("sending login information");
                            _client.Send(new Login
                                             {ID = Properties.Settings.Default.Uid, Password = textBox1.Text}.ToByteArray());
                            break;
                    }

                    break;
            }

        }

    }
}
