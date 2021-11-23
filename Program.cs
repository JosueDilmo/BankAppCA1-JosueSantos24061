using BankAppCA1_JosueSantos24061.Models;
using System;

// Student Name: Josue Dilmo dos Santos
// Student Number: 24061

namespace BankAppCA1_JosueSantos24061
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating customers.txt file
            BankSystem.FirstTimeCustomerFile();

            
            //Opening bank system menu
            BankSystem.BankSystemLogin();
            
           
        }
    }
}

