using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Type? Type { get; set; }
        public Estate? Estate { get; set; }
        public DateTime? DateDelivery { get; set; } = DateTime.Now;

    }
}
