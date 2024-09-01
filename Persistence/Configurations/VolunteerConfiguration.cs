using Domain.Entities;
using Domain.Enums.Volunteer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.Property(v => v.State)
                .HasConversion(v => v.ToString(), v => (VolunteerState)Enum.Parse(typeof(VolunteerState), v));

            builder.HasData(
                new Volunteer
                {
                    Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                    Name = "Juan",
                    LastName = "Hernandez",
                    Email = "juan.hernandez@example.com",
                    State = VolunteerState.ACTIVO
                },
                new Volunteer
                {
                    Id = new Guid("b3e9f0d6-1f2c-4d5e-8a0a-2c3d4e5f6b7a"),
                    Name = "Laura",
                    LastName = "Martínez",
                    Email = "laura.martinez@example.com",
                    State = VolunteerState.INACTIVO,
                },
                new Volunteer
                {
                    Id = new Guid("c7a8d1e5-4f3b-2c6e-9a0d-3e4f5a6b7c8d"),
                    Name = "Ricardo",
                    LastName = "García",
                    Email = "ricardo.garcia@example.com",
                    State = VolunteerState.ACTIVO,
                },
                new Volunteer
                {
                    Id = new Guid("d2b4e7c9-3f6a-4e5b-8d0c-1a2b3c4d5e6f"),
                    Name = "Elena",
                    LastName = "Lopez",
                    Email = "elena.lopez@example.com",
                    State = VolunteerState.ACTIVO,
                },
                new Volunteer
                {
                    Id = new Guid("e8f1d3b5-6a7b-4c8e-9f0a-2b3c4d5e6a7d"),
                    Name = "Miguel",
                    LastName = "Ramírez",
                    Email = "miguel.ramirez@example.com",
                    State = VolunteerState.ACTIVO,
                }
            );
        }
    }
}
