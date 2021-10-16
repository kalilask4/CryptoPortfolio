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
        public static void SetupData(CoinManager_DEL coinManager)
        {
            //Add coins
            coinManager.AddRange(new List<Coin_DEL>
            {
                new Coin_DEL
                {
                    CoinName = "CoinOne",
                    Symbol = "ONE",
                    Amount = 100,
                    ValueUSD = 1342,
                },
                new Coin_DEL
                {
                    CoinName = "CoinTwo",
                    Symbol = "TWO",
                    Amount = 2300,
                    ValueUSD = 220,
                },
                new Coin_DEL
                {
                    CoinName = "CoinThird",
                    Symbol = "Third",
                    Amount = 3000,
                    ValueUSD = 3,
                }
            });

            var coins = coinManager.coins.ToArray();

            //add transactions
            coinManager.AddBuyTransactionToCoin(
                new BuyTransaction_DEL
                {
                    Amount = 100,
                    Priсe = 12092,
                    CoinId = coins[0].CoinId
                },
                coins[0].CoinId,
                coins[1].CoinId
                );
            coinManager.AddBuyTransactionToCoin(
                new BuyTransaction_DEL
                {
                    Amount = 200,
                    Priсe = 92,
                    CoinId = coins[0].CoinId
                },
                coins[0].CoinId,
                coins[1].CoinId
                );
            coinManager.AddBuyTransactionToCoin(
                new BuyTransaction_DEL
                {
                    Amount = 200,
                    Priсe = 92,
                    CoinId = coins[0].CoinId
                },
                coins[1].CoinId, 
                coins[2].CoinId
                );
        }
    }
}
