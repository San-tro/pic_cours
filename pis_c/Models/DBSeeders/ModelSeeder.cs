using pis_c.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBSeeders
{
    public static class ModelSeeder
    {
        public static Model[] Create()
        {
            return new Model[]
            {
                new Model(){Id = 1, BrandId = 1, Name = "Camry"},
                new Model(){Id = 2, BrandId = 2, Name = "320i"},
                new Model(){Id = 3, BrandId = 3, Name = "A4"},
                new Model(){Id = 4, BrandId = 4, Name = "Rio"},
                new Model(){Id = 5, BrandId = 5, Name = "Solaris"},
                new Model(){Id = 6, BrandId = 6, Name = "Vesta"},
            };
        }
    }
}
