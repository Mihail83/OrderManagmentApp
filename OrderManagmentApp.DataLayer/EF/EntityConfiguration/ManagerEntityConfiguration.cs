using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagmentApp.DataLayer.EntityModels;

namespace OrderManagmentApp.DataLayer.EF.EntityConfiguration
{
    public class ManagerEntityConfiguration : IEntityTypeConfiguration<ManagerEntity>
    {
        public void Configure(EntityTypeBuilder<ManagerEntity> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasIndex(sp => sp.Name).IsUnique();
            builder.Property(manag => manag.Name).HasMaxLength(50);
        }
    }
}
