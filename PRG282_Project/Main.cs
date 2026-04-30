using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG282_Project
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update update = new Update();
            update.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete();
            delete.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addHero addHero = new addHero();
            addHero.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Summary summary = new Summary();
            summary.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Superheros superheros = new Superheros();
            superheros.Show();
        }
    }
}
