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
    public class CoinTestRepository : IRepository<Coin>
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

        public IQueryable<Coin> Find(Expression<Func<Coin, bool>> predicate)
        {
            throw new NotImplementedException();
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