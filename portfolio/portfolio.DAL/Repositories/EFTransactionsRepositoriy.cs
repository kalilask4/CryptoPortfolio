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
        private readonly PortfolioContext context;
        private readonly DbSet<Transaction> transactions;

        public EFTransactionsRepositoriy(PortfolioContext context)
        {
            this.context = context;
            transactions = context.Transactions;
        }

        public void Create(Transaction transaction)
        {
            context.AddAsync(transaction);
        }

        public bool Delete(int id)
        {
            var transaction = transactions.Find(id);
            if (transaction == null) 
                return false;
            if(transaction.TransactionCoins.Count > 0)
            {
                foreach (var coin in transaction.TransactionCoins)
                {
                    context.Coins
                    .Find(transaction.TransactionCoins[coin.CoinId])
                    .Transactions
                    .Remove(transaction);
                }
            }
            transactions.Remove(transaction);
            return true;
        }

        public IQueryable<Transaction> Find(Expression<Func<Transaction, bool>> predicate)
        {
            return transactions.Where(predicate);
        }

        public Transaction Get(int id, params string[] includes)
        {
            IQueryable<Transaction> query = transactions;
            
            foreach (var include in includes)
                query = query.Include(include);
            
            return query.First(t => t.TransactionId == id);
        }

        public IQueryable<Transaction> GetAll()
        {
            return transactions.AsQueryable();
        }

        public void Update(Transaction transaction)
        {
            transactions.Update(transaction);
        }
    }
}
