﻿// <auto-generated />
using System;
using Bober;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bober.Migrations
{
    [DbContext(typeof(BogbanContext))]
    [Migration("20230519200748_PaymentFix")]
    partial class PaymentFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bober.Models.DatabaseModels.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateFinish")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("DogovorID")
                        .HasColumnType("int");

                    b.Property<decimal>("Summ")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DogovorID");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("Bober.Models.DatabaseModels.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bonus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DistrictID")
                        .HasColumnType("int");

                    b.Property<int>("FlorNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZastrID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DistrictID");

                    b.HasIndex("ZastrID");

                    b.ToTable("Building");
                });

            modelBuilder.Entity("Bober.Models.DatabaseModels.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateBorn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Bober.Models.DatabaseModels.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("District");
                });

            modelBuilder.Entity("Bober.Models.DatabaseModels.Dogovor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientID")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFinish")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlatID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SotrID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientID");

                    b.HasIndex("FlatID");

                    b.HasIndex("SotrID");

                    b.ToTable("Dogovor");
                });

            modelBuilder.Entity("Bober.Models.DatabaseModels.Flat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BuildingID")
                        .HasColumnType("int");

                    b.Property<int>("FlatNumber")
                        .HasColumnType("int");

                    b.Property<int>("Flor")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("Sqyare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingID");

                    b.ToTable("Flat");
                });

            modelBuilder.Entity("Bober.Models.DatabaseModels.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BillID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PaymentSumm")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BillID");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Bober.Models.DatabaseModels.Sotrudnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Fio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtdelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sotrudnik");
                });

            modelBuilder.Entity("Bober.Models.DatabaseModels.Zastr", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Zastr");
                });

            modelBuilder.Entity("Bober.Models.DatabaseModels.Bill", b =>
                {
                    b.HasOne("Bober.Models.DatabaseModels.Dogovor", "Dogovor")
                        .WithMany()
                        .HasForeignKey("DogovorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dogovor");
                });

            modelBuilder.Entity("Bober.Models.DatabaseModels.Building", b =>
                {
                    b.HasOne("Bober.Models.DatabaseModels.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bober.Models.DatabaseModels.Zastr", "Zastr")
                        .WithMany()
                        .HasForeignKey("ZastrID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");

                    b.Navigation("Zastr");
                });

            modelBuilder.Entity("Bober.Models.DatabaseModels.Dogovor", b =>
                {
                    b.HasOne("Bober.Models.DatabaseModels.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bober.Models.DatabaseModels.Flat", "Flat")
                        .WithMany()
                        .HasForeignKey("FlatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bober.Models.DatabaseModels.Sotrudnik", "Sotrudnik")
                        .WithMany()
                        .HasForeignKey("SotrID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Flat");

                    b.Navigation("Sotrudnik");
                });

            modelBuilder.Entity("Bober.Models.DatabaseModels.Flat", b =>
                {
                    b.HasOne("Bober.Models.DatabaseModels.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("Bober.Models.DatabaseModels.Payment", b =>
                {
                    b.HasOne("Bober.Models.DatabaseModels.Bill", "Bill")
                        .WithMany()
                        .HasForeignKey("BillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");
                });
#pragma warning restore 612, 618
        }
    }
}