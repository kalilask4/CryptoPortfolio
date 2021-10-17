using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using portfolio.Domain.Entities;


namespace portfolio.Business.Managers
{
    public class TransactionManager : BaseManager
    {
        public TransactionManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region bacic CRUD operations
        public Transaction CreateTransaction(Transaction transaction)
        {
            transactionRepository.Create(transaction);
            unitOfWork.SaveChanges();
            return transaction;
        }
        
        public Transaction GetById(int id)
            => transactionRepository.Get(id);
        
        public void UpdateTransaction(Transaction transaction)
        {
            transactionRepository.Update(transaction);
            unitOfWork.SaveChanges();
        }
        
        public bool DeleteTransaction(int id)
        {
            var result = transactionRepository.Delete(id);
            if (!result) return false;
            unitOfWork.SaveChanges();
            return true;
        }
        #endregion

        public void AddRange(List<Transaction> transactions)
        {
            transactions.ForEach(transaction => transactionRepository.Create(transaction));
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Transaction> transactions
        {
            get => transactionRepository.GetAll();
        }

        //only for test - transaction should not change like that after creation 
        public void AddCoinToTransaction(Coin coin, int transactionId)
        {
            var transaction = transactionRepository.Get(transactionId);
            coin.Transactions.Add(transaction);
            if (coin.CoinId <= 0)
                coinRepository.Create(coin);
            else coinRepository.Update(coin);
            unitOfWork.SaveChanges();
        }

        public void RemoveCoinFromTransaction(Coin coin, int transactionId)
        {
            var transaction = transactionRepository.Get(transactionId);
            transaction.TransactionCoins.Remove(coin);
            coin.Transactions.Remove(transaction);   //Check it!!
            transactionRepository.Update(transaction);
            coinRepository.Update(coin);
            unitOfWork.SaveChanges();
        }

        public ICollection<Coin> GetCoinsOfTransaction(int transactionId) =>
            coinRepository
            .Find(coin => coin.Transactions.Contains(GetById(transactionId)))
            .ToList();
       
    }
}
