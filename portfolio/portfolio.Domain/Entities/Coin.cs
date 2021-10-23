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
        public string Name { get; set; }
        //private string name = "EmptyName";
        private string shortName;
        [Required]
        public decimal Amount { get; set; }
        
        public decimal PurchasePrice { get; set; } //new 
        public decimal AveragePrice { get; set; } //Average purchase price
        public decimal CurrentPrice { get; set; }
        
        //public decimal ValueUSD { get; set; }
        public decimal CurrentValue { get; set; } //new. Will change ValueCurrent 
        public decimal AverageValue { get; set; } //new.  Will change ValueAverage

        private string pictureName = "no.png";
        public string PictureName
        {
            get { return pictureName; }
            set
            {
                pictureName = value;
            }
        }
        public string ShortName
        //{ get; set; }
        {
            get { return shortName; }
            set
            {
                shortName = value;
            }
        }

        //public string Name
        //{
        //    get { return name; }
        //    set
        //    {
        //        name = value;
        //    }
        //}


        public DateTime DateUpdate { get; set; }
        // навигационное свойство
        public List<Transaction> Transactions { get; set; }


        public Coin()
        {
            Name = "DefName";
            ShortName = "DN";
            Amount = 0;
            PurchasePrice = 1;
            AveragePrice = 1;
            AverageValue = 1;
            CurrentValue = 1;
            
            PictureName = ShortName + ".png";
            DateUpdate = DateTime.Now;
            Transactions = new List<Transaction>();
        }

        //for SetupData for test
        public Coin(string name, Transaction transaction)
        {
            Name = name + "Tww";
            ShortName = "DNT";
            Amount = 0;
            CurrentValue = 0;
            AverageValue = 0;
            PictureName = ShortName + ".png";
            DateUpdate = DateTime.Now;
            Transactions = new List<Transaction>();
            Transactions.Add(transaction);
        }

        //public Coin(string name, string shortName, decimal amount, decimal currentPrice, decimal valueByCurrentPrice, decimal valueByAveragePurchasePrice, string pictureName, DateTime dateUpdate)
        //{
        //    Name = name;
        //    ShortName = shortName;
        //    Amount = amount;
        //    CurrentPrice = currentPrice;
        //    CurrentValue = valueByCurrentPrice;
        //    ValueByAveragePurchasePrice = valueByAveragePurchasePrice;
        //    PictureName = pictureName;
        //    DateUpdate = dateUpdate;
        //    Transactions = new List<Transaction>();
        //}


        public cul

        public override string ToString()
        {
            return $"Id{CoinId} - {ShortName}, amout = {Amount}, {CurrentValue} USD.";
        }
    }


}
