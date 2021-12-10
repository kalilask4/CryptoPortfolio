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
        public static void SetupData(CoinManager coinManager, TransactionManager transactionManager)
        {
            coinManager.AddRange(new List<Coin>
            {
                new Coin
                {
                    Name = "Tether",
                    ShortName = "USDT",
                    PictureName = "USDT.png",
                    Amount = 100,
                    AveragePrice = 1,
                    CurrentPrice = 1,
                },
                
                // new Coin
                // {
                //     Name = "Bitcoin",
                //     ShortName = "BTC",
                //     PictureName = "BTC.png",
                //     Amount = (decimal) 0.0119,
                //     AveragePrice = 50000,
                //     CurrentPrice = 48000
                // },
                
                new Coin
                {
                    Name = "Etherium",
                    ShortName = "ETH",
                    PictureName = "ETH.png",
                    Amount = (decimal)0.036,
                    AveragePrice = 4000,
                    CurrentPrice = 4500
                },
                new Coin
                {
                    Name = "XRP",
                    ShortName = "XRP",
                    PictureName = "XRP.png",
                    Amount = 220,
                    AveragePrice = (decimal)0.8291,
                    CurrentPrice = (decimal)0.8791,
                    Transactions = new List<Transaction>()
                    {
                        new Transaction(){
                            Symbol = "XRPUSDT", 
                            Side = "buy", 
                            Amount = 28, 
                            Price = (decimal)0.79,
                            Sum = 28 * (decimal)0.79,
                    },},
                },
            });
            var coins = coinManager.Coins.ToArray();
        }
    }
}
