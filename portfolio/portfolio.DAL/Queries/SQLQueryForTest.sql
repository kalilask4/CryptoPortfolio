/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [CoinId]
      ,[Name]
      ,[ShortName]
      ,[Amount]
      ,[CurrentPrice]
      ,[ValueUSD]
      ,[AveragePurchasePrice]
      ,[PictureName]
      ,[DateUpdate]
  FROM [portfoliotest0].[dbo].[Coins]

SELECT TOP (1000) [TransactionId]
      ,[Symbol]
      ,[Amount]
      ,[Priñe]
      ,[Sum]
      ,[DateUpdate]
      ,[Side]
  FROM [portfoliotest0].[dbo].[Transactions]

SELECT TOP (1000) [TransactionCoinsCoinId]
      ,[TransactionsTransactionId]
  FROM [portfoliotest0].[dbo].[CoinTransaction]


select * 
from Coins 
join CoinTransaction
on Coins.CoinId = CoinTransaction.TransactionCoinsCoinId
join Transactions 
on Transactions.TransactionId = CoinTransaction.TransactionsTransactionId
where CoinId = 1


select * from Transactions
where
transactionId=1

select c.CoinId, c.Name, t.TransactionId, t.Symbol 
from Coins as c
join
(select * from CoinTransaction) as tc
on
c.CoinId = tc.TransactionCoinsCoinId
join
(select * from Transactions) as t
on
t.TransactionId = tc.TransactionCoinsCoinId
where t.TransactionId=1


insert into Coins
(Name, ShortName, Amount, CurrentPrice, ValueUSD, AveragePurchasePrice, PictureName, DateUpdate) values
(N'ICP', N'ICP', 100, 2, 200, 2, N'ICP.png', GETDATE())

insert into Coins
(Name, ShortName, Amount, CurrentPrice, ValueUSD, AveragePurchasePrice, PictureName, DateUpdate) values
(N'AAA', N'A0', 100, 2, 200, 2, N'AO.png', GETDATE())

insert into Transactions
(Symbol, Amount, Priñe, Sum, DateUpdate, Side) values
(N'3kkk', 100, 5, 500, GETDATE(), N'buy')

insert into Transactions
(Symbol, Amount, Priñe, Sum, DateUpdate, Side) values
(N'ICPAAA', 20, 15, 300, GETDATE(), N'transfer')


insert into CoinTransaction
(TransactionCoinsCoinId, TransactionsTransactionId) values
(0,5)

drop database portfoliotest0

SELECT * FROM Coins
SELECT * FROM Transactions
SELECT * FROM CoinTransaction

SELECT * FROM Coins WHERE PictureName is NULL;

SELECT * FROM Coins WHERE Name = 'qq';

SELECT * FROM Coins WHERE PictureName = 'BLOW.png';

UPDATE Coins
SET PictureName=N'AO.png'
WHERE PictureName is NULL;

UPDATE Transactions
SET Symbol='hhhxxx'
where
TransactionId=4