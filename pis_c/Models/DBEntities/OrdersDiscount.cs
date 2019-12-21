using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBEntities
{
    public class OrdersDiscount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MinOrdersAmmount { get; set; }
        public double Percentage { get; set; }

        public ICollection<Order> Orders { get; set; }

        public static OrdersDiscount GetDiscount(int userId)
        {
            var dbContext = new AppDbContext(new DbContextOptions<AppDbContext>());
            var ordersAmmount = dbContext.Users.Include(u => u.Orders).FirstOrDefault(u => u.Id == userId).Orders.Count();
            return dbContext.OrdersDiscounts.FirstOrDefault(d => d.MinOrdersAmmount <= ordersAmmount);
        }
    }
}
