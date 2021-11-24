using BankAppCA1_JosueSantos24061.Models;
using System;
using System.IO;

// Student Name: Josue Dilmo dos Santos
// Student Number: 24061

namespace BankAppCA1_JosueSantos24061
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create directory BankFiles if it doesn't exist
            string pathBankFilesFolder = @"./BankFiles";
            string bankFiles = Path.Combine(pathBankFilesFolder);
            Directory.CreateDirectory(bankFiles);

            //Creating customers.txt file
            BankSystem.FirstTimeCustomerFile();
            
            //Opening bank system menu
             BankSystem.BankSystemLogin();


        }
       
    }
}

