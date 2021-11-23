using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Student Name: Josue Dilmo dos Santos
// Student Number: 24061

namespace BankAppCA1_JosueSantos24061.Models
{
    public class BankEmployee
    {
        public static void EmployeeLogin()
        {
            bool loginLoop = true;
            while (loginLoop)
            {
                Console.WriteLine("Welcome Bank Employee");
                Console.Write("Password: ");
                string employeePassword = Console.ReadLine();
                if (employeePassword == "A1234")
                {
                    loginLoop = false; //Desativation of loop
                    Driver.OutputSeparator(); //Separate different "screens"
                    Console.WriteLine("Welcome to 24061 Bank System");
                    Console.WriteLine("Opening menu...");
                    EmployeeMenu();
                }
                else
                {
                    // wrong answer keeps looping
                    Console.WriteLine("Please, try again.");
                    Driver.OutputSeparator();
                    EmployeeLogin();
                }
            }
        }

        public static void EmployeeMenu() 
        {
            bool optionLoop = true;
            while (optionLoop)
            {
                Driver.OutputSeparator();
                Console.WriteLine("1. Create Customer Account");
                Console.WriteLine("2. Delete Customer Account");
                Console.WriteLine("3. Transaction Withdrawl");
                Console.WriteLine("4. Transaction Deposit");
                Console.WriteLine("5. List Customers Accounts");
                Console.WriteLine("6. View Customers Balance");
                Console.Write("Option: ");
                if (Int32.TryParse(Console.ReadLine(), out int optionEmployee))
                {
                    switch (optionEmployee)
                    {
                        case 1:
                            optionLoop = false;
                            Driver.OutputSeparator();
                            Console.WriteLine("Create Customer Account");
                            Console.Write("Input customer's First Name: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Input customer's Last Name: ");
                            string lastName = Console.ReadLine();
                            Console.Write("Input customer's Email Address: ");
                            string email = Console.ReadLine();
                            string letterFirstName = firstName.Substring(0, 1);
                            string letterLastName = lastName.Substring(0, 1);
                            int lenghtFullName = firstName.Length + lastName.Length;
                            int positionFirst = Driver.DriverFindLetter(letterFirstName);
                            int positionLast = Driver.DriverFindLetter(letterLastName);
                            string customerAccDetails = $"{letterFirstName.ToUpper()}{letterLastName.ToUpper()}-{lenghtFullName}-{positionFirst}-{positionLast}";
                            BankSystem.CreateSavingsAcc(customerAccDetails);
                            BankSystem.CreateCurrentAcc(customerAccDetails);
                            BankSystem.CreateCustomer(customerAccDetails, firstName.ToUpper(), lastName.ToUpper(), email);
                            Driver.OutputSeparator();
                            Console.WriteLine("Account Created with sucess!");
                            Console.WriteLine($"Account Number: {customerAccDetails}");
                            Console.WriteLine($"Account PIN Number: {positionFirst}{positionLast}");
                            break;

                        case 2:
                            optionLoop = false;
                            Driver.OutputSeparator();
                            Console.WriteLine("Delete Customer Account");
                            Console.WriteLine("Insert the account code to be deleted: ");
                            Console.Write("Account code: ");
                            string accountToDelete = Console.ReadLine();
                            BankSystem.DeleteCustomerAcc(accountToDelete.ToUpper());                            
                            break;

                        case 3:
                            optionLoop = false;
                            Driver.OutputSeparator();
                            Console.WriteLine("Transaction Withdrawl");
                            Console.Write("Please, Input the Account Code: ");
                            string accountForWith = Console.ReadLine(); // file exist to check if account exist?
                            BankSystem.Withdrawl(accountForWith);
                            break;

                        case 4:
                            optionLoop = false;
                            Driver.OutputSeparator();
                            Console.WriteLine("Transaction Deposit");
                            Console.Write("Please, Input the Account Code: ");
                            string accountForDep = Console.ReadLine(); // file exist to check if account exist?
                            BankSystem.Deposit(accountForDep);
                            break;

                        case 5:
                            optionLoop = false;
                            Driver.OutputSeparator();
                            Console.WriteLine("List Customers Accounts");
                            BankSystem.ListCustomers();
                            break;

                        case 6:
                            optionLoop = false;
                            Driver.OutputSeparator();
                            Console.WriteLine("View Customer Balance");
                            Console.Write("Please, Input the Account Code: ");
                            string accountForView = Console.ReadLine();
                            Driver.OutputSeparator();
                            Console.WriteLine("1. for Savings Account");
                            Console.WriteLine("2. for Current Account");
                            Console.Write("Option: ");
                            if (Int32.TryParse(Console.ReadLine(), out int loopBalance))
                            {
                                switch (loopBalance)
                                {
                                    case 1:
                                        Console.WriteLine($"Available balance: {BankSystem.GetSavingsBalance(accountForView)}");
                                        break;

                                    case 2:
                                        Console.WriteLine($"Available balance: {BankSystem.GetCurrentBalance(accountForView)}");
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
                    EmployeeMenu();
                }
                    else 
                    {
                    // wrong answer keeps looping
                    Console.WriteLine("Please, choose a valid option.");
                    Driver.OutputSeparator();
                    EmployeeMenu();
                    }

            }
            
        
        }
       
    }
}
