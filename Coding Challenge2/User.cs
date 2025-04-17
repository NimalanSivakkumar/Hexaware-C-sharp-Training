using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding_challenge.Entity
{
    public class User
    {
        public int UserId {  get; set; }
        public string UserName {  get; set; }
        public string Password { get; set; }
        public string Role {  get; set; }

        public User()
        {
            
        }

        public User(int userId, string userName, string password,string role)
        {

            UserId = userId;
            UserName = userName;
            Password = password;
            Role = role;
        }


        public override string ToString()
        {
            return $"UserUd :{UserId},UserName :{UserName},Passwod :{Password},Role:{Role}";
        }









    }
}
