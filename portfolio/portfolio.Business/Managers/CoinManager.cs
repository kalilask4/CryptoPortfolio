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
    class CoinManager : BaseManager
    {
        public CoinManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region basic CRUD operations
        public bool DeleteCoin(int id)
        {
            var result = coinRepository.Delete(id);
            if (!result) return false;
            unitOfWork.SaveChanges();
            return true;
        }


        public IEnumerable<Coin>FindCoin(Expression<Func<Coin, bool>> predicate) => 
            coinRepository.Find(predicate);

        public Coin GetCoinById(int id) => coinRepository.Get(id);

        public IEnumerable<Coin> GetAllCoins() =>
            coinRepository.GetAll();

        public void UpdateCoin(Coin coin)
        {
            coinRepository.Update(coin);
            unitOfWork.SaveChanges();
        }
        #endregion
    }
}

