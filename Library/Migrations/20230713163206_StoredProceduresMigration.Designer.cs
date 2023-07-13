﻿// <auto-generated />
using System;
using Library.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20230713163206_StoredProceduresMigration")]
    partial class StoredProceduresMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library.DbModels.FluentModels.Fluent_BookWithDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PagesCount")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Fluent_BookWithDetails", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Library.DbModels.FluentModels.Fluent_Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fluent_Roles");
                });

            modelBuilder.Entity("Library.DbModels.FluentModels.Fluent_User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("ReaderId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique()
                        .HasFilter("[EmployeeId] IS NOT NULL");

                    b.HasIndex("ReaderId")
                        .IsUnique()
                        .HasFilter("[ReaderId] IS NOT NULL");

                    b.ToTable("Fluent_Users");
                });

            modelBuilder.Entity("Library.DbModels.FluentModels.Fluent_UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("Fluent_Users_Roles", (string)null);
                });

            modelBuilder.Entity("Library.DbModels.Fluent_Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Fluent_Authors");
                });

            modelBuilder.Entity("Library.DbModels.Fluent_Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("PublisherId");

                    b.ToTable("Fluent_Books");
                });

            modelBuilder.Entity("Library.DbModels.Fluent_BookDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("PagesCount")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 5)
                        .HasColumnType("decimal(10,5)");

                    b.HasKey("Id");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("Fluent_BookDetails");
                });

            modelBuilder.Entity("Library.DbModels.Fluent_BookReader", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("ReaderId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "ReaderId");

                    b.HasIndex("ReaderId");

                    b.ToTable("Fluent_BookReader", (string)null);
                });

            modelBuilder.Entity("Library.DbModels.Fluent_Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeTypeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fluent_Employees");
                });

            modelBuilder.Entity("Library.DbModels.Fluent_Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Fluent_Publishers");
                });

            modelBuilder.Entity("Library.DbModels.Fluent_Reader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TempId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Fluent_Readers");
                });

            modelBuilder.Entity("Library.DbModels.FluentModels.Fluent_User", b =>
                {
                    b.HasOne("Library.DbModels.Fluent_Employee", "Employee")
                        .WithOne("User")
                        .HasForeignKey("Library.DbModels.FluentModels.Fluent_User", "EmployeeId");

                    b.HasOne("Library.DbModels.Fluent_Reader", "Reader")
                        .WithOne("User")
                        .HasForeignKey("Library.DbModels.FluentModels.Fluent_User", "ReaderId");

                    b.Navigation("Employee");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("Library.DbModels.FluentModels.Fluent_UserRole", b =>
                {
                    b.HasOne("Library.DbModels.FluentModels.Fluent_Role", "Role")
                        .WithMany("UsersRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.DbModels.FluentModels.Fluent_User", "User")
                        .WithMany("UsersRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Library.DbModels.Fluent_Book", b =>
                {
                    b.HasOne("Library.DbModels.Fluent_Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.DbModels.Fluent_Employee", "Employee")
                        .WithMany("Books")
                        .HasForeignKey("EmployeeID");

                    b.HasOne("Library.DbModels.Fluent_Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Employee");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Library.DbModels.Fluent_BookDetail", b =>
                {
                    b.HasOne("Library.DbModels.Fluent_Book", "Book")
                        .WithOne("BookDetail")
                        .HasForeignKey("Library.DbModels.Fluent_BookDetail", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Library.DbModels.Fluent_BookReader", b =>
                {
                    b.HasOne("Library.DbModels.Fluent_Book", "Book")
                        .WithMany("BookReaders")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.DbModels.Fluent_Reader", "Reader")
                        .WithMany("BookReaders")
                        .HasForeignKey("ReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("Library.DbModels.FluentModels.Fluent_Role", b =>
                {
                    b.Navigation("UsersRoles");
                });

            modelBuilder.Entity("Library.DbModels.FluentModels.Fluent_User", b =>
                {
                    b.Navigation("UsersRoles");
                });

            modelBuilder.Entity("Library.DbModels.Fluent_Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Library.DbModels.Fluent_Book", b =>
                {
                    b.Navigation("BookDetail");

                    b.Navigation("BookReaders");
                });

            modelBuilder.Entity("Library.DbModels.Fluent_Employee", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Library.DbModels.Fluent_Publisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Library.DbModels.Fluent_Reader", b =>
                {
                    b.Navigation("BookReaders");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
