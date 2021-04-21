using Microsoft.EntityFrameworkCore;
using OrderManagmentApp.DataLayer.EF.EntityConfiguration;
using OrderManagmentApp.BusinessLogic.Models;

namespace OrderManagmentApp.DataLayer.EF
{
    public class OrderManagmentAppContext : DbContext
    {
        public OrderManagmentAppContext(DbContextOptions<OrderManagmentAppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<ShipmentSpecialist> ShipmentSpecialists { get; set; }
        public DbSet<ShipmentDestination> ShipmentDestinations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderInFactory> OrderByALutehs { get; set; }
        public DbSet<OrderAgreement> OrderAgreements { get; set; }

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
            
            
            //Manager manager1 = new Manager { Id = 1, Name = "FirstTestManager" };
            //Manager manager2 = new Manager { Id = 2, Name = "SecondTestManager" };
           

            //var shipDest1 = new ShipmentDestination { Id = 1, Destination = "destination1" };
            //var shipDest2 = new ShipmentDestination { Id = 2, Destination = "destination2222" };
           

            //var shipSpec1 = new ShipmentSpecialist { Id = 1, Specialist = "specialist1" };
            //var shipSpec2 = new ShipmentSpecialist { Id = 2, Specialist = "specialist2222" };
         
            
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
          
            

            //var treaty1 = new Agreement
            //{
            //    Id = 1,
            //    Good = "TestGood1",
            //    Sum = 1050m,
            //    CustomerId = 2
            //};
            //var treaty2 = new Agreement
            //{
            //    Id = 2,
            //    Good = "TestGood2222222",
            //    Sum = 150m,
            //    CustomerId = 3
            //};
            

          
            ////modelBuilder.Entity<OrderEntity>().HasData(order1, order2);
            base.OnModelCreating(modelBuilder);
        }
    }
}
