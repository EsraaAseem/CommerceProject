using AspCoreCommerce.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspCorePartCommerce.DataAccess.Orderconfig
{
    public class OrderConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.OwnsOne(o => o.ShippToAddress, a =>
            {
                a.WithOwner();
            });
            builder.Property(s => s.Status).HasConversion(
                o=>o.ToString(),
                o=>(OrderStatus) Enum.Parse(typeof(OrderStatus), o)
                );
            builder.HasMany(o=>o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
