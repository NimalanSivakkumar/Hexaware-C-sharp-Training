using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoAssignment
{
    public class Transaction
    {
        public Account Accounts {  get; set; }
        
        public string Description {  get; set; }
       
        public DateTime DateATime {  get; set; }
       
        public string TransactionType {  get; set; }
        
        public decimal TransactionAmount {  get; set; }
       
        public Transaction(Account account, string description, DateTime dateTime, string transactionType, decimal transactionAmount)
        {
            this.Accounts = account;
            this.Description = description;
            this.DateATime = dateTime;
            this.TransactionType = transactionType;
            this.TransactionAmount = transactionAmount;
        }
        public Transaction()
        {
        }
        public override string ToString()
        {
            return $"Account:{Accounts},Description:{Description},Date and Time:{DateATime},Transaction Type:{TransactionType},Transaction amount{TransactionAmount}";
        }






    }
}
