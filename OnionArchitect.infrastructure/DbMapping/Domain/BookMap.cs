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
    public class BookMap : CustomEntityTypeConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedNever().HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);
            builder.Property(p => p.NameAr).HasMaxLength(50).IsRequired();
            builder.Property(p => p.NameEn).HasMaxLength(50).IsRequired();
            builder.Property(p => p.brief).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Desc).HasMaxLength(250).IsRequired();
            builder.Property(p => p.AuthorId).IsRequired();
            builder.HasOne(r => r.author).WithMany().HasForeignKey(f => f.AuthorId);
            base.Configure(builder);
        }
    }
}
