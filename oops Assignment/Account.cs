
namespace banking_asssignment
{
    public abstract class Account 
    {

        public static int LastAccNo = 1500;
       

        public long AccountNumber { get; set; }
        public string AccountType { get; set; }
        public float AccountBalance { get; set; }
        public Customer Owner { get; set; }

        public Account(Customer owner, string accountType,float initialBalance)
        {
            AccountNumber = ++LastAccNo;
            AccountType = accountType;
            AccountBalance = initialBalance;
            Owner = owner;
        }


        public abstract void Deposit(long AccountNumber, float amount);

        public abstract void Withdraw(long AccountNumber, float amount);
     
        public override string ToString()
        {
            return $"AccountNumber : {AccountNumber},AccountType : {AccountType},AccountBalance = {AccountBalance}";
        }
    }



    class SavingsAccount : Account
    {
        public const float interestRate = 4.5f;
        public const double minimumBalance = 500;
        
        
        public SavingsAccount(Customer owner, float intialBalance) : base(owner, "Savings",intialBalance)
        {
            
        }

        public override void Deposit(long accountnumber,float amount)
        {
            if (amount < 0)
            {
                throw new InsufficientFundException("must be greater than zero");
            }
            else
            {
                AccountBalance += amount;
               
            }
            
        }

        public override void Withdraw(long accountnumber, float amount)
        {
            if ( AccountBalance - amount < 600)
            {
                throw new InsufficientFundException("less than min balance");
            }
            else
            {
                AccountBalance -= amount;
               
            }
        }

       
     



    }

    public class CurrentAccount : Account
    {

        public float OverdraftLimit = 1000f;

  
        public CurrentAccount(Customer owner,float initialBalance) : base(owner, "current", initialBalance)
        {
            
        }

        public override void Withdraw(long accountnumber, float amount)
        {
            if ( AccountBalance + OverdraftLimit  < amount)
            {
                throw new OverDraftLimitExcededException("limit exceede");
            }
            else
            {
                AccountBalance -= amount;
                Console.WriteLine($"Withdraw :{amount},remaining balance:{AccountBalance}");
            }


        }
        public override void Deposit(long accountnumber, float amount)
        {
            if (amount < 0)
            {
                throw new InsufficientFundException("amount is less than zero");
            }
            else
            {
                AccountBalance = amount + AccountBalance;
                Console.WriteLine($"depositted the amount is {amount},balance is {AccountBalance} ");
            }
        }

     

    }
   public class ZeroBalanceAccount : Account
   {
        public float OverdraftLimit = 1000f;
        public ZeroBalanceAccount(Customer owner,float initialBalance) : base(owner, "Zero Balance", initialBalance)
        { 
        
        }

