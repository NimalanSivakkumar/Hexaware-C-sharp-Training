using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoAssignment.Data;

namespace AdoAssignment
{
    public class BankApp
    {
        public static IBankRepository bankrepository = new BankRepositoryImpl();


        public static void Execute()
        {

            while (true)
            {
                Console.WriteLine("1.Create Account");
                Console.WriteLine("2.Deposit");
                Console.WriteLine("3.Withdraw");
                Console.WriteLine("4.Get Balance");
                Console.WriteLine("5.Transfer");
                Console.WriteLine("6.Get account info");
                Console.WriteLine("7.List Accounts");
                Console.WriteLine("8.Get transaction details");
                Console.WriteLine("9.Calculate Interest");
                Console.WriteLine("10.leave");
                Console.WriteLine("Enter choice");
                string choice = Console.ReadLine();

                switch (choice)
                {

                    case "1":
                        CreateAccount();
                        break;

                    case "2":
                        Deposit();
                        break;

                       case "3":
                        Withdraw();
                        break;

                    case "4":
                        GetBalance();
                        break;

                    case "5":
                        Transfer();
                        break;

                    case "6":
                        GetAccountInfo();
                        break;

                    case "7":
                        ListAccounts();
                        break;

                    case "8":
                        GetTransaction();
                        break;

                    case "9":
                        CalculateInterest();
                        break;

                    case "10":
                        Console.WriteLine("Bye bye");
                        break;

                    default:
                        Console.WriteLine("invalid choice");
                        break;

                }
            }

        }

        public static void CreateAccount()
        {
            Account a = new Account();
            Console.WriteLine("Enter account type");
            Console.WriteLine("1.savings");
            Console.WriteLine("2.current");
            Console.WriteLine("3.zerobalance");
             string accountType = Console.ReadLine();

            Console.WriteLine("enter First name");
            string firstName = Console.ReadLine();

            Console.WriteLine("enter last name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();

            Console.WriteLine("enter phone");
            string phone = Console.ReadLine();

            Console.WriteLine("Enter address");
            string address = Console.ReadLine();

            Console.WriteLine("Enter initial balance");
            float initialbalance = Convert.ToSingle(Console.ReadLine());

            

            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Address = address



            };
            try
            {
                bankrepository.CreateAccount(customer, accountType, initialbalance);
                Console.WriteLine("account created");
            }
            catch(Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }



        }

        public static void Deposit()
        {
            try
            {
                Console.WriteLine("enter acc no");
                long Accountno = long.Parse(Console.ReadLine());
                Console.WriteLine("enter amt");
                double amt = Convert.ToDouble(Console.ReadLine());
                double newamt = bankrepository.Deposit(Accountno, amt);
                Console.WriteLine($"new balance :{newamt}");
            }
            catch(InsufficientFundException ex)
            {
                Console.WriteLine(ex.Message );
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void Withdraw()
        {
            try
            {
                Console.WriteLine("enter acc no");
                long Accountno = long.Parse(Console.ReadLine());
                Console.WriteLine("enter amt");
                decimal amt = Convert.ToDecimal(Console.ReadLine());
                double newamt = bankrepository.Withdraw(Accountno, amt);
                Console.WriteLine($"new balance :{newamt}");
            }
            catch (InsufficientFundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public static void GetBalance()
        {
            try
            {
                Console.WriteLine("enter acc no");
                long accnumber = long.Parse(Console.ReadLine());
                double balance = bankrepository.GetBalance(accnumber);
                Console.WriteLine($"account balance:{balance}");
            }
            catch (InsufficientFundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void Transfer()
        {
            try
            {
                Console.WriteLine("Enter from acc");
                long from = long.Parse(Console.ReadLine());
                Console.WriteLine("Enter to acc");
                long to = long.Parse(Console.ReadLine());
                Console.WriteLine("enter amt");
                double amt = Convert.ToDouble(Console.ReadLine());
                bankrepository.Transfer((int)from, (int)to, amt);
                Console.WriteLine("Transfer done");
            }
            catch (InsufficientFundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }

        public static void GetAccountInfo()
        {
            try
            {
                Console.WriteLine("Enter acc no");
                long accountnum = long.Parse(Console.ReadLine());
                var get = bankrepository.GetBalance((int)accountnum);
                Console.WriteLine(get);
            }
            catch (InsufficientFundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public static void ListAccounts()
        {
            var list = bankrepository.ListAccounts();
            foreach( var account in list )
            {
                Console.WriteLine(account);
            }
        }

        public static void GetTransaction()
        {
            Console.WriteLine("enter from date");
            DateTime from = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter to date");
            DateTime to = DateTime.Parse(Console.ReadLine());
            var transaction = bankrepository.GetTransaction(from, to);
            foreach(var trans in transaction )
            {
                Console.WriteLine(trans);
            }
        }

        public static void CalculateInterest()
        {
            try
            {
                bankrepository.CalculateInterest();
                Console.WriteLine("interest calculation done");
            }
            catch (InsufficientFundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }



    }
}
