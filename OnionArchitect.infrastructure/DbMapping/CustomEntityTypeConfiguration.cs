using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitect.infrastructure.DbMapping
{
    public class CustomEntityTypeConfiguration<TEntity> : IModelConfiguration , IEntityTypeConfiguration<TEntity> where TEntity :class
    {
        public void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
        }
    }
}
