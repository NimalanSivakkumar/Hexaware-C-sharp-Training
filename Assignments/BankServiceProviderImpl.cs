using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoAssignment
{
    
    
        public class BankServiceProviderImpl : CustomerServiceProviderImpl, IBankServiceProvider
        {
            public string BranchName { get; set; }


            public string BranchAddress { get; set; }

            public BankServiceProviderImpl(string branchName, string branchAddress)
            {
                BranchName = branchName;
                BranchAddress = branchAddress;
            }




            public void CreateAccount(Customer customer, String accountType, float balance)
            {
                 Account newAccountCreation = null;

                //accountType = accountType.ToLower();

               if(accountType == "savings")
               {
                new SavingsAccount(customer, balance);
               }
               else if(accountType == "current")
               {
                new SavingsAccount(customer, balance);
               }
              else if (accountType =="zerobalance")
              {
                new SavingsAccount(customer, balance);
              }
              else
              {
                throw new InvalidAccountException("Invalid acct type bro");
              }

               accounts.Add(newAccountCreation);

            }


            public void ListAccounts()
            {
                if (accounts.Count() == 0)
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

                foreach (var account in accounts)
                {
                    if (account is SavingsAccount savingsAccount)
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
