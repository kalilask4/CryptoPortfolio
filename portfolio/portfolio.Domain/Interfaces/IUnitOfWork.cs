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
        IRepository<Coin> CoinRepository { get; }
        IRepository<BuyTransaction> BuyTransactioRepository { get; }
        IRepository<SellTransaction> SellTransactioRepository { get; }
        
        void SaveChanges();
    }
}
