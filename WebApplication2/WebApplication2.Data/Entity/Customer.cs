﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication2.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
