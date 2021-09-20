using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitect.Core.Repository.custom;
using OnionArchitect.Core.Repository.Generic;
using OnionArchitect.Core.Service.custom;
using OnionArchitect.Core.Service.Generic;
using OnionArchitect.Core.UnitOfWork;
using OnionArchitect.infrastructure.DbContexts;
using OnionArchitect.infrastructure.Repositories.custom;
using OnionArchitect.infrastructure.Repositories.Generic;
using OnionArchitect.infrastructure.UnitOfWorks;
using OnionArchitect.Services.custom;
using OnionArchitect.Services.Generic;

namespace OnionArchitect.Api.infrastructure
{
    public static class DependancyInjectionConfig
    {
        public static  IServiceProvider ServiceProvider { get; set; }

        internal static ServiceProvider Config(IServiceCollection services, IConfiguration configuration)
        {
            #region DbContext ...
            //services.AddDbContext<IDatabaseContext, DatabaseContext>(option =>
            //option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));
            services.AddDbContext<IDatabaseContext, DatabaseContext>(option =>
                          option.UseSqlServer(
                              configuration.GetConnectionString("DefaultConnection"),
                              opt => {
                                  opt.MigrationsAssembly("OnionArchitect.infrastructure");
                              }
                              ), ServiceLifetime.Scoped);

            services.AddTransient<IOnionArchitectUnitOfWork, OnionArchitectUnitOfWork>();
            services.AddTransient<IUnitOfWork, OnionArchitectUnitOfWork>();

            #endregion DbContext ...

            #region Repositories ...

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IBookRepository), typeof(BookRepository));

            #endregion Repositories ...

            #region Services ...
            services.AddTransient(typeof(IService<>), typeof(Service<>));
            services.AddTransient(typeof(IBookService), typeof(BookService));

            #endregion Services ...

            ServiceProvider = services.BuildServiceProvider();
            return (ServiceProvider as ServiceProvider);
        }
    }
}
