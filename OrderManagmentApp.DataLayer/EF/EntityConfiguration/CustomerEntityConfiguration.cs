using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagmentApp.BusinessLogic.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System;

namespace OrderManagmentApp.DataLayer.EF.EntityConfiguration
{
    class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(customer => customer.Id);
            builder
                .Property(customer => customer.Name).HasMaxLength(100).IsRequired();
            builder
                .HasMany(cust => cust.Agreements)
                .WithOne(treaty => treaty.Customer)
                .HasForeignKey(treaty => treaty.CustomerId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            
            builder
                .Property(customer => customer.Phones)
                .HasConversion
                    (phone => string.Join(',', phone), 
                    phones => new List<string> (phones.Split(',', System.StringSplitOptions.RemoveEmptyEntries)))
                .IsRequired();

            var valueComparer = new ValueComparer<List<string>>
                (
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList());

            builder                
                .Property(e => e.Phones)
                .Metadata
                .SetValueComparer(valueComparer);           
            builder
                .OwnsOne(customer => customer.Company);
            
        }
    }
}
