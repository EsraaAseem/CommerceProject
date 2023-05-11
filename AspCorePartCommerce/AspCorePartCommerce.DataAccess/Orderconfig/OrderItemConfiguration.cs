using AspCoreCommerce.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Orderconfig
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<orderItems>
    {
        public void Configure(EntityTypeBuilder<orderItems> builder)
        {
            builder.OwnsOne(o => o.ItemOrdered, a =>{ a.WithOwner();});
            builder.Property(s => s.Price).HasColumnType("double(18,2)");
        }
    }
}
