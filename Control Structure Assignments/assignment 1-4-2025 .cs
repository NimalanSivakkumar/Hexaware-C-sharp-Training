namespace assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //task1
            Console.WriteLine("Enter your credit score");
            int credit_score = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your annual Income");
            int annual_Income = Convert.ToInt32(Console.ReadLine());

            if (credit_score > 700 && annual_Income >= 50000)
            {
                Console.WriteLine("You are eligible for loan");
            }
            else
            {
                Console.WriteLine("Not eligible for loan");
            }


            //task3
            Console.WriteLine("Enter the customer count of bank");
            int c_count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < c_count; i++)
            {
                Console.WriteLine(i);

                Console.WriteLine("ENter the initial balance");
                double initial_balance = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter annual interest rate");
                double annual_rate = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter years");
                int years = Convert.ToInt32(Console.ReadLine());

                double future_balance = initial_balance * Math.Pow(1 + annual_rate / 100, years);

                Console.WriteLine("The future balance of customers is " + future_balance);

            }


            //task4
            string[] account_num = { "INDB1234", "INDB5678", "INDB9101" };
            double[] acc_balance = { 2000.12, 3000.20, 4000.00 };

            while (true)
            {
                Console.WriteLine("Enter account number");
                string account_number = Console.ReadLine();

                if (account_number.Length == 8 && account_number.StartsWith("INDB"))
                {
                    bool found = false;
                    for (int i = 0; i < account_num.Length; i++)
                    {
                        if (account_num[i].Equals(account_number))
                        {
                            Console.WriteLine($"your account balance is {acc_balance[i]} ");
                            found = true;
                            break;
                        }


                    }
                    if(found)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("acc not found");
                    }
                }

                else
                {
                    Console.WriteLine("Invalid account number format");
                }
            }


            //task5
            Console.WriteLine("Enter your account password");
            string password = Console.ReadLine();

            if ((password.Length >= 8) && (password.Any(char.IsUpper)) && (password.Any(char.IsDigit)))
            {
                Console.WriteLine("Password is valid");

            }
            else
            {
                Console.WriteLine("Password is invalid");
            }


            //task6
            Console.WriteLine("Enter the number of transactions");
            int trans_count = Convert.ToInt32(Console.ReadLine());
            string[] transaction = new string[trans_count];
            int transindex = 0;


            while (transindex < trans_count)
            {
                Console.WriteLine("Deposit");
                Console.WriteLine("Withdraw");
                Console.WriteLine("Enter your choice");
                string choice = Console.ReadLine();

                if (choice == "Deposit")
                {
                    Console.WriteLine("Enter deposit amount");
                    int depo_amt = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("deposited amt" + depo_amt);
                    transindex++;
                }

                else if (choice == "Withdraw")
                {
                    Console.WriteLine("Enter Withdraw amount");
                    int withdraw_amt = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("withdraw amt" + withdraw_amt);
                    transindex++;
                }

                else
                {
                    Console.WriteLine("Better luck next time");
                }

            }

            Console.WriteLine("transaction count");
            for (int i = 0; i < transaction.Length; i++)
            {
                Console.WriteLine(transaction[i]);

            }


            //task2
            Console.WriteLine("Enter your balance:");
            double balance = Convert.ToDouble(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("Deposit");
                Console.WriteLine("Check for balance");
                Console.WriteLine("withdraw");
                Console.WriteLine("Enter your choice");
                string choice = Console.ReadLine();

                if (choice == "Check for balance")
                {
                    Console.WriteLine("your account balance is " + balance);
                   
                }

                else if (choice == "Deposit")
                {
                    Console.WriteLine("enter deposit amount");
                    double deposit_amount = Convert.ToDouble(Console.ReadLine());

                    if (deposit_amount > 0)
                    {
                        balance = (int)(balance + deposit_amount);
                        Console.WriteLine("Successfully deposited,your current balance in account is " + balance);
                        
                    }
                    else
                    {

                        Console.WriteLine("better luck next time");
                        
                    }
                    
                }
                else if (choice == "withdraw")
                {
                    Console.WriteLine("enter withdraw amount");
                    double withdraw_amount = Convert.ToDouble(Console.ReadLine());

                    if (withdraw_amount % 100 != 0 && withdraw_amount % 500 != 0)
                    {
                        Console.WriteLine("Withdraw_amount should be multiples of 100 or 500 ");
                    }
                    else if (withdraw_amount > balance)
                    {
                        Console.WriteLine("it should not be greater than balance");
                    }
                    else
                    {
                        balance = (int)(balance - withdraw_amount);
                        Console.WriteLine("Successful withdrawal operation.the withdraw amt is " + withdraw_amount);
                        
                    }
                    
                }
                else
                {
                    Console.WriteLine("Thank you");
                    break;
                }


            }






        }
    }
}
