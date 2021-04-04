using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.BusinessLogic.Models;
using System.Linq;

namespace OrderManagmentApp.DataLayer.EF
{
    public  static class DBInitializer
    {
        public static void Initialize(OrderManagmentAppContext context)
        {
            context.Database.EnsureCreated();
            if (context.Orders.Any())
            {
                return;   
            }

            Manager manager1 = new Manager { Name = "FirstTestManager" };
            Manager manager2 = new Manager { Name = "SecondTestManager" };
            context.Managers.AddRange(manager1, manager2);
            context.SaveChanges();

            var shipDest1 = new ShipmentDestination { Destination = "TestDestination11111" };
            var shipDest2 = new ShipmentDestination { Destination = "22222TestDestination" };
            context.ShipmentDestinations.AddRange(shipDest1, shipDest2);
            context.SaveChanges();

            var shipSpec1 = new ShipmentSpecialist { Specialist = "specialist1111" };
            var shipSpec2 = new ShipmentSpecialist {  Specialist = "2222specialist" };
            context.ShipmentSpecialists.AddRange(shipSpec1, shipSpec2);
            context.SaveChanges();

            var customer1 = new Customer 
            {
                Name = "Testcustomer1111",
                Phones = new List<string> {"1230293332211" },
            };
            var customer2 = new Customer
            {
                Name = "Testcustomer2222",
                Phones = new List<string> { "9994448887766" },
                Company = new Company 
                { 
                    Name = "Testcustomer2222Company",
                    Address = "Testcustomer2222CompanyAddress",
                    TaxPayerId = "12346579",
                    BankAccount="asd665fgh132465"
                }
            };
            context.Customers.AddRange(customer1, customer2);
            context.SaveChanges();
            var order1 = new Order
            {
                Id = 555666777,
                ContractSum = 100m,
                AdditionalInfo = "testOrder555666777",
                Customer =customer1,
                OrderState=0,
                Manager = manager1,
                Good = "Товар1Test1",
                IsArchived = false,
                
            };
            var order2 = new Order
            {
                Id = 777666555,
                ContractSum = 500m,
                AdditionalInfo = "testOrder777666555",
                Customer = customer2,
                OrderState = 0,
                Manager = manager2,
                Good = "Товар1Test1",
                IsArchived = false
            };
            context.Orders.AddRange(order1, order2);
            context.SaveChanges();

            var agreement1 = new Agreement
            {
                Sum = 159m,
                Customer = customer1,
                Good = "товар 1 customer1",
                
            };
            var agreement2 = new Agreement
            {
                Sum = 159m,
                Customer = customer2,
                Good = "товар 1 customer2",
            };
            context.Agreements.AddRange(agreement1, agreement2);
            context.SaveChanges();

            var link = new OrderAgreement
            {
                Agreement = agreement2,
                Order = order2
            };
            context.OrderAgreements.Add(link);
            context.SaveChanges();
        }
    }
}
