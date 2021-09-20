using OnionArchitect.Core.Domain;
using OnionArchitect.Core.Repository.custom;
using OnionArchitect.Core.Repository.Generic;
using OnionArchitect.Core.Service.custom;
using OnionArchitect.Core.UnitOfWork;
using OnionArchitect.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitect.Services.custom
{
    public class BookService : Service<Book> , IBookService
    {
        private readonly IBookRepository _repository;


        public BookService(IUnitOfWork unitOfWork, IBookRepository repository):base(unitOfWork , repository)
        {
            _repository = repository;
        }

    }
}
