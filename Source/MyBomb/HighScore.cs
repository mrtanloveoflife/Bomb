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
    public partial class HighScore : Form
    {
        GameData gameData;
        public HighScore(int[] Score, bool t)
        {
            InitializeComponent();
            HS_1.Text = Score[0].ToString();
            HS_2.Text = Score[1].ToString();
            HS_3.Text = Score[2].ToString();
            if (t == true)
            {
                Over_Label.Show();
            }
            else Over_Label.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
