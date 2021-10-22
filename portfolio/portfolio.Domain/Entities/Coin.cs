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
        public decimal CurrentPrice { get; set; }
        public decimal ValueUSD { get; set; }
        public decimal AveragePurchasePrice { get; set; }
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
            ShortName = "NO";
            Amount = 0;
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
            PictureName = ShortName + ".png";
            DateUpdate = DateTime.Now;
            Transactions = new List<Transaction>();
            Transactions.Add(transaction);
        }

        public Coin(string name, string shortName, decimal amount, decimal currentPrice, decimal valueUSD, string pictureName, DateTime dateUpdate)
        {
            Name = name;
            ShortName = shortName;
            Amount = amount;
            CurrentPrice = currentPrice;
            ValueUSD = valueUSD;
            PictureName = pictureName;
            DateUpdate = dateUpdate;
            Transactions = new List<Transaction>();

        }

        public override string ToString()
        {
            return $"Id{CoinId} - {ShortName}, amout = {Amount}";
        }
    }


}