        public override void Withdraw(long accountnumber, float amount)
        {
            if (AccountBalance + OverdraftLimit < amount)
            {
                throw new OverDraftLimitExcededException("limit exceede");
            }
            else
            {
                AccountBalance -= amount;

            }


        }
        public override void Deposit(long accountnumber, float amount)
        {
            if (amount < 0)
            {
                throw new InsufficientFundException("amount is less than zero");
            }
            else
            {
                AccountBalance = amount + AccountBalance;
                Console.WriteLine($"depositted the amount is {amount},balance is {AccountBalance} ");
            }
        }

    }


}
























        //public void Deposit(float amount)
        //{

        //    if (amount > 0)
        //    {
        //        acc_balance = (int)(amount + acc_balance);
        //        Console.WriteLine($"depositted the amount{amount},account_balance is {acc_balance}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("amt should not be null");
        //    }
        //}

        //public void Withdraw(float amount)
        //{
        //    if (amount < acc_balance)
        //    {
        //        acc_balance -= (int)amount;
        //        Console.WriteLine($"successful withdrawal here is amt {amount},balance is {acc_balance}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("amount is higher than balance");
        //    }
        //}

        //public void Transfer(long FromAccount, int ToAccount, float Amount)
        //{

        //    if (Amount < acc_balance)
        //    {
        //        acc_balance -= (int)Amount;
        //        ToAccount.acc_balance += Amount;
        //        Console.WriteLine($"Transfer done amt is {Amount},new balance is :{acc_balance} ");
        //    }
        //    else
        //    {
        //        Console.WriteLine("less balance than amount");
        //    }

        //}

    





        //public void DepositArea(double amount)
        //{

        //    if (amount > 0)
        //    {
        //        acc_balance = (int)(amount + acc_balance);
        //        Console.WriteLine($"depositted the amount is {amount},account_balance is {acc_balance} ");
        //    }
        //    else
        //    {
        //        Console.WriteLine("amt should not be null");
        //    }
        //}

        //public virtual void DepositArea(float amount)
        //{
        //    if (amount > 0)
        //    {
        //        acc_balance = (int)(amount + acc_balance);
        //        Console.WriteLine($"depositted the amount is {amount},balance is {acc_balance} ");
        //    }
        //    else
        //    {
        //        Console.WriteLine("amt should not be null");
        //    }
        //}
        ////method overloading of withdraw


        //public  virtual void WithdrawArea(int amount)
        //{
        //    if (amount < acc_balance)
        //    {
        //        acc_balance -= (int)amount;
        //        Console.WriteLine($"successful withdrawal here is amt {amount},balance is {acc_balance}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("amount is higher than balance");
        //    }
        //}


        //public virtual void WithdrawArea(double amount)
        //{
        //    if (amount < acc_balance)
        //    {
        //        acc_balance -= (int)amount;
        //        Console.WriteLine($"successful withdrawal here is amt {amount},balance is {acc_balance}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("amount is higher than balance");
        //    }
        //}




        //public void Display()
        //{
        //    Console.WriteLine($"AccountNumber : {account_number},AccountType : {account_type},AccountBalance = {acc_balance}");
        //}

        ////interest
        //public virtual void CalculateInterest()
        //{
        //    if (account_type == "savings")
        //    {
        //        double Interest_Amt = acc_balance * 4.5;
        //        acc_balance = (int)(acc_balance + Interest_Amt);
        //        Console.WriteLine($"Interest amount is {Interest_Amt} and account balance is {acc_balance}");

        //    }
        //    else
        //    {
        //        Console.WriteLine("Interest can be found for savings acct only");

        //    }
        //}


    //class SavingAccount : BankAccount
    //{
    //    public double InterestRate;

    //    public SavingAccount(int account_number, double acc_balance, double interestRate = 4.5) : base(account_number, "savings", (int)acc_balance)
    //    {
    //        this.InterestRate = interestRate;
    //    }

    //    public override void CalculateInterest()
    //    {
    //        double interest_amt = acc_balance * 4.5;
    //        acc_balance += (int)interest_amt;
    //        Console.WriteLine($"Interest amt is {interest_amt} and balance is {acc_balance}");
    //    }

    //    public override void Withdraw(float amount)
    //    {
    //        if (amount < acc_balance)
    //        {
    //            acc_balance -= (int)amount;
    //            Console.WriteLine($"successful withdrawal here is amt {amount},balance is {acc_balance}");
    //        }
    //        else
    //        {
    //            Console.WriteLine("amount is higher than balance");
    //        }
    //    }
    //    public override void Deposit(float amount)
    //    {
    //        if (amount > 0)
    //        {
    //            acc_balance += (int)amount;
    //            Console.WriteLine($"depositted the amount is {amount},balance is {acc_balance} ");
    //        }
    //        else
    //        {
    //            Console.WriteLine("amt should not be null");
    //        }
    //    }

    //}

    //class CurrentAccount : BankAccount
    //{


    //    public const double overdraftlimit = 3000.00;

    //    public CurrentAccount(int account_number, double acc_balance) : base(account_number, "current", (int)acc_balance)
    //    {
            
    //    }

    //    public override void Withdraw(float amount)
    //    {
    //        if (amount < acc_balance + overdraftlimit)
    //        {
    //            acc_balance -= (int)amount;
    //            Console.WriteLine($"successful withdrawal here is amt {amount},balance is {acc_balance}");
    //        }
    //        else
    //        {
    //            Console.WriteLine("amount is higher than balance");
    //        }


    //    }
    //    public override void Deposit(float amount)
    //    {
    //        if (amount > 0)
    //        {
    //            acc_balance = (int)(amount + acc_balance);
    //            Console.WriteLine($"depositted the amount is {amount},balance is {acc_balance} ");
    //        }
    //        else
    //        {
    //            Console.WriteLine("amt should not be null");
    //        }
    //    }

    //    public override void CalculateInterest()
    //    {
    //        double interest_amt = acc_balance * 4.5;
    //        acc_balance += (int)interest_amt;
    //        Console.WriteLine($"Interest amt is {interest_amt} and balance is {acc_balance}");
    //    }


    //

