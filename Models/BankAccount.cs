using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

// Student Name: Josue Dilmo dos Santos
// Student Number: 24061

namespace BankAppCA1_JosueSantos24061.Models
{
    public class BankAccount
    {
        public static void BankSystemLogin()// Login to bank menu
        {
            Driver.OutputSeparator();
            Console.WriteLine("============================| Welcome to Bank 24061 |===========================");
            Driver.OutputSeparator();
            bool loginLoop = true;
            while (loginLoop) // while true keep looping
            {
                Console.WriteLine("Type 1. Bank Employee");
                Console.WriteLine("Type 2. Bank Customer");
                Console.Write("Option: ");
                // TryParse to avoid an Exception if the user types a letter for example.
                if (Int32.TryParse(Console.ReadLine(), out int userOption))
                {
                    switch (userOption)
                    {
                        case 1:
                            loginLoop = false;
                            BankEmployee employee = new();
                            employee.EmployeeLogin();
                            break;

                        case 2:
                            loginLoop = false;
                            BankCustomer customer = new();
                            customer.CustomerLogin();
                            break;

                        default:
                            loginLoop = true;
                            break;
                    }
                }

                if (loginLoop)
                    Console.WriteLine("Please, choose a valid option.");
                Driver.OutputSeparator(); // Simulate new screen
            }

        }

        public static void FirstTimeCustomerFile() //create the custome.txt file when program start.
        {
            string customersFile = "customers.txt";

            string[] bankCustomers = Array.Empty<string>(); // empty array, will be added data when created customers;

            CreateCustomerFile(customersFile, bankCustomers);
        }

        public static void CreateCustomer(string customerAccDetails, string firstName, string lastName, string email)// creating customers.txt file
        {
            string customersFile = "customers.txt";

            string[] bankCustomers = { customerAccDetails + "|" + firstName + "|" + lastName + "|" + email };

            CreateCustomerFile(customersFile, bankCustomers);
            //creating customers
        }

