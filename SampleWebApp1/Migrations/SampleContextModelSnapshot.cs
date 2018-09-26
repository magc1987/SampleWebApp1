﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleWebApp1.Data;

namespace SampleWebApp1.Migrations
{
    [DbContext(typeof(SampleContext))]
    partial class SampleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SampleWebApp1.Model.Admission", b =>
                {
                    b.Property<int>("AdmissionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AdmissionDate");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("getdate()");

                    b.Property<int>("PatientId");

                    b.HasKey("AdmissionId");

                    b.HasIndex("PatientId");

                    b.ToTable("Admissions");
                });

            modelBuilder.Entity("SampleWebApp1.Model.ItemOrderDetail", b =>
                {
                    b.Property<int>("OrderDetailID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdmissionId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("getdate()");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("OrderQuantity");

                    b.Property<int>("Position");

                    b.Property<int>("SupplyID");

                    b.HasKey("OrderDetailID");

                    b.HasIndex("AdmissionId");

                    b.HasIndex("SupplyID");

                    b.ToTable("ItemOrderDetails");
                });

            modelBuilder.Entity("SampleWebApp1.Model.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("getdate()");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MiddleName");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("SampleWebApp1.Model.Supply", b =>
                {
                    b.Property<int>("SupplyID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SupplyDescription");

                    b.Property<string>("SupplyName");

                    b.Property<double>("SupplyUnitPrice");

                    b.HasKey("SupplyID");

                    b.ToTable("Supplies");
                });

            modelBuilder.Entity("SampleWebApp1.Model.Admission", b =>
                {
                    b.HasOne("SampleWebApp1.Model.Patient", "Patients")
                        .WithMany("Admissions")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SampleWebApp1.Model.ItemOrderDetail", b =>
                {
                    b.HasOne("SampleWebApp1.Model.Admission", "Admissions")
                        .WithMany("ItemOrderDetails")
                        .HasForeignKey("AdmissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SampleWebApp1.Model.Supply", "Supplies")
                        .WithMany("ItemOrderDetails")
                        .HasForeignKey("SupplyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
