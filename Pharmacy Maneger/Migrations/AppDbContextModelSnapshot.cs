// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pharmacy_Maneger.Data;

#nullable disable

namespace Pharmacy_Maneger.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.13");

            modelBuilder.Entity("Pharmacy_Maneger.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Pharmacy_Maneger.Models.BillGood", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BillId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GoodId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("BillId");

                    b.HasIndex("GoodId");

                    b.ToTable("BillGoods");
                });

            modelBuilder.Entity("Pharmacy_Maneger.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Pharmacy_Maneger.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Pharmacy_Maneger.Models.Expenses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("Pharmacy_Maneger.Models.SellItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NetPrice")
                        .HasColumnType("INTEGER");

                    b.Property<int>("companyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("price")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("companyId");

                    b.ToTable("sellItems");
                });

            modelBuilder.Entity("Pharmacy_Maneger.Models.Bill", b =>
                {
                    b.HasOne("Pharmacy_Maneger.Models.Customer", "Customer")
                        .WithMany("Bills")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Pharmacy_Maneger.Models.BillGood", b =>
                {
                    b.HasOne("Pharmacy_Maneger.Models.Bill", "Bill")
                        .WithMany("BillGoods")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pharmacy_Maneger.Models.SellItem", "Good")
                        .WithMany("BillGoods")
                        .HasForeignKey("GoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("Good");
                });

            modelBuilder.Entity("Pharmacy_Maneger.Models.SellItem", b =>
                {
                    b.HasOne("Pharmacy_Maneger.Models.Company", "company")
                        .WithMany("sellItems")
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("company");
                });

            modelBuilder.Entity("Pharmacy_Maneger.Models.Bill", b =>
                {
                    b.Navigation("BillGoods");
                });

            modelBuilder.Entity("Pharmacy_Maneger.Models.Company", b =>
                {
                    b.Navigation("sellItems");
                });

            modelBuilder.Entity("Pharmacy_Maneger.Models.Customer", b =>
                {
                    b.Navigation("Bills");
                });

            modelBuilder.Entity("Pharmacy_Maneger.Models.SellItem", b =>
                {
                    b.Navigation("BillGoods");
                });
#pragma warning restore 612, 618
        }
    }
}
