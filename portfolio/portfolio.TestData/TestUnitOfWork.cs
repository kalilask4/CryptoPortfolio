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
        private IRepository<Coin> coinsRepository;
        private IRepository<BuyTransaction> buyTransactionsRepository;
        private IRepository<SellTransaction> sellTransactionsRepository;
        private List<Coin> coins;
        private List<BuyTransaction> buyTransactions;
        private List<SellTransaction> sellTransactions;

        public TestUnitOfWork()
        {
            coins = new List<Coin>();
            buyTransactions = new List<BuyTransaction>();
            sellTransactions = new List<SellTransaction>();
            
            buyTransactionsRepository = new BuyTransactionTestRepository(buyTransactions);
            foreach (var buyTransaction in buyTransactions)
            {
                coins.Add(buyTransaction.coins["credit"]);
                coins.Add(buyTransaction.coins["debet"]);
            }          
            sellTransactionsRepository = new SellTransactionTestRepository(sellTransactions);
            foreach (var sellTransaction in buyTransactions)
            {
                coins.Add(sellTransaction.coins["credit"]);
                coins.Add(sellTransaction.coins["debet"]);
            }
             
            coinsRepository = new CoinTestRepository(coins);
        }

        public IRepository<Coin> CoinRepository => coinsRepository;

        public IRepository<BuyTransaction> BuyTransactioRepository => buyTransactionsRepository;

        public IRepository<SellTransaction> SellTransactioRepository => sellTransactionsRepository;

        public void SaveChanges()
        {
        }
    }
}
