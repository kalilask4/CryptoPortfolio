using portfolio.Domain.Entities;
using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.TestData
{
    class TestUnitOfWork : IUnitOfWork
    {
        public IRepository<Coin> coinRepository;
        public IRepository<Transaction> transactioRepository;
        private List<Coin> coins;
        private List<Transaction> transactions;

        public TestUnitOfWork()
        {
            coins = new List<Coin>();
            transactions = new List<Transaction>();
            transactioRepository = new TransactionTestRepository(transactions);
            foreach (var transaction in transactions)
                coins.AddRange(transaction.TransactionCoins);
            coinRepository = new CoinTestRepository(coins);
        }

        public IRepository<Coin> CoinRepository => throw new NotImplementedException();

        public IRepository<Transaction> TransactioRepository => throw new NotImplementedException();

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}