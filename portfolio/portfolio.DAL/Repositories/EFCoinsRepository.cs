﻿using Microsoft.EntityFrameworkCore;
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
    class EFCoinsRepository : IRepository<Coin>
    {
        PortfolioContext context;
        private readonly DbSet<Coin> coins;

        public EFCoinsRepository(PortfolioContext context)
        {
            coins = context.Coins;
        }

        public void Create(Coin entity)
        {
            context.Add(entity);
        }

        public bool Delete(int id)
        {
            var coin = coins.Find(id);
            if (coin == null) return false;
            coins.Remove(coin);
            return true;
        }

        public IQueryable<Coin> Find(Expression<Func<Coin, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Coin Get(int id, params string[] includes)
        {
            IQueryable<Coin> query = coins;

            foreach (var include in includes)
                query = query.Include(include);

            return query.First(c => c.CoinId == id);
        }

        public IQueryable<Coin> GetAll()
        {
            return coins.AsQueryable();
        }

        public void Update(Coin entity)
        {
            coins.Update(entity);
        }
    }
}