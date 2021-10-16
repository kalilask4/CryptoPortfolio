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
        [Required]
        private string side;
        static readonly List<string> SideType = new List<string> { "buy", "sell", "transfer" };
        
        public decimal Amount { get; set; }
        public decimal Priсe { get; set; }
        public decimal Sum { get; set; }
        public DateTime DateUpdate { get; set; }
        // навигационное свойство
        public List<Coin> TransactionCoins { get; set; }
        
        public string Side
        {
            get { return side; }
            set
            {
                if (SideType.Contains(value))
                    side = value;
            }
        }

        public Transaction()
        {
            Symbol = "DefaultSymbol";
            Side = "buy";
            Amount = 0;
            Priсe = 0;
            DateUpdate = DateTime.Now; 
            TransactionCoins = new List<Coin>(2);
        }

        public override string ToString()
        {
            return $"Id {TransactionId} {Symbol} {Side}";
        }

    }
}