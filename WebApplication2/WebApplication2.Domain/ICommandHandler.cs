using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication2.Domain
{
    public interface ICommandHandler<T> where T : class
    {
         CommandResult Execute(T command);
    }
}
