using pis_c.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBSeeders
{
    public static class UserSeeder
    {
        public static User[] Create(int ammount)
        {
            var users = new User[ammount];
            for (int i = 0; i < ammount; i++)
                users[i] = new User()
                {
                    Id = i+1,
                    Name = "TESTNAME" + i,
                    Surname = "TESTSURNAME" + i,
                    Patronymic = "TESTPATR" + i,
                    Passport = "TESTPASSPORT" + i,
                    DriverLicense = "TESTDL" + i,
                    Inn = "TESTINN" + i,
                    Phone = "TESTPHONE" + i,
                    IsAdmin = false
                };
            users.Last().IsAdmin = true;
            return users;
        }
    }
}
