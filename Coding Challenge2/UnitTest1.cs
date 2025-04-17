using coding_challenge.Entity;
using NUnit.Framework;
using coding_challenge.Dao;
using coding_challenge.ExceptionInfor;



namespace TestProject3
{
    public class Tests
    {
        IPolicyService repo;
        [SetUp]
        public void Setup()
        {
            repo = new InsuranceServiceImplementation();
        }

      

        [Test]

        public void CreatePolicyTrueornot()
        {
            var policy = new Policy
            {
                PolicyId = 1,
                PolicyName = "Test",
                PolicyAmount = 6000.00m,
                PolicyDuration = DateTime.Now,
            };
           
            var result = repo.CreatePolicy(policy);
            Assert.IsTrue(result);

        }


    }
}