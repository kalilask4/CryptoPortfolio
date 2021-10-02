using portfolio.Business.Managers;
using portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Business.Infrastructure
{
    public static class DbTestData
    {
        public static void SetupData(CoinManager coinManager)
        {
            //Add coins
            coinManager.AddRange(new List<Coin>
            {
                new Coin
                {
                    CoinName = "CoinOne",
                    Symbol = "ONE",
                    Amount = 100,
                    ValueUSD = 2342,
                },
                new Coin
                {
                    CoinName = "CoinTwo",
                    Symbol = "TWO",
                    Amount = 2300,
                    ValueUSD = 220,
                } 
            });

            var coins = coinManager.coins.ToArray();

            //add transactions
            coinManager.AddBuyTransactionToCoin(
                new BuyTransaction
                { },
                coins[0].CoinId, false
                );
            coinManager.AddBuyTransactionToCoin(
                new BuyTransaction
                { },
                coins[0].CoinId, false
                );
            coinManager.AddBuyTransactionToCoin(
                new BuyTransaction
                { },
                coins[1].CoinId, false
                );
        }
    }
}
