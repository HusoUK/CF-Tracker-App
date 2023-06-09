﻿// <auto-generated />
using System;
using CFTrackerServices.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CFTrackerServices.Migrations
{
    [DbContext(typeof(CFTrackerContext))]
    [Migration("20230421191637_newForeignKeys")]
    partial class newForeignKeys
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CFTrackerServices.Models.BodyMassIndex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Bmi")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("HeightCm")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<string>("HeightTestingMachine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserInfoId")
                        .HasColumnType("int");

                    b.Property<decimal>("WeightKg")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<string>("WeightTestingMachine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoId");

                    b.ToTable("BodyMassIndexes");
                });

            modelBuilder.Entity("CFTrackerServices.Models.LungFunction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Fev")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<decimal>("Fvc1")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<string>("TestingMachine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoId");

                    b.ToTable("LungFunctions");
                });

            modelBuilder.Entity("CFTrackerServices.Models.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CFTrackerServices.Models.BodyMassIndex", b =>
                {
                    b.HasOne("CFTrackerServices.Models.UserInfo", "User")
                        .WithMany("BodyMassIndexes")
                        .HasForeignKey("UserInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CFTrackerServices.Models.LungFunction", b =>
                {
                    b.HasOne("CFTrackerServices.Models.UserInfo", "User")
                        .WithMany("LungFunctions")
                        .HasForeignKey("UserInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CFTrackerServices.Models.UserInfo", b =>
                {
                    b.Navigation("BodyMassIndexes");

                    b.Navigation("LungFunctions");
                });
#pragma warning restore 612, 618
        }
    }
}
