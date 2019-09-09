using System;
using System.Collections.Generic;
using System.Text;
using WebApplication2.Data;

namespace WebApplication2.Domain
{
    public class AddCustomerCommandHandler : ICommandHandler<Customer>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public CommandResult Execute(Customer command)
        {
            var isCustomerExist = this.unitOfWork.GetRepository<Customer>().FindById(command.Id);
            if (isCustomerExist == null)
            {
                this.unitOfWork.GetRepository<Customer>().Add(command);
                this.unitOfWork.Commit();
                return new CommandResult { Status = true, Message = "Customer added succesfully" };
            }

            return new CommandResult { Status = false, Message = "This customer id already exist" };
        }
    }
}
