1 challenge was to make a loop working if the user enters a letter instead of a number 
	to be able to make it I used the TryParse, while loop, switch case

2 challenge find a way to compare the customer details with the accounts created, if right let them in if not repeat details.
	solve that creating method ValidateCustomer which read customer.txt and loop inside it comparing if the variables exist in there.
	accountcode, pin, name and last name (almost same structure when creating a new customer.)

3 challenge was creating the customer.txt file, needed a way to add every new account in the file using the same variables 
	solved that passing variables when creating the object.

4 challenge how to add every new customer account in a new line, keeping the old ones 
	solved that putting TRUE after filetowrite.

5 challenge how to retrieve each first letter of the customer name and calculate the full name lenght. 
	Did that using string.length for the full name and for first letters of each name string.Substring.

6 challenge how to get the position of the first letter of each name according to the table given.
	string contains worked well created a method in Driver class to find the first letter of each name and get the position according to the table

7 challenge formating the deposit/withdrawl transactions in the savings/current accounts files. AND input the date.
	solved that using DateTime.Now.ToString found that in Microsoft docs.

8 challenge a way to check if the savings/current account exist if not make the user type account code again. 
	when the program as customer if your acc does not exist customer cant get in
	if exist custoemr get in and the account code pass to the customer menu and so on when opening other methods
	when using as employee to make transactions for customers have to type it right or create new files with the acc code typed.

9 challenge update the balanceCurrentAcc/SavingsAcce and write to the file the new balance when making transactions.
	solved that with GetCurrentBalance/SavingsBalance, last position of the array is the balance and returning it as decimal.

10 challenge how to list customers and display balance of savings and current accounts of each one
	with the GetCurrentBalance/Savings the last position of the array is always the balance,
	just put that in a variable and return it.
	when there is a transaction i get that value, add the amount in the transaction and write the file again with the new line/updated balance.

11 challenge delete customers and update customer.txt file
	the first part to check balances was ok nothing challenge
	the second part when gets in the switch case 1
		i was having erro because streamwriter/reader was being used by another process...
		and the file was being used as well
			was when i discover streamreader or streamwriter.Close();
			file.delete and move which made my life easier.
		works like read > keep it open and write to another file > close writer and close reader
		after that delete files which has that acc code and delete the old customer.txt file
		rename the new-customers.txt to customers.txt
	customer deleted

### Changed the variable path from absolute path to relative ./BankFiles
To be able to to that had to change the location of the folder BankFiles to ./bin/Debug/net5.0/BankFiles


Abstract classes  *******?   Interface *******?
	Not confident enough to use it and i think i need more understanding of what it is to be able to see it's use.


Best regards,
Josue Dilmo dos Santos
Sno: 24061