using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagmentApp.DataLayer.EntityModels;

namespace OrderManagmentApp.DataLayer.EF.EntityConfiguration
{
    public class Agreement_Order_Configuration : IEntityTypeConfiguration<OrderEntityAgreementEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntityAgreementEntity> builder)
        {
            builder.HasKey(key=> new {key.OrderEntityId, key.AgreementEntityId });
            builder.HasIndex(entity =>entity.OrderEntityId).IsUnique();            
        }
    }
}
