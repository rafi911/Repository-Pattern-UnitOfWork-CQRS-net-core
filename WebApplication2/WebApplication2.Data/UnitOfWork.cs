using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApplication2.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext DatabaseContext { get; set; }

        private readonly Dictionary<string, object> repositories = new Dictionary<string, object>();

        public UnitOfWork(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }
        public void Commit()
        {
            DatabaseContext.SaveChanges();
            repositories.Clear();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            string typeName = typeof(T).Name;
            if (repositories.Keys.Contains(typeName))
            {
                return repositories[typeName] as IRepository<T>;
            }
            IRepository<T> newRepository = new Repository<T>(DatabaseContext);

            repositories.Add(typeName, newRepository);
            return newRepository;
        }
    }
}
