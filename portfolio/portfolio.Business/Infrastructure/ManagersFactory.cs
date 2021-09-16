using portfolio.Business.Managers;
using portfolio.Domain.Interfaces;
using portfolio.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Business.Infrastructure
{
    public class ManagersFactory
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CoinManager coinManager;
        private readonly BuyTransactionManager buyTransactionManager;
        private readonly SellTransactionManager sellTransactionManager;

        public ManagersFactory()
        {
            unitOfWork = new TestUnitOfWork();
        }

        public CoinManager GetCoinManager()
        {
            return coinManager
                ?? new CoinManager(unitOfWork);
        }

        public BuyTransactionManager GetTransactionManager()
        {
            return buyTransactionManager
                ?? new BuyTransactionManager(unitOfWork);
        }

        public SellTransactionManager GetSellTransactionManager()
        {
            return sellTransactionManager
                ?? new SellTransactionManager(unitOfWork);
        }
    }
}
