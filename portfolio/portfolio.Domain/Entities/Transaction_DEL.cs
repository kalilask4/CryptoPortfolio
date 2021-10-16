using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Domain.Entities
{




    public abstract class Transaction_DEL
    {
        [Key]
        public int TransactionId { get; set; }
        public string Side { get; set; }
        //public Dictionary<String, Coin_DEL> transactionCoins { get; set; }
        public int CoinId { get; set; } // debit coin reference
        public Coin_DEL Coin { get; set; }



        //public Coin_DEL DebetCoin { get; set; }
        //public Coin_DEL CreditCoin { get; set; }
        public decimal Amount { get; set; }
        public decimal Priсe { get; set; }
        public DateTime AddDate { get; set; }
        public string TransactionSymbol { get; set; }

        public Transaction_DEL()
        {
            transactionCoins = new Dictionary<string, Coin_DEL>();
            AddDate = DateTime.Now;
        }

        public Transaction_DEL(Coin_DEL debetCoin, Coin_DEL creditCoin, decimal amount, decimal priсe)
        {
            transactionCoins = new Dictionary<string, Coin_DEL>(2);
            transactionCoins.Add("debet", debetCoin);
            transactionCoins.Add("credit", creditCoin);
            Amount = amount;
            Priсe = priсe;
            AddDate = DateTime.Now;
            TransactionSymbol = debetCoin.CoinName + creditCoin.CoinName;
            //"default_symbol"; //DebetCoin.Symbol + CreditCoin.Symbol;
        }



        public override string ToString()
        {
            return $"Transaction_DEL {this.Side}: {this.TransactionSymbol}  {this.Amount}  {this.Priсe} Total: {this.Amount}*{this.Priсe}";
        }
    }
}
