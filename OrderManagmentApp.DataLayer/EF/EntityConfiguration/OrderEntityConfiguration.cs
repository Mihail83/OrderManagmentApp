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
                .HasKey(order => order.Id);
            builder
                .Property(order => order.Id).ValueGeneratedNever();
            builder
                 .Property(order => order.DateOfCreating).HasDefaultValue(DateTime.Today);            
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
                .WithMany(sse => sse.OrderEntities)
                //.HasForeignKey(order => order.ShipmentSpecialist)
                .OnDelete(DeleteBehavior.ClientNoAction);
            builder
               .HasOne(order => order.ShipmentDestination)
               .WithMany(shipmentDest => shipmentDest.OrderEntities)
               //.HasForeignKey(order => order.ShipmentDestinationId)
               .OnDelete(DeleteBehavior.ClientNoAction);
            builder
                .HasOne(order => order.Manager)
                .WithMany(manager => manager.OrderEntities)
                //.HasForeignKey(order => order.ManagerId)
                .OnDelete(DeleteBehavior.ClientNoAction);
           
            builder
                .HasOne(order => order.OrderInFactory)
                .WithOne(orderAl => orderAl.Order)
                .HasForeignKey<OrderInFactoryEntity>(orderAL => orderAL.OrderId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            //builder
            //    .HasOne(order => order.CurrentAgreement)
            //    .WithOne(agr => agr.Order)
            //    .HasForeignKey<AgreementEntity>(agreement => agreement.OrderId);
                
        }
    }
}
