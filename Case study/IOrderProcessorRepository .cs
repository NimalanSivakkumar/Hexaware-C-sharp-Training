using System;
using System.Collections.Generic;
using System.Linq;
using case_study.Entity;

namespace case_study.Dao
{
    public interface IOrderProcessorRepository
    {
        bool CreateProduct(Product product);
        bool CreateCustomer(Customer customer);

        bool DeleteProduct(int productId);

        bool DeleteCustomer(int customerId);

        bool AddToCart(int customerId, Product product, int quantity);

        bool RemoveFromCart(Customer customer, Product product);

        List<Product> GetAllFromCart(Customer customer);

        bool PlaceOrder(Customer customer, List<(Product,int)> products, string shippingAddress);

        Customer GetCustomerById(int customerId);

         List<Tuple<Product ,int>> GetOrdersByCustomer(int customerId);
        public Product productQuantity(int ProductId);




    }
}
