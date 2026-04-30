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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            Admin admin = new Admin();
            Main main = new Main();
            admin.Login(username,password);
            if (textBox1 != null && textBox2 != null) {
                if (admin.Login(username, password))
                {
                    main.Show();
                    this.MinimizeBox = true;
                }
                else
                {
                    MessageBox.Show("Incorrect username or password");
                }
            }
            else
            {
                MessageBox.Show("Please input your Details");
            }

            this.Hide();

        }
    }
}
