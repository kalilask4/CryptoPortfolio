using portfolio.Business.Managers;
using portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.Business.Infrastructure
{
    public class DbTestData
    {
        public static void SetupData(CoinManager coinManager)
        {
            coinManager.AddRange(new List<Coin>
            {
                new Coin
                {
                    Name = "Litecoin",
                    ShortName = "LTC",
                    PictureName = "LTC.png"
                },
                new Coin
                {
                    Name = "Tron",
                    ShortName = "TRX",
                    PictureName = "TRX.png"
                },
                new Coin
                {
                    Name = "Chainlink",
                    ShortName = "LINK",
                    PictureName = "LINK.png"
                }
            });

            var coins = coinManager.Coins.ToArray();

            coinManager.AddTransactionToCoin(
                new Transaction
                {
                    Symbol = "LTCTRX",
                },
                0,
                1
                );
            coinManager.AddTransactionToCoin(
                new Transaction
                {
                    Symbol = "LTCLINK",
                },
                0,
                2
                );
        }
    }
}
