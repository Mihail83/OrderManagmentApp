using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagmentApp.DataLayer.EntityModels;

namespace OrderManagmentApp.DataLayer.EF.EntityConfiguration
{
    class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.HasKey(customer => customer.Id);
            builder.Property(customer => customer.Name).HasMaxLength(100).IsRequired();
            //builder.OwnsOne(customer => customer.PhoneNumbers);

            builder
                .HasMany(cust => cust.TreatyEntities)
                .WithOne(treaty => treaty.Customer)
                .HasForeignKey(treaty => treaty.CustomerId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            builder
                .OwnsOne(customer => customer.LegalPerson, bankInfo =>
                {
                    bankInfo.OwnsOne(c => c.Bank);
                });


        }
    }
}
