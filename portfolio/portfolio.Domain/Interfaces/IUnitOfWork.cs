using portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Domain.Interfaces
{
    interface IUnitOfWork
    {
        IRepository<Coin> CoinRepository { get; }
        IRepository<Buying> BuyingRepository { get; }
        IRepository<Selling> SelliRepository { get; }

        void SaveChanges();
    }
}
