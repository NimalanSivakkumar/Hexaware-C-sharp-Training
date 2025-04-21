using System.Xml.Linq;
using System.Data.SqlClient;
using case_study.Dao;
using case_study.Entity;
using case_study.Exceptions;
using NUnit.Framework;

namespace TestProjectfinal
{
    [TestFixture]
    public class Tests
    {

        public IOrderProcessorRepository repo = null;

        

        [SetUp]
        public void Setup()
        {
            repo = new OrderProcessorRepositoryImpl();

        }

        [Test]
        public void Test_Product_Created_Successfully()
        {


            Product product = new Product
            {
                ProductId = 12,
                Name = "keyboard1",
                Price = 32.99M,
                Description = "musical instrument",
                StockQuantity = 20
            };

            bool result = repo.CreateProduct(product);

            Assert.That(result, Is.True);
        }


        [Test]
        public void Test_PlaceOrder_WithExistingData_Success()
        {

            Customer customer = new Customer
            {
                CustomerId = 1
            };

            var products = new List<(Product, int)>
            {
               (new Product { ProductId = 3 }, 1)
            };

            string shippingAddress = "456 Billing St, Chennai";


            bool result = repo.PlaceOrder(customer, products, shippingAddress);


            Assert.That(result, Is.True);
        }





        [Test]
        public void AddToCart_InvalidCustomer_ThrowsCustomerNotFoundException()
        {
            var product = new Product { ProductId = 1 }; 

            Assert.Throws<CustomerNotFoundException>(() =>repo.AddToCart(9999, product, 1)); 
        }

        [Test]
        public void AddToCart_InvalidProduct_ThrowsProductNotFoundException()
        {
            var product = new Product { ProductId = 9999 }; 

            Assert.Throws<ProductNotFoundException>(() => repo.AddToCart(1, product, 1)); 
        }

        


        //[Test]
        //public void TestCustomerNotFoundException()
        //{
        //    var ex = Assert.Throws<CustomerNotFoundException>(() =>
        //    {
        //        throw new CustomerNotFoundException("Customer not found");
        //    });
        //    Assert.AreEqual("Customer not found", ex.Message);
        //}




        [Test]
        public void Test_Product_Added_To_Cart_Successfully()
        {


            Customer customer = new Customer { CustomerId = 2 };
            Product product = new Product { ProductId = 5 };

            bool result = repo.AddToCart(customer.CustomerId, product, 2);

            Assert.That(result, Is.True);
        }


        [Test]
        public void DeleteCustomerShouldThrowExceptionWhenCustomerDoesNotExist()
        {

            int invalidCustomerId = -1;


            var ex = Assert.Throws<CustomerNotFoundException>(() => repo.DeleteCustomer(invalidCustomerId));
            Assert.That(ex.Message, Does.Contain("not there"));
        }



    }
}


