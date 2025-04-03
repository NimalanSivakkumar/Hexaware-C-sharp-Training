using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_assignment
{
    internal class HMBank
    {
        public string account_num;
        public double account_balance;
        public string account_Nature;
        public int over_draft_limit;


        public HMBank(string account_num, double account_balance, string account_Nature,int over_draft_limit)
        {
            this.account_num = account_num;
            this.account_balance = account_balance;
            this.account_Nature = account_Nature;
            this.over_draft_limit = over_draft_limit;
        }

        public void Withdraw(double amount)
        {
            if(amount > account_balance)
            {
                throw new InsufficientFundException("amount large than balance");
            }

            else if (account_Nature == "current" && amount > over_draft_limit)
            {
                throw new OverDraftLimitExcededException("Large than limit and type is current");
            }

            else
            {
                account_balance = account_balance - amount;
                Console.WriteLine($"New balance is {account_balance}");
            }

        }

        public void Transfer(double amount,string receiveraccount)
        {
            if(amount > account_balance)
            {
                throw  new InsufficientFundException("amount large than balance");
            }

            else if (string.IsNullOrEmpty(receiveraccount) )
            {
                throw new NullPointerException("account num is null");
            }

            else if (!IsvalidAcc_num(receiveraccount))
            {
                throw new InvalidAccountException("Invalid account num");
            }
                   
            else
            {
                account_balance -= amount;
                receiveraccount += amount ;
                Console.WriteLine($"New balance is {receiveraccount}");
            }

        }

        public bool IsvalidAcc_num(string account_num)
        {
            return account_num.Length == 4;
        }

        public void Display()
        {
            Console.WriteLine($"acc_num {account_num},acc_type : {account_Nature},acc_balance : {account_balance}");
        }


    }
}
