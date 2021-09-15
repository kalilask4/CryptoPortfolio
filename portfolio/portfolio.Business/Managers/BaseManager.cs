using portfolio.Domain.Entities;
using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Business.Managers
{
    class BaseManager
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


protected readonly IUnitOfWork unitOfWork;
protected readonly IRepository<Student> studentRepository;
protected readonly IRepository<Group> groupRepository;
public BaseManager(IUnitOfWork unitOfWork)
{
    this.unitOfWork = unitOfWork;
    studentRepository = unitOfWork.StudentsRepository;
    groupRepository = unitOfWork.GroupsRepository;
}