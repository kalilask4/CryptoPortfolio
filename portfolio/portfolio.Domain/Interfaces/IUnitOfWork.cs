using portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Coin_DEL> CoinRepository { get; }
        IRepository<BuyTransaction_DEL> BuyTransactioRepository { get; }
        IRepository<SellTransaction_DEL> SellTransactioRepository { get; }
        
        void SaveChanges();
    }
}
