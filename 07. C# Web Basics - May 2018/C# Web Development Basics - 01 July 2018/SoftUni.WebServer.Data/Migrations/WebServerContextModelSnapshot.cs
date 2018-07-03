﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftUni.WebServer.Data;

namespace SoftUni.WebServer.Data.Migrations
{
    [DbContext(typeof(WebServerContext))]
    partial class WebServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SoftUni.WebServer.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClientId");

                    b.Property<DateTime>("OrderedOn");

                    b.Property<int?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SoftUni.WebServer.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<int?>("ProductTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SoftUni.WebServer.Models.ProductOrder", b =>
                {
                    b.Property<int>("IdProduct");

                    b.Property<Guid>("IdOrder");

                    b.Property<int>("Id");

                    b.HasKey("IdProduct", "IdOrder");

                    b.HasIndex("IdOrder");

                    b.ToTable("ProductOrder");
                });

            modelBuilder.Entity("SoftUni.WebServer.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("SoftUni.WebServer.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SoftUni.WebServer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FullName")
                        .IsRequired();

                    b.Property<string>("PasswordHash")
                        .IsRequired();

                    b.Property<int?>("RoleId");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SoftUni.WebServer.Models.Order", b =>
                {
                    b.HasOne("SoftUni.WebServer.Models.User", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("SoftUni.WebServer.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("SoftUni.WebServer.Models.Product", b =>
                {
                    b.HasOne("SoftUni.WebServer.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId");
                });

            modelBuilder.Entity("SoftUni.WebServer.Models.ProductOrder", b =>
                {
                    b.HasOne("SoftUni.WebServer.Models.Order", "Order")
                        .WithMany("ProductNavigation")
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SoftUni.WebServer.Models.Product", "Product")
                        .WithMany("OrderNavigation")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SoftUni.WebServer.Models.User", b =>
                {
                    b.HasOne("SoftUni.WebServer.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
