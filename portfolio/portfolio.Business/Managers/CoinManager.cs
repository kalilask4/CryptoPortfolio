using portfolio.Domain.Entities;
using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace portfolio.Business.Managers
{
    public class CoinManager : BaseManager
    {
        public CoinManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Coin> Coins
        {
            get => _coinRepository.GetAll();
        }

        #region basic CRUD operations
        public Coin Create()
        {
            Coin coin = new Coin();
            _unitOfWork.SaveChanges();
            return coin;
        }
        
        public bool Delete(int id)
        {
            var result = _coinRepository.Delete(id);
            if (!result) return false;
            _unitOfWork.SaveChanges();
            return true;
        }

        public Coin GetById(int id) => _coinRepository?.Get(id);

        public void Update(Coin coin)
        {
            _coinRepository.Update(coin);
            _unitOfWork.SaveChanges();
        }
        #endregion

        public void AddRange(List<Coin> coin)
        {
            coin.ForEach(c => _coinRepository.Create(c));
            _unitOfWork.SaveChanges();
        }
        
        public IEnumerable<Coin> Find(Expression<Func<Coin, bool>> predicate) =>
            _coinRepository.Find(predicate);


        public void AddTransactionToCoin(Transaction transaction, int debetCoinId, int creditCoinId)
        {
            var debetCoin = _coinRepository.Get(debetCoinId);
            var creditCoin = _coinRepository.Get(creditCoinId);
            debetCoin.Transactions.Add(transaction);
            creditCoin.Transactions.Add(transaction);
            if (debetCoin.CoinId <= 0)
                _coinRepository.Create(debetCoin);
            else _coinRepository.Update(debetCoin);
            if (creditCoin.CoinId <= 0)
                _coinRepository.Create(creditCoin);
            else _coinRepository.Update(creditCoin);
            transaction.TransactionCoins.Add(debetCoin);
            transaction.TransactionCoins.Add(creditCoin);
            _unitOfWork.SaveChanges();
        }

        public void AddTransactionToCoin(Transaction transaction, int debetCoinId)
        {
            var debetCoin = _coinRepository.Get(debetCoinId);
            debetCoin.Transactions.Add(transaction);
            if (debetCoin.CoinId <= 0)
                _coinRepository.Create(debetCoin);
            else _coinRepository.Update(debetCoin);
            transaction.TransactionCoins.Add(debetCoin);
            _unitOfWork.SaveChanges();
        }
   
        public void RemoveTransactionFromCoin(Transaction transaction, int coinId)
        {
            var coin = _coinRepository.Get(coinId);
            coin.Transactions.Remove(transaction);
            _coinRepository.Update(coin);
            transaction.TransactionCoins.Remove(coin);
            _transactionRepository.Update(transaction);
            _unitOfWork.SaveChanges();
        }       

        public Coin Recount(int coinId)
        {
            var newCoin = _coinRepository.Get(coinId);
            newCoin.AverageValue = newCoin.Amount * newCoin.AveragePrice;
            newCoin.CurrentValue = newCoin.Amount * newCoin.CurrentPrice;
            newCoin.ProfitUSD = newCoin.Amount * newCoin.CurrentPrice - newCoin.Amount * newCoin.AveragePrice;
            newCoin.ProfitPerс = newCoin.ProfitUSD / newCoin.AverageValue * 10;

                return newCoin;
        }
        
        public ICollection<Transaction> GetTransactionsOfCoin(int coinId) => _transactionRepository
            .Find(transaction => transaction.TransactionCoins.Contains(GetById(coinId)))
            .ToList();
    }
}
