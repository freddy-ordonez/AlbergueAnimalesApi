using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class AdopterConfiguration : IEntityTypeConfiguration<Adopter>
    {
        public void Configure(EntityTypeBuilder<Adopter> builder)
        {
            builder.HasData(
                new Adopter
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    Name = "Freddy",
                    LastName = "Aguilar",
                    Email = "freddy@outlook.com",
                    State = Domain.Enums.Adopter.State.ACTIVO
                },
                new Adopter
                {
                    Id = new Guid("9d6f2d34-a1d7-4d2e-8c12-6b9c8d7e6a1b"),
                    Name = "Carlos",
                    LastName = "Mendoza",
                    Email = "carlos.mendoza@example.com",
                    State = Domain.Enums.Adopter.State.INACTIVO,
                },
                new Adopter
                {
                    Id = new Guid("b4a3e2d6-c9d5-4e8b-9f1d-5b9a8c7d2e3a"),
                    Name = "Sofia",
                    LastName = "Pérez",
                    Email = "sofia.perez@example.com",
                    State = Domain.Enums.Adopter.State.ACTIVO,
                },
                new Adopter
                {
                    Id = new Guid("d8a5c6f3-b2d1-4a6e-8b9d-3e4f5b6c7d8e"),
                    Name = "Luis",
                    LastName = "Hernández",
                    Email = "luis.hernandez@example.com",
                    State = Domain.Enums.Adopter.State.INACTIVO,
                },
                new Adopter
                {
                    Id = new Guid("e7b4a3d5-8f1c-4d6e-9b7e-8c1d9e2f3b4a"),
                    Name = "María",
                    LastName = "García",
                    Email = "maria.garcia@example.com",
                    State = Domain.Enums.Adopter.State.ACTIVO,
                }
            );
        }
    }
}
