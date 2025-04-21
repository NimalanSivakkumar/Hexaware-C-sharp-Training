
using System;
using System.Linq;
using System.Collections.Generic;
using case_study.Entity;
using System.Data;
using System.Data.SqlClient;
using case_study.Dao;
using case_study.Entity;
using case_study.Exceptions;
using System.Transactions;


namespace case_study.Dao
{
    public class OrderProcessorRepositoryImpl : IOrderProcessorRepository
    {
        public string name;

        public static bool CustomerExists(int customerId)
        {
            try
            {
                using (SqlConnection con = DBUtility.GetConnection())
                {
                    string query = "select count(*) from customers where customer_id = @id";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@id", customerId);
                    return (int)command.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }

        public static bool ProductExists(int productId)
        {
            try {
                using (SqlConnection con = DBUtility.GetConnection())
                {
                    string query = "select count(*) from products where product_id = @id";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@id", productId);
                    return (int)command.ExecuteScalar() > 0;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
            
        }

        public bool CreateProduct(Product product)
        {
            using (SqlConnection con = DBUtility.GetConnection())
            {
                string query = "insert into products(product_id,name,price,description,stockQuantity) values (@id,@name,@price,@description,@stockQuantity)";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@id", product.ProductId);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@description", product.Description);
                command.Parameters.AddWithValue("@stockQuantity", product.StockQuantity);

                return command.ExecuteNonQuery() > 0;


            }

        }

        public bool CreateCustomer(Customer customer)
        {
            using(SqlConnection con = DBUtility.GetConnection())
            {

                string query = "insert into customers(customer_id,name,email,password)values(@cid,@name,@email,@password)";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@cid", customer.CustomerId);
                command.Parameters.AddWithValue("@name", customer.Name);
                command.Parameters.AddWithValue("@email", customer.Email);
                command.Parameters.AddWithValue("@password", customer.Password);

                return command.ExecuteNonQuery() > 0;


            }

        }

        public bool DeleteProduct(int productId)
        {
           using(SqlConnection con = DBUtility.GetConnection())
            {

                if(!ProductExists(productId))
                    throw new ProductNotFoundException($"product Id {productId} not found");

                string query = "delete from products where product_id = @productId";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@productId", productId);
                return command.ExecuteNonQuery() > 0;

            }
           
        }

        

        public bool DeleteCustomer(int customerId)

        {
            using(SqlConnection con = DBUtility.GetConnection())
            {

                if(!CustomerExists(customerId))
                        throw new CustomerNotFoundException($"Customer with Id{customerId} not there");


                string query = "delete from customers where customer_id = @customerId";
                SqlCommand command1 = new SqlCommand(query, con);
                command1.Parameters.AddWithValue("@customerId",customerId);
                return command1.ExecuteNonQuery() > 0;

            }
            
        }

        public bool AddToCart(int customerId, Product product, int quantity)
        {

            if(customerId <= 0)
            {
                Console.WriteLine("customer not found");
                return false;
            }
            if(product == null)
            {
                Console.WriteLine("Product is null.");
                return false;
            }
          


            if (product.ProductId <= 0)
            {
                Console.WriteLine("Product ID is invalid.");
                return false;
                
            }
            try
            {
                using (SqlConnection con = DBUtility.GetConnection())
                {
                    if (!CustomerExists(customerId))
                    { 
                        throw new CustomerNotFoundException("Customer not found");
                    }
                       
                    if (!ProductExists(product.ProductId))
                    {
                        throw new ProductNotFoundException("Product not found");
                    }
                       
                    string query = "insert into cart(customer_id,product_id,quantity) values (@customerId,@productId,@quantity)";
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.AddWithValue("@productId", product.ProductId);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Product added to cart successfully.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Failed to add product to cart.");
                        return false;
                    }

                }
            }
            catch (CustomerNotFoundException )
            {
                throw ;
                //Console.WriteLine(ex.Message);
                //return false;
            }
            catch (ProductNotFoundException ex)
            {
                throw ex;
                //Console.WriteLine(ex.Message);
                //return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        

        }

        public bool RemoveFromCart(Customer customer, Product product)
        {
           using(SqlConnection con = DBUtility.GetConnection())
            {
                string query = "delete from cart where customer_id = @customerId and product_id = @productId ";
                SqlCommand command = new SqlCommand (query,con);
                command.Parameters.AddWithValue("@customerId",customer.CustomerId);
                command.Parameters.AddWithValue("@productId",product.ProductId);
                return command.ExecuteNonQuery() > 0;   


            }
            
        }

         public List<Product> GetAllFromCart(Customer customer)
         {
          
        
            List<Product> products = new List<Product>();
            if (customer == null)
            {
                Console.WriteLine("Customer is null in GetAllFromCart method.");
                return products;
                
            }

            try
            {
                using (SqlConnection con = DBUtility.GetConnection())
                {

                    if (!CustomerExists(customer.CustomerId))
                        throw new CustomerNotFoundException("customer not found");

                    string query = "select c.product_id,c.quantity,p.name,p.price, p.description From cart c join products p on c.product_id = p.product_id where c.customer_id = @customerId";

                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@customerId", customer.CustomerId);

                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        products.Add(new Product
                        {

                            ProductId = Convert.ToInt32(reader["product_id"]),
                            Name = (string)reader["name"],
                            Price = Convert.ToDecimal(reader["price"]),
                            Description = (string)reader["description"],
                            StockQuantity = Convert.ToInt32(reader["quantity"])
                            

                        });

                        
                        
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message);
            }


            return products;
         }
        public Product productQuantity(int ProductId)
        {
            int quantity = 0;
            int price = 0;
            Product product = null;
            try
            {
                using (SqlConnection con = DBUtility.GetConnection())
                {


                    string query = "select stockquantity,name,price from products where product_id = @ProductId";
                    

                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@productId",ProductId);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        product = new Product
                        {
                            Name = (string)reader["name"],
                            Price = (decimal)reader["price"],
                            StockQuantity = (int)reader["stockquantity"],
                        };
                        


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return product;
            
        }








        public bool PlaceOrder(Customer customer, List<(Product, int)> productsWithValues, string shippingAddress)
        {
            using (SqlConnection con = DBUtility.GetConnection())
            {
                if (!CustomerExists(customer.CustomerId))
                    throw new CustomerNotFoundException("customer not found");

                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    decimal totalPrice = 0;

                    foreach (var (product, quantity) in productsWithValues)
                    {
                        if (!ProductExists(product.ProductId))
                            throw new ProductNotFoundException($"Product ID {product.ProductId} not found");

                        string stockQuery = "select stockQuantity, price from products where product_id = @productId";
                        using (SqlCommand stockcommand = new SqlCommand(stockQuery, con, transaction))
                        {
                            stockcommand.Parameters.AddWithValue("@productId", product.ProductId);
                            using (SqlDataReader reader = stockcommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int stock = Convert.ToInt32(reader["stockQuantity"]);
                                    decimal price = Convert.ToDecimal(reader["price"]);

                                    if (stock < quantity)
                                        throw new Exception($"Insufficient stock for Product ID {product.ProductId}");

                                    totalPrice += price * quantity;
                                }
                                else
                                {
                                    throw new ProductNotFoundException($"Product ID {product.ProductId} not found ");
                                }
                            }
                        }
                    }

                    string orderQuery = @"insert into orders (customer_id, order_date, total_price, shipping_address)
                                  values (@customerId, @orderDate, @totalPrice, @shippingAddress);
                                  select top 1 order_id from orders order by order_id desc;";

                    SqlCommand orderCommand = new SqlCommand(orderQuery, con, transaction);
                    orderCommand.Parameters.AddWithValue("@customerId", customer.CustomerId);
                    orderCommand.Parameters.AddWithValue("@orderDate", DateTime.Now);
                    orderCommand.Parameters.AddWithValue("@totalPrice", totalPrice);
                    orderCommand.Parameters.AddWithValue("@shippingAddress", shippingAddress);

                    int orderId = Convert.ToInt32(orderCommand.ExecuteScalar());

                    foreach (var (product, quantity) in productsWithValues)
                    {
                        string itemQuery = "insert into order_items (order_id, product_id, quantity) values (@orderId, @productId, @quantity)";
                        SqlCommand itemCommand = new SqlCommand(itemQuery, con, transaction);
                        itemCommand.Parameters.AddWithValue("@orderId", orderId);
                        itemCommand.Parameters.AddWithValue("@productId", product.ProductId);
                        itemCommand.Parameters.AddWithValue("@quantity", quantity);
                        itemCommand.ExecuteNonQuery();

                        string updateStock = "update products set stockQuantity = stockQuantity - @quantity where product_id = @productId";
                        using (SqlCommand updateStockCmd = new SqlCommand(updateStock, con, transaction))
                        {
                            updateStockCmd.Parameters.AddWithValue("@quantity", quantity);
                            updateStockCmd.Parameters.AddWithValue("@productId", product.ProductId);
                            updateStockCmd.ExecuteNonQuery();
                        }
                    }

                    SqlCommand clearCartCommand = new SqlCommand("delete from cart where customer_id = @customerId", con, transaction);
                    clearCartCommand.Parameters.AddWithValue("@customerId", customer.CustomerId);
                    clearCartCommand.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("PlaceOrder failed: " + ex.Message);
                    transaction.Rollback();
                    return false;
                }
            }
        }



        public List<Tuple<Product , int>> GetOrdersByCustomer(int CustomerId)
        {
            List<Tuple<Product, int>> orders = new List<Tuple<Product, int>>();
            using (SqlConnection con = DBUtility.GetConnection())
            {
                string query = @"select p.product_id, p.name, p.price, p.description, p.stockQuantity, oi.quantity from orders o 
                                 join order_items oi on o.order_id = oi.order_id 
                                 join products p on p.product_id = oi.product_id 
                                 where o.customer_id = @customerId";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@customerId", CustomerId);

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product()
                        {
                            ProductId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Description = reader.GetString(3),
                            StockQuantity = reader.GetInt32(4)
                        };
                        int quantity = reader.GetInt32(5);
                        orders.Add(new Tuple<Product, int>(product, quantity));


                    }



                }

            }
            if (orders.Count == 0)
                throw new OrderNotFoundException("No orders found for this customer.");

            return orders;

        }


        public Customer GetCustomerById(int customerId)
        {
            Customer customer = null;
            using (SqlConnection con = DBUtility.GetConnection())
            {
                string query = "select * from customers where customer_id = @customerId";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@customerId", customerId);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    customer =  new Customer
                    {
                        CustomerId = Convert.ToInt32(reader["customer_id"]),
                        Name = reader["name"].ToString(),
                        Email = reader["email"].ToString(),
                        Password = reader["password"].ToString()
                    };
                }
            }
            return customer; 
        }



    }

}
