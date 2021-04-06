using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagmentApp.BusinessLogic.Models;
using System;

namespace OrderManagmentApp.DataLayer.EF.EntityConfiguration
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(order => order.Id);
            builder
                .Property(order => order.Id).ValueGeneratedNever();
            builder
                 .Property(order => order.DateOfCreating).HasDefaultValueSql("getdate()"); ;
            builder
                .HasOne(order => order.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(order => order.CustomerId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            //builder
            //    .Property(order => order.CurrentAgreement)
            //    .HasMaxLength(50);
            builder
                .Property(order => order.Good)
                .HasMaxLength(200);

            builder
                .Property(order => order.ContractSum)
                .HasColumnType("money");
            builder
                .Property(order => order.Advance)
                .HasColumnType("money");
            builder
                .Property(order => order.AdditionalInfo)
                .HasMaxLength(200);
            builder
                .HasOne(order => order.ShipmentSpecialist)
                .WithMany(sse => sse.Orders)
                .HasForeignKey(order => order.ShipmentSpecialistId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            builder
               .HasOne(order => order.ShipmentDestination)
               .WithMany(shipmentDest => shipmentDest.Orders)
               .HasForeignKey(order => order.ShipmentDestinationId)
               .OnDelete(DeleteBehavior.ClientNoAction);
            builder
                .HasOne(order => order.Manager)
                .WithMany(manager => manager.OrderEntities)
                .HasForeignKey(order => order.ManagerId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder
                .HasOne(order => order.OrderInFactory)
                .WithOne(orderAl => orderAl.Order)
                .HasForeignKey<OrderInFactory>(orderAL => orderAL.OrderId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
