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
                new DriveType {Id = 1, Name = "Полный"},
                new DriveType {Id = 2, Name = "Передний"},
                new DriveType {Id = 3, Name = "Задний"}
            };
        }
    }
}
