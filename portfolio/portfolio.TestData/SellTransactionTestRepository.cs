using portfolio.Domain.Entities;
using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.TestData
{
    /// <summary>
    /// Test repository for Buying
    /// Get, GetAll implementations are sufficient
    /// </summary>
    class SellTransactionTestRepository : IRepository<SellTransaction>
    {
        private readonly List<SellTransaction> sellTransactions;

        public SellTransactionTestRepository(List<SellTransaction> sellTransactions)
        {
            this.sellTransactions = sellTransactions;
            SetupData(); //generate test data
        }

        private void SetupData()
        {
            Random r = new Random();
            var coins = new List<Coin>();
            for (var i = 0; i < 10; i++)
            {
                coins.Add(new Coin
                {
                    CoinName = $"Coin {i}"
                });
            }

            for (var i = 1; i <= 5; i++)
            {
                var sellTransaction = new SellTransaction
                {
                    DebetCoin = coins[r.Next(0, 10)],
                    CreditCoin = coins[r.Next(0, 10)],
                    Amount = r.Next(1, 500),
                    Prise = r.Next(1, 100000),
                    TradeDate = DateTime.Now + TimeSpan.FromDays(r.Next(10, 20)),
                    TransactionId = i,
                };
                sellTransactions.Add(sellTransaction);
            }
        }

        public void Create(SellTransaction entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SellTransaction> Find(Expression<Func<SellTransaction, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public SellTransaction Get(int id, params string[] includes)
        {
            return sellTransactions.FirstOrDefault(b => b.TransactionId == id);

        }

        public IQueryable<SellTransaction> GetAll()
        {
            return sellTransactions.AsQueryable();
        }

        public void Update(SellTransaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
