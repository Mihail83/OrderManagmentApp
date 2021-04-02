using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OrderManagmentApp.DataLayer.EntityModels;
using OrderManagmentApp.DataLayer.EF.EntityConfiguration;

namespace OrderManagmentApp.DataLayer.EF
{
    public class OrderManagmentAppContext : DbContext
    {
        public OrderManagmentAppContext(DbContextOptions options) : base(options)
        { }
        public DbSet<AgreementEntity> Сontracts {get; set;}
        public DbSet<ShipmentSpecialistEntity> ShipmentSpecialists {get; set;}
        public DbSet<ShipmentDestinationEntity>  ShipmentDestinations{ get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ManagerEntity> Managers { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<OrderInFactoryEntity> OrderByALutehs { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                        
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ManagerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderInFactoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ShipmentDestinationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ShipmentDestinationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AgreementEntityConfiguration());
            modelBuilder.ApplyConfiguration(new Agreement_Order_Configuration());
            modelBuilder.Owned<Phones>();

            ManagerEntity manager1 = new ManagerEntity {Id = 1,  Name = "FirstTestManager" };
            ManagerEntity manager2 = new ManagerEntity { Id = 2, Name = "SecondTestManager" };
            modelBuilder.Entity<ManagerEntity>().HasData(manager1, manager2);

            var shipDest1 = new ShipmentDestinationEntity { Id = 1, Destination = "destination1" };
            var shipDest2 = new ShipmentDestinationEntity { Id = 2, Destination = "destination2222" };
            modelBuilder.Entity<ShipmentDestinationEntity>().HasData(shipDest1, shipDest2);

            var shipSpec1 = new ShipmentSpecialistEntity { Id = 1, Specialist = "specialist1" };
            var shipSpec2 = new ShipmentSpecialistEntity { Id = 2, Specialist = "specialist2222" };
            modelBuilder.Entity<ShipmentSpecialistEntity>().HasData(shipSpec1, shipSpec2);
            #region Seed CustomerEntity
            //var customer1 = new CustomerEntity
            //{
            //    Id = 1,
            //    Address = "test address1, test address1,test address1, ",
            //    Comment = "No comment",
            //    Emeil = "testEmail1@post.by",                
            //    Name = "testName",
            //    PhoneNumbers = new Phones { FirstNumber = "261111111", SecondNumber = "359999999", ThirdNumber = "489999999" }
            //};
            //var customer2 = new CustomerEntity
            //{
            //    Id = 2,
            //    Address = "test address1, test address1,test address1, ",
            //    Comment = "No comment",
            //    Emeil = "testEmail2222222@post.by",                
            //    Company = new Company
            //    {
            //        TaxPayerId = "1234567981",
            //        Address = "bankAddress1",
            //        Bank = new BankInfo
            //        {
            //            Account = "bankAccount",
            //            Name = "BankName",
            //            Number = "112233aassddffgg"
            //        }
            //    },
            //    Name = "testLegalName",
            //    PhoneNumbers = new Phones { FirstNumber = "262222222", SecondNumber = "358888888", ThirdNumber = "485555555" }
            //};
            //modelBuilder.Entity<CustomerEntity>().HasData(customer1, customer2);
            #endregion

            //var treaty1 = new AgreementEntity
            //{
            //    Id = 1,
            //    Good = "TestGood1",
            //    Sum = 1050m,
            //    CustomerId = 2
            //};
            //var treaty2 = new AgreementEntity
            //{
            //    Id = 2,
            //    Good = "TestGood2222222",
            //    Sum = 150m,
            //    CustomerId = 3
            //};
            //modelBuilder.Entity<AgreementEntity>().HasData(treaty1, treaty2);

            //var order1 = new OrderEntity
            //{
            //    Id = 50001,
            //    CustomerId = 2,
            //    ManagerId = 1,
            //    Good = "TestGoodin Order"
            //};
            //var order2 = new OrderEntity
            //{
            //    Id = 50555,
            //    CustomerId = 3,
            //    ManagerId = 2,
            //    Good = "TestGood2   in Order2"
            //};
            //modelBuilder.Entity<OrderEntity>().HasData(order1, order2);
            base.OnModelCreating(modelBuilder); 
        }
    }
}
