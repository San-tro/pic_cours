﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBEntities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        ICollection<Model> Models { get; set; }
    }
}
