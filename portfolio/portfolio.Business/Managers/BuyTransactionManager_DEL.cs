using portfolio.Domain.Entities;
using portfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Business.Managers
{
    public class BuyTransactionManager_DEL : BaseManager
    {
        public BuyTransactionManager_DEL(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// general list of buy transactions
        /// </summary>
        public IEnumerable<BuyTransaction_DEL> buyTransactions
        {
            get => buyTransactionRepository.GetAll();
        }

        public BuyTransaction_DEL GetById(int id) => buyTransactionRepository.Get(id);

        public BuyTransaction_DEL CreateBuyTransaction(BuyTransaction_DEL buyTransaction)
        {
            buyTransactionRepository.Create(buyTransaction);
            Coin_DEL coinDebet = buyTransaction.transactionCoins["debet"];
            decimal newAmountDebetCoin = coinDebet.Amount + buyTransaction.Amount;
            coinDebet.Amount = newAmountDebetCoin;
            Coin_DEL coinCredit = buyTransaction.transactionCoins["credit"];
            decimal newAmountCreditCoin = coinCredit.Amount - buyTransaction.Amount * buyTransaction.Priсe;
            coinCredit.Amount = newAmountCreditCoin;
            coinRepository.Update(coinDebet);
            coinRepository.Update(coinCredit);
            unitOfWork.SaveChanges();
            return buyTransaction;
        }

        ///<summary>
        /// Add buy transactions from list
        /// </summary>
        /// <param name = "buyTransactions"></param>
        public void AddRange(List<BuyTransaction_DEL> buyTransactions)
        {
            buyTransactions.ForEach(b => buyTransactionRepository.Create(b));
            unitOfWork.SaveChanges();
        }

        ///<summary>
        /// Delete buy transactions by id
        /// </summary>
        /// <param name = "id">id buy transactions to delete</param>
        /// <returns></returns>
        public bool DeleteBuyTransaction(int id)
        {
            var result = buyTransactionRepository.Delete(id);
            if (!result) return false;
            unitOfWork.SaveChanges();
            return true;
        }

        /// <summary>
        /// Update buy transaction
        /// </summary>
        /// <param name="buyTransaction"></param>
        public void UpdateBuyTransaction(BuyTransaction_DEL buyTransaction)
        {
            buyTransactionRepository.Update(buyTransaction);
            unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Change debet coin. Only for demonstration, cause shouldn't change
        /// </summary>
        /// <param name="coinId"></param>
        /// <param name="buyTransactionId"></param>
        //public void ChangeDebetCoin(int coinId, int buyTransactionId)
        //{
        //    var buyTransaction = buyTransactionRepository.Get(buyTransactionId);
        //    var coin = coinRepository.Get(coinId);
        //    buyTransaction.DebetCoin = coin;
        //    unitOfWork.SaveChanges();
        //}

    }
}

      