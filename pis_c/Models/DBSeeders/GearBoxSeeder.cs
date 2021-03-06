﻿using pis_c.Models.DBEntities;
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
                new GearBox(){ Id = 1, Name = "АКПП"},
                new GearBox(){ Id = 2, Name = "МКПП"},
                new GearBox(){ Id = 3, Name = "Робот"},
                new GearBox(){ Id = 4, Name = "Вариатор"}
            };
        }
    }
}
