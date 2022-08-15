﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RenderApp.DataAccess.Postgres;

#nullable disable

namespace RenderApp.DataAccess.Postgres.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220815113929_init_someData")]
    partial class init_someData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RenderApp.Domain.SomeData", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateTimeValue")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("DecimalValue")
                        .HasColumnType("numeric");

                    b.Property<int>("IntValue")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("SomeData");
                });
#pragma warning restore 612, 618
        }
    }
}