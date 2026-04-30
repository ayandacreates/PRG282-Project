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

namespace PRG282_Project
{
    public partial class Superheros : Form
    {
        
        public Superheros()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Superheros_Load(object sender, EventArgs e)
        {
            LoadSuperheros();
        }

        private void LoadSuperheros()
        {
            Superhero superheros = new Superhero();
            List<Superhero> heros = superheros.GetAllSuperheroes();

            dataGridView1.DataSource = heros;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        
    }
}
