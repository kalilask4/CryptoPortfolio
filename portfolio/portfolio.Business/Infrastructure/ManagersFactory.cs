using Microsoft.Extensions.Configuration;
using portfolio.Business.Managers;
using portfolio.Domain.Interfaces;
using portfolio.DAL.Repositories;
using portfolio.TestData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Business.Infrastructure
{
    public class ManagersFactory
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly CoinManager_DEL coinManager;
        private readonly BuyTransactionManager_DEL buyTransactionManager;
        private readonly SellTransactionManager_DEL sellTransactionManager;
        private readonly IConfiguration configuration;

        public ManagersFactory()
        {
            unitOfWork = new TestUnitOfWork_DEL();
        }

            public ManagersFactory(string connStringName)
        {
            configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var connString = configuration
                .GetConnectionString(connStringName);
            unitOfWork = new EFUnitOfWork(connString);
        }

        public CoinManager_DEL GetCoinManager()
        {
            return coinManager
                ?? new CoinManager_DEL(unitOfWork);
        }

        public BuyTransactionManager_DEL GetBuyTransactionManager()
        {
            return buyTransactionManager
                ?? new BuyTransactionManager_DEL(unitOfWork);
        }

        public SellTransactionManager_DEL GetSellTransactionManager()
        {
            return sellTransactionManager
                ?? new SellTransactionManager_DEL(unitOfWork);
        }
    }
}
