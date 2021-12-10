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
        private readonly IUnitOfWork _unitOfWork;
        private readonly CoinManager _coinManager;
        private readonly TransactionManager _transactionManager;
        private readonly IConfiguration _configuration;

        public ManagersFactory()
        {
            _unitOfWork = new TestUnitOfWork();
        }

        public ManagersFactory(string connStringName)
        {
            _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var connString = _configuration
                .GetConnectionString(connStringName);
            _unitOfWork = new EFUnitOfWork(connString);
        }

        public CoinManager GetCoinManager()
        {
            return _coinManager
                ?? new CoinManager(_unitOfWork);
        }

        public TransactionManager GetTransactionManager()
        {
            return _transactionManager
                ?? new TransactionManager(_unitOfWork);
        }
    }
}