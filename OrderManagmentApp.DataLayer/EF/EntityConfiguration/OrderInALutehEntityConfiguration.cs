using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagmentApp.DataLayer.EntityModels;

namespace OrderManagmentApp.DataLayer.EF.EntityConfiguration
{
    public class OrderInALutehEntityConfiguration : IEntityTypeConfiguration<OrderInALutehEntity>
    {
        public void Configure(EntityTypeBuilder<OrderInALutehEntity> builder)
        {
            builder
                .HasKey(or => or.ID);            
            builder
                .Property(or => or.ID)
                .ValueGeneratedNever();
            builder
                .Property(or => or.StateOfSet)
                .HasMaxLength(50);
            builder
                .Property(or => or.StateOfShipment)
                .HasMaxLength(50);
            builder
                .Property(or => or.Sum)
                .HasColumnType("money");
            builder
                .Property(or => or.PaymentedSum)
                .HasColumnType("money");
            builder
                .Property(or => or.StateOfPayment)
                .HasMaxLength(50);
            builder
                .Property(or => or.StateOfOrder)
                .HasMaxLength(50);
        }
    }
}