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
        private readonly PortfolioContext _context;
        private IRepository<Coin> _coinRepository;
        private IRepository<Transaction> _transactionRepository;

        
        public EFUnitOfWork(string connectionString)
        {
            var options = new DbContextOptionsBuilder<PortfolioContext>()
                .UseSqlServer(connectionString)
                .Options;
            _context = new PortfolioContext(options);
            _context.Database.EnsureCreated();
        }

        public IRepository<Coin> CoinRepository =>
            _coinRepository ?? new EFCoinsRepository(_context);

        public IRepository<Transaction> TransactioRepository =>
            _transactionRepository ?? new EFTransactionsRepositoriy(_context);


        public void SaveChanges()
        {
                _context.SaveChanges();
        }
    }
}
