using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Windows;
using portfolio.Domain.Interfaces;

namespace portfolio.Domain.Entities
{
    public class Coin : ICoinCloneable
    {
        [Key] public int CoinId { get; set; }
        private string _name = "No name coin";
        private string _shortName = "NONAME";
        [Required] public decimal Amount { get; set; }

        public decimal PurchasePrice { get; set; } //last purchase price
        public decimal AveragePrice { get; set; } //Average purchase price
        public decimal CurrentPrice { get; set; }

        public decimal CurrentValue { get; set; }
        public decimal AverageValue { get; set; }

        public decimal ProfitUSD { get; set; }
        public decimal ProfitPerс { get; set; }

        private string _pictureName = "no.png";
        //private ICoinCloneable _coinCloneableImplementation;

        public string PictureName
        {
            get { return _pictureName; }
            set { _pictureName = value; }
        }

        public string ShortName

        {
            get { return _shortName; }
            set
            {
                if (value != null)
                {
                    _shortName = value;
                }

            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value != null)
                {
                    _name = value;
                }

            }
        }


        public DateTime DateUpdate { get; set; }

        // навигационное свойство
        public List<Transaction> Transactions { get; set; }

        public Coin()
        {
            //Trace.WriteLine($"constr 1");

            AveragePrice = PurchasePrice;
            //Name = "DefName";
            //ShortName = "DN";
            //Amount = 0;
            //PurchasePrice = 1;
            //AveragePrice = this.CurrentPrice;

            //AverageValue = this.Amount * this.AveragePrice;
            //CurrentValue = this.Amount * this.CurrentPrice;

            //ProfitUSD = CurrentValue - AverageValue;
            //try
            //{
            //    ProfitPerс = ProfitUSD / Amount;
            //}
            //catch { }


            //PictureName = this.ShortName + ".png";
            //DateUpdate = DateTime.Now;
            Transactions = new List<Transaction>();
        }

        //for SetupData for test
        public Coin(string name, Transaction transaction)
        {
            //Trace.WriteLine($"constr 2");
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

        public Coin(string name, decimal amount, decimal purchasePrice, decimal currentPrice)
        {
            //Trace.WriteLine($"constr 3");
            Name = name;
            ShortName = name.Substring(0, 3).ToUpper();
            Amount = culcAmount(amount);
            PurchasePrice = purchasePrice;
            CurrentPrice = currentPrice;

            AveragePrice = culcAveragePrice(purchasePrice);
            CurrentValue = culcCurrentValue(amount, currentPrice);
            AverageValue = culcAverageValue(amount, purchasePrice);

            ProfitUSD = CurrentValue - AverageValue;
            ProfitPerс = (CurrentValue - AverageValue) / CurrentPrice;

            PictureName = ShortName + "png";
            DateUpdate = DateTime.Today;
            Transactions = new List<Transaction>();
        }

        public void recalcByTransfer(decimal amountTransfer, decimal priceTransfer)
        {
            AveragePrice = (AveragePrice + priceTransfer) / 2;
            Amount += amountTransfer;
            PurchasePrice = priceTransfer;
            AverageValue = Amount * AveragePrice;
            CurrentValue = Amount * CurrentPrice;
            ProfitUSD = CurrentValue - AverageValue;
            ProfitPerс = (CurrentValue - AverageValue) / Amount;
        }
        public static void recalcByExchangeTransaction(
            Coin debetCoin, Coin creditCoin,
            decimal dialogAmount, decimal dialogPrice, string dialogSide,
            out Coin outDebetCoin, out Coin outCreditCoin)
        {
            if (dialogSide == "buy")
            {
                debetCoin.Amount += dialogAmount;
                creditCoin.Amount -= dialogPrice;
            }
            else if (dialogSide == "sell")
            {
                debetCoin.Amount -= dialogAmount;
                creditCoin.Amount += dialogPrice;
            }
            
            debetCoin.AverageValue = debetCoin.Amount * debetCoin.AveragePrice;
            creditCoin.AverageValue = creditCoin.Amount * creditCoin.AveragePrice;
            debetCoin.ProfitUSD = debetCoin.CurrentValue - debetCoin.AverageValue;
            creditCoin.ProfitUSD = creditCoin.CurrentValue - creditCoin.AverageValue;
            outDebetCoin = debetCoin;
            outCreditCoin = creditCoin;
        }
            
        public void calculateValues()
        {
            CurrentValue = Amount * CurrentPrice;
            AverageValue = Amount * AveragePrice;
            ProfitUSD = CurrentValue - AverageValue;
            ProfitPerс = (CurrentValue - AverageValue) / Amount;
        }

        public decimal culcAmount(decimal amount)
        {
            return this.Amount + amount;
        }

        public decimal culcAveragePrice(decimal purchasePrice)
        {
            if (this.AveragePrice != 0)
            {
                return (purchasePrice + this.AveragePrice) / (decimal)2.0;
            }
            return purchasePrice;
        }

        public decimal culcCurrentValue(decimal amount, decimal currentPrice)
        {
            return this.Amount*currentPrice;
        }

        public decimal culcAverageValue(decimal amount, decimal purchasePrice)
        {
            if (this.AveragePrice != 0)
            {
                return this.culcAveragePrice(purchasePrice) * amount;
            }
            return (this.Amount + amount) * purchasePrice; 
            }

        public override string ToString()
        {
            return $"{ShortName}" ;
        }
        
        public string FullToString()
        {
            return $"{ShortName} {Name} amount {Amount} average price {AveragePrice} profit {ProfitUSD}" ;
        }

        public Coin Clone()
        {
            return new Coin
            {
                CoinId = CoinId,
                Name = Name,
                ShortName = ShortName,
                Amount = Amount,
               
                PurchasePrice = PurchasePrice,
                CurrentPrice = CurrentPrice,
                AveragePrice = AveragePrice,
                
                CurrentValue = CurrentValue,
                AverageValue = AverageValue,
                
                ProfitUSD = ProfitUSD,
                ProfitPerс = ProfitPerс,
                
                _pictureName = _pictureName,
            };
            
        }
    }
}



