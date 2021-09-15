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
                coins.Add(buyTransaction.CreditCoin);
                coins.Add(buyTransaction.DebetCoin);
            }          
            sellTransactionsRepository = new SellTransactionTestRepository(sellTransactions);
            foreach (var sellTransaction in buyTransactions)
            {
                coins.Add(sellTransaction.CreditCoin);
                coins.Add(sellTransaction.DebetCoin);
            }
             
            coinsRepository = new CoinTestRepository(coins);
        }

        public IRepository<Coin> CoinRepository => coinsRepository;

        public IRepository<BuyTransaction> BuyingRepository => buyTransactionsRepository;

        public IRepository<SellTransaction> SellingRepository => sellTransactionsRepository;

        public void SaveChanges()
        {
        }
    }
}
