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
            get => coinRepository.GetAll();
        }

        #region basic CRUD operations
        public Coin Create()
        {
            Coin coin = new Coin();
            unitOfWork.SaveChanges();
            return coin;
        }
        
        public bool Delete(int id)
        {
            var result = coinRepository.Delete(id);
            if (!result) return false;
            unitOfWork.SaveChanges();
            return true;
        }

        public Coin GetById(int id) => coinRepository?.Get(id);

        public void Update(Coin coin)
        {
            coinRepository.Update(coin);
            unitOfWork.SaveChanges();
        }
        #endregion

        public void AddRange(List<Coin> coin)
        {
            coin.ForEach(c => coinRepository.Create(c));
            unitOfWork.SaveChanges();
        }
        
        public IEnumerable<Coin> Find(Expression<Func<Coin, bool>> predicate) =>
            coinRepository.Find(predicate);


        public void AddTransactionToCoin(Transaction transaction, int debetCoinId, int creditCoinId)
        {
            var debetCoin = coinRepository.Get(debetCoinId);
            var creditCoin = coinRepository.Get(creditCoinId);
            debetCoin.Transactions.Add(transaction);
            creditCoin.Transactions.Add(transaction);
            if (debetCoin.CoinId <= 0)
                coinRepository.Create(debetCoin);
            else coinRepository.Update(debetCoin);
            if (creditCoin.CoinId <= 0)
                coinRepository.Create(creditCoin);
            else coinRepository.Update(creditCoin);
            transaction.TransactionCoins.Add(debetCoin);
            transaction.TransactionCoins.Add(creditCoin);
            unitOfWork.SaveChanges();
        }

        public void AddTransactionToCoin(Transaction transaction, int debetCoinId)
        {
            var debetCoin = coinRepository.Get(debetCoinId);
            debetCoin.Transactions.Add(transaction);
            if (debetCoin.CoinId <= 0)
                coinRepository.Create(debetCoin);
            else coinRepository.Update(debetCoin);
            transaction.TransactionCoins.Add(debetCoin);
            unitOfWork.SaveChanges();
        }
   
        public void RemoveTransactionFromCoin(Transaction transaction, int coinId)
        {
            var coin = coinRepository.Get(coinId);
            coin.Transactions.Remove(transaction);
            coinRepository.Update(coin);
            transaction.TransactionCoins.Remove(coin);
            transactionRepository.Update(transaction);
            unitOfWork.SaveChanges();
        }       

        //Recount only one coin. Recount all - have to add 
        public Coin Recount(int coinId)
        {
            var newCoin = coinRepository.Get(coinId);
            newCoin.AverageValue = newCoin.Amount * newCoin.AveragePrice;
            newCoin.CurrentValue = newCoin.Amount * newCoin.CurrentPrice;
            newCoin.ProfitUSD = newCoin.Amount * newCoin.CurrentPrice - newCoin.Amount * newCoin.AveragePrice;
            newCoin.ProfitPerс = newCoin.ProfitUSD / newCoin.AverageValue * 10;

                return newCoin;
        }
        
        
        public int FullRecount()
        {
            int startPrice, currentPrice, profit;
            startPrice = 0;
           //var result[] = [0,0,0];
            
            // var newCoin = coinRepository.Get(coinId);
            // newCoin.AverageValue = newCoin.Amount * newCoin.AveragePrice;
            // newCoin.CurrentValue = newCoin.Amount * newCoin.CurrentPrice;
            // newCoin.ProfitUSD = newCoin.Amount * newCoin.CurrentPrice - newCoin.Amount * newCoin.AveragePrice;
            // newCoin.ProfitPerс = newCoin.ProfitUSD / newCoin.AverageValue * 10;
        
            return startPrice;
        }
        
        public ICollection<Transaction> GetTransactionsOfCoin(int coinId) => transactionRepository
            .Find(transaction => transaction.TransactionCoins.Contains(GetById(coinId)))
            .ToList();
    }
}
