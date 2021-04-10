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

            var managerList = new List<Manager> 
            {
                new Manager { Name = "1FirstTest1Manager" },
                new Manager { Name = "2SecondTest2Manager" },
                new Manager { Name = "3ThirdTest3Manager" },
                new Manager { Name = "4FourthTest4Manager" }
                };            
            context.Managers.AddRange(managerList);
            context.SaveChanges();

            var shipDest1 = new ShipmentDestination { Destination = "TestDestination11111" };
            var shipDest2 = new ShipmentDestination { Destination = "22222TestDestination" };
            var shipDest3 = new ShipmentDestination { Destination = "333TestDest" };
            var shipDest4 = new ShipmentDestination { Destination = "4444Dest" };
            context.ShipmentDestinations.AddRange(shipDest1, shipDest2 , shipDest3, shipDest4);
            context.SaveChanges();

            var shipSpec1 = new ShipmentSpecialist { Specialist = "specialist1111" };
            var shipSpec2 = new ShipmentSpecialist {  Specialist = "2222specialist" };
            var shipSpec3 = new ShipmentSpecialist { Specialist = "3333specialist" };
            var shipSpec4 = new ShipmentSpecialist { Specialist = "4444specialist" };
            context.ShipmentSpecialists.AddRange(shipSpec1, shipSpec2, shipSpec3, shipSpec4);
            context.SaveChanges();

            #region Customer

            var CustomerList = new List<Customer>();

            var customer1 = new Customer
            {
                Name = "MegaTestCustomer",
                Phones = new List<string> { "999444888000" },
                Company = new Company
                {
                    Name = "Testcustomer333Company",
                    Address = "Testcustomer3333CompanyAddress",
                    TaxPayerId = "12346533",
                    BankAccount = "as3365fgh132465"
                }
            };

            var customer2 = new Customer
            {
                Name = "SuperTestCustomer2222",
                Phones = new List<string> { "9994448887766" },
                Company = new Company
                {
                    Name = "Testcustomer2222Company",
                    Address = "Testcustomer2222CompanyAddress",
                    TaxPayerId = "12346579",
                    BankAccount = "asd665fgh132465"
                }
            };
            CustomerList.Add(customer1);
            CustomerList.Add(customer2);
            for (int i = 0; i < 50; i++)
            {
                CustomerList.Add(new Customer
                {
                    Name = $"Testcustomer{i}{i}",
                    Phones = new List<string> { $"+37500111223{i % 10}" },
                });

            }
            context.Customers.AddRange(CustomerList);
            context.SaveChanges();
            #endregion

            #region Order

            var OrderList = new List<Order>();
            var rnd = new Random();
            var order1 = new Order
            {
                Id = 555666777,
                ContractSum = 100m,
                AdditionalInfo = "testOrder555666777",
                Customer = customer1,
                OrderState = 0,
                Manager = managerList[0],
                Good = "Товар1Test1",
                IsArchived = false,

            };
            var order2 = new Order
            {
                Id = 777666555,
                ContractSum = rnd.Next(0, 500),
                AdditionalInfo = $"testAdditionalInfo {rnd.Next(0, 500)}",
                Customer = customer1,
                OrderState = 0,
                Manager = managerList[1],
                Good = "Товар1Test1",
                IsArchived = false
            };
            OrderList.Add(order1);
            OrderList.Add(order2);
            for (int i = 0; i < 50; i++)
            {
                OrderList.Add(new Order
                {
                    Id = 100000 + i,
                    ContractSum = rnd.Next(0, 500),
                    AdditionalInfo = $"testAdditionalInfo {rnd.Next(0, 500)}",
                    Customer = CustomerList[i],
                    OrderState = 0,
                    Manager = managerList[rnd.Next(0, 3)],
                    Good = $"TestGood{rnd.Next(0, 500)}",
                    IsArchived = false
                });
            }

            context.Orders.AddRange(OrderList);
            context.SaveChanges();
            #endregion

            #region  Agreement
            var AgreementList = new List<Agreement>();
            var agreement1 = new Agreement
            {
                Sum = 159m,
                Customer = customer1,
                Good = "товар 1 customer1",
                
            };
            var agreement2 = new Agreement
            {
                Sum = 159m,
                Customer = customer1,
                Good = "товар 1 customer2",
            };
            AgreementList.Add(agreement1);
            AgreementList.Add(agreement2);
            for (int i = 0; i < 50; i++)
            {
                AgreementList.Add(new Agreement 
                {
                    Sum = rnd.Next(0,1000),
                    Customer = CustomerList[rnd.Next(0,50)],
                    Good = $"товар 1 {CustomerList[rnd.Next(0, 50)]}",
                });
            }

            context.Agreements.AddRange(AgreementList);
            context.SaveChanges();

            #endregion

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
