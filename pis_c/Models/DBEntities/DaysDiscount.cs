using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBEntities
{
    public class DaysDiscount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MinDaysAmmount { get; set; }
        public double Percent { get; set; }

        public ICollection<Order> Orders { get; set; }

        public static DaysDiscount GetDiscount(int days)
        {
            var dbContext = new AppDbContext(new DbContextOptions<AppDbContext>());
            return dbContext.DaysDiscounts.FirstOrDefault(d => d.MinDaysAmmount <= days);
        }
    }
}
