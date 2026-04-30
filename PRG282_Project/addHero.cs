using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRG282_Project.Database_Layer;
using PRG282_Project.Presentation_Layer;
using PRG282_Project.Logic_Layer;


namespace PRG282_Project
{
    public partial class addHero : Form
    {
        public addHero()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Info superhero = new Info();
            Calculations calculations = new Calculations();
            string rank = calculations.CalculateRank(Convert.ToInt32(textBox4.Text));
            superhero.AddHero(calculations.GenerateNewID(), textBox1.Text, Convert.ToInt32(textBox2.Text), textBox5.Text, groupBox1.Text, Convert.ToInt32(textBox4.Text), rank, calculations.CalculateThreatLevel(rank));
            this.Close();
            MessageBox.Show("Superhero added successfully!");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
