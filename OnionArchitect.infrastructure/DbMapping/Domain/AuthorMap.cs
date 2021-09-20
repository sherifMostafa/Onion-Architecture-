using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitect.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitect.infrastructure.DbMapping.Domain
{
    public class AuthorMap : CustomEntityTypeConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedNever().HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);
            builder.Property(p => p.NameAr).HasMaxLength(50).IsRequired();
            builder.Property(p => p.NameEn).HasMaxLength(50).IsRequired();
            base.Configure(builder);
        }
    }
}
