using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using case_study.Dao;
using case_study.Entity;
using case_study.Exceptions;

namespace case_study.Main
{
    internal class EcomApp
    {
        static void Main(string[] args)
        {
            IOrderProcessorRepository repository = new OrderProcessorRepositoryImpl();
            UserInterface ui = new UserInterface();
            bool running = true;
            Customer customer = null;

            while (running)
            {

                Console.WriteLine("1. Register Customer");
                Console.WriteLine("2. Create Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Add to Cart");
                Console.WriteLine("5. View Cart");
                Console.WriteLine("6. Place Order");
                Console.WriteLine("7. View Customer Orders");
                Console.WriteLine("8. leave");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();



                try
                {
                    switch (option)
                    {

                        case "1":
                            Customer newCustomer = new Customer
                            {
                                CustomerId = ui.GetCustomerId(),
                                Name = ui.GetCustomerName(),
                                Email = ui.GetCustomerEmail(),
                                Password = ui.GetCustomerPassword()
                            };

                            bool customerAdded = repository.CreateCustomer(newCustomer);
                            Console.WriteLine(customerAdded ? "customre registered " : "customer not registered");
                            break;

                        case "2":
                            Product newProduct = new Product
                            {
                                ProductId = ui.GetProductId(),
                                Name = ui.GetProductName(),
                                Price = ui.GetProductPrice(),
                                Description = ui.GetProductDescription(),
                                StockQuantity = ui.GetProductStock()
                            };
                            bool ProductAdded = repository.CreateProduct(newProduct);
                            Console.WriteLine(ProductAdded ? "product addded" : "product not added");
                            break;

                        case "3":
                            int delId = ui.GetProductId();
                            bool deleted = repository.DeleteProduct(delId);
                            Console.WriteLine(deleted ? "Product deleted." : "Product not deleted.");
                            break;

                        case "4":
                            int customerId = ui.GetCustomerId();
                            int productId = ui.GetProductId();
                            int quantity = ui.GetQuantity();
                            Product product = new Product { ProductId = productId };
                            bool addedToCart = repository.AddToCart(customerId, product, quantity);
                            Console.WriteLine(addedToCart ? "Added to cart." : "Failed to add to cart.");
                            break;

                        case "5":
                            int custId = ui.GetCustomerId();

                            Customer retrivedcustomer = repository.GetCustomerById(custId);
                            if (retrivedcustomer == null)
                            {
                                Console.WriteLine("Customer not found.");
                                break;
                            }

                            var cartItems = repository.GetAllFromCart(retrivedcustomer);
                            if (cartItems.Count == 0)
                            {
                                Console.WriteLine("Your cart is empty.");
                            }
                            else
                            {
                                Console.WriteLine("Your cart contains:");
                                foreach (var item in cartItems)
                                {
                                    Console.WriteLine($"{item.ProductId} - {item.Name} - {item.Price} - Qty: {item.StockQuantity}");
                                }
                            }
                            break;

                        case "6":
                            int orderCustomerId = ui.GetCustomerId();
                            Customer fetchCustomer = repository.GetCustomerById(orderCustomerId);
                            if (fetchCustomer == null)
                            {
                                Console.WriteLine("Customer not found.");
                                break;
                            }

                            var itemsInCart = repository.GetAllFromCart(fetchCustomer);
                            if (itemsInCart.Count == 0)
                            {
                                Console.WriteLine("Your cart is empty.");
                                break;
                            }
                           

                            List<(Product, int)> orderItems = new List<(Product, int)>();
                            foreach (var item in itemsInCart)
                            {
                                var quantityincart = repository.productQuantity(item.ProductId);
                                Console.WriteLine($"Product: {quantityincart.Name} - Price: {quantityincart.Price} - Stock: {quantityincart.StockQuantity}");
                                int orderQuantity = ui.GetQuantity();

                                if (orderQuantity > item.StockQuantity)
                                {
                                    Console.WriteLine($"Not enough stock for {quantityincart.Name}. Available: {quantityincart.StockQuantity}");
                                    continue;
                                }

                                orderItems.Add((item, orderQuantity));
                            }

                            string shippingAddress = ui.GetShippingAddress();
                            bool orderPlaced = repository.PlaceOrder(fetchCustomer, orderItems, shippingAddress);

                            if (orderPlaced)
                            {
                                Console.WriteLine("Your order has been placed successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to place the order. Please try again.");
                            }
                            break;

                        case "7":

                            int orderCustomerIdForView = ui.GetCustomerId();
                            try
                            {
                                
                                Customer customers = repository.GetCustomerById(orderCustomerIdForView);

                                if (customers == null)
                                {
                                    Console.WriteLine("Customer not found.");
                                    break;
                                }

                                
                                var orders = repository.GetOrdersByCustomer(customers.CustomerId);

                                if (orders.Count == 0)
                                {
                                    Console.WriteLine("No orders found for this customer.");
                                }
                                else
                                {
                                    Console.WriteLine("Orders for customer " + customers.CustomerId + ":");
                                    foreach (var order in orders)
                                    {
                                        var orderproduct = order.Item1;  
                                        int orderquantity = order.Item2; 

                                        Console.WriteLine($"Product: {orderproduct.Name}, Qty: {orderquantity}, Price: {orderproduct.Price}, Total: {orderproduct.Price * orderquantity}");
                                    }
                                }
                            }
                            catch (OrderNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                            break;

                        case "8":
                            running = false;
                            Console.WriteLine("bye bye");
                            break;

                        default:
                            Console.WriteLine("Invalid choice");
                            break;


                    }
                }
                catch (ProductNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (CustomerNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (OrderNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                
            }
        }
    }
}
                


