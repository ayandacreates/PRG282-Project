using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRG282_Project.Database_Layer;
using PRG282_Project.Logic_Layer;

namespace PRG282_Project.Presentation_Layer
{
    internal class Info
    {
        public Info() { }

        
        
        public void AddHero(string id, string name, int age, string superPower,
                            string gender, int examScore, string ranking, string threatLevel)
        {
            try
            {
                Superhero newHero = new Superhero(id, name, age, superPower, gender, examScore, ranking, threatLevel);
                newHero.AddSuperhero();

                MessageBox.Show("Superhero added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding superhero: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateHero(string field , string newValue ,string ID)
        {
            try
            {
                Superhero superhero = new Superhero();
                superhero.ID = ID;
                superhero.UpdateSuperhero(field, newValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating superhero: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void DeleteHero(string ID)
        {
            try
            {
                Superhero superhero = new Superhero();
                superhero.ID = ID;
                superhero.DeleteSuperhero();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting superhero: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
