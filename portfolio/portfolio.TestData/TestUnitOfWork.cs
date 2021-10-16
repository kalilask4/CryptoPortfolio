using portfolio.Domain.Entities;
using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.TestData
{
    public class TestUnitOfWork: IUnitOfWork

    {
        private IRepository<Coin_DEL> coinsRepository;
        private IRepository<BuyTransaction_DEL> buyTransactionsRepository;
        private IRepository<SellTransaction_DEL> sellTransactionsRepository;
        private List<Coin_DEL> coins;
        private List<BuyTransaction_DEL> buyTransactions;
        private List<SellTransaction_DEL> sellTransactions;

        public TestUnitOfWork()
        {
            coins = new List<Coin_DEL>();
            buyTransactions = new List<BuyTransaction_DEL>();
            sellTransactions = new List<SellTransaction_DEL>();
            
            buyTransactionsRepository = new BuyTransactionTestRepository(buyTransactions);
            foreach (var buyTransaction in buyTransactions)
            {
                coins.Add(buyTransaction.transactionCoins["credit"]);
                coins.Add(buyTransaction.transactionCoins["debet"]);
            }          
            sellTransactionsRepository = new SellTransactionTestRepository(sellTransactions);
            foreach (var sellTransaction in buyTransactions)
            {
                coins.Add(sellTransaction.transactionCoins["credit"]);
                coins.Add(sellTransaction.transactionCoins["debet"]);
            }
             
            coinsRepository = new CoinTestRepository(coins);
        }

        public IRepository<Coin_DEL> CoinRepository => coinsRepository;

        public IRepository<BuyTransaction_DEL> BuyTransactioRepository => buyTransactionsRepository;

        public IRepository<SellTransaction_DEL> SellTransactioRepository => sellTransactionsRepository;

        public void SaveChanges()
        {
        }
    }
}
