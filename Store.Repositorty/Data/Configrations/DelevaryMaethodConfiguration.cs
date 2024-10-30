using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositorty.Data.Configrations
{
    public class DelevaryMaethodConfiguration : IEntityTypeConfiguration<DelevaryMethod>
    {
        public void Configure(EntityTypeBuilder<DelevaryMethod> builder)
        {
            builder.Property(DM => DM.Cost).HasColumnType("decimal(18,2)");

        }
    }
}
