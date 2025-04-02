namespace banking_asssignment
{
    internal class Account
    {
        public int account_number;
        public string account_type;
        public int acc_balance;

        public int Account_number
        {
            set { account_number = value; }
            get { return account_number; }
        }
        public string Account_type
        {
            set { account_type = value; }
            get { return account_type; }
        }

        public int Acc_balance
        {
            set { acc_balance = value; }
            get { return acc_balance; }
        }

        public Account(int account_number, string account_type, int acc_balance)
        {
            this.account_number = account_number;
            this.account_type = account_type;
            this.acc_balance = acc_balance;
        }
        //method overloading of deposit

        public void DepositArea(int amount)
        {

            if (amount > 0)
            {
                acc_balance = (int)(amount + acc_balance);
                Console.WriteLine($"depositted the amount{amount},account_balance is {acc_balance}");
            }
            else
            {
                Console.WriteLine("amt should not be null");
            }
        }
        public void DepositArea(double amount)
        {

            if (amount > 0)
            {
                acc_balance = (int)(amount + acc_balance);
                Console.WriteLine($"depositted the amount is {amount},account_balance is {acc_balance} ");
            }
            else
            {
                Console.WriteLine("amt should not be null");
            }
        }

        public void DepositArea(float amount)
        {
            if (amount > 0)
            {
                acc_balance = (int)(amount + acc_balance);
                Console.WriteLine($"depositted the amount is {amount},balance is {acc_balance} ");
            }
            else
            {
                Console.WriteLine("amt should not be null");
            }
        }
        //method overloading of withdraw
        public void WithdrawArea(float amount)
        {
            if (amount < acc_balance)
            {
                acc_balance -= (int)amount;
                Console.WriteLine($"successful withdrawal here is amt {amount},balance is {acc_balance}");
            }
            else
            {
                Console.WriteLine("amount is higher than balance");
            }
        }

        public void WithdrawArea(int amount)
        {
            if (amount < acc_balance)
            {
                acc_balance -= (int)amount;
                Console.WriteLine($"successful withdrawal here is amt {amount},balance is {acc_balance}");
            }
            else
            {
                Console.WriteLine("amount is higher than balance");
            }
        }


        public virtual void WithdrawArea(double amount)
        {
            if (amount < acc_balance)
            {
                acc_balance -= (int)amount;
                Console.WriteLine($"successful withdrawal here is amt {amount},balance is {acc_balance}");
            }
            else
            {
                Console.WriteLine("amount is higher than balance");
            }
        }



        //display
        public void Display()
        {
            Console.WriteLine($"AccountNumber : {account_number},AccountType : {account_type},AccountBalance = {acc_balance}");
        }

        //interest
        public virtual void CalculateInterest()
        {
            if (account_type == "savings")
            {
                double Interest_Amt = acc_balance * 4.5;
                acc_balance = (int)(acc_balance + Interest_Amt);
                Console.WriteLine($"Interest amount is {Interest_Amt} and account balance is {acc_balance}");

            }
            else
            {
                Console.WriteLine("Interest can be found for savings acct only");

            }
        }

    }
        //Inheritance
        class SavingAccount : Account
        {
            private double InterestRate;

            public SavingAccount(int account_number, double acc_balance, double interestRate = 4.5) : base(account_number, "savings", (int)acc_balance)
            {
                this.InterestRate = interestRate;
            }

            public override void CalculateInterest()
            {
                double interest_amt = acc_balance * 4.5;
                acc_balance += (int)interest_amt;
                Console.WriteLine($"Interest amt is {interest_amt} and balance is {acc_balance}");
            }

        }

        class CurrentAccount : Account
        {


            private const double overdraftlimit = 3000.00;

            public CurrentAccount(int account_number, double acc_balance) : base(account_number, "current", (int)acc_balance)
            {

            }

            public override void WithdrawArea(double amount)
            {
                if (amount < acc_balance)
                {
                    acc_balance -= (int)amount;
                    Console.WriteLine($"successful withdrawal here is amt {amount},balance is {acc_balance}");
                }
                else
                {
                    Console.WriteLine("amount is higher than balance");
                }


            }
        } 
    
}