        public static void CreateCustomerFile(string customersFile, string[] bankCustomers) //adding customer to customers.txt
        {
            string path = "c:/Users/DELL/Desktop/Josue/BSC2 - 0921 - Semester 1/Object-Oriented Programming/Assignment CA1 and CA2/BankAppCA1@JosueSantos24061/BankFiles";

            string fileToWrite = $"{path}/{customersFile}";

            try
            {
                using (StreamWriter sw = new StreamWriter(fileToWrite, true))// true was necessary for inputing new data and keeping old
                {
                    foreach (string customer in bankCustomers)
                    {
                        sw.WriteLine(customer);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The {fileToWrite} file could not be written");
                Console.WriteLine(e.Message);
            }
        }

        public static void CreateSavingsAcc(string customerAccDetails) //creating savings.txt file
        {
            string savingsAccFile = $"{customerAccDetails}-savings.txt";

            string[] customerSavingsAcc = { DateTime.Now.ToString("yyyy-MM-dd") + "|" + "Transactions" + "|" + "Amount" + "|" + "Balance" };

            CreateSavingsFile(savingsAccFile, customerSavingsAcc);
            //passing the values to create the savings account/file
        }

        public static void CreateSavingsFile(string savingsAccFile, string[] customerSavingsAcc) //creating savings.txt file
        {
            string path = "c:/Users/DELL/Desktop/Josue/BSC2 - 0921 - Semester 1/Object-Oriented Programming/Assignment CA1 and CA2/BankAppCA1@JosueSantos24061/BankFiles";

            string fileToWrite = $"{path}/{savingsAccFile}";

            try
            {
                using (StreamWriter sw = new StreamWriter(fileToWrite, true))
                {
                    foreach (string saving in customerSavingsAcc)
                    {
                        sw.WriteLine(saving);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The {fileToWrite} file could not be written");
                Console.WriteLine(e.Message);
            }
        }

        public static void CreateCurrentAcc(string customerAccDetails) //creating current.txt file
        {
            string currentAccFile = $"{customerAccDetails}-current.txt";

            string[] customerCurrentAcc = { DateTime.Now.ToString("yyyy-MM-dd") + "|" + "Transactions" + "|" + "Amount" + "|" + "Balance" };

            CreateCurrentFile(currentAccFile, customerCurrentAcc);
        }

        public static void CreateCurrentFile(string currentAccFile, string[] customerCurrentAcc) //creating current.txt file
        {
            string path = "c:/Users/DELL/Desktop/Josue/BSC2 - 0921 - Semester 1/Object-Oriented Programming/Assignment CA1 and CA2/BankAppCA1@JosueSantos24061/BankFiles";

            string fileToWrite = $"{path}/{currentAccFile}";

            try
            {
                using (StreamWriter sw = new StreamWriter(fileToWrite, true))
                {
                    foreach (string current in customerCurrentAcc)
                    {
                        sw.WriteLine(current);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The {fileToWrite} file could not be written");
                Console.WriteLine(e.Message);
            }
        }

        public static decimal CurrentAccBalance //curent account balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in CurrentTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        public static decimal SavingsAccBalance //savings account balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in SavingsTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        public static List<CurrentAccTransactions> CurrentTransactions = new(); // list to store all transactions in current account

        public static List<SavingsAccTransactions> SavingsTransactions = new(); // list to store all transactions in savings account

        public class CurrentAccTransactions // to access current account transacions
        {
            public decimal Amount { get; set; }
            public string Date { get; set; }
            public string Action { get; set; }

            public CurrentAccTransactions(string date, string action, decimal amount)
            {
                Amount = amount;
                Date = date;
                Action = action;
            }
        }

        public class SavingsAccTransactions // to access savings account transactions
        {
            public decimal Amount { get; set; }
            public string Date { get; set; }
            public string Action { get; set; }

            public SavingsAccTransactions(string date, string action, decimal amount)
            {
                Amount = amount;
                Date = date;
                Action = action;
            }
        }

        public static void Deposit() //deposit method
        {
            string path = "c:/Users/DELL/Desktop/Josue/BSC2 - 0921 - Semester 1/Object-Oriented Programming/Assignment CA1 and CA2/BankAppCA1@JosueSantos24061/BankFiles";
            bool optionLoop = true;
            while (optionLoop)
            {
                Console.Write("Enter Account Code: ");
                string accountCode = Console.ReadLine();
                Console.WriteLine("1. Deposit in Current Account");
                Console.WriteLine("2. Deposit in Savings Account");
                Console.Write("Option: ");
                if (Int32.TryParse(Console.ReadLine(), out int optionUser))
                {
                    switch (optionUser)
                    {
                        case 1:
                            optionLoop = false;
                            string currentToWrite = $"{path}/{accountCode}-current.txt";
                            Console.Write("Please, Enter Amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal currentDepositAmount) && currentDepositAmount > 0)
                            {
                                try
                                {
                                    using (StreamWriter sw = new StreamWriter(currentToWrite, true))
                                    {
                                        var formartedCurrentDeposit = new CurrentAccTransactions(DateTime.Now.ToString("yyyy-MM-dd"), "Deposit", currentDepositAmount);
                                        CurrentTransactions.Add(formartedCurrentDeposit);
                                        sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd") + "|" + "Deposit" + "|" + currentDepositAmount + "|" + CurrentAccBalance);
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"The {currentToWrite} file could not be written");
                                    Console.WriteLine(e.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please, Enter a Valid Amount");
                                optionLoop = true;
                            }
                            break;

                        case 2:
                            optionLoop = false;
                            string savingsToWrite = $"{path}/{accountCode}-savings.txt";
                            Console.Write("Please, Enter Amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal savingsDepositAmount) && savingsDepositAmount > 0)
                            {
                                try
                                {
                                    using (StreamWriter sw = new StreamWriter(savingsToWrite, true))
                                    {
                                        var formartedSavingsDeposit = new SavingsAccTransactions(DateTime.Now.ToString("yyyy-MM-dd"), "Deposit", savingsDepositAmount);
                                        SavingsTransactions.Add(formartedSavingsDeposit);
                                        sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd") + "|" + "Deposit" + "|" + savingsDepositAmount + "|" + SavingsAccBalance);
                                    }

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"The {savingsToWrite} file could not be written");
                                    Console.WriteLine(e.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please, Enter a Valid Amount");
                                optionLoop = true;
                            }
                            break;

                        default:
                            optionLoop = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please, choose a valid option.");
                    Driver.OutputSeparator(); // Simulate new screen
                }
            }




        }

        public static void Withdrawl() //withdrawl method
        {
            string path = "c:/Users/DELL/Desktop/Josue/BSC2 - 0921 - Semester 1/Object-Oriented Programming/Assignment CA1 and CA2/BankAppCA1@JosueSantos24061/BankFiles";
            bool optionLoop = true;
            while (optionLoop)
            {
                Console.Write("Enter Account Code: ");
                string accountCode = Console.ReadLine();
                Console.WriteLine("1. Withdrawl in Current Account");
                Console.WriteLine("2. Withdrawl in Savings Account");
                Console.Write("Option: ");
                if (Int32.TryParse(Console.ReadLine(), out int optionUser))
                {
                    switch (optionUser)
                    {
                        case 1:
                            optionLoop = false;
                            string currentToWrite = $"{path}/{accountCode}-current.txt";
                            Console.Write("Please, Enter Amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal currentWithdrawlAmount) && currentWithdrawlAmount > 0 && currentWithdrawlAmount - CurrentAccBalance <= 0)
                            {
                                try
                                {
                                    using (StreamWriter sw = new StreamWriter(currentToWrite, true))
                                    {
                                        var formartedCurrentWithdrawl = new CurrentAccTransactions(DateTime.Now.ToString("yyyy-MM-dd"), "Withdrawl", -currentWithdrawlAmount);
                                        CurrentTransactions.Add(formartedCurrentWithdrawl);
                                        sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd") + "|" + "Withdrawl" + "|" + currentWithdrawlAmount + "|" + CurrentAccBalance);
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"The {currentToWrite} file could not be written");
                                    Console.WriteLine(e.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please, Enter a Valid Amount");
                                optionLoop = true;
                            }
                            break;

                        case 2:
                            optionLoop = false;
                            string savingsToWrite = $"{path}/{accountCode}-savings.txt";
                            Console.Write("Please, Enter Amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal savingsWithdrawlAmount) && savingsWithdrawlAmount > 0 && savingsWithdrawlAmount - SavingsAccBalance <= 0)
                            {
                                try
                                {
                                    using (StreamWriter sw = new StreamWriter(savingsToWrite, true))
                                    {
                                        var formartedSavingsWithdrawl = new SavingsAccTransactions(DateTime.Now.ToString("yyyy-MM-dd"), "Withdrawl", -savingsWithdrawlAmount);
                                        SavingsTransactions.Add(formartedSavingsWithdrawl);
                                        sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd") + "|" + "Withdrawl" + "|" + savingsWithdrawlAmount + "|" + SavingsAccBalance);
                                    }

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"The {savingsToWrite} file could not be written");
                                    Console.WriteLine(e.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please, Enter a Valid Amount");
                                optionLoop = true;
                            }
                            break;

                        default:
                            optionLoop = true;
                            break;
                    }


                }
                else
                {
                    Console.WriteLine("Please, choose a valid option.");
                    Driver.OutputSeparator(); // Simulate new screen
                }
            }
        }

        public static void ListCustomers() // read customers.txt file and out put a list with all of them
        {
            string path = "c:/Users/DELL/Desktop/Josue/BSC2 - 0921 - Semester 1/Object-Oriented Programming/Assignment CA1 and CA2/BankAppCA1@JosueSantos24061/BankFiles";
            string customersFile = "customers.txt";
            string customerToRead = $"{path}/{customersFile}";

            try
            {
                using (StreamReader sr = new StreamReader(customerToRead))
                {
                    string line;

                    while ((line = sr.ReadLine()) is not null)
                    {
                        string[] customerData = line.Split("|");
                        string customerAcc = String.Format("{0,-10}", customerData[0]);
                        Console.WriteLine($"{customerAcc}\t{customerData[1]}\t{customerData[2]}");
                        
                        
                        
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The {customerToRead} file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

       

    }
}
