using pis_c.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBSeeders
{
    public static class BodyTypeSeeder
    {
        public static BodyType[] Create()
        {
            return new BodyType[]
            {
                new BodyType() {Id = 1, Name = "Седан"},
                new BodyType() {Id = 2, Name = "Универсал"},
                new BodyType() {Id = 3, Name = "Внедорожник"},
                new BodyType() {Id = 4, Name = "Хэтчбэк"}
            };
        }
    }
}
