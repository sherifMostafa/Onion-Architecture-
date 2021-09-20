using OnionArchitect.infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitect.infrastructure.UnitOfWorks
{
    public class OnionArchitectUnitOfWork : IOnionArchitectUnitOfWork
    {
        #region Properties

        public IDatabaseContext DatabaseContext { get; private set; }

        #endregion Properties

        #region ctor

        public OnionArchitectUnitOfWork(IDatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        #endregion ctor

        #region Execute

        public int SaveChanges()
        {
            return DatabaseContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return DatabaseContext.SaveChangesAsync();
        }

        #endregion Execute
    }
}
