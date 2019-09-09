using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication2.Domain.Commands
{
    public class CustomerCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
