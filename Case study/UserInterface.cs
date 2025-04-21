using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace case_study.Main
{
    internal class UserInterface
    {
        public int GetCustomerId()
        {
            Console.Write("Enter Customer ID: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public string GetCustomerName()
        {
            Console.Write("Enter Customer Name: ");
            return Console.ReadLine();
        }

        public string GetCustomerEmail()
        {
            Console.Write("Enter Customer Email: ");
            return Console.ReadLine();
        }

        public string GetCustomerPassword()
        {
            Console.Write("Enter Customer Password: ");
            return Console.ReadLine();
        }

        public int GetProductId()
        {
            Console.Write("Enter Product ID: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public string GetProductName()
        {
            Console.Write("Enter Product Name: ");
            return Console.ReadLine();
        }

        public decimal GetProductPrice()
        {
            Console.Write("Enter Product Price: ");
            return Convert.ToDecimal(Console.ReadLine());
        }

        public string GetProductDescription()
        {
            Console.Write("Enter Product Description: ");
            return Console.ReadLine();
        }

        public int GetProductStock()
        {
            Console.Write("Enter Product Stock Quantity: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public string GetShippingAddress()
        {
            Console.Write("Enter Shipping Address: ");
            return Console.ReadLine();
        }

        public int GetQuantity()
        {
            Console.Write("Enter Quantity: ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
