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
            //s1.WithdrawArea(100);
            //s1.DepositArea(3000);
            //s1.Display();

            //CurrentAccount c1 = new CurrentAccount(1601, 50000);
            //c1.WithdrawArea(100);
            //c1.DepositArea(6000);
            //c1.Display();
            //Account newaccount = null;
            //Console.WriteLine("1.saving account creation");
            //Console.WriteLine("2.Current account creation");
            //Console.WriteLine("enter any one option");
            //int option = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Enter new account numberr");
            //int account_numberrr = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Please deposit initial amt");
            //double depoamt = Convert.ToDouble(Console.ReadLine());

            //switch(option)
            //{
            //    case 1:

            //        newaccount = new SavingAccount(account_numberrr, depoamt);
            //            Console.WriteLine($"saving account created with acc num {account_numberrr},balance is {depoamt} ");
            //        break;
            //    case 2:

            //        newaccount = new CurrentAccount(account_numberrr, depoamt);
            //            Console.WriteLine($"saving account created with acc num {account_numberrr},balance is {depoamt} ");
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
            //            newaccount.DepositArea(deposit_amount);
            //            break;

            //        case 2:
            //            Console.WriteLine("Enter withdraw amt");
            //            double withdraw_amount = Convert.ToDouble(Console.ReadLine());
            //            newaccount.WithdrawArea(withdraw_amount);
            //            break;

            //        case 3:
            //            newaccount.CalculateInterest();
            //            break;


            //    }

            Account newaccount = null;
            Console.WriteLine("1.saving account creation");
            Console.WriteLine("2.Current account creation");
            Console.WriteLine("enter any one option");
            int option = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter new account numberr");
            int account_numberrr = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Customer name");
            string custom_name = Console.ReadLine();

            Console.WriteLine("Enter initial  balance");
            double ini_balance = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    newaccount = new SavingsAccount(account_numberrr, custom_name, ini_balance);
                    Console.WriteLine($"saving account created with acc num {account_numberrr},balance is {ini_balance} ");
                    break;

                case 2:
                    newaccount = new CurrentAccounts(account_numberrr, custom_name, ini_balance);
                    Console.WriteLine($"saving account created with acc num {account_numberrr},balance is {ini_balance} ");
                    break;
            }

            while (true)
            {
                Console.WriteLine("1.Deposit");
                Console.WriteLine("2.Withdraw");
                Console.WriteLine("Enter choice");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter deposit amt");
                        double deposit_amount = Convert.ToDouble(Console.ReadLine());
                        newaccount.Deposit(deposit_amount);
                        break;

                    case 2:
                        Console.WriteLine("Enter withdraw amt");
                        double withdraw_amount = Convert.ToDouble(Console.ReadLine());
                        newaccount.Withdraw(withdraw_amount);
                        break;



                }

            }
        }
    }
}
