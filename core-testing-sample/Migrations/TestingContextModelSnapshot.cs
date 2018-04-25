﻿// <auto-generated />
using CoreTestingSample.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CoreTestingSample.Migrations
{
    [DbContext(typeof(TestingContext))]
    partial class TestingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("CoreTestingSample.Context.DataModels.Address", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("City");

                    b.Property<Guid>("PersonId");

                    b.Property<string>("Street");

                    b.Property<string>("Suite");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("address");
                });

            modelBuilder.Entity("CoreTestingSample.Context.DataModels.Company", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Bs");

                    b.Property<string>("CatchPhrase");

                    b.Property<string>("Name");

                    b.Property<Guid>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("company");
                });

            modelBuilder.Entity("CoreTestingSample.Context.DataModels.Person", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Avatar");

                    b.Property<DateTimeOffset>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.Property<string>("UserName");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.HasIndex("FirstName");

                    b.HasIndex("LastName");

                    b.ToTable("person");
                });

            modelBuilder.Entity("CoreTestingSample.Context.DataModels.Address", b =>
                {
                    b.HasOne("CoreTestingSample.Context.DataModels.Person", "Person")
                        .WithOne("Address")
                        .HasForeignKey("CoreTestingSample.Context.DataModels.Address", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoreTestingSample.Context.DataModels.Company", b =>
                {
                    b.HasOne("CoreTestingSample.Context.DataModels.Person", "Person")
                        .WithOne("Company")
                        .HasForeignKey("CoreTestingSample.Context.DataModels.Company", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
