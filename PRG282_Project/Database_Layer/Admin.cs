using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PRG282_Project.Database_Layer
{
    internal class Admin
    {
        public Admin() { }

        string path = @"C:\Users\King\source\repos\PRG282_Project\PRG282_Project\bin\Debug\Admin.txt";

       public bool Login(string username , string password)
        {
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] info = line.Split('|');

                if (info.Length == 2)
                {
                    string user = info[0];
                    string pass = info[1];

                    if(user==username && pass == password)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


       


    }
}
