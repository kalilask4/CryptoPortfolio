using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Domain.Entities
{
    public class Coin
    {
        public int CoinId { get; set; }
        public string Symbol { get; set; }
        public string CoinName { get; set; }
        public decimal Amount { get; set; }
        public decimal ValueUSD { get; set; }
        public decimal AveragePurchasePrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public string PictureName { get; set; }
        public DateTime DateUpdate { get; set; }
        public List<BuyTransaction> Buyings { get; set; }
        public List<SellTransaction> Sellings { get; set; }

        public Coin()
        {
            Symbol = "defaultSymbol";
            Buyings = new List<BuyTransaction>();
            Sellings = new List<SellTransaction>();
        }

        public Coin(string name)
        {
            CoinName = name;
            Symbol = name.Substring(0, 3);
            Buyings = new List<BuyTransaction>();
            Sellings = new List<SellTransaction>();
        }
    }
}
