using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Domain.Entities
{
    public abstract class Transaction
    {
        public int TransactionId { get; set; }
        public string Side { get; set; }
        public Dictionary<String, Coin> transactionCoins { get; set; }
        public int CoinId { get; set; } // debit coin reference
        public Coin Coin { get; set; }



        //public Coin DebetCoin { get; set; }
        //public Coin CreditCoin { get; set; }
        public decimal Amount { get; set; }
        public decimal Priсe { get; set; }
        public DateTime AddDate { get; set; }
        public string TransactionSymbol { get; set; }

        public Transaction()
        {
            transactionCoins = new Dictionary<string, Coin>();
            AddDate = DateTime.Now;
        }

        public Transaction(Coin debetCoin, Coin creditCoin, decimal amount, decimal priсe)
        {
            transactionCoins = new Dictionary<string, Coin>(2);
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
            return $"Transaction {this.Side}: {this.TransactionSymbol}  {this.Amount}  {this.Priсe} Total: {this.Amount}*{this.Priсe}";
        }
    }
}
