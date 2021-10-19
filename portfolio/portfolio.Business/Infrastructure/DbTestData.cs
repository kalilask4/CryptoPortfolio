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
                    PictureName = "BNB.png"
                },
            });

            var coins = coinManager.Coins.ToArray();

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
