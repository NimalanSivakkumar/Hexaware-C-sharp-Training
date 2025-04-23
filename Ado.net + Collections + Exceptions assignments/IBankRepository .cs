using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoAssignment.Data
{
    public interface IBankRepository
    {
        void CreateAccount(Customer customer, string accountType, double initialbalance);

        int Deposit(long AccountNumber, double amount);
        int Withdraw(long AccountNumber, decimal amount);
        int GetBalance(long AccountNumber);
        void Transfer(int fromid, int toid, double amount);
        Account GetAccountDetails(long AccountNumber);
      
        List<Account> ListAccounts();

        void CalculateInterest();
        
       public List<Transaction>GetTransaction(DateTime fromdate, DateTime todate);





    }
}
