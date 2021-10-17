using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using portfolio.Domain.Entities;


namespace portfolio.Business.Managers
{
    class TransactionManager : BaseManager
    {
        public TransactionManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Transaction> transactions
        {
            get => transactionRepository.GetAll();
        }

        public Transaction GetById(int id)
            => transactionRepository.Get(id);

        public Transaction CreateTransaction(Transaction transaction)
        {
            transactionRepository.Create(transaction);
            unitOfWork.SaveChanges();
            return transaction;
        }

        public void AddRange(List<Transaction> transactions)
        {
            transactions.ForEach(transaction => transactionRepository.Create(transaction));
            unitOfWork.SaveChanges();
        }

        public bool DeleteTransaction(int id)
        {
            var resulr = transactionRepository.Delete(id);
            if (!resulr) return false;
            unitOfWork.SaveChanges();
            return true;
        }

        public void UpdateTransaction(Transaction transaction)
        {
            transactionRepository.Update(transaction);
            unitOfWork.SaveChanges();
        }

       
    }
}
