using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking_asssignment
{
    public class BankServiceProviderImpl : CustomerServiceProviderImpl, IBankServiceProvider
    {
        public string BranchName {  get; set; }


        public string BranchAddress{ get; set; }

        public BankServiceProviderImpl(string branchName,string branchAddress)
        {
            BranchName = branchName;
            BranchAddress = branchAddress;
        }
        



        public void CreateAccount(Customer customer, String accountType, float balance)
        {
            Account newAccount = accountType switch

            //accountType = accountType.ToLower();

            //switch (accountType)
            {
                "savings" => new SavingsAccount(customer, balance),



                "current" => new CurrentAccount(customer, balance),


                "zerobalance" =>
                    new ZeroBalanceAccount(customer, balance),


                _ =>
                     throw new InvalidAccountException("Invalid account")

            };


                accounts.Add(newAccount);
                Console.WriteLine($"Acc created : {newAccount.AccountNumber} ");


            }
            
        

        public void ListAccounts()
        {
            if(accounts.Count() == 0)
            {
                throw new InvalidAccountException("Invalid Account bro");
            }
            else
            {
                foreach (var account in accounts)
                {
                    Console.WriteLine(account.ToString());
                }
            }
               
        }


        public void CalculateInterest()
        {
           
            foreach(var account in accounts)
            {
                if(account is SavingsAccount savingsAccount)
                {
                    float interest = savingsAccount.AccountBalance * SavingsAccount.interestRate;
                    savingsAccount.AccountBalance += interest;
                    Console.WriteLine($"Interest calculated,amount:{interest}");

                }
                else
                {
                    throw new InvalidAccountException("Account type is wrong");
                }
                
            }

        }


    }
}
