using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositorty.Data.Configrations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x=> x.PictureUrl).IsRequired(true);
            builder.Property(x=> x.Price).HasColumnType("decimal(18,2)");
            builder.HasOne(x => x.Brand).WithMany().HasForeignKey(p=>p.BrandId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Type).WithMany().HasForeignKey(p=>p.TypeId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.BrandId).IsRequired(false);
            builder.Property(x => x.TypeId).IsRequired(false);

        }
    }
}
