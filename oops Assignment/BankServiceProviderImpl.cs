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
            if (!Customer.IsValidPhoneNumber(customer.Phone))
            {
                throw new InvalidAccountException("Invalid phone number. Please provide a valid 10-digit phone number.");
            }

            if (!Customer.IsValidEmail(customer.Email))
            {
                throw new InvalidAccountException("incorrect email");
            }


            bool exists = accounts.Any(a => a.Owner.CustomerID == customer.CustomerID);
            if (exists)
            {
                throw new InvalidAccountException("Account already exists for this customer ID.");
            }


            Account newAccount;
            if (accountType == "savings")
            {
                newAccount = new SavingsAccount(customer, balance);
            }
            else if (accountType == "current")
            {
                newAccount = new CurrentAccount(customer, balance);
            }
            else if (accountType == "zerobalance")
            {
                newAccount = new ZeroBalanceAccount(customer, balance);
            }
            else
            {
                throw new InvalidAccountException("Invalid account");
            }
            accounts.Add(newAccount);
            

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


        public void CalculateInterest(long accountNumber)
        {
            var account = accounts.Find(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                Console.WriteLine("account not found");
                return;
            }
           
            
                if(account is SavingsAccount savingsAccount)
                {
                    float interest = savingsAccount.AccountBalance * SavingsAccount.interestRate;
                    savingsAccount.AccountBalance += interest;
                    Console.WriteLine($"Interest calculated,amount:{interest}");

                }
                else
                {
                Console.WriteLine("interest is calculated only for savings acct");
                }
                
            

        }


    }
}
