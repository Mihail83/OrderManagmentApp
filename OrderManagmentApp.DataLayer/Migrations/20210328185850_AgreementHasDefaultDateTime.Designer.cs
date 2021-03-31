﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderManagmentApp.DataLayer.EF;

namespace OrderManagmentApp.DataLayer.Migrations
{
    [DbContext(typeof(OrderManagmentAppContext))]
    [Migration("20210328185850_AgreementHasDefaultDateTime")]
    partial class AgreementHasDefaultDateTime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrderManagmentApp.DataLayer.EntityModels.AgreementEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Good")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Sum")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Сontracts");
                });

            modelBuilder.Entity("OrderManagmentApp.DataLayer.EntityModels.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emeil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("OrderManagmentApp.DataLayer.EntityModels.ManagerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Managers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "FirstTestManager"
                        },
                        new
                        {
                            Id = 2,
                            Name = "SecondTestManager"
                        });
                });

            modelBuilder.Entity("OrderManagmentApp.DataLayer.EntityModels.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("AdditionalInfo")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Advance")
                        .HasColumnType("money");

                    b.Property<decimal>("ContractSum")
                        .HasColumnType("money");

                    b.Property<string>("CurrentAgreement")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfCreating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 3, 28, 0, 0, 0, 0, DateTimeKind.Local));

                    b.Property<string>("Good")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<int>("OrderState")
                        .HasColumnType("int");

                    b.Property<int?>("ShipmentDestinationId")
                        .HasColumnType("int");

                    b.Property<int?>("ShipmentSpecialistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("ShipmentDestinationId");

                    b.HasIndex("ShipmentSpecialistId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrderManagmentApp.DataLayer.EntityModels.OrderInFactoryEntity", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfPayment")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("PaymentedSum")
                        .HasColumnType("money");

                    b.Property<DateTime>("ShipmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StateOfOrder")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StateOfPayment")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StateOfSet")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StateOfShipment")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Sum")
                        .HasColumnType("money");

                    b.HasKey("ID");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("OrderByALutehs");
                });

            modelBuilder.Entity("OrderManagmentApp.DataLayer.EntityModels.ShipmentDestinationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Destination")
                        .IsUnique()
                        .HasFilter("[Destination] IS NOT NULL");

                    b.ToTable("ShipmentDestinations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Destination = "destination1"
                        },
                        new
                        {
                            Id = 2,
                            Destination = "destination2222"
                        });
                });

            modelBuilder.Entity("OrderManagmentApp.DataLayer.EntityModels.ShipmentSpecialistEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Specialist")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ShipmentSpecialists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Specialist = "specialist1"
                        },
                        new
                        {
                            Id = 2,
                            Specialist = "specialist2222"
                        });
                });

            modelBuilder.Entity("OrderManagmentApp.DataLayer.EntityModels.AgreementEntity", b =>
                {
                    b.HasOne("OrderManagmentApp.DataLayer.EntityModels.CustomerEntity", "Customer")
                        .WithMany("AgreemenEntities")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("OrderManagmentApp.DataLayer.EntityModels.CustomerEntity", b =>
                {
                    b.OwnsOne("OrderManagmentApp.DataLayer.EntityModels.Company", "Company", b1 =>
                        {
                            b1.Property<int>("CustomerEntityId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Address")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<decimal>("OKPO")
                                .HasColumnType("decimal(20,0)");

                            b1.Property<string>("TaxPayerId")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CustomerEntityId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerEntityId");

                            b1.OwnsOne("OrderManagmentApp.DataLayer.EntityModels.BankInfo", "Bank", b2 =>
                                {
                                    b2.Property<int>("CompanyCustomerEntityId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<string>("Account")
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Name")
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Number")
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("CompanyCustomerEntityId");

                                    b2.ToTable("Customers");

                                    b2.WithOwner()
                                        .HasForeignKey("CompanyCustomerEntityId");
                                });

                            b1.Navigation("Bank");
                        });

                    b.OwnsOne("OrderManagmentApp.DataLayer.EntityModels.Phones", "PhoneNumbers", b1 =>
                        {
                            b1.Property<int>("CustomerEntityId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("FirstNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SecondNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ThirdNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CustomerEntityId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerEntityId");
                        });

                    b.Navigation("Company");

                    b.Navigation("PhoneNumbers");
                });

            modelBuilder.Entity("OrderManagmentApp.DataLayer.EntityModels.OrderEntity", b =>
                {
                    b.HasOne("OrderManagmentApp.DataLayer.EntityModels.CustomerEntity", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("OrderManagmentApp.DataLayer.EntityModels.ManagerEntity", "Manager")
                        .WithMany("OrderEntities")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.HasOne("OrderManagmentApp.DataLayer.EntityModels.ShipmentDestinationEntity", "ShipmentDestination")
                        .WithMany("OrderEntities")
                        .HasForeignKey("ShipmentDestinationId")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.HasOne("OrderManagmentApp.DataLayer.EntityModels.ShipmentSpecialistEntity", "ShipmentSpecialist")
                        .WithMany("OrderEntities")
                        .HasForeignKey("ShipmentSpecialistId")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.Navigation("Customer");

                    b.Navigation("Manager");

                    b.Navigation("ShipmentDestination");

                    b.Navigation("ShipmentSpecialist");
                });

            modelBuilder.Entity("OrderManagmentApp.DataLayer.EntityModels.OrderInFactoryEntity", b =>
                {
                    b.HasOne("OrderManagmentApp.DataLayer.EntityModels.OrderEntity", "Order")
                        .WithOne("OrderInFactory")
                        .HasForeignKey("OrderManagmentApp.DataLayer.EntityModels.OrderInFactoryEntity", "OrderId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("OrderManagmentApp.DataLayer.EntityModels.CustomerEntity", b =>
                {
                    b.Navigation("AgreemenEntities");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OrderManagmentApp.DataLayer.EntityModels.ManagerEntity", b =>
                {
                    b.Navigation("OrderEntities");
                });

            modelBuilder.Entity("OrderManagmentApp.DataLayer.EntityModels.OrderEntity", b =>
                {
                    b.Navigation("OrderInFactory");
                });

            modelBuilder.Entity("OrderManagmentApp.DataLayer.EntityModels.ShipmentDestinationEntity", b =>
                {
                    b.Navigation("OrderEntities");
                });

            modelBuilder.Entity("OrderManagmentApp.DataLayer.EntityModels.ShipmentSpecialistEntity", b =>
                {
                    b.Navigation("OrderEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
