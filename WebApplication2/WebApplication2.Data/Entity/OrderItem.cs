using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication2.Data
{
    public class OrderItem
    {

        public int ProductId { get; set; }
        public int Price { get; set; }
        public decimal ProductCount { get; set; }
        public decimal SubTotal { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
