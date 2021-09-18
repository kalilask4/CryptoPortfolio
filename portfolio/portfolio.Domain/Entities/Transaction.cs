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
        public Coin DebetCoin { get; set; }
        public Coin CreditCoin { get; set; }
        public decimal Amount { get; set; }
        public decimal Prise { get; set; }
        public DateTime TradeDate { get; set; }
        public string Symbol { get; set; }

        public Transaction()
        {
            Symbol = "symbol";
                //DebetCoin.Symbol + CreditCoin.Symbol;
        }

        public override string ToString()
        {
            return $"Transaction {this.Side}: {this.Symbol}  {this.Amount}  {this.Prise} Total: {this.Amount}*{this.Prise}";
        }
    }
}
