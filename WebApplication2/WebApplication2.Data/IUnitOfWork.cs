using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication2.Data
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;

        void Commit();
    }
}
