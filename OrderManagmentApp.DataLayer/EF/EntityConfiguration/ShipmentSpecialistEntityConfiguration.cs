using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagmentApp.BusinessLogic.Models;

namespace OrderManagmentApp.DataLayer.EF.EntityConfiguration
{
    public class ShipmentSpecialistEntityConfiguration : IEntityTypeConfiguration<ShipmentSpecialist>
    {
        public void Configure(EntityTypeBuilder<ShipmentSpecialist> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasIndex(sp => sp.Specialist).IsUnique();
        }
    }
}