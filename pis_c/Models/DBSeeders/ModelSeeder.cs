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
                new Model(){ BrandId = 1, Name = "Camry"},
                new Model(){ BrandId = 2, Name = "320i"},
                new Model(){ BrandId = 3, Name = "A4"},
                new Model(){ BrandId = 4, Name = "Rio"},
                new Model(){ BrandId = 5, Name = "Solaris"},
                new Model(){ BrandId = 6, Name = "Vesta"},
            };
        }
    }
}
