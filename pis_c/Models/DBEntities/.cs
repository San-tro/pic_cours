using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBEntities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        public string DriverLicense { get; set; }
        public string Inn { get; set; }
    }
}
