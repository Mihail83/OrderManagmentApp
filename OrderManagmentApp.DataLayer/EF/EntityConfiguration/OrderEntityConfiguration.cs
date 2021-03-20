using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagmentApp.DataLayer.EntityModels;

namespace OrderManagmentApp.DataLayer.EF.EntityConfiguration
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder
                .HasKey(order => order.ID);
            builder
                .Property(order => order.ID).ValueGeneratedNever();
            builder
                 .Property(order => order.DateOfCreating).HasDefaultValue(DateTime.Today);            
            builder
                .HasOne(order => order.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(order => order.CustomerId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            builder
                .Property(order => order.CurrentTreaty)
                .HasMaxLength(50);
            builder
                .Property(order => order.Good)
                .HasMaxLength(200);
            builder
                .Property(order => order.ContractAmount)
                .HasColumnType("money");
            builder
                .Property(order => order.Advance)
                .HasColumnType("money");
            builder
                .Property(order => order.Comment)
                .HasMaxLength(200);
            builder
                .HasOne(order => order.ShipmentSpecialist)
                .WithMany(sse => sse.OrderEntities)
                .HasForeignKey(order => order.ShipmentSpecialistId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            builder
               .HasOne(order => order.ShipmentDestination)
               .WithMany(shipmentDest => shipmentDest.OrderEntities)
               .HasForeignKey(order => order.ShipmentDestinationId)
               .OnDelete(DeleteBehavior.ClientNoAction);
            builder
                .HasOne(order => order.Manager)
                .WithMany(manager => manager.OrderEntities)
                .HasForeignKey(order => order.ManagerId)
                .OnDelete(DeleteBehavior.ClientNoAction);
           
            builder
                .HasOne(order => order.OrderInALuteh)
                .WithOne(orderAl => orderAl.Order)
                .HasForeignKey<OrderInALutehEntity>(orderAL => orderAL.OrderId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
