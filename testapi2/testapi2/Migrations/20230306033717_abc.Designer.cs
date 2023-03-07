﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testapi2.Data;

#nullable disable

namespace testapi2.Migrations
{
    [DbContext(typeof(MyDbConText))]
    [Migration("20230306033717_abc")]
    partial class abc
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("testapi2.Data.Phong", b =>
                {
                    b.Property<int>("IdPhong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPhong"), 1L, 1);

                    b.Property<int>("IdTang")
                        .HasColumnType("int");

                    b.Property<int>("SoPhong")
                        .HasColumnType("int");

                    b.Property<string>("TenChuPhong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPhong");

                    b.HasIndex("IdTang");

                    b.ToTable("phongs", (string)null);
                });

            modelBuilder.Entity("testapi2.Data.Tang", b =>
                {
                    b.Property<int>("IdTang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTang"), 1L, 1);

                    b.Property<string>("ChuTro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdSonha")
                        .HasColumnType("int");

                    b.HasKey("IdTang");

                    b.ToTable("tangs");
                });

            modelBuilder.Entity("testapi2.Data.Phong", b =>
                {
                    b.HasOne("testapi2.Data.Tang", "tang")
                        .WithMany("phongs")
                        .HasForeignKey("IdTang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tang");
                });

            modelBuilder.Entity("testapi2.Data.Tang", b =>
                {
                    b.Navigation("phongs");
                });
#pragma warning restore 612, 618
        }
    }
}
