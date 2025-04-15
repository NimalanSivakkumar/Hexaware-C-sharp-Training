using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoAssignment
{
    
    public class CustomerServiceProviderImpl
    {
        public List<Account> accounts = new List<Account>();
        public List<Transaction>translist = new List<Transaction>();
        //public HashSet<Account>accountsset = new HashSet<Account>(){ };
        //public Dictionary<long,Account>accountmap = new Dictionary<long,Account>();
        //private Account acc;

        public Account FindAccount(long accNo)
        {

            
            var account = accounts.Find(acc => acc.AccountNumber == accNo);
            if (account == null)
            {
                throw new InvalidAccountException("Account bro");
            }
            return account;
        }

        public float GetAccountBalance(long AccountNumber)
        {
            var account = accounts.Find(a=>a.AccountNumber == AccountNumber);
            return account.AccountBalance;
            //public virtual float GetAccountBalance(long AccountNumber)

            //{
            //    if(!accountmap.TryGetValue(AccountNumber,out acc))
            //    {
            //        throw new InvalidAccountException("Account bro");
                    
            //    }
            //    return acc.AccountBalance;
            //}
        }

        public int Deposit(long AccountNumber, float Amount)
        {
            var acc = FindAccount(AccountNumber);
            acc.Deposit(AccountNumber, Amount);
            return (int)acc.AccountBalance;

        }

        public int Withdraw(long AccountNumber, float Amount)
        {
            var acc = FindAccount(AccountNumber);
            acc.Withdraw(AccountNumber, Amount);
            return (int)acc.AccountBalance;


        }

        public void Transfer(long fromAccountNumber, int toAccountNumber, float amount)
        {
            var fromAccount = FindAccount(fromAccountNumber);
            var toAccount = FindAccount(toAccountNumber);
            fromAccount.Withdraw(fromAccountNumber, amount);
            toAccount.Deposit(toAccountNumber, amount);
            Console.WriteLine("Transfer done");
        }

        public void GetAccountDetails(long AccountNumber)
        {
            var acc = FindAccount(AccountNumber);

            Console.WriteLine(acc.ToString());

        }

        public List<Transaction>GetTransactions(DateTime fromD, DateTime toD)
        {

           List<Transaction>final = new List<Transaction>();
            foreach(Transaction t in translist)
            {
                if(t.DateATime >= fromD && t.DateATime<=toD)
                {
                    final.Add(t);
                }
            }

            return final;

        }

    }
}
