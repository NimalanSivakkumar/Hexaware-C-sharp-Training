using AdoAssignment.Data;

namespace AdoAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BankApp.Execute();

            //AccountDaoImplementation accountDao = new AccountDaoImplementation();
            //CustomerDaoImpl customerDao = new CustomerDaoImpl();
            //TransactionDaoImpl transactionDao = new TransactionDaoImpl();

            //try
            //{

            //    Account A = new Account();
            //    A.AccountNumber = 


















            }




















            //BankServiceProviderImpl bank = new BankServiceProviderImpl("C sharp bank", "North streeet");
            //while (true)
            //{
            //    Console.WriteLine("1.Create Account");
            //    Console.WriteLine("2.Deposit");
            //    Console.WriteLine("3.Withdraw");
            //    Console.WriteLine("4.Get Balance ");
            //    Console.WriteLine("5.Transfer");
            //    Console.WriteLine("6.GetAccountInfo");
            //    Console.WriteLine("7.List Accounts");
            //    Console.WriteLine("8.Interest calculation");
            //    Console.WriteLine("9.Exit");
            //    Console.WriteLine("Enter your wish");
            //    int choice = Convert.ToInt32(Console.ReadLine());


            //    switch (choice)
            //    {
            //        case 1:
            //            CreateAccount(bank);
            //            break;

            //        case 2:
            //            Console.WriteLine("Enter acc no");
            //            long acc_n = long.Parse(Console.ReadLine());
            //            Console.WriteLine("Enter amount");
            //            float amount = Convert.ToSingle(Console.ReadLine());
            //            bank.Deposit(acc_n, amount);

            //            break;

            //        case 3:

            //            Console.WriteLine("Enter acc no");
            //            long acc_n1 = long.Parse(Console.ReadLine());
            //            Console.WriteLine("Enter amount");
            //            float amount1 = Convert.ToSingle(Console.ReadLine());
            //            bank.Withdraw(acc_n1, amount1);

            //            break;

            //        case 4:

            //            Console.WriteLine("Enter acc no");
            //            long acc_n2 = long.Parse(Console.ReadLine());
            //            bank.GetAccountBalance(acc_n2);
            //            break;

            //        case 5:

            //            Console.WriteLine("Enter from acc no");
            //            long from_acc_n = long.Parse(Console.ReadLine());
            //            Console.WriteLine("Enter to acc no");
            //            int to_acc_n = Convert.ToInt32(Console.ReadLine());
            //            Console.WriteLine("Enter amt");
            //            float amt = float.Parse(Console.ReadLine());
            //            bank.Transfer(from_acc_n, to_acc_n, amt);
            //            Console.WriteLine("Transfer successful");
            //            break;

            //        case 6:
            //            Console.WriteLine("Enter from acc no");
            //            long acc_n3 = long.Parse(Console.ReadLine());
            //            bank.GetAccountDetails(acc_n3);

            //            break;

            //        case 7:
            //            bank.ListAccounts();
            //            break;

            //        case 8:
            //            bank.CalculateInterest();
            //            break;

            //        case 9:
            //            Console.WriteLine("bye bye");
            //            return;




            //    }





            //}

            //static void CreateAccount(BankServiceProviderImpl bank)
            //{
            //    Console.WriteLine("Enter details");
            //    Console.WriteLine("enter id");
            //    int id = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine("Enter First Name");
            //    string firstname = Console.ReadLine();
            //    Console.WriteLine("Enter Last Name");
            //    string lastname = Console.ReadLine();
            //    Console.WriteLine("enter mail id");
            //    string email = Console.ReadLine();
            //    Console.WriteLine("Enter phone no");
            //    string phone = Console.ReadLine();
            //    Console.WriteLine("Enter address");
            //    string address = Console.ReadLine();


            //    Customer customer = new Customer(id, firstname, lastname, email, phone, address);


            //    Console.WriteLine("enter account tye");
            //    Console.WriteLine("1.savings");
            //    Console.WriteLine("2.current");
            //    Console.WriteLine("3.zerobalance");
            //    Console.WriteLine("Enter choice");
            //    string choice = Console.ReadLine();

            //    //switch(choice)
            //    //{
            //    //    case 1:
            //    //        Console.WriteLine("savings");
            //    //        break;

            //    //    case 2:
            //    //        Console.WriteLine("Current");
            //    //        break;

            //    //    case 3:
            //    //        Console.WriteLine("Zerobalance");
            //    //        break;

            //    //}

            //    //if(choice > 3 )
            //    //{
            //    //    throw new InvalidAccountException("NO account type found");
            //    //}
            //    float depo_amt = 0;
            //    if (choice != "Zerobalance")
            //    {
            //        Console.WriteLine("ENter initial deposit amt");
            //        depo_amt = float.Parse(Console.ReadLine());
            //    }

            //    bank.CreateAccount(customer, choice, depo_amt);
            //}






        
    }
}
