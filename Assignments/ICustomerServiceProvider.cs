using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoAssignment
{
    internal interface ICustomerServiceProvider
    {
        float GetAccountBalance(long accountNumber);
        int Deposit(long AccountNumber, float Amount);
        int Withdraw(long AccountNumber, float Amount);
        int Transfer(long FromAccountNumber, int ToAccountNumber, float amount);
        void GetAccountDetails(long AccountNumber);


        List<Transaction> GetTransactions(DateTime fromD, DateTime ToD);

    }
}
