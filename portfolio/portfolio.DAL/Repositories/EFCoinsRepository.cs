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
    public class EFCoinsRepository : IRepository<Coin_DEL>
    {
        private readonly PortfolioContext context;
        private readonly DbSet<Coin_DEL> coins;

        public EFCoinsRepository(PortfolioContext context)
        {
            coins = context.Coins;
        }

        public void Create(Coin_DEL coin)
        {
            context.Add(coin);
        }

        public bool Delete(int id)
        {
            var coin = coins.Find(id);
            if (coin == null) return false;
            coins.Remove(coin);
            return true;
        }

        public IQueryable<Coin_DEL> Find(Expression<Func<Coin_DEL, bool>> predicate)
        {
            return coins.Where(predicate);
        }

        public Coin_DEL Get(int id, params string[] includes)
        {
            IQueryable<Coin_DEL> query = coins;

            foreach (var include in includes)
                query = query.Include(include);

            return query.First(c => c.CoinId == id);
        }

        public IQueryable<Coin_DEL> GetAll()
        {
            return coins.AsQueryable();
        }

        public void Update(Coin_DEL coin)
        {
            coins.Update(coin);
        }
    }
}
