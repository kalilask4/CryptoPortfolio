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
    class BuyingTestRepository : IRepository<Buying>
    {
        private readonly List<Buying> buyings;
        public BuyingTestRepository(List<Buying> buyings)
        {
            this.buyings = buyings;
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
                var buying = new Buying
                {
                    DebetCoin = coins[r.Next(0, 10)],
                    CreditCoin = coins[r.Next(0, 10)],
                    Amount = r.Next(1, 500),
                    Prise = r.Next(1, 100000),
                    TradeDate = DateTime.Now + TimeSpan.FromDays(r.Next(10, 20)),
                    TransactionId = i,
                };
                buyings.Add(buying);
            }
        }

        public void Create(Buying entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Buying> Find(Expression<Func<Buying, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Buying Get(int id, params string[] includes)
        {
            return buyings.FirstOrDefault(b => b.TransactionId == id);
        }

        public IQueryable<Buying> GetAll()
        {
            return buyings.AsQueryable();
        }

        public void Update(Buying entity)
        {
            throw new NotImplementedException();
        }
    }
}
