using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Domain.Entities
{
    public class BuyTransaction_DEL : Transaction_DEL
    {

        public BuyTransaction_DEL(Coin_DEL debetCoin, Coin_DEL creditCoin, decimal amount, decimal price): base (debetCoin, creditCoin, amount, price)
        {
            Side = "Buy";
        }

        public BuyTransaction_DEL() //: base ()
        {
            Side = "Buy";
        }
    }
}
