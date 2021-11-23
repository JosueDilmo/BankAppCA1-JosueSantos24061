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
        public static void CustomerLogin()
        {
            bool loginLoop = true;
            while (loginLoop)
            { // have to create a way to compare with the accounts created or keep looping
                loginLoop = false;
                Console.WriteLine("Welcome Bank Customer");
                Console.WriteLine("Please, type in your details");
                Driver.OutputSeparator();
                Console.Write("Your First Name: ");
                string customerFirstName = Console.ReadLine();
                Console.Write("Your Last Name: ");
                string customerLastName = Console.ReadLine();
                Console.Write("Your Account Code: ");
                string customerAccountCode = Console.ReadLine();
                Console.Write("Your Pin Number: ");
                string customerPin = Console.ReadLine();
                Driver.OutputSeparator();
                ValidateCustomer(customerFirstName.ToUpper(), customerLastName.ToUpper(), customerAccountCode.ToUpper(), customerPin);
                CustomerLogin();
            }

        }

        public static void ValidateCustomer(string firstName, string lastName, string accountCode, string pinNumber)
        {
            string path = "c:/Users/DELL/Desktop/Josue/BSC2 - 0921 - Semester 1/Object-Oriented Programming/Assignment CA1 and CA2/BankAppCA1@JosueSantos24061/BankFiles";
            string customersFile = "customers.txt";
            string customerToRead = $"{path}/{customersFile}";
            string letterFirstName = firstName.Substring(0, 1);
            string letterLastName = lastName.Substring(0, 1);
            int positionFirst = Driver.DriverFindLetter(letterFirstName);
            int positionLast = Driver.DriverFindLetter(letterLastName);
            string password = positionFirst + "" + positionLast;
            string[] customersInfo = File.ReadAllText(customerToRead).Split("|");
            for (int i = 0; i < customersInfo.Length; i++)
            {
                if (customersInfo[i].Contains(firstName))
                {
                    if (customersInfo[i + 1].Contains(lastName))
                    {
                        if (customersInfo[i - 1].Contains(accountCode))
                        {
                            if (password == pinNumber)
                            {
                                Console.WriteLine($"Welcome to Bank 24061 - {firstName} {lastName}");
                                Console.WriteLine("Opening Menu...");
                                CustomerMenu(accountCode.ToUpper());
                            }
                            Console.WriteLine("PIN number is wrong");
                        }
                        Console.WriteLine("Account does not exist");
                    }
                }
            }

        }

        public static void CustomerMenu( string CustomerAccountCode)
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
                            Console.WriteLine("1. for Savings Account");
                            Console.WriteLine("2. for Current Account");
                            Console.Write("Option: ");
                            if (Int32.TryParse(Console.ReadLine(), out int userAnswer))
                            {
                                Driver.OutputSeparator();
                                switch (userAnswer)
                                {
                                    case 1:
                                        BankSystem.ReadSavingsTransactions(CustomerAccountCode);
                                        break;
                                    case 2:
                                        BankSystem.ReadCurrentTransactions(CustomerAccountCode);
                                        break;
                                    default:
                                        optionLoop = true;
                                        break;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Please Enter Valid Option.");
                            }
                            break;
                            

                        case 2:
                            optionLoop = false;
                            Driver.OutputSeparator();
                            Console.WriteLine("Deposit");
                            BankSystem.Deposit(CustomerAccountCode);
                            break;

                        case 3:
                            optionLoop = false;
                            Driver.OutputSeparator();
                            Console.WriteLine("Withdrawl");
                            BankSystem.Withdrawl(CustomerAccountCode);
                            break;

                        case 4:
                            optionLoop = false;
                            Driver.OutputSeparator();
                            Console.WriteLine("Check Balance");
                            Console.WriteLine("1. for Savings Account");
                            Console.WriteLine("2. for Current Account");
                            Console.Write("Option: ");
                            if (Int32.TryParse(Console.ReadLine(), out int loopBalance))
                            {
                                switch (loopBalance)
                                {
                                    case 1:
                                        Console.WriteLine($"Available balance: {BankSystem.GetSavingsBalance(CustomerAccountCode)}");
                                        break;

                                    case 2:
                                        Console.WriteLine($"Available balance: {BankSystem.GetCurrentBalance(CustomerAccountCode)}");
                                        break;

                                    default:
                                        optionLoop = true;
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please Enter Valid Option.");
                            }
                            break;

                        default:
                            optionLoop = true;
                            break;
                    }
                    CustomerMenu(CustomerAccountCode);
                }
                    else
                    {
                    // wrong answer keeps looping
                    Console.WriteLine("Please, choose a valid option.");
                    Driver.OutputSeparator();
                    CustomerMenu(CustomerAccountCode);
                    }

            }
        }


    }
}
