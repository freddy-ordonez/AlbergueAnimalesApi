﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace AlbergueAnimalesRescatadosApi.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Adopter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Adopters");

                    b.HasData(
                        new
                        {
                            Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            Email = "freddy@outlook.com",
                            LastName = "Aguilar",
                            Name = "Freddy",
                            State = "ACTIVO"
                        },
                        new
                        {
                            Id = new Guid("9d6f2d34-a1d7-4d2e-8c12-6b9c8d7e6a1b"),
                            Email = "carlos.mendoza@example.com",
                            LastName = "Mendoza",
                            Name = "Carlos",
                            State = "INACTIVO"
                        },
                        new
                        {
                            Id = new Guid("b4a3e2d6-c9d5-4e8b-9f1d-5b9a8c7d2e3a"),
                            Email = "sofia.perez@example.com",
                            LastName = "Pérez",
                            Name = "Sofia",
                            State = "ACTIVO"
                        },
                        new
                        {
                            Id = new Guid("d8a5c6f3-b2d1-4a6e-8b9d-3e4f5b6c7d8e"),
                            Email = "luis.hernandez@example.com",
                            LastName = "Hernández",
                            Name = "Luis",
                            State = "INACTIVO"
                        },
                        new
                        {
                            Id = new Guid("e7b4a3d5-8f1c-4d6e-9b7e-8c1d9e2f3b4a"),
                            Email = "maria.garcia@example.com",
                            LastName = "García",
                            Name = "María",
                            State = "ACTIVO"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Adoption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdopterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnimalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAdoption")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<Guid>("VolunteerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AdopterId");

                    b.HasIndex("AnimalId");

                    b.HasIndex("VolunteerId");

                    b.ToTable("Adoptions");
                });

            modelBuilder.Entity("Domain.Entities.Animal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateDelivery")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            DateDelivery = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Lucila",
                            State = "ADOPCION",
                            Type = "Perro"
                        },
                        new
                        {
                            Id = new Guid("d3c3d7d2-5b76-4eaf-bd9b-5c7d0a9e8b9e"),
                            DateDelivery = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Rex",
                            State = "ADOPCION",
                            Type = "Perro"
                        },
                        new
                        {
                            Id = new Guid("f1f1e2e3-9c7e-4a0d-8b47-cce9b4a915b6"),
                            DateDelivery = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Whiskers",
                            State = "ADOPCION",
                            Type = "Gato"
                        },
                        new
                        {
                            Id = new Guid("a3b6c8d7-0d29-4b08-873d-378d6ab9c6a2"),
                            DateDelivery = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Goldie",
                            State = "ADOPCION",
                            Type = "Gato"
                        },
                        new
                        {
                            Id = new Guid("e2a4f8b3-1c6b-4d77-8a6c-8b012d5c1d7f"),
                            DateDelivery = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Nina",
                            State = "ADOPCION",
                            Type = "Perro"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Volunteers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            Email = "juan.hernandez@example.com",
                            LastName = "Hernandez",
                            Name = "Juan",
                            State = "ACTIVO"
                        },
                        new
                        {
                            Id = new Guid("b3e9f0d6-1f2c-4d5e-8a0a-2c3d4e5f6b7a"),
                            Email = "laura.martinez@example.com",
                            LastName = "Martínez",
                            Name = "Laura",
                            State = "INACTIVO"
                        },
                        new
                        {
                            Id = new Guid("c7a8d1e5-4f3b-2c6e-9a0d-3e4f5a6b7c8d"),
                            Email = "ricardo.garcia@example.com",
                            LastName = "García",
                            Name = "Ricardo",
                            State = "ACTIVO"
                        },
                        new
                        {
                            Id = new Guid("d2b4e7c9-3f6a-4e5b-8d0c-1a2b3c4d5e6f"),
                            Email = "elena.lopez@example.com",
                            LastName = "Lopez",
                            Name = "Elena",
                            State = "ACTIVO"
                        },
                        new
                        {
                            Id = new Guid("e8f1d3b5-6a7b-4c8e-9f0a-2b3c4d5e6a7d"),
                            Email = "miguel.ramirez@example.com",
                            LastName = "Ramírez",
                            Name = "Miguel",
                            State = "ACTIVO"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Adoption", b =>
                {
                    b.HasOne("Domain.Entities.Adopter", "Adopter")
                        .WithMany()
                        .HasForeignKey("AdopterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Volunteer", "Volunteer")
                        .WithMany()
                        .HasForeignKey("VolunteerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adopter");

                    b.Navigation("Animal");

                    b.Navigation("Volunteer");
                });
#pragma warning restore 612, 618
        }
    }
}
