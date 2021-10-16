using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Domain.Entities
{
    public class SellTransaction_DEL : Transaction_DEL
    {
        public SellTransaction_DEL(Coin_DEL debetCoin, Coin_DEL creditCoin, decimal amount, decimal priсe): base (debetCoin, creditCoin, amount, priсe)
        {
            Side = "Sell";
        }

        public SellTransaction_DEL()
        {
            Side = "Sell";
        }
    }
}
