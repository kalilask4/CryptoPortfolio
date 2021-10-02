using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Domain.Entities
{
    public class Coin
    {
        [Key]
        public int CoinId { get; set; }
        [Required]
        public string Symbol { get; set; }
        public string CoinName { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public decimal ValueUSD { get; set; }
        public decimal AveragePurchasePrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public string PictureName { get; set; }
        public DateTime DateUpdate { get; set; }
        public List<BuyTransaction> BuyTransactions { get; set; }
        public List<SellTransaction> SellTransactions { get; set; }

        public Coin()
        {
            Symbol = "defaultSymbol";
            BuyTransactions = new List<BuyTransaction>();
            SellTransactions = new List<SellTransaction>();
        }

        public Coin(string name)
        {
            CoinName = name;
            Symbol = "defaultSymbol2";
            //Symbol = name.Substring(0, 3);
            BuyTransactions = new List<BuyTransaction>();
            SellTransactions = new List<SellTransaction>();
        }

        //for test!!
        public Coin(string name, BuyTransaction buyTransaction)
        {
            CoinName = name;
            Symbol = "defaultSymbol3";
            //Symbol = name.Substring(0, 3);
            Amount = 3; //test
            CurrentPrice = 10000; //test
            BuyTransactions = new List<BuyTransaction>();
            BuyTransactions.Add(buyTransaction);
            SellTransactions = new List<SellTransaction>();
        }

        public override string ToString()
        {
            return $"id {this.CoinId} Coin name: {this.CoinName} amout = {this.Amount} symbol: {this.Symbol} ";
        }
    }
}
