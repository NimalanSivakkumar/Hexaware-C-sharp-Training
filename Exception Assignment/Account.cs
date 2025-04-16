using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_assignment
{
    public class Account : IComparable<Account>
    {
        public int AccountNumber {  get; set; }
        public string Name { get; set; }
        public double Balance {  get; set; }
        public string AccountType {  get; set; }

        public Account(int accNo,string name,double balance,string accounttype) 
        { 
            this.AccountNumber = accNo;
            this.Name = name;
            this.Balance = balance;
            this.AccountType = accounttype;

        }

        public void Deposit(double amount)







    }
}
