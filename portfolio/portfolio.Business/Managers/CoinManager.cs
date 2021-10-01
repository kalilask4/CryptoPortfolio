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

        // <summary>
        /// general list of coins
        /// </summary>
        public IEnumerable<Coin> coins
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

        public Coin Create(string name, BuyTransaction buyTransaction)
        {
            Coin coin = new Coin("name2", buyTransaction);
            unitOfWork.SaveChanges();
            return coin;
        }


        public Coin GetById(int id) => coinRepository.Get(id);

        public bool Delete(int id)
        {
            var result = coinRepository.Delete(id);
            if (!result) return false;
            unitOfWork.SaveChanges();
            return true;
        }

        public IEnumerable<Coin>Find(Expression<Func<Coin, bool>> predicate) => 
            coinRepository.Find(predicate);

        /// <summary>
        /// Редактирование монеты
        /// </summary>
        /// <param name="coin">Обновленный объект монеты</param>
        public void Update(Coin coin)
        {
            coinRepository.Update(coin);
            unitOfWork.SaveChanges();
        }
        #endregion
        
        /// <summary>
        /// Добавление транзакции покупки к монете
        /// </summary>
        /// <param name="buyTransaction">Добавляемый объект</param>
        /// <param name="coinId">Id монеты</param>
        /// <returns></returns>
        public void AddBuyTransactionToCoin(BuyTransaction buyTransaction, int debetCoinId, int creditCoinId)
        {
            var debetCoin = coinRepository.Get(debetCoinId);
            var creditCoin = coinRepository.Get(creditCoinId);
            debetCoin.BuyTransactions.Add(buyTransaction);
            creditCoin.BuyTransactions.Add(buyTransaction);
            if (debetCoin.CoinId <= 0)
                coinRepository.Create(debetCoin);
            else coinRepository.Update(debetCoin);
            if (creditCoin.CoinId <= 0)
                coinRepository.Create(creditCoin);
            else coinRepository.Update(creditCoin);

            unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Удаление транзакции покупки к монете
        /// </summary>
        /// <param name="buyTransaction">Удаляемая транзакция</param>
        /// <param name="coinId">Id монеты</param>
        /// <returns></returns>
        public void RemoveBuyTransactionFromCoin(BuyTransaction buyTransaction, int coinId)
        {
            var coin = coinRepository.Get(coinId, "Buyings");
            coin.BuyTransactions.Remove(buyTransaction);
            coinRepository.Update(coin);
            unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Получение списка транзакций покупки
        /// </summary>
        /// <param name="coinId">Id монеты</param>
        /// <returns></returns>
        public ICollection<BuyTransaction> GetBuyTransactionsOfCoin(int coinId) => buyTransactionRepository
       .Find(b => b.transactionCoins["debet"].CoinId == coinId)
       .ToList();
    }
}


