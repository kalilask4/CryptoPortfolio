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

            // transactionManager.AddRange(new List<Transaction> {
            //     new Transaction {
            //         Symbol = "LTCTRX",
            //         Side = "sell"
            //     },
            //     new Transaction {
            //     },
            //     new Transaction
            //     {
            //         Symbol = "LINKBNB",
            //         Side = "sell"
            //     }}
            //     );

            coinManager.AddRange(new List<Coin>
            {
                new Coin
                {
                    Name = "Tether",
                    ShortName = "USDT",
                    PictureName = "USDT.png",
                    Amount = 1000,
                    AveragePrice = 1,
                    CurrentPrice = 1,
                },
                
                new Coin
                {
                    Name = "Bitcoin",
                    ShortName = "BTC",
                    PictureName = "BTC.png",
                    Amount = (decimal) 0.001,
                    AveragePrice = 50000
                },
                
                new Coin
                {
                    Name = "Etherium",
                    ShortName = "ETH",
                    PictureName = "ETH.png",
                    Amount = (decimal)0.3,
                    AveragePrice = 4200
                },
                new Coin
                {
                    Name = "XRP",
                    ShortName = "XRP",
                    PictureName = "XRP.png",
                    Amount = 220,
                    AveragePrice = (decimal)0.8791
                },
                
                
                
                // new Coin
                // {
                //     Name = "Tron",
                //     ShortName = "TRX",
                //     PictureName = "TRX.png",
                //     Amount = 100,
                //     //PurchasePrice = 10  /only for transactions
                //     AveragePrice = 15,
                //     CurrentPrice = 30,
                //     AverageValue = 1500,
                //     CurrentValue = 3000,
                // },
                // new Coin
                // {
                //     Name = "Chainlink",
                //     ShortName = "LINK",
                //     PictureName = "LINK.png",
                //     Amount = 2000,
                //     AveragePrice = (decimal)2.5,
                //     CurrentPrice = (decimal)1.7,
                //     AverageValue = 5000,
                //     CurrentValue = 3400,
                // },
                // new Coin
                // {
                // },
                // new Coin
                // {
                //     Name = "Cardano",
                //     ShortName = "ADA",
                //     PictureName = "ADA.png"
                // },
                // new Coin
                // {
                //     Name = "CRV",
                //     ShortName = "CRV",
                //     PictureName = "CRV.png"
                // },
                // new Coin
                // {
                //     Name = "BNB",
                //     ShortName = "BNB",
                //     PictureName = "BNB.png",
                //     Amount = 2000,
                //     AveragePrice = (decimal)2.5,
                //     CurrentPrice = (decimal)1.7,
                //     AverageValue = 5000,
                //     CurrentValue = 3400,
                // },
                // new Coin                                     //created with empty constructor, after fields changed
                // {
                //     Name = "4testconstr",
                //     Amount = 10,
                //     PurchasePrice = (decimal)5,
                //     CurrentPrice = (decimal)4.2,
                //
                // },
                // new Coin("5testconstr", 10, (decimal)5, (decimal)4.2) //created with not empty constructor, methods was called

            });

            var coins = coinManager.Coins.ToArray();
            
            // Coin coin = new Coin("1testconstr", 100, (decimal)1.1, (decimal)1.2);
            // Coin coin2 = new Coin("2testConstr", 200, (decimal)5, (decimal)4.2);
            // Coin coin3 = new Coin("3testconstr", 10, (decimal)5, (decimal)4.2);
            // List<Coin> coins2 = new List<Coin>();
            // coins2.Add(coin);
            // coins2.Add(coin2);
            // coins2.Add(coin3);
            // coinManager.AddRange(coins2);

            // transactionManager.AddCoinToTransaction(coins[2], 0);
            // transactionManager.AddCoinToTransaction(coins[0], 0);
            // transactionManager.AddCoinToTransaction(coins[5], 3);
            //
            // coinManager.AddTransactionToCoin(
            //     new Transaction
            //     {
            //         Symbol = "LLLXXX",
            //         Side = "sell"
            //     },
            //     0,
            //     1
            //     );
            //
            // coinManager.AddTransactionToCoin(
            //     new Transaction
            //     {
            //         Symbol = "AAA",
            //         Side = "transfer"
            //     },
            //     2,
            //     2
            //     );


            //coinManager.AddTransactionToCoin(
            //    new Transaction{}, 0, 1);


            /*coinManager.AddTransactionToCoin(
                new Transaction
                {
                    Symbol = "LTCTRX",
                    Side = "sell"
                },
                0,
                1
                );
            coinManager.AddTransactionToCoin(
                new Transaction
                {
                    Symbol = "LTCLINK",
                    Side = "buy"
                },
                0,
                2
                );*/
        }
    }
}
