﻿// <auto-generated />
using System;
using AllostaServer.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AllostaServer.Migrations
{
    [DbContext(typeof(BudgetContext))]
    [Migration("20240528002928_FinancialAccount_RenameToAccount")]
    partial class FinancialAccount_RenameToAccount
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AllostaServer.Models.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AccountId"));

                    b.Property<int>("AccountTypeId")
                        .HasColumnType("integer");

                    b.Property<double>("Balance")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AccountId");

                    b.HasIndex("AccountTypeId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("AllostaServer.Models.Entities.AccountType", b =>
                {
                    b.Property<int>("AccountTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AccountTypeId"));

                    b.Property<int>("FinancialCategory")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AccountTypeId");

                    b.ToTable("AccountType");
                });

            modelBuilder.Entity("AllostaServer.Models.Entities.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TransactionId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer");

                    b.Property<bool>("Cleared")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Inflow")
                        .HasColumnType("numeric");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<decimal>("Outflow")
                        .HasColumnType("numeric");

                    b.Property<int>("TransactionCategoryId")
                        .HasColumnType("integer");

                    b.Property<int?>("VendorId")
                        .HasColumnType("integer");

                    b.HasKey("TransactionId");

                    b.HasIndex("AccountId");

                    b.HasIndex("TransactionCategoryId");

                    b.HasIndex("VendorId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("AllostaServer.Models.Entities.TransactionCategory", b =>
                {
                    b.Property<int>("TransactionCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TransactionCategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("integer");

                    b.HasKey("TransactionCategoryId");

                    b.HasIndex("ParentCategoryId");

                    b.HasIndex("Name", "ParentCategoryId")
                        .IsUnique();

                    b.ToTable("TransactionCategory");
                });

            modelBuilder.Entity("AllostaServer.Models.Entities.Vendor", b =>
                {
                    b.Property<int>("VendorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VendorId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("VendorId");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("AllostaServer.Models.Entities.Account", b =>
                {
                    b.HasOne("AllostaServer.Models.Entities.AccountType", "AccountType")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountType");
                });

            modelBuilder.Entity("AllostaServer.Models.Entities.Transaction", b =>
                {
                    b.HasOne("AllostaServer.Models.Entities.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId");

                    b.HasOne("AllostaServer.Models.Entities.TransactionCategory", "TransactionCategory")
                        .WithMany("Transactions")
                        .HasForeignKey("TransactionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllostaServer.Models.Entities.Vendor", "Vendor")
                        .WithMany("Transactions")
                        .HasForeignKey("VendorId");

                    b.Navigation("Account");

                    b.Navigation("TransactionCategory");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("AllostaServer.Models.Entities.TransactionCategory", b =>
                {
                    b.HasOne("AllostaServer.Models.Entities.TransactionCategory", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("AllostaServer.Models.Entities.Account", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("AllostaServer.Models.Entities.AccountType", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("AllostaServer.Models.Entities.TransactionCategory", b =>
                {
                    b.Navigation("SubCategories");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("AllostaServer.Models.Entities.Vendor", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
