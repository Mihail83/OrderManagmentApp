using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagmentApp.DataLayer.EntityModels;

namespace OrderManagmentApp.DataLayer.EF.EntityConfiguration
{
    public class AgreementEntityConfiguration : IEntityTypeConfiguration<AgreementEntity>
    {
        public void Configure(EntityTypeBuilder<AgreementEntity> builder)
        {            
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");
            builder
                .Property(agreement => agreement.Sum)
                .HasColumnType("money");
            //builder
            //    .HasOne(agreement => agreement.Order)
            //    .WithOne(ord => ord.CurrentAgreement)
            //    .HasForeignKey<OrderEntity>(ord => ord.CurrentAgreementID);
            
        }
    }
}
