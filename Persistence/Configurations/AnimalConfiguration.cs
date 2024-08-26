using Domain.Entities;
using Domain.Enums.Animal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasData(
                new Animal 
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Name = "Lucila",
                    Type = Domain.Enums.Animal.Type.Perro,
                    State = State.ADOPCION,
                },
                new Animal
                {
                    Id = new Guid("d3c3d7d2-5b76-4eaf-bd9b-5c7d0a9e8b9e"),
                    Name = "Rex",
                    Type = Domain.Enums.Animal.Type.Perro,
                    State = State.ADOPCION,
                },
                new Animal
                {
                    Id = new Guid("f1f1e2e3-9c7e-4a0d-8b47-cce9b4a915b6"),
                    Name = "Whiskers",
                    Type = Domain.Enums.Animal.Type.Gato,
                    State = State.ADOPCION,
                },
                new Animal
                {
                    Id = new Guid("a3b6c8d7-0d29-4b08-873d-378d6ab9c6a2"),
                    Name = "Goldie",
                    Type = Domain.Enums.Animal.Type.Gato,
                    State = State.ADOPCION,
                },
                new Animal
                {
                    Id = new Guid("e2a4f8b3-1c6b-4d77-8a6c-8b012d5c1d7f"),
                    Name = "Nina",
                    Type = Domain.Enums.Animal.Type.Perro,
                    State = State.ADOPCION,
                }
            );
        }
    }
}
