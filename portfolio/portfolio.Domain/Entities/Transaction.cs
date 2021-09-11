using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Domain.Entities
{
    abstract class Transaction
    {
        public string TransactionId { get; set; }
        public string Side { get; set; }
        public string Symbol { get; set; }
        public Coin DebetCoin { get; set; }
        public Coin CreditCoin { get; set; }
        public decimal Amount { get; set; }
        public decimal Prise { get; set; }
        public DateTime DateAdd { get; set; }

        protected Transaction()
        {
        }

        public override string ToString()
        {
            return $"Transaction {this.Side}: {this.Symbol}  {this.Amount}  {this.Prise} Total: {this.Amount}*{this.Prise}";
        }

    }
}
