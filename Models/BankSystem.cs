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
    public class BankSystem
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
                    Driver.OutputSeparator();
                {
                    switch (userOption)
                    {
                        case 1:
                            loginLoop = false;
                            BankEmployee.EmployeeLogin();
                            break;

                        case 2:
                            loginLoop = false;
                            BankCustomer.CustomerLogin();
                            break;

                        default:
                            loginLoop = true;
                            break;
                    }
                }

                if (loginLoop)
                    Console.WriteLine("Please, choose a valid option.");
                Driver.OutputSeparator(); // Simulate new screen
                BankSystemLogin();
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
                StreamWriter sw = new (fileToWrite, true);// true was necessary for inputing new data and keeping old
                {
                    foreach (string customer in bankCustomers)
                    {
                        sw.WriteLine(customer);
                        sw.Close();
                    }
                    sw.Close();
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
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            string[] customerSavingsAcc = { date + "|" + "Opening" + "|" + "Action" + "|" + 0 };

            CreateSavingsFile(savingsAccFile, customerSavingsAcc);
            //passing the values to create the savings account/file
        }

        public static void CreateSavingsFile(string savingsAccFile, string[] customerSavingsAcc) //creating savings.txt file
        {
            string path = "c:/Users/DELL/Desktop/Josue/BSC2 - 0921 - Semester 1/Object-Oriented Programming/Assignment CA1 and CA2/BankAppCA1@JosueSantos24061/BankFiles";

            string fileToWrite = $"{path}/{savingsAccFile}";

            try
            {
                StreamWriter sw = new (fileToWrite, true);
                {
                    foreach (string saving in customerSavingsAcc)
                    {
                        sw.WriteLine(saving);
                        sw.Close();
                    }
                    sw.Close();
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

            string date = DateTime.Now.ToString("yyyy-MM-dd");

            string[] customerCurrentAcc = { date + "|" + "Opening" + "|" + "Action" + "|" + 0 };

            CreateCurrentFile(currentAccFile, customerCurrentAcc);
        }

        public static void CreateCurrentFile(string currentAccFile, string[] customerCurrentAcc) //creating current.txt file
        {
            string path = "c:/Users/DELL/Desktop/Josue/BSC2 - 0921 - Semester 1/Object-Oriented Programming/Assignment CA1 and CA2/BankAppCA1@JosueSantos24061/BankFiles";

            string fileToWrite = $"{path}/{currentAccFile}";

            try
            {
                StreamWriter sw = new (fileToWrite, true);
                {
                    foreach (string current in customerCurrentAcc)
                    {
                        sw.WriteLine(current);
                        sw.Close();
                    }
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The {fileToWrite} file could not be written");
                Console.WriteLine(e.Message);
            }
        }

        public static void Deposit(string customerAccDetails) //deposit method
        {
            string path = "c:/Users/DELL/Desktop/Josue/BSC2 - 0921 - Semester 1/Object-Oriented Programming/Assignment CA1 and CA2/BankAppCA1@JosueSantos24061/BankFiles";
            bool optionLoop = true;
            while (optionLoop)
            {
                Console.WriteLine("1. Deposit in Current Account");
                Console.WriteLine("2. Deposit in Savings Account");
                Console.Write("Option: ");
                if (Int32.TryParse(Console.ReadLine(), out int optionUser))
                {
                    Driver.OutputSeparator();
                    switch (optionUser)
                    {
                        case 1:
                            optionLoop = false;
                            string currentToWrite = $"{path}/{customerAccDetails}-current.txt"; // have to check if file exist before going on
                            Console.Write("Please, Enter Amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal currentDepositAmount) && currentDepositAmount > 0)
                            {
                                try
                                {
                                    decimal balanceAccount =  GetCurrentBalance(customerAccDetails);
                                    decimal updatedCurrentBalance = balanceAccount + currentDepositAmount;
                                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                                    StreamWriter sw = new (currentToWrite, true);
                                    string[] currentDeposit = { date + "|" + "Deposit" + "|" + currentDepositAmount + "|" + updatedCurrentBalance };
                                        foreach (string cd in currentDeposit)
                                        {
                                            sw.WriteLine(cd);
                                            sw.Close();
                                        }
                                    sw.Close();

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"The {currentToWrite} file could not be written");
                                    Console.WriteLine(e.Message);
                                }
                                Console.WriteLine("Transaction Succeed!");
                            }
                            else
                            {
                                Console.WriteLine("Please, Enter a Valid Amount");
                                optionLoop = true;
                            }
                            break;

                        case 2:
                            optionLoop = false;
                            string savingsToWrite = $"{path}/{customerAccDetails}-savings.txt"; // have to check if file exist before going on
                            Console.Write("Please, Enter Amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal savingsDepositAmount) && savingsDepositAmount > 0)
                            {
                                try
                                {
                                    decimal balanceAccount = GetSavingsBalance(customerAccDetails);
                                    decimal updatedSavingsBalance = balanceAccount + savingsDepositAmount;
                                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                                    StreamWriter sw = new (savingsToWrite, true);
                                    string[] savingsDeposit = { date + "|" + "Deposit" + "|" + savingsDepositAmount + "|" + updatedSavingsBalance };
                                        foreach (string sd in savingsDeposit)
                                        {
                                            sw.WriteLine(sd);
                                            sw.Close();
                                        }
                                    sw.Close();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"The {savingsToWrite} file could not be written");
                                    Console.WriteLine(e.Message);
                                }
                                Console.WriteLine("Transaction Succeed!");
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

        public static void Withdrawl(string customerAccDetails) //withdrawl method
        {
            string path = "c:/Users/DELL/Desktop/Josue/BSC2 - 0921 - Semester 1/Object-Oriented Programming/Assignment CA1 and CA2/BankAppCA1@JosueSantos24061/BankFiles";
            bool optionLoop = true;
            while (optionLoop)
            {
                Console.WriteLine("1. Withdrawl in Current Account");
                Console.WriteLine("2. Withdrawl in Savings Account");
                Console.Write("Option: ");
                if (Int32.TryParse(Console.ReadLine(), out int optionUser))
                {
                    Driver.OutputSeparator();
                    switch (optionUser)
                    {
                        case 1:
                            optionLoop = false;
                            string currentToWrite = $"{path}/{customerAccDetails}-current.txt"; // have to check if file exist before going on
                            Console.Write("Please, Enter Amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal currentWithdrawlAmount) && currentWithdrawlAmount > 0 && currentWithdrawlAmount - GetCurrentBalance(customerAccDetails) <= 0)
                            {
                                try
                                {
                                    decimal balanceAccount = GetCurrentBalance(customerAccDetails);
                                    decimal updatedCurrentBalance = balanceAccount - currentWithdrawlAmount;
                                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                                    StreamWriter sw = new (currentToWrite, true);
                                    string[] currentWithdrawl = { date + "|" + "Withdrawl" + "|" + -currentWithdrawlAmount + "|" + updatedCurrentBalance };
                                        foreach (string cw in currentWithdrawl)
                                        {
                                            sw.WriteLine(cw);
                                            sw.Close();
                                        }
                                    sw.Close();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"The {currentToWrite} file could not be written");
                                    Console.WriteLine(e.Message);
                                }
                                Console.WriteLine("Transaction Succeed!");
                            }
                            else
                            {
                                Console.WriteLine("Please, Enter a Valid Amount");
                                optionLoop = true;
                            }
                            break;

                        case 2:
                            optionLoop = false;
                            string savingsToWrite = $"{path}/{customerAccDetails}-savings.txt"; // have to check if file exist before going on
                            Console.Write("Please, Enter Amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal savingsWithdrawlAmount) && savingsWithdrawlAmount > 0 && savingsWithdrawlAmount - GetSavingsBalance(customerAccDetails) <= 0)
                            {
                                try
                                {
                                    decimal balanceAccount = GetSavingsBalance(customerAccDetails);
                                    decimal updatedSavingsBalance = balanceAccount - savingsWithdrawlAmount;
                                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                                    StreamWriter sw = new (savingsToWrite, true);
                                    string[] savingsWithdrawl = { date + "|" + "Withdrawl" + "|" + -savingsWithdrawlAmount + "|" + updatedSavingsBalance };
                                        foreach (string swith in savingsWithdrawl)
                                        {
                                            sw.WriteLine(swith);
                                            sw.Close();
                                        }
                                    sw.Close();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"The {savingsToWrite} file could not be written");
                                    Console.WriteLine(e.Message);
                                }
                                Console.WriteLine("Transaction Succeed!");
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
                StreamReader sr = new (customerToRead);
                string line;
                    while ((line = sr.ReadLine()) is not null)
                    {
                        string[] customerData = line.Split("|");
                        string customerAcc = customerData[0];
                        Console.WriteLine($"{customerData[0]}\t{customerData[1]}\t{customerData[2]}\t{customerData[3]}\tTotal Account Balance: {GetCurrentBalance(customerAcc) + GetSavingsBalance(customerAcc)}");
                    }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"The {customerToRead} file could not be read");
                Console.WriteLine(e.Message);
            }
        }

        public static decimal GetCurrentBalance(string customerAccDetails)
        {
            string path = "c:/Users/DELL/Desktop/Josue/BSC2 - 0921 - Semester 1/Object-Oriented Programming/Assignment CA1 and CA2/BankAppCA1@JosueSantos24061/BankFiles";
            string currentAccount = $"{customerAccDetails}-current.txt";
            string loadCurrentAccount = $"{path}/{currentAccount}";
            string[] currentData = File.ReadAllText(loadCurrentAccount).Split("|");
            int finalPosition = currentData.Length - 1;
            decimal loadCurrentBalance = decimal.Parse(currentData[finalPosition]);
            return loadCurrentBalance;

        } //read current.txt file and getting the balance aka last position.

        public static decimal GetSavingsBalance(string customerAccDetails)
        {
            string path = "c:/Users/DELL/Desktop/Josue/BSC2 - 0921 - Semester 1/Object-Oriented Programming/Assignment CA1 and CA2/BankAppCA1@JosueSantos24061/BankFiles";
            string savingsAccount = $"{customerAccDetails}-savings.txt";
            string loadSavingsAccount = $"{path}/{savingsAccount}";
            string[] savingsData = File.ReadAllText(loadSavingsAccount).Split("|");
            int finalPosition = savingsData.Length - 1;
            decimal loadSavingsBalance = decimal.Parse(savingsData[finalPosition]);
            return loadSavingsBalance;

        }//read savings.txt file and getting the balance aka last position

        public static void ReadCurrentTransactions(string customerAccDetails)
        {
            string path = "c:/Users/DELL/Desktop/Josue/BSC2 - 0921 - Semester 1/Object-Oriented Programming/Assignment CA1 and CA2/BankAppCA1@JosueSantos24061/BankFiles";
            string currentAccount = $"{customerAccDetails}-current.txt";
            string loadCurrentAccount = $"{path}/{currentAccount}";
            try
            {
                StreamReader sr = new (loadCurrentAccount);
                string line;
                while ((line = sr.ReadLine()) is not null)
                {
                    string[] currentData = line.Split("|");
                    string first = String.Format("{0,-10}", currentData[0]);
                    Console.WriteLine($"{first}\t{currentData[1]}\t{currentData[2]}\t{currentData[3]}");
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"The {loadCurrentAccount} file could not be read");
                Console.WriteLine(e.Message);
            }

        }

        public static void ReadSavingsTransactions(string customerAccDetails)
        {
            string path = "c:/Users/DELL/Desktop/Josue/BSC2 - 0921 - Semester 1/Object-Oriented Programming/Assignment CA1 and CA2/BankAppCA1@JosueSantos24061/BankFiles";
            string savingsAccount = $"{customerAccDetails}-savings.txt";
            string loadSavingsAccount = $"{path}/{savingsAccount}";
            try
            {
                StreamReader sr = new (loadSavingsAccount);
                string line;
                while ((line = sr.ReadLine()) is not null)
                {
                    string[] currentData = line.Split("|");
                    string first = String.Format("{0,-10}", currentData[0]);
                    Console.WriteLine($"{first}\t{currentData[1]}\t{currentData[2]}\t{currentData[3]}");
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"The {loadSavingsAccount} file could not be read");
                Console.WriteLine(e.Message);
            }

        }

        public static void DeleteCustomerAcc(string customerAccDetails)
        {
            Driver.OutputSeparator();
            if (GetCurrentBalance(customerAccDetails) + GetSavingsBalance(customerAccDetails) > 0)
            {
                Console.WriteLine($"The account {customerAccDetails} has positive balances.");
                Console.WriteLine($"Available balance in Current Account: " + GetCurrentBalance(customerAccDetails));
                Console.WriteLine($"Available balance in Savings Account: " + GetSavingsBalance(customerAccDetails));
                Console.WriteLine("Access Denied.");
                BankEmployee.EmployeeLogin();
            }
            else
            {
                Console.WriteLine("1. To Confirm.");
                Console.WriteLine("2. To Cancel.");
                Console.Write("Option: ");
                int confirmAciton = int.Parse(Console.ReadLine());
                switch (confirmAciton)
                {
                    case 1:
                        string path = "c:/Users/DELL/Desktop/Josue/BSC2 - 0921 - Semester 1/Object-Oriented Programming/Assignment CA1 and CA2/BankAppCA1@JosueSantos24061/BankFiles";
                        string customersFile = "customers.txt";                       
                        string customerToRead = $"{path}/{customersFile}";
                        string newCustomerFile = "new-customers.txt";
                        string customerToWrite = $"{path}/{newCustomerFile}";
                        string customerSavings = $"{path}/{customerAccDetails}-savings.txt";
                        string customerCurrent = $"{path}/{customerAccDetails}-current.txt";
                        using (var sr = new StreamReader(customerToRead))
                        using (var sw = new StreamWriter(customerToWrite))
                        {
                            string eachLine;
                            while ((eachLine = sr.ReadLine()) != null)
                            {
                                if (!eachLine.Contains(customerAccDetails))
                                {
                                    sw.WriteLine(eachLine);
                                }
                            }
                            sw.Close();
                            sr.Close();
                        }
                        File.Delete(customerToRead);
                        File.Delete(customerSavings);
                        File.Delete(customerCurrent);
                        File.Move(customerToWrite, customerToRead);
                        Console.WriteLine($"Account: {customerAccDetails} has been deleted.");
                        break;

                    case 2:
                        BankEmployee.EmployeeMenu();
                        break;

                    default:
                        DeleteCustomerAcc(customerAccDetails);
                        break;
                }
            }
           
            
        }


    }



}

