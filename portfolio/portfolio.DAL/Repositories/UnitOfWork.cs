using Microsoft.EntityFrameworkCore;
using portfolio.DAL.Data;
using portfolio.Domain.Entities;
using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.DAL.Repositories
{
    class UnitOfWork: IUnitOfWork
    {
        private readonly PortfolioContext context;
        private IRepository<Coin> coinRepository;
        private IRepository<BuyTransaction> buyRepository;

        public UnitOfWork(string connectionString)
        {
            var options = new DbContextOptionsBuilder<PortfolioContext>()
                .UseSqlServer(connectionString)
                .Options;
            context = new PortfolioContext(options);
            context.Database.EnsureCreated();
        }

        public IRepository<Coin> CoinRepository =>
            coinRepository ?? new EFCoinsRepository(context);

        public IRepository<BuyTransaction> BuyTransactioRepository =>
            buyRepository ?? new EFBuyTransactionRepositories(context);

        public IRepository<SellTransaction> SellTransactioRepository => throw new NotImplementedException();

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
