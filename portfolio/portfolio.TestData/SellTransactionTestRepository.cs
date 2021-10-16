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
    class SellTransactionTestRepository : IRepository<SellTransaction_DEL>
    {
        private readonly List<SellTransaction_DEL> sellTransactions;

        public SellTransactionTestRepository(List<SellTransaction_DEL> sellTransactions)
        {
            this.sellTransactions = sellTransactions;
            SetupData(); //generate test data
        }

        private void SetupData()
        {
            Random r = new Random();
            var coins = new List<Coin_DEL>();
            for (var i = 0; i < 10; i++)
            {
                coins.Add(new Coin_DEL
                {
                    CoinName = $"Coin_DEL {i}"
                });
            }

            for (var i = 1; i <= 5; i++)
            {
                var sellTransaction = new SellTransaction_DEL
                {
                   transactionCoins = new Dictionary<string, Coin_DEL>
                   {
                       {"debet", coins[r.Next(0,10)]},
                       {"credit", coins[r.Next(0,10)]}
                   },
                    Amount = r.Next(1, 500),
                    Priсe = r.Next(1, 100000),
                    AddDate = DateTime.Now + TimeSpan.FromDays(r.Next(10, 20)),
                    TransactionId = i,
                };
                sellTransactions.Add(sellTransaction);
            }
        }

        public void Create(SellTransaction_DEL entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SellTransaction_DEL> Find(Expression<Func<SellTransaction_DEL, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public SellTransaction_DEL Get(int id, params string[] includes)
        {
            return sellTransactions.FirstOrDefault(b => b.TransactionId == id);

        }

        public IQueryable<SellTransaction_DEL> GetAll()
        {
            return sellTransactions.AsQueryable();
        }

        public void Update(SellTransaction_DEL entity)
        {
            throw new NotImplementedException();
        }
    }
}
