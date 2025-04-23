namespace banking_asssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Customer customer2 = new Customer(1001, "Nimal", "Siva", "nim@mail.com", 12345789, "29/37 North street");
            //customer2.Display();


            //Account account1 = new Account(1200, "savings", 3500);
            //account1.Display();
            //account1.WithdrawArea(100);
            //account1.WithdrawArea(200.00);
            //account1.WithdrawArea(250.12f);

            //account1.DepositArea(1000);
            //account1.DepositArea(2000.00);
            //account1.DepositArea(3000.00f);
            //account1.CalculateInterest();

            //SavingAccount s1 = new SavingAccount(1501, 5000.00);
            //s1.Withdraw(100);
            //s1.Deposit(3000);
            //s1.Display();

            //CurrentAccount c1 = new CurrentAccount(1601, 50000);
            //c1.Withdraw(100);
            //c1.Deposit(6000);
            //c1.Display();
            //BankAccount newaccount = null;
            //Console.WriteLine("1.saving account creation");
            //Console.WriteLine("2.Current account creation");
            //Console.WriteLine("enter any one option");
            //int option = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Enter new account numberr");
            //int account_numberrr = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Please deposit initial amt");
            //double depoamt = Convert.ToDouble(Console.ReadLine());

            //switch (option)
            //{
            //    case 1:

            //        newaccount = new SavingAccount(account_numberrr, depoamt);
            //        Console.WriteLine($"saving account created with acc num {account_numberrr},balance is {depoamt} ");
            //        break;
            //    case 2:

            //        newaccount = new CurrentAccount(account_numberrr, depoamt);
            //        Console.WriteLine($"saving account created with acc num {account_numberrr},balance is {depoamt} ");
            //        break;

            //}
            //while (true)
            //{

            //    Console.WriteLine("1.Deposit");
            //    Console.WriteLine("2.Withdraw");
            //    Console.WriteLine("3.calculate Interest");
            //    Console.WriteLine("Enter choice");
            //    int choice = Convert.ToInt32(Console.ReadLine());

            //    switch (choice)
            //    {
            //        case 1:
            //            Console.WriteLine("Enter deposit amt");
            //            double deposit_amount = Convert.ToDouble(Console.ReadLine());
            //            newaccount.Deposit((float)deposit_amount);
            //            break;

            //        case 2:
            //            Console.WriteLine("Enter withdraw amt");
            //            double withdraw_amount = Convert.ToDouble(Console.ReadLine());
            //            newaccount.Withdraw((float)withdraw_amount);
            //            break;

            //        case 3:
            //            newaccount.CalculateInterest();
            //            break;


            ////    }

            //Bank bank = new Bank();
            //Customer customer1 = new Customer(1, "albert", "joe", "aj@mail.com","123456789", "123 road");
            //Customer customer2 = new Customer(2, "kumar", "kohli", "kk@mail.com", "1326233152", "7345 main road");

            //while(true)
            //{

            //Console.WriteLine("1.Create account");
            //Console.WriteLine("2.Deposit");
            //Console.WriteLine("3.Withdraw");
            //Console.WriteLine("4.get Account details");
            //Console.WriteLine("5.leave");
            //Console.WriteLine("Enter option");

            //string option = Console.ReadLine();

            //switch (option)
            //{
            //    case 1:
            //        Console.WriteLine("Enter customer Id");
            //        int CustomerID = Convert.ToInt32(Console.ReadLine());
            //        Console.WriteLine("Enter first name");
            //        string firstName = Console.ReadLine();
            //        Console.WriteLine("Enter last name");
            //        string lastName = Console.ReadLine();
            //        Console.WriteLine("Enter phone n o");
            //        string phone = Console.ReadLine();
            //        Console.WriteLine("Enter email");
            //        string email = Console.ReadLine();
            //        Console.WriteLine("Enter address");
            //        string address = Console.ReadLine();

            //        Customer customer = new Customer(CustomerID, firstName, lastName, email, phone, address);

            //        Console.WriteLine("Enter acc type");
            //        string accountType = Console.ReadLine();
            //        Console.WriteLine("Enter initial amt");
            //        float ini_balance = Convert.ToSingle(Console.ReadLine());

            //        Bank.CreateAccount(customer, AccountNumber, accountType, ini_balance);

            //        break;

            //    case 2:

            //        Console.WriteLine("Enter acc no");
            //        int accountNumber = Convert.ToInt32(Console.ReadLine());
            //        Console.WriteLine("enter amt");
            //        float amount = Convert.ToSingle(Console.ReadLine());
            //        Bank.Deposit(accountNumber, amount);
            //        break;

            //    case 3:


            //        Console.WriteLine("Enter acc no");
            //        int accountNumber1 = Convert.ToInt32(Console.ReadLine());
            //        Console.WriteLine("enter amt");
            //        float amount1 = Convert.ToSingle(Console.ReadLine());
            //        bank.Withdraw(accountNumber1, amount1);
            //        break;


            //    case 4:

            //        Console.WriteLine("enter acc num");
            //        int accountNumber2 = Convert.ToInt32((string)Console.ReadLine());

            //        bank.Display(accountNumber2);
            //        break;


            //    case 5:
            //        Console.WriteLine("leaving");
            //        break;
            //}






            //}

            //var Customer = new Customer(1, "siv", "nim", "nims@mail.com", "976545646", "north street");
            //var bank = new BankServiceProviderImpl();



            //bank.CreateAccount(Customer, "current", 2000);
            //bank.Deposit(1000, 1000);



            BankServiceProviderImpl bank = new BankServiceProviderImpl("C sharp bank", "North streeet");
             while(true)
             {
                try
                {
                    Console.WriteLine("1.Create Account");
                    Console.WriteLine("2.Deposit");
                    Console.WriteLine("3.Withdraw");
                    Console.WriteLine("4.Get Balance ");
                    Console.WriteLine("5.Transfer");
                    Console.WriteLine("6.GetAccountInfo");
                    Console.WriteLine("7.List Accounts");
                    Console.WriteLine("8.Interest calculation");
                    Console.WriteLine("9.Exit");
                    Console.WriteLine("Enter your wish");
                    int choice = Convert.ToInt32(Console.ReadLine());


                    switch (choice)
                    {
                        case 1:
                            CreateAccount(bank);
                            break;

                        case 2:
                            Console.WriteLine("Enter acc no");
                            long acc_n = long.Parse(Console.ReadLine());
                            Console.WriteLine("Enter amount");
                            float amount = Convert.ToSingle(Console.ReadLine());
                            bank.Deposit(acc_n, amount);

                            break;

                        case 3:

                            Console.WriteLine("Enter acc no");
                            long acc_n1 = long.Parse(Console.ReadLine());
                            Console.WriteLine("Enter amount");
                            float amount1 = Convert.ToSingle(Console.ReadLine());
                            bank.Withdraw(acc_n1, amount1);

                            break;

                        case 4:

                            Console.WriteLine("Enter acc no");
                            long acc_n2 = long.Parse(Console.ReadLine());
                            float balance = bank.GetAccountBalance(acc_n2);
                            Console.WriteLine("Balance: " + balance);
                            break;

                        case 5:

                            Console.WriteLine("Enter from acc no");
                            long from_acc_n = long.Parse(Console.ReadLine());
                            Console.WriteLine("Enter to acc no");
                            int to_acc_n = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter amt");
                            float amt = float.Parse(Console.ReadLine());
                            bank.Transfer(from_acc_n, to_acc_n, amt);
                            Console.WriteLine("Transfer successful");
                            break;

                        case 6:
                            Console.WriteLine("Enter from acc no");
                            long acc_n3 = long.Parse(Console.ReadLine());
                            bank.GetAccountDetails(acc_n3);

                            break;

                        case 7:
                            bank.ListAccounts();
                            break;

                        case 8:
                            Console.WriteLine("Enter account number to calculate interest:");
                            long accountnum = long.Parse(Console.ReadLine());
                            bank.CalculateInterest(accountnum);
                            break;

                        case 9:
                            Console.WriteLine("bye bye");
                            return;




                    }
                }
                catch (InvalidAccountException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NullPointerException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }







             }

            static void CreateAccount(BankServiceProviderImpl bank)
            {
                Console.WriteLine("Enter details");
                Console.WriteLine("enter id");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter First Name");
                string firstname = Console.ReadLine();
                Console.WriteLine("Enter Last Name");
                string lastname = Console.ReadLine();

                foreach (var c in bank.accounts)
                {
                    if (c.Owner.FirstName.ToLower() == firstname.ToLower())
                    {
                        Console.WriteLine("A customer with this first name already exists");
                        return;
                    }
                }
                foreach (var c in bank.accounts)
                {
                    if (c.Owner.LastName.ToLower() == lastname.ToLower())
                    {
                        Console.WriteLine("A customer with this last name already exists");
                        return;
                    }
                }




                Console.WriteLine("enter mail id");
                string email = Console.ReadLine();

                if (!Customer.IsValidEmail(email))
                {
                    Console.WriteLine("Invalid email address. Please provide a valid email.");
                    return;
                }

             

                Console.WriteLine("Enter phone no");
                string phone = Console.ReadLine();

                if (!Customer.IsValidPhoneNumber(phone))
                {
                    Console.WriteLine("Invalid phone number. Please provide a valid 10-digit phone number.");
                    return;
                }

                Console.WriteLine("Enter address");
                string address = Console.ReadLine();


                Customer customer = new Customer(id, firstname, lastname, email, phone,address);


                Console.WriteLine("enter account tye");
                Console.WriteLine("1.savings");
                Console.WriteLine("2.current");
                Console.WriteLine("3.zerobalance");
                Console.WriteLine("Enter choice");
                string choice = Console.ReadLine();

                //switch(choice)
                //{
                //    case 1:
                //        Console.WriteLine("savings");
                //        break;

                //    case 2:
                //        Console.WriteLine("Current");
                //        break;

                //    case 3:
                //        Console.WriteLine("Zerobalance");
                //        break;

                //}

                //if(choice > 3 )
                //{
                //    throw new InvalidAccountException("NO account type found");
                //}
                float depo_amt = 0;
                if (choice != "Zerobalance")
                {
                    Console.WriteLine("ENter initial deposit amt");
                     depo_amt = float.Parse(Console.ReadLine());
                }

                 bank.CreateAccount(customer, choice, depo_amt);
                Console.WriteLine($"account created,Account number is :{Account.LastAccNo}");
            }


        } 

    }
}
