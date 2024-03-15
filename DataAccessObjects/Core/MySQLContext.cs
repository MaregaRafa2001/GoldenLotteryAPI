using GoldenLotteryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenLotteryAPI.DataAccessObjects.Core
{
    public class MySQLContext<T> : DbContext where T : class
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("Server=node174656-bubupremios.jelastic.saveincloud.net;Database=GoldenLottery;User Id=root;Password=LIDafp96343;Port=15542;");
        }

        public DbSet<T> Table { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Raffle> Raffle { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<RaffleCustomer> RaffleCustomer { get; set; }
    }
}