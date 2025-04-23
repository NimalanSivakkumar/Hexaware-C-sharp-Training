using AdoAssignment;
using AdoAssignment.Data;

namespace TestProject4
{
    public class Tests
    {
        public IBankRepository repo = null;
        [SetUp]
        public void Setup()
        {
            repo = new BankRepositoryImpl();
        }

        [Test]
        public void Test_GetAccountBalance_ValidAccountNumber()
        {
            
            var balance = repo.GetBalance(102);

            
            Assert.AreEqual(2000.00, balance);
        }

     

        [Test]
  
        public void Test_CreateAccount_Successfully()
        {
            // Arrange
            var newCustomer = new Customer
            {
                FirstName = "andre",
                LastName = "russel",
                Email = "drerus@mail.com",
                Phone = "9876543210",
                Address = "west indies"
            };

            string accountType = "current";
            double initialBalance = 2500.00;

            
            repo.CreateAccount(newCustomer, accountType, initialBalance);

            
            var createdAccount = repo.GetAccountDetails(104); 
            Assert.AreEqual(accountType, createdAccount.AccountType);
            Assert.AreEqual(initialBalance, createdAccount.AccountBalance);
        }




    }
}