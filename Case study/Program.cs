//using System.Diagnostics;
//using case_study.Dao;
//using case_study.Entity;
//using case_study.Exceptions;

//namespace case_study.Main
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            IOrderProcessorRepository repository = new OrderProcessorRepositoryImpl();
//            bool running = true;
//            Customer customer = null;

//            while (running)
//            {

//                Console.WriteLine("1. Register Customer");
//                Console.WriteLine("2. Create Product");
//                Console.WriteLine("3. Delete Product");
//                Console.WriteLine("4. Add to Cart");
//                Console.WriteLine("5. View Cart");
//                Console.WriteLine("6. Place Order");
//                Console.WriteLine("7. View Customer Orders");
//                Console.WriteLine("8. leave");
//                Console.Write("Choose an option: ");
//                string option = Console.ReadLine();



//                try
//                {
//                    switch (option)
//                    {

//                        case "1":
//                            Console.WriteLine("Enter Customer id:");
//                            int id = Convert.ToInt32(Console.ReadLine());
//                            Console.WriteLine("Enter name");
//                            string name = Console.ReadLine();
//                            Console.WriteLine("enter email");
//                            string email = Console.ReadLine();
//                            Console.WriteLine("Enter password");
//                            string password = Console.ReadLine();

//                            Customer newCustomer = new Customer { CustomerId = id,Name = name, Email = email, Password = password };
//                            bool customerAdded = repository.CreateCustomer(newCustomer);
//                            Console.WriteLine(customerAdded ? "customre registered " : "customer not registered");
//                            break;

//                        case "2":
//                            Console.Write("Enter product name: ");
//                            string productname = Console.ReadLine();
//                            Console.WriteLine("Enter Product id");
//                            int productid = Convert.ToInt32(Console.ReadLine());
//                            Console.Write("Enter price: ");
//                            decimal productprice = decimal.Parse(Console.ReadLine());
//                            Console.Write("Enter description: ");
//                            string description = Console.ReadLine();
//                            Console.Write("Enter stock quantity: ");
//                            int stock = Convert.ToInt32(Console.ReadLine());

//                            Product newProduct = new Product { ProductId = productid,Name = productname, Price = productprice, Description = description, StockQuantity = stock };
//                            bool ProductAdded = repository.CreateProduct(newProduct);
//                            Console.WriteLine(ProductAdded ? "product addded" : "product not added");
//                            break;

//                        case "3":
//                            Console.Write("Enter product ID to delete: ");
//                            int delId = int.Parse(Console.ReadLine());
//                            bool deleted = repository.DeleteProduct(delId);
//                            Console.WriteLine(deleted ? "deleted product" : "product not deleted");
//                            break;

//                        case "4":
//                            Console.WriteLine("enter the customer_id");
//                            int customerid = Convert.ToInt32(Console.ReadLine());
//                            Console.Write("Enter product ID to add to cart: ");
//                            int productId = Convert.ToInt32(Console.ReadLine());
//                            Console.Write("Enter quantity: ");
//                            int quantity = Convert.ToInt32(Console.ReadLine());
//                            Product product = new Product { ProductId = productId };
//                            bool addedToCart = repository.AddToCart(customerid, product, quantity);
//                            Console.WriteLine(addedToCart ? "Added to cart." : "Failed to add to cart.");
//                            break;

//                        case "5":
//                            Console.Write("Enter your customer ID: ");
//                            int custId = Convert.ToInt32(Console.ReadLine());

//                            Customer retrivedcustomer = repository.GetCustomerById(custId);
//                            if (retrivedcustomer == null)
//                            {
//                                Console.WriteLine("Customer not found.");
//                                break;
//                            }

//                            var cartItems = repository.GetAllFromCart(retrivedcustomer);
//                            if (cartItems.Count == 0)
//                            {
//                                Console.WriteLine("Your cart is empty.");
//                            }
//                            else
//                            {
//                                Console.WriteLine("Your cart contains:");
//                                foreach (var item in cartItems)
//                                {
//                                    Console.WriteLine($"{item.ProductId} - {item.Name} - {item.Price} - Qty: {item.StockQuantity}");
//                                }
//                            }
//                            break;



//                        case "6":
                            
//                            Console.Write("Enter your customer ID: ");
//                            int customerId = int.Parse(Console.ReadLine());

                         
//                            Customer fetchcustomer = repository.GetCustomerById(customerId);
//                            if (fetchcustomer == null)
//                            {
//                                Console.WriteLine("Customer not found.");
//                                break; 
//                            }

                            
//                            var Itemsincart = repository.GetAllFromCart(fetchcustomer);
//                            if (Itemsincart.Count == 0)
//                            {
//                                Console.WriteLine("Your cart is empty.");
//                                break; 
//                            }

                            
//                            List<(Product, int)> orderItems = new List<(Product, int)>();
//                            foreach (var item in Itemsincart)
//                            {
//                                Console.WriteLine($"Product: {item.Name} - Price: {item.Price} - Stock: {item.StockQuantity}");
//                                Console.Write($"Enter quantity for {item.Name}: ");
//                                int orderquantity = int.Parse(Console.ReadLine());

                                
//                                if (orderquantity > item.StockQuantity)
//                                {
//                                    Console.WriteLine($"Not enough stock for {item.Name}. Available: {item.StockQuantity}");
//                                    continue; 
//                                }

//                                orderItems.Add((item, orderquantity));
//                            }

//                            Console.Write("Enter your shipping address: ");
//                            string shippingAddress = Console.ReadLine();

                          
//                            bool orderPlaced = repository.PlaceOrder(fetchcustomer, orderItems, shippingAddress);

                            
//                            if (orderPlaced)
//                            {
//                                Console.WriteLine("Your order has been placed successfully.");
//                            }
//                            else
//                            {
//                                Console.WriteLine("Failed to place the order. Please try again.");
//                            }
//                            break;

//                        case "7":
//                            Console.Write("Enter your customer ID: ");
//                            int getcustomerId = Convert.ToInt32(Console.ReadLine());

//                            try
//                            {
//                                // Fetch the customer object from the database
//                                Customer customers = repository.GetCustomerById(getcustomerId);

//                                if (customers == null)
//                                {
//                                    Console.WriteLine("Customer not found.");
//                                    break;
//                                }

//                                // Fetch the orders for this customer
//                                var orders = repository.GetOrdersByCustomer(customers.CustomerId);

//                                if (orders.Count == 0)
//                                {
//                                    Console.WriteLine("No orders found for this customer.");
//                                }
//                                else
//                                {
//                                    Console.WriteLine("Orders for customer " + customers.CustomerId + ":");
//                                    foreach (var order in orders)
//                                    {
//                                        var orderproduct = order.Item1;  // Product
//                                        int orderquantity = order.Item2; // Quantity

//                                        Console.WriteLine($"Product: {orderproduct.Name}, Qty: {orderquantity}, Price: {orderproduct.Price}, Total: {orderproduct.Price * orderquantity}");
//                                    }
//                                }
//                            }
//                            catch (OrderNotFoundException ex)
//                            {
//                                Console.WriteLine(ex.Message);
//                            }
//                            catch (Exception ex)
//                            {
//                                Console.WriteLine("Error: " + ex.Message);
//                            }
//                            break;

//                        case "8":
//                            running = false;
//                            Console.WriteLine("bye bye");
//                            break;

//                        default:
//                            Console.WriteLine("invalid choice");
//                            break;
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"{ex.Message}");
//                }



//            }

//        }
//    }    
//}
