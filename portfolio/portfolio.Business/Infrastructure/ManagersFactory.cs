using Microsoft.Extensions.Configuration;
using portfolio.Business.Managers;
using portfolio.DAL.Repositories;
using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using portfolio.TestData;

namespace portfolio.Business.Infrastructure
{   
    public class ManagersFactory
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CoinManager coinManager;
        private readonly TransactionManager transactionManager;
        private readonly IConfiguration configuration;

        public ManagersFactory()
        {
            unitOfWork = new TestUnitOfWork();
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

        public CoinManager GetCoinManager()
        {
            return coinManager
                ?? new CoinManager(unitOfWork);
        }

        public TransactionManager GetTransactionManager()
        {
            return transactionManager
                ?? new TransactionManager(unitOfWork);
        }
    }
}