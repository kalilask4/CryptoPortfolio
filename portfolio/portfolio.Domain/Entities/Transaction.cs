using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace portfolio.Domain.Entities
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Required]
        string side;
        static List<string> SideType = new List<string> { "buy", "sell", "transfer" };
        public string Side
        {
            get { return side; }
            set
            {
                if (SideType.Contains(value))
                    side = value;
            }
        }

        public string TransactionSymbol { get; set; }
        public decimal Amount { get; set; }
        public decimal Priсe { get; set; }
        public decimal Sum { get; set; }
        public DateTime DateUpdate { get; set; }
        // навигационное свойство
        public List<Coin> TransactionCoins { get; set; }

    }
}