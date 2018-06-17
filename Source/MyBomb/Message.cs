using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBomb
{
    public partial class Message : Form
    {
        private bool Yes = false;
        public Message(string Msg)
        {
            InitializeComponent();
            label1.Text = Msg;
        }
        public bool isYes()
        {
            return Yes;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Yes = true;
            this.Close();
        }
    }
}
