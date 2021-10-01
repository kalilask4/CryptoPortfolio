using portfolio.Domain.Entities;
using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.TestData
{
    /// <summary>
    /// Test repository for Coin
    /// Find implementation is sufficient
    /// </summary>
    class CoinTestRepository : IRepository<Coin>
    {
        private readonly List<Coin> coins;
        public CoinTestRepository(List<Coin> coins)
        {
            this.coins = coins;
            SetupData();
        }

        private void SetupData()
        {
            Random r = new Random();
            var coins = new List<Coin>();
            BuyTransaction buyTransaction = new BuyTransaction(new Coin("coinfortrans1"), new Coin("coinfortrans2"), 10, 100);
            for (var i = 0; i < 10; i++)
            {
                var coin = new Coin($"Coin {i}", buyTransaction);
                coins.Add(coin);
                Trace.WriteLine($"Test setup coin in \"for\": {coin}"); 
            }
  
            Trace.WriteLine("Test setup coin " + coins[0].BuyTransactions[0].transactionCoins["debet"].ToString());
            Trace.WriteLine("Test setup coin " + coins[0].BuyTransactions[0].transactionCoins["credit"].ToString());
        }

        public void Create(Coin entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Coin> Find(System.Linq.Expressions.Expression<Func<Coin, bool>> predicate)
        {
            Func<Coin, bool> filter = predicate.Compile();
            return coins.Where(filter).AsQueryable();
        }

        public Coin Get(int id, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Coin> GetAll()
        {
            return coins.AsQueryable();
        }

        public void Update(Coin entity)
        {
            throw new NotImplementedException();
        }
    }
}
