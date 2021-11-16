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
    public class BankCustomer
    {
        public void CustomerLogin()
        {
            bool loginLoop = true;
            while (loginLoop)
            { // have to create a way to compare with the accounts created
                Console.WriteLine("Welcome Bank Customer");
                Console.WriteLine("Please, type in your details");
                Driver.OutputSeparator();
                //if ()
                //{
                loginLoop = false;
                Console.Write("Your First Name: ");
                string customerFirstName = Console.ReadLine();
                Console.Write("Your Last Name: ");
                string customerLastName = Console.ReadLine();
                Console.Write("Your Account code: ");
                string customerAccount = Console.ReadLine();
                Console.Write("Your pin number: ");
                string customerPin = Console.ReadLine();
                Driver.OutputSeparator();
                Console.WriteLine($"Welcome to Bank 24061 - {customerFirstName} {customerLastName}");
                Console.WriteLine("Opening Menu...");
                BankCustomer customerMenu = new();
                customerMenu.CustomerMenu();

                //loginLoop = true;
            }

        
        }
        
        public void CustomerMenu()
        {
            bool optionLoop = true;
            while (optionLoop)
            {
                Driver.OutputSeparator();
                Console.WriteLine("1. Transactions History");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdrawl");
                Console.WriteLine("4. Check balance");
                Console.Write("Option: ");
                if (Int32.TryParse(Console.ReadLine(), out int optionCustomer))
                {
                    switch (optionCustomer)
                    {
                        case 1:
                            optionLoop = false;
                            Driver.OutputSeparator();
                            Console.WriteLine("Transactions History");
                            break;

                        case 2:
                            optionLoop = false;
                            Driver.OutputSeparator();
                            Console.WriteLine("Deposit");
                            break;

                        case 3:
                            optionLoop = false;
                            Driver.OutputSeparator();
                            Console.WriteLine("Withdrawl");
                            break;

                        case 4:
                            optionLoop = false;
                            Driver.OutputSeparator();
                            Console.WriteLine("Check Balance");
                            break;

                        default:
                            optionLoop = true;
                            break;
                    }
                }
                    else
                    {
                    // wrong answer keeps looping
                    Console.WriteLine("Please, choose a valid option.");
                    Driver.OutputSeparator();
                    optionLoop = true;
                    }

            }
        }



        
    
    
    
    
    }
}
