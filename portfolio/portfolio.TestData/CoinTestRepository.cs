using portfolio.Domain.Entities;
using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void Update(Coin entity)
        {
            throw new NotImplementedException();
        }
    }
}
