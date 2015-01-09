using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsmqClient
{
    public partial class Form1 : Form
    {
        MsmqContractClient client = new MsmqContractClient("MsmqService");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            messageText.Text = messageText.Text.Trim();

            if (messageText.Text.Length > 0)
            {
                client.SendMessage(messageText.Text);
            }
        }
    }
}
