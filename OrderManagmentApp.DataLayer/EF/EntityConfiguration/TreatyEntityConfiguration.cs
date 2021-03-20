using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagmentApp.DataLayer.EntityModels;

namespace OrderManagmentApp.DataLayer.EF.EntityConfiguration
{
    public class TreatyEntityConfiguration : IEntityTypeConfiguration<TreatyEntity>
    {
        public void Configure(EntityTypeBuilder<TreatyEntity> builder)
        {
            builder
                .Property(treaty => treaty.CreateDate)
                .HasDefaultValue(DateTime.Today);
            builder
                .Property(treaty => treaty.Amount)
                .HasColumnType("money");
            
        }
    }
}
