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
    public class TransactionTestRepository : IRepository<Transaction>
    {
        private readonly List<Transaction> transactions;

        public TransactionTestRepository(List<Transaction> transactions)
        {
            this.transactions = transactions;
            SetupData();
        }

        private void SetupData()
        {
            Random r = new Random();
            var coins = new List<Coin>();
            for (var i = 0; i < 5; i++)
            {
                coins.Add(new Coin
                {
                    Name = $"Coin{i}"
                });
            }

            for (var i = 1; i <= 5; i++)
            {
                var Transaction = new Transaction
                {
                    TransactionCoins = new List<Coin>
                    {
                        coins[r.Next()],
                        coins[r.Next()],
                    },
                    Amount = r.Next(1, 10),
                    Priсe = r.Next(1, 100000),
                    DateUpdate = DateTime.Now + TimeSpan.FromDays(r.Next(10, 20)),
                };

                transactions.Add(Transaction);
            }
        }

        public void Create(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Transaction> Find(Expression<Func<Transaction, bool>> predicate)
        {
            Func<Transaction, bool> filter = predicate.Compile();
            return transactions.Where(filter).AsQueryable();
        }

        public Transaction Get(int id, params string[] includes)
        {
            return transactions.FirstOrDefault(t => t.TransactionId == id);
        }

        public IQueryable<Transaction> GetAll()
        {
            return transactions.AsQueryable();
        }

        public void Update(Transaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
