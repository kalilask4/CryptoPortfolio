using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace portfolio.Domain.Entities
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public string Symbol { get; set; } //like Name exs BTNBTC
        public decimal Amount { get; set; }
        public decimal Price { get; set; } //Price
        public decimal Sum { get; set; }
        public DateTime DateUpdate { get; set; }
        // навигационное свойство
        public List<Coin> TransactionCoins { get; set; }
        [Required]
        private string side = "transfer";
        public static readonly List<string> sideType = new() { "transfer", "buy", "sell"};
        public string Side
        {
            get { return side; }
            set
            {
                if (sideType.Contains(value))
                    side = value;
            }
        }

        public Transaction(Coin coin)
        {
            Symbol = coin.ShortName;
            Side = this.Side;
            Amount = 0;
            Price = 0;
            DateUpdate = DateTime.Now;
            TransactionCoins = new List<Coin>(2);
            TransactionCoins.Add(coin);
        }

        public Transaction()
        {
            Symbol = "DefaultSymbol";
            Side = "buy";
            Amount = 0;
            Price = 0;
            DateUpdate = DateTime.Now; 
            TransactionCoins = new List<Coin>(2);
        }

        //for SetupData for test
        /*public Transaction(Coin coin)
        {
            Symbol = coin.ShortName;
            Side = "transfer";
            Amount = 0;
            Priсe = 0;
            DateUpdate = DateTime.Now;
            TransactionCoins = new List<Coin>(2);
            TransactionCoins.Add(coin);
        }*/

        public override string ToString()
        {
            return $"Id {TransactionId} {Symbol} {Side}";
        }

    }
}