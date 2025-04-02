using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking_asssignment
{
    internal class Customer
    {
        private int customerID;
        private string firstname;
        private string lastname;
        private string emailaddress;
        private int phonenumber;
        private string address;

        public int CustomerID
        {
            set { customerID = value; }
            get { return customerID; }
        }

        public string Firstname
        {
            set {firstname = value; }
            get { return firstname; }
        }

        public string Lastname
        {
            set { lastname = value; }
            get { return lastname; }
        }

        public string Emailaddress
        {
            set { emailaddress = value; }
            get { return emailaddress; }
        }


        public int Phonenumber
        {
            set { phonenumber = value; }
            get { return phonenumber; }
        }

        public string Address
        {
            set { address = value; }
            get { return address; }
        }

        public Customer(int  customer_id,string first_name,
            string last_name,string email_address,int phone_number,string address)
        {
            this.customerID = customer_id;
            this.firstname = first_name;
            this.lastname = last_name;
            this.emailaddress = email_address;
            this.phonenumber = phone_number;
            this.address = address;
        }
        public void Display()
        {
            Console.WriteLine($"Customer_ID : {customerID},First_Name : {firstname},Last_name : {lastname},Email :{emailaddress},Phone_no : {phonenumber},Address : {address}");
        }






    }
}
