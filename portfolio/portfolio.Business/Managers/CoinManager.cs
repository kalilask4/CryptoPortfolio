using portfolio.Domain.Entities;
using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
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

        #region bacic CRUD operations
        public bool Delete(int id)
        {
            var result = coinRepository.Delete(id);
            if (!result) return false;
            unitOfWork.SaveChanges();
            return true;
        }

        public IEnumerable<Coin> FindCoin(Expression<Func<Coin, bool>> predicate) 
            => coinRepository.Find(predicate);

        public Coin GetCoinById(int id) => coinRepository.Get(id);

        public IEnumerable<Coin> GetALLCoins() => coinRepository.GetAll();

        public void UpdateCoin(Coin coin)
        {
            coinRepository.Update(coin);
            unitOfWork.SaveChanges();
        }
        #endregion

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

        public void DeleteTransactionFromCoin(Transaction transaction, int coinId)
        {
            var coin = coinRepository.Get(coinId);
            coin.Transactions.Remove(transaction);
            coinRepository.Update(coin);
            unitOfWork.SaveChanges();
        }

        public ICollection<Transaction> GetTransactionsOfCoin(int coinId)
            => transactionRepository
            .Find(transaction => transaction.TransactionCoins.Contains(GetCoinById(coinId)))
            .ToList();

        public void AddRange(List<Coin> coins)
        {
            coins.ForEach(coin => coinRepository.Create(coin));
            unitOfWork.SaveChanges();
        }
    }
}
