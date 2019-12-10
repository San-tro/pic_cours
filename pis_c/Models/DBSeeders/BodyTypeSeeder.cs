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
                new BodyType() {Name = "Седан"},
                new BodyType() {Name = "Универсал"},
                new BodyType() {Name = "Внедорожник"},
                new BodyType() {Name = "Хэтчбэк"}
            };
        }
    }
}
