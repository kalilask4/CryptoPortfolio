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
    /// Test repository for Coin_DEL
    /// Find implementation is sufficient
    /// </summary>
    class CoinTestRepository_DEL : IRepository<Coin_DEL>
    {
        private readonly List<Coin_DEL> coins;
        public CoinTestRepository_DEL(List<Coin_DEL> coins)
        {
            this.coins = coins;
            SetupData();
        }

        private void SetupData()
        {
            Random r = new Random();
            var coins = new List<Coin_DEL>();
            BuyTransaction_DEL buyTransaction = new BuyTransaction_DEL(new Coin_DEL("coinfortrans1"), new Coin_DEL("coinfortrans2"), 10, 100);
            for (var i = 0; i < 10; i++)
            {
                var coin = new Coin_DEL($"Coin_DEL {i}", buyTransaction);
                coins.Add(coin);
                Trace.WriteLine($"Test setup coin in \"for\": {coin}"); 
            }
  
            Trace.WriteLine("Test setup coin " + coins[0].BuyTransactions[0].transactionCoins["debet"].ToString());
            Trace.WriteLine("Test setup coin " + coins[0].BuyTransactions[0].transactionCoins["credit"].ToString());
        }

        public void Create(Coin_DEL entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Coin_DEL> Find(System.Linq.Expressions.Expression<Func<Coin_DEL, bool>> predicate)
        {
            Func<Coin_DEL, bool> filter = predicate.Compile();
            return coins.Where(filter).AsQueryable();
        }

        public Coin_DEL Get(int id, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Coin_DEL> GetAll()
        {
            return coins.AsQueryable();
        }

        public void Update(Coin_DEL entity)
        {
            throw new NotImplementedException();
        }
    }
}
