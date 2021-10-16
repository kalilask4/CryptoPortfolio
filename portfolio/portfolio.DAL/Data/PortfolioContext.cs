using Microsoft.EntityFrameworkCore;
using portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.DAL.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        { }

        public DbSet<Coin_DEL> Coins { get; set; }
        public DbSet<BuyTransaction_DEL> BuyTransactions { get; set; }
        public DbSet<SellTransaction_DEL> SellTransactions { get; set; }
        
    }
}
