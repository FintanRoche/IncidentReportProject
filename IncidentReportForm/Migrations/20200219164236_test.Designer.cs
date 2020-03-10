﻿// <auto-generated />
using IncidentReportForm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IncidentReportForm.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200219164236_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IncidentReportForm.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CentreName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CostCentre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IncidentDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IncidentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagementUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PRNBool")
                        .HasColumnType("bit");

                    b.Property<string>("PRN_Medication")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrincipalPin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SecondaryPin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ServiceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdPin")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderId");

                    b.HasIndex("PrincipalPin");

                    b.HasIndex("SecondaryPin");

                    b.HasIndex("ThirdPin");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("IncidentReportForm.Models.Principal", b =>
                {
                    b.Property<string>("Pin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pin");

                    b.ToTable("Principal");
                });

            modelBuilder.Entity("IncidentReportForm.Models.Secondary", b =>
                {
                    b.Property<string>("Pin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pin");

                    b.ToTable("Secondary");
                });

            modelBuilder.Entity("IncidentReportForm.Models.Third", b =>
                {
                    b.Property<string>("Pin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pin");

                    b.ToTable("Third");
                });

            modelBuilder.Entity("IncidentReportForm.Models.Order", b =>
                {
                    b.HasOne("IncidentReportForm.Models.Principal", "Principal")
                        .WithMany()
                        .HasForeignKey("PrincipalPin");

                    b.HasOne("IncidentReportForm.Models.Secondary", "Secondary")
                        .WithMany()
                        .HasForeignKey("SecondaryPin");

                    b.HasOne("IncidentReportForm.Models.Third", "Third")
                        .WithMany()
                        .HasForeignKey("ThirdPin");
                });
#pragma warning restore 612, 618
        }
    }
}