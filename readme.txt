First challenge was to make a loop working if the user enters a letter instead of a number 
	to be able to make it I used the TryParse, while loop, switch case

Second challenge find a way to compare the customer details with the accounts created, if right let them in else repeat.
	***?

Third challenge was creating the customer.txt file, needed a way to add every new account in the file using the same variables 
	solved that passing variables when creating the object.

Fourth challenge how to add every new customer account in a new line, keeping the old ones 
	solved that putting TRUE after filetowrite.

Fifth challenge how to retrieve each first letter of the customer name and calculate the full name lenght. 
	Did that using string.length for the full name and for first letters of each name string.Substring.

Sixth challenge how to get the position of the first letter of each name according to the table given.
	string contains worked well created a method in Driver class to find the first letter of each name and get the position according to the table

Seventh challenge formating the deposit/withdrawl transactions in the savings/current accounts files. AND input the date.
	solved that using DateTime.Now.ToString found that in Microsoft docs.

Eighth challenge a way to check if the savings/current account exist if not make the user type account code again. (why? if the account code does not exist it is creating a new file, if misstype create new file)
	****?

Nineth challenge update the balance in the class CurrentAccBalance/SavingsAccBalance and write to the file the new balance.
	solved that with get/set, creation of a list and a class for the transactions separate by current/savings account

Tenth challenge how to list customers and display balance of savings and current accounts of each one
	***? ListCustomers readfile customers.txt ... but .... how to get their balances?? loop through all the transactions and sum it? Or read their files and 
		in some way get the last transaction/balance?

Eleventh challenge delete customers and update customer.txt file
	****? no ideia
