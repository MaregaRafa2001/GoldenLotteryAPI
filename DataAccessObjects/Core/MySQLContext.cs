using GoldenLotteryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenLotteryAPI.DataAccessObjects.Core
{
    public class MySQLContext<T> : DbContext where T : class
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("server=localhost;database=GoldenLottery;user=root;");
        }

        public DbSet<T> Table { get; set; }
        public DbSet<Raffle> Raffle { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<RaffleCustomer> RaffleCustomer { get; set; }
    }
}