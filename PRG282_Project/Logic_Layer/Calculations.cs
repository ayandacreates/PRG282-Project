using PRG282_Project.Database_Layer;
using PRG282_Project.Database_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace PRG282_Project.Logic_Layer
{
    internal class Calculations
    {
        public Calculations() { }

     

        public string CalculateRank(int ExamScore) //method to calculate the rank and threat level based on the exam score
        {
            string Rank = "";
            if (ExamScore >= 81 && ExamScore <= 100)
            {
                Rank = "S-Rank";
                

            }
            else if (ExamScore >= 61 && ExamScore <= 80)
            {
                Rank = "A-Rank";
                
            }
            else if (ExamScore >= 41 && ExamScore <= 60)
            {
                Rank = "B-Rank";
              
            }
            else if (ExamScore >= 0 && ExamScore <= 40)
            {
                Rank = "C-Rank";
              
            }
            else
            {
                throw new ArgumentException("Invalid exam score");
            }
            return Rank;
        }

        public string CalculateThreatLevel(string rank) //method to calculate the rank and threat level based on the exam score
        {
            string ThreatLevel = "";
            if (rank == "S-Rank")
            {
                ThreatLevel = "Finals Week";

            }
            else if (rank == "A-Rank")
            {
                ThreatLevel = "Midterm Madness";
            }
            else if (rank == "B-Rank")
            {
                ThreatLevel = "Group Project Gone Wrong";
            }
            else if (rank == "C-Rank")
            {

                ThreatLevel = "Pop Quiz";
            }
            else
            {
                throw new ArgumentException("Invalid exam score");
            }
            return ThreatLevel;
        }

        public string GenerateNewID()
        {
            Superhero superhero = new Superhero();
            Random IDs = new Random();
            var superheroes = superhero.ReadSuperheroes();
          
            HashSet<string> existingIDs = new HashSet<string>(
        superheroes.Select(line => line.Split('|')[0])
    );

            string newID;
            do
            {
                newID = IDs.Next(100, 1001).ToString(); // 100 to 1000 inclusive
            } while (existingIDs.Contains(newID));

            return newID;
        }




        public void SummaryStatistics(DataGridView dataGridView)
        {
            Superhero superhero = new Superhero();
            List<string> superheroes = superhero.ReadSuperheroes();

            int totalHeroes = superheroes.Count;
            double totalExamScore = 0;
            Dictionary<string, int> rankDistribution = new Dictionary<string, int>();
            Dictionary<string, int> threatLevelDistribution = new Dictionary<string, int>();

            foreach (string hero in superheroes)
            {
                string[] details = hero.Split('|');
                if (details.Length == 8)
                {
                    // Exam score
                    if (int.TryParse(details[5], out int examScore))
                    {
                        totalExamScore += examScore;
                    }

                    // Rank
                    string rank = details[6];
                    if (rankDistribution.ContainsKey(rank))
                        rankDistribution[rank]++;
                    else
                        rankDistribution[rank] = 1;

                    // Threat level
                    string threatLevel = details[7];
                    if (threatLevelDistribution.ContainsKey(threatLevel))
                        threatLevelDistribution[threatLevel]++;
                    else
                        threatLevelDistribution[threatLevel] = 1;
                }
            }

            double averageExamScore = totalHeroes > 0 ? totalExamScore / totalHeroes : 0;

            // --- Prepare DataTable for display ---
            DataTable table = new DataTable();
            table.Columns.Add("Statistic");
            table.Columns.Add("Value");

            // Add total heroes and average score
            table.Rows.Add("Total Superheroes", totalHeroes);
            table.Rows.Add("Average Exam Score", Math.Round(averageExamScore, 2));

            // Add rank distribution
            foreach (var rank in rankDistribution)
            {
                table.Rows.Add($"Rank: {rank.Key}", rank.Value);
            }

            // Add threat level distribution
            foreach (var level in threatLevelDistribution)
            {
                table.Rows.Add($"Threat Level: {level.Key}", level.Value);
            }

            // Bind to DataGridView
            dataGridView.DataSource = table;
        }

    }
}

