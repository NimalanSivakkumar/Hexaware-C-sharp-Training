namespace banking_asssignment
{
   public class CustomerServiceProviderImpl : ICustomerServiceProvider
   {
        public List<Account> accounts = new List<Account>();


     

        public Account FindAccount(long accNo)
        {
            var account = accounts.Find(acc => acc.AccountNumber == accNo);
            if (account == null)
            {
                throw new InvalidAccountException("Invalid Account bro");
            }
            return account;
        }

        public float GetAccountBalance(long AccountNumber)
        {
            var account = accounts.Find(a => a.AccountNumber == AccountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found");
                return -1;
            }
            return account.AccountBalance;

        }

        public void Deposit(long AccountNumber,float Amount)
        {
           var acc = FindAccount(AccountNumber);
            acc.Deposit(AccountNumber,Amount);
            Console.WriteLine(acc.AccountBalance);  

        }

        public void Withdraw(long AccountNumber, float Amount)
        {
            var acc = FindAccount(AccountNumber);
            acc.Withdraw(AccountNumber, Amount);
            Console.WriteLine(acc.AccountBalance); 


        }

        public void Transfer(long fromAccountNumber, int toAccountNumber, float amount)
        {
            var fromAccount = FindAccount(fromAccountNumber);
            var toAccount = FindAccount(toAccountNumber);
            fromAccount.Withdraw(fromAccountNumber,amount);
            toAccount.Deposit(toAccountNumber,amount);
           
        }

       public void GetAccountDetails(long AccountNumber)
        {
            var acc = FindAccount(AccountNumber);

            Console.WriteLine(acc.ToString());

        }

   
    }
}
