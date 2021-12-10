using Microsoft.EntityFrameworkCore;
using portfolio.DAL.Data;
using portfolio.Domain.Entities;
using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.DAL.Repositories
{
    public class EFTransactionsRepositoriy : IRepository<Transaction>
    {
        private readonly PortfolioContext _context;
        private readonly DbSet<Transaction> _transactions;

        public EFTransactionsRepositoriy(PortfolioContext context)
        {
            this._context = context;
            _transactions = context.Transactions;
        }

        public void Create(Transaction entity)
        {
            _context.AddAsync(entity);
        }

        public bool Delete(int id)
        {
            var transaction = _transactions.Find(id);
            if (transaction == null) 
                return false;
            if(transaction.TransactionCoins.Count > 0)
            {
                foreach (var coin in transaction.TransactionCoins)
                {
                    _context.Coins
                    .Find(transaction.TransactionCoins[coin.CoinId])
                    .Transactions
                    .Remove(transaction);
                }
            }
            _transactions.Remove(transaction);
            return true;
        }

        public IQueryable<Transaction> Find(Expression<Func<Transaction, bool>> predicate)
        {
            return _transactions.Where(predicate);
        }

        public Transaction Get(int id, params string[] includes)
        {
            IQueryable<Transaction> query = _transactions;
            
            foreach (var include in includes)
                query = query.Include(include);
            try
            {
                return query.First(t => t.TransactionId == id);
            }
            catch
            {
                return new Transaction();
            }
            
        }

        public IQueryable<Transaction> GetAll()
        {
            return _transactions.AsQueryable();
        }

        public void Update(Transaction transaction)
        {
            _transactions.Update(transaction);
        }
    }
}
