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
    public class EFCoinsRepository : IRepository<Coin>
    {
        private readonly PortfolioContext _context;
        private readonly DbSet<Coin> _coins;

        public EFCoinsRepository(PortfolioContext context)
        {
            this._context = context;
            _coins = context.Coins;
        }

        public void Create(Coin entity)
        {
            _context.AddAsync(entity);
        }

        public bool Delete(int id)
        {
            var coin = _coins.Find(id);
            if (coin == null) return false;
            
            _coins.Remove(coin);
            return true;
        }

        public IQueryable<Coin> Find(Expression<Func<Coin, bool>> predicate)
        {
            return _coins.Where(predicate);
        }

        public Coin Get(int id, params string[] includes)
        {
            IQueryable<Coin> query = _coins;

            foreach (var include in includes)
                query = query.Include(include);

            try
            {
                return query.First(c => c.CoinId == id);
            }
            catch
            {
                return new Coin();
            }
            
        }

        public IQueryable<Coin> GetAll()
        {
            return _coins.AsQueryable();
        }

        public void Update(Coin coin)
        {
            _coins.Update(coin);
        }
    }
}
