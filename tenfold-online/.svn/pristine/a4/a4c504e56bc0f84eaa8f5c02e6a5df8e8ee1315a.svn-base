using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MercuryServer
{
    public partial class Form1 : Form
    {

        Mercury.Mercury _server = new Mercury.Mercury(2500);

        public Form1()
        {
            InitializeComponent();

            _server.Output += new Mercury.Mercury.MercuryConsoleOutput(_server_Output);
            _server.Error += new Mercury.Mercury.MercuryErrorOutput(_server_Error);

        }

        void _server_Error(Mercury.MercuryErrorEventArgs error)
        {
            listBox1.Invoke(new Action(delegate { listBox1.Items.Add(error.Message); listBox1.SelectedIndex = listBox1.Items.Count - 1; }));
            listBox1.Invoke(new Action(delegate { listBox1.Items.Add(error.Exception.ToString()); listBox1.SelectedIndex = listBox1.Items.Count - 1; }));
        }

        void _server_Output(Mercury.MercuryOutputEventArgs output)
        {
            listBox1.Invoke(new Action(delegate { listBox1.Items.Add(output.Output); listBox1.SelectedIndex = listBox1.Items.Count - 1; }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _server.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _server.Stop();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                MessageBox.Show(listBox1.Items[listBox1.SelectedIndex].ToString());
            }
        }
    }
}
