using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBEntities
{
    public class Photo
    {
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
