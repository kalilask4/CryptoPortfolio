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
    class EFBuyTransactionRepositories : IRepository<BuyTransaction>
    {
        private readonly PortfolioContext context;
        private readonly DbSet<BuyTransaction> buyTransactions;

        public EFBuyTransactionRepositories(PortfolioContext context)
        {
            buyTransactions = context.BuyTransactions;
        }

        public void Create(BuyTransaction buyTransaction)
        {
            context.AddAsync(buyTransaction);
        }

        public bool Delete(int id)
        {
            var buyTransaction = buyTransactions.Find(id);
            if (buyTransaction == null) return false;
            if(buyTransaction.CoinId > 0)
            {
                context.Coins
                    .Find(buyTransaction.CoinId)
                    .BuyTransactions
                    .Remove(buyTransaction);
            }
            buyTransactions.Remove(buyTransaction);
            return true;
        }

        public IQueryable<BuyTransaction> Find(Expression<Func<BuyTransaction, bool>> predicate)
        {
            return buyTransactions.Where(predicate);
        }

        public BuyTransaction Get(int id, params string[] includes)
        {
            IQueryable<BuyTransaction> query = buyTransactions;

            foreach (var include in includes)
                query = query.Include(include);
            return query.First(b => b.TransactionId == id);
        }

        public IQueryable<BuyTransaction> GetAll()
        {
            return buyTransactions.AsQueryable();
        }

        public void Update(BuyTransaction buyTransaction)
        {
            buyTransactions.Update(buyTransaction);
        }
    }
}
