using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagmentApp.BusinessLogic.Models;

namespace OrderManagmentApp.DataLayer.EF.EntityConfiguration
{
    public class ManagerEntityConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.HasIndex(sp => sp.Name).IsUnique();
            builder.Property(manag => manag.Name).HasMaxLength(50);
        }
    }
}
