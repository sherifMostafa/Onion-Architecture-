using Microsoft.EntityFrameworkCore;
using OnionArchitect.Core.Domain;
using OnionArchitect.infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArchitect.infrastructure.Repositories.Generic;
using OnionArchitect.Core.Repository.custom;

namespace OnionArchitect.infrastructure.Repositories.custom
{
    public class BookRepository : Repository<Book> ,IBookRepository
    {
        private readonly DbSet<Book> _entitiesSet;
        private readonly IBookRepository _bookRepo;

        public BookRepository(IDatabaseContext databaseContext)
            : base(databaseContext)
        {
            _entitiesSet = databaseContext.Set<Book>();
        }
    }
}
