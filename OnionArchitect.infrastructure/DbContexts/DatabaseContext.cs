using Microsoft.EntityFrameworkCore;
using OnionArchitect.infrastructure.DbMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OnionArchitect.infrastructure.DbContexts
{
    public class DatabaseContext : DbContext , IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> optionsBuilder):base(optionsBuilder)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RegisterDomainModels(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }


        #region Methods

        private void RegisterDomainModels(ModelBuilder modelBuilder)
        {
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.BaseType != null && t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == (typeof(CustomEntityTypeConfiguration<>)))
                .ToList()
                .ForEach(map =>
                {
                    if ((Activator.CreateInstance(map) as IModelConfiguration) != null)
                        ((IModelConfiguration)Activator.CreateInstance(map)).ApplyConfiguration(modelBuilder);
                });
        }

        #endregion Methods
    }
}
