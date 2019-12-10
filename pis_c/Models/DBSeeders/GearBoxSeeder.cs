using pis_c.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBSeeders
{
    public static class GearBoxSeeder
    {
        public static GearBox[] Create()
        {
            return new GearBox[]
            {
                new GearBox(){ Name = "АКПП"},
                new GearBox(){ Name = "МКПП"},
                new GearBox(){ Name = "Робот"},
                new GearBox(){ Name = "Вариатор"}
            };
        }
    }
}
