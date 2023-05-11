using AspCoreCommerce.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Orderconfig
{
    public class DelivaryMethodConfiguration : IEntityTypeConfiguration<DelivaryMethod>
    {
        public void Configure(EntityTypeBuilder<DelivaryMethod> builder)
        {
            builder.Property(s => s.Price).HasColumnType("double(18,2)");
        }
    }
}
