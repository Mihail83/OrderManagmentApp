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
            
            

            builder
                .HasMany(cust => cust.AgreementEntities)
                .WithOne(treaty => treaty.Customer)
                .HasForeignKey(treaty => treaty.CustomerId)
                .OnDelete(DeleteBehavior.ClientNoAction);


            #region Without seedeng data
            builder
                .OwnsOne(customer => customer.Phones);
            builder
                .OwnsOne(customer => customer.Company);
            #endregion
            #region WITH seedeng data
            //var customer1 = new CustomerEntity
            //{
            //    Id = 2,
            //    Address = "test address1, test address1,test address1, ",
            //    Comment = "No comment",
            //    Emeil = "testEmail1@post.by",
            //    Name = "testName"
            //};
            //var customer2 = new CustomerEntity
            //{
            //    Id = 3,
            //    Address = "test address1, test address1,test address1, ",
            //    Comment = "No comment",
            //    Emeil = "testEmail2222222@post.by",
            //    Name = "testCompanyName"
            //};
            //builder.HasData(customer1,customer2);
            //builder
            //    .OwnsOne(customer => customer.PhoneNumbers)
            //    .HasData(
            //        new
            //        {
            //            CustomerEntityId = 2,
            //            FirstNumber = "+375 11 111 22 33",
            //            SecondNumber = "+375 66 222 22 33",
            //            ThirdNumber = "+375 99 333 22 33"
            //        },
            //        new
            //        {
            //            CustomerEntityId = 3,
            //            FirstNumber = "+375 22 333 44 33",
            //            SecondNumber = "+375 77 333 22 33",
            //            ThirdNumber = "+375 88 333 55 33"
            //        });
            //builder
            //    .OwnsOne(customer => customer.Company, bankInfo =>
            //    {
            //        bankInfo.OwnsOne(c => c.Bank);
            //    })
            //    .HasData(
            //      new
            //      {
            //          CustomerEntityId = 3,
            //          Name = "TestCompanyName",
            //          TaxPayerId = "1234567981",
            //          Address = "bankAddress1",
            //          OKPO = 113355779922446688,
            //          Bank = new BankInfo
            //          {
            //              Account = "bankAccount",
            //              Name = "BankName",
            //              Number = "112233aassddffgg"
            //          }
            //      }


            //    );
            #endregion
        }
    }
}
