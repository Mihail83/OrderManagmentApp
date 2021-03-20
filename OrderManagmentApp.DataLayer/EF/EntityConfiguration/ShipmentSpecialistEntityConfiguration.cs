using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagmentApp.DataLayer.EntityModels;

namespace OrderManagmentApp.DataLayer.EF.EntityConfiguration
{
    public class ShipmentSpecialistEntityConfiguration : IEntityTypeConfiguration<ShipmentSpecialistEntity>
    {
        public void Configure(EntityTypeBuilder<ShipmentSpecialistEntity> builder)
        {
            
        }
    }
}