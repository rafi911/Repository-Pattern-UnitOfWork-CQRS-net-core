using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Domain;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private readonly ICommandHandler<Customer> customerCommandHandler;
        private readonly CustomerQueryHandler customerQueryHandler;
        public CustomerController(CustomerQueryHandler customerQueryHandler, ICommandHandler<Customer> customerCommandHandler)
        {
            this.customerQueryHandler = customerQueryHandler;
            this.customerCommandHandler = customerCommandHandler;
        }  
        // GET: Customer
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(customerQueryHandler.GetCustomers());
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            return Ok(customerCommandHandler.Execute(customer));
        }


    }
}