﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace case_study.Entity
{
    public class OrderItem
    {
        public int OrderItemId {  get; set; }
        public int OrderId {  get; set; }
        public int ProductId { get; set; }
        public int Quantity {  get; set; }


        public OrderItem()
        {
            
        }

        public OrderItem(int orderItemId,int orderId,int productId,int quantity)
        {
            OrderItemId = orderItemId;
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }

    }
}
