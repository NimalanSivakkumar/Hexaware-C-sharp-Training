using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking_asssignment
{
    public interface ICustomerServiceProvider
    {
        float GetAccountBalance(long accountNumber);
        void Deposit(long AccountNumber,float Amount);
        void Withdraw(long AccountNumber,float Amount);
        void Transfer(long FromAccountNumber, int ToAccountNumber, float amount);
        void GetAccountDetails(long AccountNumber);


    }
}
