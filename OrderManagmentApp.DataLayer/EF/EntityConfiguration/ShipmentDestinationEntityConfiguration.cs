using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagmentApp.BusinessLogic.Models;

namespace OrderManagmentApp.DataLayer.EF.EntityConfiguration
{
    public class ShipmentDestinationEntityConfiguration : IEntityTypeConfiguration<ShipmentDestination>
    {
        public void Configure(EntityTypeBuilder<ShipmentDestination> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasIndex(sp => sp.Destination).IsUnique();
        }
    }
}