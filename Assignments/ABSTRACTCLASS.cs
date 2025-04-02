namespace banking_asssignment
{
    abstract class BANKACCOUNT
    {

        public int AccountNumber;
        public string CustomerName;
        public double Balance;


        public BANKACCOUNT(int AccountNumber, string CustomerName, double Balance)
        {
            this.AccountNumber = AccountNumber;
            this.CustomerName = CustomerName;
            this.Balance = Balance;
        }
        public int AccountNumber
        {
            set { accountNumber = value; }
            get { return accountNumber; }
        }
        public string CustomerName
        {
            set { customerName = value; }
            get { return customerName; }
        }

        public double Balance
        {
            set { balance = value; }
            get { return balance; }
        }

        public void Display()
        {
            Console.WriteLine($"ACCNUM : {AccountNumber},customername : {CustomerName},balance : {Balance}");
        }


       
        public abstract void CalculateInterestvalue();
        public abstract void withdraw(float amount);


    }

    class SavingsAccount : BANKACCOUNT
    {

        private double interestRate = 4.5;

        public SavingsAccount(int accountNumber,string CustomerName,double Balance):base(accountNumber, CustomerName, Balance) { }


        public override void CalculateInterestvalue()
        {
            double interestAMt = Balance * 4.5;
            Balance = Balance + interestAMt;
            Console.WriteLine($"Interest amt is {interestAMt},balance is {Balance}");

        }
    }
    class CurrentAccounts : BANKACCOUNT
    {
        private double overdraftlimits = 4500;

        public CurrentAccounts(int accountNumber, string CustomerName, double Balance) : base(accountNumber, CustomerName, Balance) { }e

        public override void withdraw(float amount)
        {
            if (amount < 0 && (Balance - amount) >= overdraftlimits)
            {
                Balance -= (int)amount; 
                Console.WriteLine($"successful withdrawal here is amt {amount},balance is {Balance}");
            }
            else
            {
                Console.WriteLine("amount is higher than balance");
            }

        }




    }



    
}
