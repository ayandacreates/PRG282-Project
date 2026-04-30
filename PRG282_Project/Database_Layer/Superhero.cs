using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using PRG282_Project.Logic_Layer;

namespace PRG282_Project.Database_Layer
{
    internal class Superhero
    {
        private readonly string FilePath =
            @"SuperherosList.txt";

        public string ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string SuperPower { get; set; }
        public string Gender { get; set; }
        public int ExamScore { get; set; }
        public string Ranking { get; set; }
        public string ThreatLevel { get; set; }

        public Superhero() { }

        public Superhero(string id, string name, int age, string superPower,
                         string gender, int examScore, string ranking, string threatLevel)
        {
            ID = id;
            Name = name;
            Age = age;
            SuperPower = superPower;
            Gender = gender;
            ExamScore = examScore;
            Ranking = ranking;
            ThreatLevel = threatLevel;
        }

        
        public List<string> ReadSuperheroes()
        {
           List<string> heros = new List<string>();
            try
            {
                if (File.Exists(FilePath))
                {
                    heros.AddRange(File.ReadAllLines(FilePath));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading superheroes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return heros;


        }

        public void AddSuperhero()
        {
            // Ensure file exists
            if (!File.Exists(FilePath))
            {
                using (File.Create(FilePath)) { }
            }

            using (StreamWriter sw = File.AppendText(FilePath))
            {
                foreach (string line in ReadSuperheroes())
                {
                   sw.WriteLine(line);
                }
                sw.WriteLine(ToString());
            }
        }

        public void UpdateSuperhero(string field, string newValue)
        {
            try
            {
                List<string> superheroes = ReadSuperheroes();
                Calculations calc = new Calculations();
                bool updated = false;

                for (int i = 0; i < superheroes.Count; i++)
                {
                    string[] details = superheroes[i].Split('|');

                    if (details.Length == 8 && details[0] == ID)
                    {
                        // Update the correct field based on the field name
                        switch (field.ToLower())
                        {
                            case "name": details[1] = newValue; break;
                            case "age": details[2] = newValue; break;
                            case "superpower": details[3] = newValue; break;
                            case "gender": details[4] = newValue; break;
                            case "examscore": details[5] = newValue; break;
                            default:
                                MessageBox.Show("Invalid field name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                        }

                        details[6] = calc.CalculateRank(int.Parse(details[5]));
                        details[7] = calc.CalculateThreatLevel(details[6]);

                        // Rebuild the line and mark updated
                        superheroes[i] = string.Join("|", details);
                        updated = true;
                        break;
                    }
                }

                if (updated)
                {
                    File.WriteAllLines(FilePath, superheroes);
                    MessageBox.Show("Superhero updated successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Superhero not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating superhero: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteSuperhero()
        {
            try
            {
                var superheroes = ReadSuperheroes();
                bool removed = false;

                for (int i = 0; i < superheroes.Count; i++)
                {
                    var details = superheroes[i].Split('|');
                    if (details.Length == 8 && details[0] == ID)
                    {
                        superheroes.RemoveAt(i);
                        removed = true;
                        break;
                    }
                }

                if (removed)
                {
                    File.WriteAllLines(FilePath, superheroes);
                    MessageBox.Show("Superhero deleted successfully!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Superhero not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting superhero: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public List<Superhero> GetAllSuperheroes()
        {
            List<Superhero> superheroes = new List<Superhero>();

            if (!File.Exists(FilePath))
                return superheroes;

            string[] lines = File.ReadAllLines(FilePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] details = line.Split('|');
                if (details.Length == 8)
                {
                    superheroes.Add(new Superhero(
                        details[0],                // ID
                        details[1],                // Name
                       int.Parse(details[2]),               // Age
                        details[3],                // SuperPower
                        details[4],                // Gender
                        int.Parse(details[5]),                // ExamScore
                        details[6],                // Ranking
                        details[7]                 // ThreatLevel
                    ));
                }
            }

            return superheroes;
        }


        public override string ToString()
        {
            return $"{ID}|{Name}|{Age}|{SuperPower}|{Gender}|{ExamScore}|{Ranking}|{ThreatLevel}";
        }
    }
}
