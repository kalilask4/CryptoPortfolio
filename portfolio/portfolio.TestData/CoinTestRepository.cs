using portfolio.Domain.Entities;
using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.TestData
{
    /// <summary>
    /// Test repository for Coin_DEL
    /// Find implementation is sufficient
    /// </summary>
    public class CoinTestRepository : IRepository<Coin>
    {
        private readonly List<Coin> coins;

        public CoinTestRepository(List<Coin> coins)
        {
            this.coins = coins;
            SetupData(); //generate test data
        }

        private static void SetupData()
        {
            Random r = new Random();
            var coins = new List<Coin>();
            Transaction transaction = new Transaction();

            for (var i = 0; i < 5; i++)
            {
                var coin = new Coin($"C{i}", transaction);
                coins.Add(coin);
                //Trace.WriteLine($"Test setup coin in \"for\": {coin}");
            }
            //Trace.WriteLine("Test setup coin " + coins[0].Transactions[0].ToString());
            //Trace.WriteLine("Test setup coin " + coins[0].Transactions[0].ToString());
        }

        public void Create(Coin entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Coin> Find(Expression<Func<Coin, bool>> predicate)
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