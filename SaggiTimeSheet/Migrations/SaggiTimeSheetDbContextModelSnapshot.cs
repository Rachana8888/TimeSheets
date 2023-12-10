﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaggiTimeSheet;

#nullable disable

namespace SaggiTimeSheet.Migrations
{
    [DbContext(typeof(SaggiTimeSheetDbContext))]
    partial class SaggiTimeSheetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SaggiTimeSheet.Models.Approval", b =>
                {
                    b.Property<int>("ApprovalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApprovalId"));

                    b.Property<DateTime?>("ApprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApprovalStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ApproverUserId")
                        .HasColumnType("int");

                    b.Property<int?>("TimeSheetId")
                        .HasColumnType("int");

                    b.Property<int?>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("ApprovalId");

                    b.HasIndex("TimeSheetId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("approvals");
                });

            modelBuilder.Entity("SaggiTimeSheet.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("ProjectCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectManagerId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("SaggiTimeSheet.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("SaggiTimeSheet.Models.TimeSheet", b =>
                {
                    b.Property<int>("TimeSheetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeSheetId"));

                    b.Property<string>("ApprovalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalHours")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("WeekStarting")
                        .HasColumnType("datetime2");

                    b.HasKey("TimeSheetId");

                    b.HasIndex("UserID");

                    b.ToTable("timesheets");
                });

            modelBuilder.Entity("SaggiTimeSheet.Models.TimeSheetEntry", b =>
                {
                    b.Property<int>("TimeSheetEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeSheetEntryId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("HoursWorked")
                        .HasColumnType("int");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<int>("TimeSheetId")
                        .HasColumnType("int");

                    b.HasKey("TimeSheetEntryId");

                    b.HasIndex("ProjectID");

                    b.HasIndex("TimeSheetId");

                    b.ToTable("timesheetentries");
                });

            modelBuilder.Entity("SaggiTimeSheet.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("SaggiTimeSheet.Models.Approval", b =>
                {
                    b.HasOne("SaggiTimeSheet.Models.TimeSheet", "TimeSheets")
                        .WithMany("Approvals")
                        .HasForeignKey("TimeSheetId");

                    b.HasOne("SaggiTimeSheet.Models.User", "Users")
                        .WithMany("Approvals")
                        .HasForeignKey("UsersUserId");

                    b.Navigation("TimeSheets");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("SaggiTimeSheet.Models.Project", b =>
                {
                    b.HasOne("SaggiTimeSheet.Models.User", "Users")
                        .WithMany("Projects")
                        .HasForeignKey("UsersUserId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("SaggiTimeSheet.Models.TimeSheet", b =>
                {
                    b.HasOne("SaggiTimeSheet.Models.User", "Users")
                        .WithMany("TimeSheets")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("SaggiTimeSheet.Models.TimeSheetEntry", b =>
                {
                    b.HasOne("SaggiTimeSheet.Models.Project", "Projects")
                        .WithMany("TimeSheetEntries")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaggiTimeSheet.Models.TimeSheet", "TimeSheets")
                        .WithMany("TimeSheetEntries")
                        .HasForeignKey("TimeSheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");

                    b.Navigation("TimeSheets");
                });

            modelBuilder.Entity("SaggiTimeSheet.Models.User", b =>
                {
                    b.HasOne("SaggiTimeSheet.Models.Role", "Roles")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("SaggiTimeSheet.Models.Project", b =>
                {
                    b.Navigation("TimeSheetEntries");
                });

            modelBuilder.Entity("SaggiTimeSheet.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SaggiTimeSheet.Models.TimeSheet", b =>
                {
                    b.Navigation("Approvals");

                    b.Navigation("TimeSheetEntries");
                });

            modelBuilder.Entity("SaggiTimeSheet.Models.User", b =>
                {
                    b.Navigation("Approvals");

                    b.Navigation("Projects");

                    b.Navigation("TimeSheets");
                });
#pragma warning restore 612, 618
        }
    }
}
