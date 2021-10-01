using Microsoft.EntityFrameworkCore;
using portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.DAL.Data
{
    class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        { }

        public DbSet<Coin> Coins { get; set; }
        public DbSet<BuyTransaction> buyTransactions { get; set; }
        public DbSet<SellTransaction> sellTransactions { get; set; }
        
    }
}
