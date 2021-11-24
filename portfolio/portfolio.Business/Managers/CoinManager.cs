using portfolio.Domain.Entities;
using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
        
        //сделать отдельные функции для расчета каждого значения
        public Coin calculateValues(int coinId)
        {
            var coin = coinRepository.Get(coinId);
            //var newCoin = coin;
            //coin.Name = "!clone"; объект передается по ссылке, не по значению - реализовать ICloneable
            Coin newCoin;
                newCoin = (Coin)coin.Clone();
            newCoin.CurrentValue = coin.Amount * coin.CurrentPrice;
            newCoin.AverageValue = coin.Amount * coin.AveragePrice;
            newCoin.ProfitUSD = coin.CurrentValue - coin.AverageValue;
            newCoin.ProfitUSD = (coin.CurrentValue - coin.AverageValue) / coin.Amount;
            
            // coin.Transactions.Remove(transaction);
             coinRepository.Update(newCoin);
            // transaction.TransactionCoins.Remove(coin);
            // transactionRepository.Update(transaction);
            unitOfWork.SaveChanges();
            return newCoin;
        }


        //Have to add:
        //check ValueCurrent
        //check ValueByBought
        public Coin countProfit(int coinId)
        {
            var newCoin = coinRepository.Get(coinId);
            newCoin.ProfitUSD = newCoin.Amount * newCoin.CurrentPrice - newCoin.Amount * newCoin.AveragePrice;
            newCoin.ProfitPerс = newCoin.ProfitUSD/newCoin.AverageValue * 10;
            return newCoin;
        }
        
        

        
        public ICollection<Transaction> GetTransactionsOfCoin(int coinId) => transactionRepository
            .Find(transaction => transaction.TransactionCoins.Contains(GetById(coinId)))
            .ToList();
    }
}
