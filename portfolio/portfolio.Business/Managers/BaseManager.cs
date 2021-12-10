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
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRepository<Coin> _coinRepository;
        protected readonly IRepository<Transaction> _transactionRepository;

        public BaseManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _coinRepository = unitOfWork.CoinRepository;
            _transactionRepository = unitOfWork.TransactioRepository;
        }
    }
}


