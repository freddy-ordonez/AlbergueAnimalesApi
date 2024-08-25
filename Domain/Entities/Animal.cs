﻿using Domain.Enums.Animal;
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
        public Enums.Animal.Type? Type { get; set; }
        public State? State { get; set; }
        public DateTime? DateDelivery { get; set; }
    }
}
