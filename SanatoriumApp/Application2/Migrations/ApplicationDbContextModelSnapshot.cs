﻿// <auto-generated />
using System;
using Application2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Application2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Application2.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportSeries")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Application2.Entities.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfCheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfCheckOut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfConclusion")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<int>("SanatoriumProgramId")
                        .HasColumnType("int");

                    b.Property<int>("SanatoriumRoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("SanatoriumProgramId");

                    b.HasIndex("SanatoriumRoomId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("Application2.Entities.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("Application2.Entities.SanatoriumProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MinQuantityDays")
                        .HasColumnType("int");

                    b.Property<int>("QuantityOfProcedures")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SanatoriumPrograms");
                });

            modelBuilder.Entity("Application2.Entities.SanatoriumRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityOfRooms")
                        .HasColumnType("int");

                    b.Property<int>("QuantityOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("RoomAmenities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RoomSize")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RoomWindow")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SanatoriumRoomCategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("SanatoriumRoomCategoryId");

                    b.ToTable("SanatoriumRooms");
                });

            modelBuilder.Entity("Application2.Entities.SanatoriumRoomCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Coefficient")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SanatoriumRoomCategories");
                });

            modelBuilder.Entity("Application2.Entities.Contract", b =>
                {
                    b.HasOne("Application2.Entities.Client", "Client")
                        .WithMany("Contracts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application2.Entities.PaymentMethod", "PaymentMethod")
                        .WithMany("Contracts")
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application2.Entities.SanatoriumProgram", "SanatoriumProgram")
                        .WithMany("Contracts")
                        .HasForeignKey("SanatoriumProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application2.Entities.SanatoriumRoom", "SanatoriumRoom")
                        .WithMany("Contracts")
                        .HasForeignKey("SanatoriumRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("PaymentMethod");

                    b.Navigation("SanatoriumProgram");

                    b.Navigation("SanatoriumRoom");
                });

            modelBuilder.Entity("Application2.Entities.SanatoriumRoom", b =>
                {
                    b.HasOne("Application2.Entities.SanatoriumRoomCategory", "SanatoriumRoomCategory")
                        .WithMany("SanatoriumRooms")
                        .HasForeignKey("SanatoriumRoomCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanatoriumRoomCategory");
                });

            modelBuilder.Entity("Application2.Entities.Client", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("Application2.Entities.PaymentMethod", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("Application2.Entities.SanatoriumProgram", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("Application2.Entities.SanatoriumRoom", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("Application2.Entities.SanatoriumRoomCategory", b =>
                {
                    b.Navigation("SanatoriumRooms");
                });
#pragma warning restore 612, 618
        }
    }
}
