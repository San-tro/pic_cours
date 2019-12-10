using pis_c.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBSeeders
{
    public static class CarClassSeeder
    {
        public static CarClass[] Create()
        {
            return new CarClass[]
            {
                new CarClass {Name = "A"},
                new CarClass {Name = "B"},
                new CarClass {Name = "C"},
                new CarClass {Name = "D"},
                new CarClass {Name = "E"}
            };
        }
    }
}
