﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Thor.Provider;

#nullable disable

namespace Thor.Provider.MySql.Logger
{
    [DbContext(typeof(MySqlLoggerContext))]
    partial class MySqlLoggerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Thor.Service.Domain.ChatLogger", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ChannelId")
                        .HasColumnType("longtext");

                    b.Property<string>("ChannelName")
                        .HasColumnType("longtext");

                    b.Property<int>("CompletionTokens")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Creator")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("IP")
                        .HasColumnType("longtext");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Modifier")
                        .HasColumnType("longtext");

                    b.Property<int>("PromptTokens")
                        .HasColumnType("int");

                    b.Property<long>("Quota")
                        .HasColumnType("bigint");

                    b.Property<bool>("Stream")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("TokenName")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("TotalTime")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserAgent")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Creator");

                    b.HasIndex("ModelName");

                    b.HasIndex("TokenName");

                    b.HasIndex("UserName");

                    b.ToTable("Loggers");
                });

            modelBuilder.Entity("Thor.Service.Domain.ModelStatisticsNumber", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Creator")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Modifier")
                        .HasColumnType("longtext");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("Quota")
                        .HasColumnType("int");

                    b.Property<int>("TokenUsed")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Creator");

                    b.HasIndex("Day");

                    b.HasIndex("ModelName");

                    b.HasIndex("Month");

                    b.HasIndex("Year");

                    b.ToTable("ModelStatisticsNumbers");
                });

            modelBuilder.Entity("Thor.Service.Domain.StatisticsConsumesNumber", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Creator")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<string>("Modifier")
                        .HasColumnType("longtext");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<long>("Number")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("Value")
                        .HasColumnType("bigint");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Creator");

                    b.HasIndex("Day");

                    b.HasIndex("Month");

                    b.HasIndex("Year");

                    b.ToTable("StatisticsConsumesNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
