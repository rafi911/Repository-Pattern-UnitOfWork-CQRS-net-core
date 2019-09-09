using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication2.Data;

namespace WebApplication2.Domain
{
    public class CustomerQueryHandler
    {
        private readonly IUnitOfWork unitOfWork;
        public CustomerQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Customer> GetCustomers()
        {
            return unitOfWork.GetRepository<Customer>().GetAllAsQueryable();
        }
    }
}
