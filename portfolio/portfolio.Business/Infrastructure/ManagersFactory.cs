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
        private readonly CoinManager coinManager;
        private readonly BuyTransactionManager buyTransactionManager;
        private readonly SellTransactionManager sellTransactionManager;
       


        public ManagersFactory(string connStringName)
        {
            //unitOfWork = new TestUnitOfWork();
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var connString = configuration
            .GetConnectionString(connStringName);
            unitOfWork = new EFUnitOfWork(connString);
        }

        public CoinManager GetCoinManager()
        {
            return coinManager
                ?? new CoinManager(unitOfWork);
        }

        public BuyTransactionManager GetBuyTransactionManager()
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
