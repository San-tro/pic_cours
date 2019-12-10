using pis_c.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBSeeders
{
    public static class DriveTypeSeeder
    {
        public static DriveType[] Create()
        {
            return new DriveType[]
            {
                new DriveType {Name = "Полный"},
                new DriveType {Name = "Передний"},
                new DriveType {Name = "Задний"}
            };
        }
    }
}
