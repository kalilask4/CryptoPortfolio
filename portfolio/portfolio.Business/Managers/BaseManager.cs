using portfolio.Domain.Entities;
using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Business.Managers
{
    public class BaseManager
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IRepository<Coin> coinRepository;
        protected readonly IRepository<BuyTransaction> buyTransactionRepository;
        protected readonly IRepository<SellTransaction> sellTransactionRepository;

        public BaseManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            coinRepository = unitOfWork.CoinRepository;
            buyTransactionRepository = unitOfWork.BuyTransactioRepository;
            sellTransactionRepository = unitOfWork.SellTransactioRepository;
        }
    }
}


