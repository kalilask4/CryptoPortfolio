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
    class BuyTransactionTestRepository_DEL : IRepository<BuyTransaction_DEL>
    {
        private readonly List<BuyTransaction_DEL> buyTransactions;
        public BuyTransactionTestRepository_DEL(List<BuyTransaction_DEL> buyTransactions)
        {
            this.buyTransactions = buyTransactions;
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
                var buyTransaction = new BuyTransaction_DEL
                {
                    transactionCoins = new Dictionary<string, Coin_DEL>
                    {
                        {"debet", coins[r.Next(0, 10)]},
                        {"credit", coins[r.Next(0, 10)] }
                    },
                    Amount = r.Next(1, 500),
                    Priсe = r.Next(1, 100000),
                    AddDate = DateTime.Now + TimeSpan.FromDays(r.Next(10, 20)),
                    TransactionId = i,
                };
                buyTransactions.Add(buyTransaction);
            }
        }

        public void Create(BuyTransaction_DEL entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<BuyTransaction_DEL> Find(Expression<Func<BuyTransaction_DEL, bool>> predicate)
        {
            Func<BuyTransaction_DEL, bool> filter = predicate.Compile();
            return buyTransactions.Where(filter).AsQueryable();
        }

        public BuyTransaction_DEL Get(int id, params string[] includes)
        {
            return buyTransactions.FirstOrDefault(b => b.TransactionId == id);
        }

        public IQueryable<BuyTransaction_DEL> GetAll()
        {
            return buyTransactions.AsQueryable();
        }

        public void Update(BuyTransaction_DEL entity)
        {
            throw new NotImplementedException();
        }
    }
}
