using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoAssignment
{
    public  class Account
    {
        public int LastAccNo = 1500;


        public long AccountNumber { get; set; }
        public string AccountType { get; set; }
        public float AccountBalance { get; set; }
        public Customer Owner { get; set; }

        public Account(Customer owner, string accountType, float initialBalance)
        {
            AccountNumber = ++LastAccNo;
            AccountType = accountType;
            AccountBalance = initialBalance;
            Owner = owner;
        }

        public Account()
        {
                
        }

        public virtual int Deposit(long AccountNumber, double amount)
        {
            if(amount <= 0)
            {
                throw new InsufficientFundException("amt must be greater than 0");
            }
            else
            {
                AccountBalance += (float)amount;
            }
            return (int)AccountBalance;
        }

        

        public virtual int Withdraw(long AccountNumber, double amount)
        {
         if(amount > AccountBalance)
         {
                throw new InsufficientFundException("amt cannot be greater than balance");
         }
            else
            {
                AccountBalance -= (float)amount;
            }
         return (int)AccountBalance;
        }





        public override string ToString()
        {
            return $"AccountNumber : {AccountNumber},AccountType : {AccountType},AccountBalance = {AccountBalance}";
        }
    }

    class SavingsAccount : Account
    {
        public const float interestRate = 4.5f;
        public const double minimumBalance = 500;


        public SavingsAccount(Customer owner, float intialBalance) : base(owner, "Savings", intialBalance < 500 ? throw new InsufficientFundException("initial balance must be greater than 500") : intialBalance) 
        {

        }

        public override int Deposit(long accountnumber, double amount)
        {
            if (amount < 0)
            {
                throw new InsufficientFundException("must be greater than zero");
            }
            else
            {
                AccountBalance += (float)amount;

            }
            return (int)AccountBalance;
        }

        public override int Withdraw(long accountnumber, double amount)
        {
            if (AccountBalance - amount < 600)
            {
                throw new InsufficientFundException("less than min balance");
            }
            else
            {
                AccountBalance -= (float)amount;

            }
            return (int)AccountBalance;
        }






    }

    public class CurrentAccount : Account
    {

        public float OverdraftLimit = 1000f;


        public CurrentAccount(Customer owner, float initialBalance) : base(owner, "current", initialBalance)
        {

        }

        public override int Withdraw(long accountnumber, double amount)
        {
            if (AccountBalance + OverdraftLimit < amount)
            {
                throw new OverDraftLimitExcededException("limit exceede");
            }
            else
            {
                AccountBalance -= (float)amount;

            }
            return (int)AccountBalance;


        }
        public override int Deposit(long accountnumber, double amount)
        {
            if (amount < 0)
            {
                throw new InsufficientFundException("amount is less than zero");
            }
            else
            {
                AccountBalance = (float)(amount + AccountBalance);
                Console.WriteLine($"depositted the amount is {amount},balance is {AccountBalance} ");
            }
            return (int)AccountBalance;
        }



    }
    public class ZeroBalanceAccount : Account
    {
        public float OverdraftLimit = 1000f;
        public ZeroBalanceAccount(Customer owner, float initialBalance) : base(owner, "Zero Balance", initialBalance)
        {

        }

        public override int Withdraw(long accountnumber, double amount)
        {
            if (AccountBalance + OverdraftLimit < amount)
            {
                throw new OverDraftLimitExcededException("limit exceede");
            }
            else
            {
                AccountBalance -= (float)amount;

            }
            return(int)AccountBalance;

        }
        public override int Deposit(long accountnumber, double amount)
        {
            if (amount < 0)
            {
                throw new InsufficientFundException("amount is less than zero");
            }
            else
            {
                AccountBalance = (float)(amount + AccountBalance);
                Console.WriteLine($"depositted the amount is {amount},balance is {AccountBalance} ");
            }
            return(int)AccountBalance;
        }


    }
}
