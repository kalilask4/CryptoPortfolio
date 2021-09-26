using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Domain.Entities
{
    public class SellTransaction : Transaction
    {
        public SellTransaction(Coin debetCoin, Coin creditCoin, decimal amount, decimal priсe): base (debetCoin, creditCoin, amount, priсe)
        {
            Side = "Sell";
        }

        public SellTransaction()
        {
            Side = "Sell";
        }
    }
}
