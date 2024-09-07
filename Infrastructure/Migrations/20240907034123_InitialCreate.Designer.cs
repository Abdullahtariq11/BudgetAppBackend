﻿// <auto-generated />
using System;
using BudgetApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BudgetApp.Infrastructure.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240907034123_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BudgetApp.Domain.Models.BudgetCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("BudgetCategoryId");

                    b.Property<decimal>("AllocatedAmount")
                        .HasColumnType("numeric");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("RemainingAmount")
                        .HasColumnType("numeric");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("BudgetCategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f377faa4-4336-4b2b-adc7-0aea3cc15e1b"),
                            AllocatedAmount = 500m,
                            CategoryName = "Groceries",
                            LastUpdated = new DateTime(2024, 9, 7, 3, 41, 23, 26, DateTimeKind.Utc).AddTicks(7760),
                            RemainingAmount = 0m,
                            UserID = "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4"
                        },
                        new
                        {
                            Id = new Guid("b336cbc3-409f-4554-ade4-e4388c4c7af2"),
                            AllocatedAmount = 200m,
                            CategoryName = "Entertainment",
                            LastUpdated = new DateTime(2024, 10, 7, 3, 41, 23, 26, DateTimeKind.Utc).AddTicks(7760),
                            RemainingAmount = 0m,
                            UserID = "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4"
                        });
                });

            modelBuilder.Entity("BudgetApp.Domain.Models.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("CardId");

                    b.Property<decimal?>("AvailableBalance")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Balance")
                        .HasColumnType("numeric");

                    b.Property<string>("CardName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("TotalCreditLimit")
                        .HasColumnType("numeric");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("cardType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = new Guid("54e0c90e-1e91-42d1-8d24-8e00fa63ec0b"),
                            Balance = 1000m,
                            CardName = "Debit Card",
                            UserId = "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4",
                            cardType = 0
                        },
                        new
                        {
                            Id = new Guid("abf2b781-ea45-4d36-b5f7-3c6fd7e4bdf7"),
                            AvailableBalance = 2000m,
                            Balance = -500m,
                            CardName = "Credit Card",
                            TotalCreditLimit = 2500m,
                            UserId = "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4",
                            cardType = 1
                        });
                });

            modelBuilder.Entity("BudgetApp.Domain.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("TransactionId");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("CardId")
                        .HasColumnType("uuid");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("UserID");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0ee1dfb2-ba31-4887-a753-6123d1fe4c95"),
                            Amount = 200m,
                            CardId = new Guid("54e0c90e-1e91-42d1-8d24-8e00fa63ec0b"),
                            Category = "Groceries",
                            Description = "Weekly groceries",
                            TransactionDate = new DateTime(2024, 9, 7, 3, 41, 23, 26, DateTimeKind.Utc).AddTicks(8080),
                            Type = 1,
                            UserID = "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4"
                        },
                        new
                        {
                            Id = new Guid("cc25f84c-b612-40c6-aa7f-a9e167b769ec"),
                            Amount = 500m,
                            CardId = new Guid("54e0c90e-1e91-42d1-8d24-8e00fa63ec0b"),
                            Category = "Freelance",
                            Description = "Web development project",
                            TransactionDate = new DateTime(2024, 9, 7, 3, 41, 23, 26, DateTimeKind.Utc).AddTicks(8090),
                            Type = 0,
                            UserID = "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4"
                        });
                });

            modelBuilder.Entity("BudgetApp.Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "dcf9a4c7-aacd-491e-a145-d84e639af2c8",
                            Email = "abdullahtariq096@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Abdullah",
                            LastName = "Tariq",
                            LockoutEnabled = false,
                            NormalizedEmail = "ABDULLAHTARIQ096@GMAIL.COM",
                            NormalizedUserName = "ABDULLAHT",
                            PasswordHash = "AQAAAAIAAYagAAAAEAPK/i1kY1XBPxkBnTZX7DHWbHPW38aO+30DzFf+LRK63IIJOdI8XU0pjKnDdPkt6w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d4b03b5a-3107-45f2-b1f6-e9ff67f4b268",
                            TwoFactorEnabled = false,
                            UserName = "abdullahT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BudgetApp.Domain.Models.BudgetCategory", b =>
                {
                    b.HasOne("BudgetApp.Domain.Models.User", "User")
                        .WithMany("BudgetCategories")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BudgetApp.Domain.Models.Card", b =>
                {
                    b.HasOne("BudgetApp.Domain.Models.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BudgetApp.Domain.Models.Transaction", b =>
                {
                    b.HasOne("BudgetApp.Domain.Models.Card", "Card")
                        .WithMany("Transactions")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("BudgetApp.Domain.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BudgetApp.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BudgetApp.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BudgetApp.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BudgetApp.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BudgetApp.Domain.Models.Card", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("BudgetApp.Domain.Models.User", b =>
                {
                    b.Navigation("BudgetCategories");

                    b.Navigation("Cards");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
