using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Student Name: Josue Dilmo dos Santos
// Student Number: 24061

namespace BankAppCA1_JosueSantos24061.Models
{
    public class Driver
    { 
        public static int DriverFindLetter(string findLetterAt) //Method to find the first letter of customer name
        {
            string s1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string s2 = findLetterAt.ToUpper();
            int letterAt = s1.IndexOf(s2)+1;
            return letterAt;
        }

        public static void OutputSeparator() //Method to output a line to separate information
            {
            Console.WriteLine("=".PadRight(80, '='));
            }
    }
}
