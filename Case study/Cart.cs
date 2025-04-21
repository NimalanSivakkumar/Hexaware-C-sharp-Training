using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace case_study.Entity
{
    public class Cart
    {

       public int CartId { get; set; }
        public int CustomerId {  get; set; }
        public int ProductId {  get; set; }
        public int Quantity {  get; set; }


        public Cart()
        {
            
        }

        public Cart(int cartId,int customerId, int productId,int quantity)
        {
            ProductId = productId;
            CartId = cartId;
            CustomerId = customerId;
            Quantity = quantity;
        }






    }
}
