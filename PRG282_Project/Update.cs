using PRG282_Project.Database_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using PRG282_Project.Presentation_Layer;

namespace PRG282_Project
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private void Update_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Info superhero = new Info();
            superhero.UpdateHero(comboBox1.Text, textBox2.Text,textBox1.Text);
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
