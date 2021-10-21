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
    public class EFUnitOfWork: IUnitOfWork
    {
        private readonly PortfolioContext context;
        private IRepository<Coin> coinRepository;
        private IRepository<Transaction> transactionRepository;

        
        public EFUnitOfWork(string connectionString)
        {
            var options = new DbContextOptionsBuilder<PortfolioContext>()
                .UseSqlServer(connectionString)
                .Options;
            context = new PortfolioContext(options);
            context.Database.EnsureCreated();
        }

        public IRepository<Coin> CoinRepository =>
            coinRepository ?? new EFCoinsRepository(context);

        public IRepository<Transaction> TransactioRepository =>
            transactionRepository ?? new EFTransactionsRepositoriy(context);


        public void SaveChanges()
        {
        
                context.SaveChanges();
          
           
     
        }
    }
}
