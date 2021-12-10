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

        public IEnumerable<Transaction> Transactions
        {
            get => _transactionRepository.GetAll();
        }

        #region bacic CRUD operations
        public Transaction CreateTransaction(Transaction transaction)
        {
            _transactionRepository.Create(transaction);
            _unitOfWork.SaveChanges();
            return transaction;
        }
        
        public Transaction GetById(int id)
            => _transactionRepository.Get(id);
        
        public void UpdateTransaction(Transaction transaction)
        {
            _transactionRepository.Update(transaction);
            _unitOfWork.SaveChanges();
        }
        
        public bool Delete(int id)
        {
            var result = _transactionRepository.Delete(id);
            if (!result) return false;
            _unitOfWork.SaveChanges();
            return true;
        }
        #endregion

        public void AddRange(List<Transaction> transactions)
        {
            transactions.ForEach(transaction => _transactionRepository.Create(transaction));
            _unitOfWork.SaveChanges();
        }

        //only for test - transaction should not change like that after creation 
        public void AddCoinToTransaction(Coin coin, int transactionId)
        {
            var transaction = _transactionRepository.Get(transactionId);
            coin.Transactions.Add(transaction);
            if (coin.CoinId <= 0)
                _coinRepository.Create(coin);
            else _coinRepository.Update(coin);
            _unitOfWork.SaveChanges();
        }

        public void AddCoinToTransaction(Coin coin)
        {
            var transaction = new Transaction(coin);
            coin.Transactions.Add(transaction);
            if (coin.CoinId <= 0)
                _coinRepository.Create(coin);
            else _coinRepository.Update(coin);
            _unitOfWork.SaveChanges();
        }

        public void RemoveCoinFromTransaction(Coin coin, int transactionId)
        {
            var transaction = _transactionRepository.Get(transactionId);
            transaction.TransactionCoins.Remove(coin);
            coin.Transactions.Remove(transaction);   
            _transactionRepository.Update(transaction);
            _coinRepository.Update(coin);
            _unitOfWork.SaveChanges();
        }

        public ICollection<Coin> GetCoinsOfTransaction(int transactionId) =>
            _coinRepository
            .Find(coin => coin.Transactions.Contains(GetById(transactionId)))
            .ToList();
       
    }
}
