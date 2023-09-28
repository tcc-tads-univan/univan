﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Univan.Infrastructure.Persistence.Context;

#nullable disable

namespace Univan.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(UnivanContext))]
    partial class UnivanContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Univan.Domain.Entities.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionId"));

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("ExpirationDay")
                        .HasColumnType("int");

                    b.Property<decimal>("MonthlyFee")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("SubscriptionId");

                    b.HasIndex("DriverId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Subscription", (string)null);
                });

            modelBuilder.Entity("Univan.Domain.Entities.SubscriptionHistory", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("Value")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("SubscriptionId");

                    b.ToTable("SubscriptionHistory", (string)null);
                });

            modelBuilder.Entity("Univan.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique()
                        .HasFilter("[Cpf] IS NOT NULL");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("User");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Univan.Domain.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FabricationYear")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vehicle", (string)null);
                });

            modelBuilder.Entity("Univan.Domain.Entities.Driver", b =>
                {
                    b.HasBaseType("Univan.Domain.Entities.User");

                    b.Property<string>("Cnh")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasIndex("VehicleId")
                        .IsUnique()
                        .HasFilter("[VehicleId] IS NOT NULL");

                    b.ToTable("Driver", (string)null);
                });

            modelBuilder.Entity("Univan.Domain.Entities.Student", b =>
                {
                    b.HasBaseType("Univan.Domain.Entities.User");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("Univan.Domain.Entities.Subscription", b =>
                {
                    b.HasOne("Univan.Domain.Entities.Driver", "Driver")
                        .WithMany("Subscriptions")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Univan.Domain.Entities.Student", "Student")
                        .WithOne("Subscription")
                        .HasForeignKey("Univan.Domain.Entities.Subscription", "StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Univan.Domain.Entities.SubscriptionHistory", b =>
                {
                    b.HasOne("Univan.Domain.Entities.Subscription", "Subscription")
                        .WithMany("SubscriptionHistory")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("Univan.Domain.Entities.Driver", b =>
                {
                    b.HasOne("Univan.Domain.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Univan.Domain.Entities.Driver", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Univan.Domain.Entities.Vehicle", "Vehicle")
                        .WithOne("Driver")
                        .HasForeignKey("Univan.Domain.Entities.Driver", "VehicleId");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Univan.Domain.Entities.Student", b =>
                {
                    b.HasOne("Univan.Domain.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Univan.Domain.Entities.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Univan.Domain.Entities.Subscription", b =>
                {
                    b.Navigation("SubscriptionHistory");
                });

            modelBuilder.Entity("Univan.Domain.Entities.Vehicle", b =>
                {
                    b.Navigation("Driver");
                });

            modelBuilder.Entity("Univan.Domain.Entities.Driver", b =>
                {
                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("Univan.Domain.Entities.Student", b =>
                {
                    b.Navigation("Subscription");
                });
#pragma warning restore 612, 618
        }
    }
}
