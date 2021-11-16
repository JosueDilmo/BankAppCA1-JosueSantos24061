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
            BankAccount.FirstTimeCustomerFile();

            
            //Opening bank system menu
            bool systemOn = true;
            while (systemOn) 
            { 
            BankAccount.BankSystemLogin();

               Console.WriteLine("Do you want to close the program? ");
               string answer = Console.ReadLine();
               if (answer == "yes")
               {
                   systemOn = false;
               }
            }
            

        }
    }
}

