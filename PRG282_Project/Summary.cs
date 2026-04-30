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
using PRG282_Project.Logic_Layer;

namespace PRG282_Project
{
    public partial class Summary : Form
    {
        public Summary()
        {
            InitializeComponent();
        }
        Calculations summary = new Calculations();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Summary_Load(object sender, EventArgs e)
        {
            summary.SummaryStatistics(dataGridView1);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        
    }
}
