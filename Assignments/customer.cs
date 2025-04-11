using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking_asssignment
{
    public class Customer
    {
        public int CustomerID {  get; set; }
        public string FirstName {  get; set; }
        public string LastName {  get; set; }
        public string Email {  get; set; }
        public string Phone{  get; set; }
        public string Address {  get; set; }

     

        public Customer(int id, string firstName,
            string lastName, string email, string phone, string address)
        {
            this.CustomerID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
        }
        public override string ToString() 
        {
            return $"Customer_ID : {CustomerID},First_Name : {FirstName},Last_name : {LastName},Email :{Email},Phone_no : {Phone},Address : {Address}";
        }

        //public static bool IsValidPhoneNumber(string phone)
        //{
        //    if (phone.Length == 10)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}





    }
}
