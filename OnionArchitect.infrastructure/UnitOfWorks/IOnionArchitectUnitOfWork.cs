using OnionArchitect.Core.UnitOfWork;
using OnionArchitect.infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitect.infrastructure.UnitOfWorks
{
    public interface IOnionArchitectUnitOfWork : IUnitOfWork { 
         IDatabaseContext DatabaseContext { get; }
        
    }
}
