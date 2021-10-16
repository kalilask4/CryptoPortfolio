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
        public IEnumerable<Coin_DEL> coins
        {
            get => coinRepository.GetAll();
        }

        #region basic CRUD operations
        public Coin_DEL Create()
        {
            Coin_DEL coin = new Coin_DEL(); 
            unitOfWork.SaveChanges();
            return coin;
        }

        public Coin_DEL Create(string name, BuyTransaction_DEL buyTransaction)
        {
            Coin_DEL coin = new Coin_DEL("name2", buyTransaction);
            unitOfWork.SaveChanges();
            return coin;
        }

        public Coin_DEL GetById(int id) => coinRepository.Get(id);

        ///<summary>
        /// Add coins from list
        /// </summary>
        /// <param name = "coins"></param>
        public void AddRange(List<Coin_DEL> coin)
        {
            coin.ForEach(c => coinRepository.Create(c));
            unitOfWork.SaveChanges();
        }

        public bool Delete(int id)
        {
            var result = coinRepository.Delete(id);
            if (!result) return false;
            unitOfWork.SaveChanges();
            return true;
        }

        public IEnumerable<Coin_DEL>Find(Expression<Func<Coin_DEL, bool>> predicate) => 
            coinRepository.Find(predicate);

        /// <summary>
        /// Редактирование монеты
        /// </summary>
        /// <param name="coin">Обновленный объект монеты</param>
        public void Update(Coin_DEL coin)
        {
            coinRepository.Update(coin);
            unitOfWork.SaveChanges();
        }
        #endregion

        //simplified. could later be transformed as another hereditary transaction entity 
        public void Transfer(int coinId, decimal amount, bool isAddition)
        {
            var coin = coinRepository.Get(coinId);
            if (isAddition)
            {
                coin.Amount += amount;
            }
            else
            {
                coin.Amount -= amount;

            }
            coinRepository.Update(coin);
            unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Добавление транзакции покупки к монете
        /// </summary>
        /// <param name="buyTransaction">Добавляемый объект</param>
        /// <param name="coinId">Id монеты</param>
        /// <returns></returns>
        public void AddBuyTransactionToCoin(BuyTransaction_DEL buyTransaction, int debetCoinId, int creditCoinId)
        {

            var debetCoin = coinRepository.Get(debetCoinId);
            var creditCoin = coinRepository.Get(creditCoinId);
            debetCoin.BuyTransactions.Add(buyTransaction);
            creditCoin.BuyTransactions.Add(buyTransaction);  // !!!!сделать обратную привязку - sell transaction
            if (debetCoin.CoinId <= 0)
                coinRepository.Create(debetCoin);
            else coinRepository.Update(debetCoin);
            if (creditCoin.CoinId <= 0)
                coinRepository.Create(creditCoin);
            else coinRepository.Update(creditCoin);
            buyTransaction.CoinId = debetCoinId;

            unitOfWork.SaveChanges();
        }

        //internal void AddBuyTransactionToCoin(BuyTransaction_DEL buyTransaction, int coinId, bool v)
        //{
        //    throw new NotImplementedException();
        //}


        /// <summary>
        /// Удаление транзакции покупки к монете
        /// </summary>
        /// <param name="buyTransaction">Удаляемая транзакция</param>
        /// <param name="coinId">Id монеты</param>
        /// <returns></returns>
        public void RemoveBuyTransactionFromCoin(BuyTransaction_DEL buyTransaction, int coinId)
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
        public ICollection<BuyTransaction_DEL> GetBuyTransactionsOfCoin(int coinId) => buyTransactionRepository
       .Find(b => b.transactionCoins["debet"].CoinId == coinId)
       .ToList();
    }

}


