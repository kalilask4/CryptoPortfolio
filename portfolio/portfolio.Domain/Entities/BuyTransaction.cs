using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Domain.Entities
{
    public class BuyTransaction : Transaction
    {

        public BuyTransaction(Coin debetCoin, Coin creditCoin, decimal amount, decimal price): base (debetCoin, creditCoin, amount, price)
        {
            Side = "Buy";
        }

        public BuyTransaction(): base ()
        {
            Side = "Buy";
        }
    }
}
