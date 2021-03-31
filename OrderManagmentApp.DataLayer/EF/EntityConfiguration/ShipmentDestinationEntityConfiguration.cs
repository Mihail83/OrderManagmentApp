using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagmentApp.DataLayer.EntityModels;

namespace OrderManagmentApp.DataLayer.EF.EntityConfiguration
{
    public class ShipmentDestinationEntityConfiguration : IEntityTypeConfiguration<ShipmentDestinationEntity>
    {
        public void Configure(EntityTypeBuilder<ShipmentDestinationEntity> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasIndex(sp => sp.Destination).IsUnique();
        }
    }
}