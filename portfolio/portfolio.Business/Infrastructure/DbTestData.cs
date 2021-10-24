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

            transactionManager.AddRange(new List<Transaction> {
                new Transaction {
                    Symbol = "LTCTRX",
                    Side = "sell"
                },
                new Transaction {
                },
                new Transaction
                {
                    Symbol = "LINKBNB",
                    Side = "sell"
                }}
                );

            coinManager.AddRange(new List<Coin>
            {
                new Coin
                {
                    Name = "Litecoin",
                    ShortName = "LTC",
                    PictureName = "LTC.png",
                    Amount = 10,
                    //PurchasePrice = 10  /only for transactions
                    AveragePrice = 150,
                    CurrentPrice = 200,
                    AverageValue = 1500,
                    CurrentValue = 2000,

        },
                new Coin
                {
                    Name = "Tron",
                    ShortName = "TRX",
                    PictureName = "TRX.png",
                    Amount = 100,
                    //PurchasePrice = 10  /only for transactions
                    AveragePrice = 15,
                    CurrentPrice = 30,
                    AverageValue = 1500,
                    CurrentValue = 3000,
                },
                new Coin
                {
                    Name = "Chainlink",
                    ShortName = "LINK",
                    PictureName = "LINK.png",
                    Amount = 2000,
                    AveragePrice = (decimal)2.5,
                    CurrentPrice = (decimal)1.7,
                    AverageValue = 5000,
                    CurrentValue = 3400,
                },
                new Coin
                {
                },
                new Coin
                {
                    Name = "Cardano",
                    ShortName = "ADA",
                    PictureName = "ADA.png"
                },
                new Coin
                {
                    Name = "CRV",
                    ShortName = "CRV",
                    PictureName = "CRV.png"
                },
                new Coin
                {
                    Name = "BNB",
                    ShortName = "BNB",
                    PictureName = "BNB.png",
                    Amount = 2000,
                    AveragePrice = (decimal)2.5,
                    CurrentPrice = (decimal)1.7,
                    AverageValue = 5000,
                    CurrentValue = 3400,
                },
                new Coin
                {
                    Name = "4testconstr",
                    Amount = 10,
                    PurchasePrice = (decimal)5,
                    CurrentPrice = (decimal)4.2,

                },
                new Coin("5testconstr", 10, (decimal)5, (decimal)4.2)

            });

            var coins = coinManager.Coins.ToArray();

            Coin coin = new Coin("1testconstr", 100, (decimal)1.1, (decimal)1.2);
            Coin coin2 = new Coin("2testConstr", 200, (decimal)5, (decimal)4.2);
            Coin coin3 = new Coin("3testconstr", 10, (decimal)5, (decimal)4.2);
            List<Coin> coins2 = new List<Coin>();
            coins2.Add(coin);
            coins2.Add(coin2);
            coins2.Add(coin3);
            coinManager.AddRange(coins2);

            transactionManager.AddCoinToTransaction(coins[2], 0);
            transactionManager.AddCoinToTransaction(coins[0], 0);
            transactionManager.AddCoinToTransaction(coins[5], 3);

            coinManager.AddTransactionToCoin(
                new Transaction
                {
                    Symbol = "LLLXXX",
                    Side = "sell"
                },
                0,
                1
                );

            coinManager.AddTransactionToCoin(
                new Transaction
                {
                    Symbol = "AAA",
                    Side = "transfer"
                },
                2,
                2
                );


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
