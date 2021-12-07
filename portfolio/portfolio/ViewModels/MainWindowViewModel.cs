using portfolio.Business.Infrastructure;
using portfolio.Business.Managers;
using portfolio.Command;
using portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Input;
using portfolio.Business;

namespace portfolio.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ManagersFactory factory;
        CoinManager coinManager;
        TransactionManager transactionManager;
        
        private string titleCoins = "Coin Window";
        private string titleTransactions = "Transaction Window";
        private string titleCoinPerformance = "Coin Performance Window";

        #region Public properties

        public static ObservableCollection<Coin> Coins { get; set; }
        //public ObservableCollection<Transaction> Transactions { get; set; }
        //public ObservableCollection<Transaction> TransactionsForCoin { get; set; }
        public static ObservableCollection<Transaction> AllTransactions { get; set; }
        public static ObservableCollection<PortfolioIndicator> PortfolioIndicators { get; set; }
        public ObservableCollection<Transaction> TransactionsFromCoin { get; set; }

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern int MessageBoxTimeout(IntPtr hwnd, String text, String title,
            uint type, Int16 wLanguageId, Int32 milliseconds);

        public MainWindowViewModel()
        {
            factory = new ManagersFactory("DefaultConnection");
            coinManager = factory.GetCoinManager();
            transactionManager = factory.GetTransactionManager();

            //init db
            if (coinManager.Coins.Count() == 0)
                DbTestData.SetupData(coinManager, transactionManager);

            Coins = new ObservableCollection<Coin>(coinManager.Coins);
            Coins.CollectionChanged += CoinsOnCollectionChanged;
          
            AllTransactions = new ObservableCollection<Transaction>(transactionManager.Transactions);
            AllTransactions.CollectionChanged += AllTransactionsOnCollectionChanged;
            //Transactions = new ObservableCollection<Transaction>();
            TransactionsFromCoin = new ObservableCollection<Transaction>();
            
            PortfolioIndicators = new ObservableCollection<PortfolioIndicator>();
            PortfolioIndicators.CollectionChanged += PortfolioIndicatorsOnCollectionChanged;
            
            var startPrice = new PortfolioIndicator
            {
                IndicatorName = "Start price"
            };
            PortfolioIndicators.Add(startPrice);
            var currentPrice = new PortfolioIndicator
            {
                IndicatorName = "Current price"
            };
            PortfolioIndicators.Add(currentPrice);
            var profit = new PortfolioIndicator
            {
                IndicatorName = "Profit"
            };
            PortfolioIndicators.Add(profit);
            //CollectionChanged

            if (Coins.Count > 0)
                OnGetTransactionExecuted(Coins[0].CoinId);
        }
       
        private void PortfolioIndicatorsOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Replace:
                    PortfolioIndicator replasedIndicator = e.OldItems[0] as PortfolioIndicator;
                    PortfolioIndicator replasingIndicator = e.NewItems[0] as PortfolioIndicator;
                    MessageBoxTimeout((System.IntPtr) 0, $"{replasedIndicator.IndicatorName} recounted.", "Indicators",
                        0, 0, 1000);
                    break;
            }
        }

        private void AllTransactionsOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Transaction transaction = e.NewItems[0] as Transaction;
                    MessageBoxTimeout((System.IntPtr) 0, $"{transaction.Symbol} added.", "Transaction", 0, 0, 2000);
                    break;
            }
        }

        private static void CoinsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Coin coin = e.NewItems[0] as Coin;
                    MessageBoxTimeout((System.IntPtr) 0, $"{coin.Name} - {coin.ShortName} added.", "Coins", 0, 0, 2000);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Coin oldCoin = e.OldItems[0] as Coin;
                    MessageBoxTimeout((System.IntPtr) 0, $"{oldCoin.Name} deleted.", "Coins", 0, 0, 2000);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Coin replasedCoin = e.OldItems[0] as Coin;
                    Coin replasingCoin = e.NewItems[0] as Coin;
                    MessageBoxTimeout((System.IntPtr) 0, $"{replasedCoin.Name} replased {replasingCoin.Name}.", "Coins",
                        0, 0, 2000);
                    break;
            }
        }

        #region selected coin

        private Coin _selectedCoin;

        public Coin SelectedCoin
        {
            get => _selectedCoin;
            set { Set(ref _selectedCoin, value); }
        }
        
        // public static Coin stSelectedCoin
        // {
        //     get => SelectedCoin;
        // }

        #endregion

        #region selected transaction

        private Transaction _selectedTransaction;

        public Transaction SelectedTransaction
        {
            get => _selectedTransaction;
            set { Set(ref _selectedTransaction, value); }
        }

        #endregion

        #endregion

        #region Command

        #region Add coin

        private ICommand _newCoinCommand;
        public ICommand NewCoinCommand =>
            _newCoinCommand ??= new RelayCommand(OnNewCoinExecuted);

        private void OnNewCoinExecuted(object id)
        {
            var dialog = new EditCoinWindow
            {
                DateUpdate = DateTime.Now
            };

            if (dialog.ShowDialog() != true) return;

            var coin = new Coin
            {
                Name = dialog.Name,
                ShortName = dialog.ShortName.ToUpper(),
                Amount = dialog.Amount,
                PurchasePrice = dialog.PurchasePrice,
                CurrentPrice = dialog.CurrentPrice,
                AveragePrice = dialog.PurchasePrice,
                CurrentValue = dialog.CurrentPrice * dialog.Amount,
                AverageValue = dialog.PurchasePrice * dialog.Amount,
                DateUpdate = dialog.DateUpdate
            };

            var transaction = new Transaction
            {
                Symbol = coin.ShortName,
                Side = "transfer",
                Amount = coin.Amount,
                Price = coin.PurchasePrice,
            };

            var fileName = Path.GetFileName(dialog.PictureName);
            if (fileName != null)
            {
                coin.PictureName = fileName;
            }
            else
            {
                coin.PictureName = "no.png";
            }

            if (dialog.PictureName != null)
            {
                try
                {
                    var target = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);
                    File.Copy(dialog.PictureName, target);
                }
                catch (IOException e)
                {
                    MessageBox.Show("This file already exist. Choose another one. \n (Select coin, click button Edit)");
                }
            }

            transactionManager.AddCoinToTransaction(coin);
            //Transactions.Add(transaction);
            Coins.Add(coin);
            coinManager.AddTransactionToCoin(transaction, coin.CoinId);
        }

        #endregion

        #region Choose coin in list

        private ICommand _getTransactionsFromCoinCommand;

        public ICommand GetTransactionsFromCoinCommand =>
            _getTransactionsFromCoinCommand
                ??= new RelayCommand(OnGetTransactionExecuted);

        private void OnGetTransactionExecuted(object id)
        {
            TransactionsFromCoin.Clear();
            if (id is not null)
            {
                var transactions = coinManager.GetTransactionsOfCoin((int) id);
                foreach (var transaction in transactions)
                    TransactionsFromCoin.Add(transaction);
            }
        }

        #endregion

        #region Edit coin

        private ICommand _editCoinCommand;
        public ICommand EditCoinCommand =>
            _editCoinCommand ??= new RelayCommand(OnEditCoinExecuted, EditCoinCanExecute);


        // check if can edit
        private bool EditCoinCanExecute(object p) =>
            _selectedCoin != null;

        private void OnEditCoinExecuted(object id)
        {
            var dialog = new EditCoinWindow
            {
                Name = _selectedCoin.Name,
                ShortName = _selectedCoin.ShortName,
                Amount = _selectedCoin.Amount,
                PurchasePrice = _selectedCoin.PurchasePrice,
                CurrentPrice = _selectedCoin.CurrentPrice,
                AveragePrice = _selectedCoin.AveragePrice,
                DateUpdate = _selectedCoin.DateUpdate,
                PictureName = _selectedCoin.PictureName
            };
            if (dialog.ShowDialog() != true) return;

            // to Images
            var imageFolderPass = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            // for new picture
            try
            {
                if (!_selectedCoin.PictureName.Equals(dialog.PictureName))
                {
                    // delete old picture
                    //_selectedCoin.PictureName = null;
                    File.Delete(Path.Combine(imageFolderPass, _selectedCoin.PictureName));
                    // get new picture
                    var newImage = Path.GetFileName(dialog.PictureName);
                    // copy file to Images
                    File.Copy(dialog.PictureName, Path.Combine(imageFolderPass, newImage));

                    _selectedCoin.PictureName = newImage;
                }
            }
            catch
            {
                _selectedCoin.PictureName = dialog.PictureName;
            }

            _selectedCoin.Name = dialog.Name;
            _selectedCoin.ShortName = dialog.ShortName;
            _selectedCoin.Amount = dialog.Amount;
            _selectedCoin.PurchasePrice = dialog.PurchasePrice;
            _selectedCoin.CurrentPrice = dialog.CurrentPrice;
            _selectedCoin.CurrentValue = dialog.Amount * dialog.CurrentPrice;
            _selectedCoin.AverageValue = dialog.Amount * dialog.PurchasePrice;
            _selectedCoin.DateUpdate = dialog.DateUpdate;

            coinManager.Update(SelectedCoin);
            OnGetTransactionExecuted(_selectedCoin.CoinId);
        }

        #endregion

        #region Delete coin

        private ICommand _deleteCoinCommand;
        public ICommand DeleteCoinCommand => _deleteCoinCommand ??= new RelayCommand(OnDeleteCoinExecuted, DeleteCoinCanExecute);


        // check if can del
        private bool DeleteCoinCanExecute(object p) =>
            _selectedCoin != null;

        private void OnDeleteCoinExecuted(object id)
        {
            var result = MessageBox.Show("Are you sure?", $"Delete coin {_selectedCoin.Name}?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                coinManager.Delete(_selectedCoin.CoinId); //deleting only coin and relating, not transaction
                OnGetTransactionExecuted(_selectedCoin.CoinId);
                Coins.Remove(SelectedCoin);
                //MessageBoxTimeout((System.IntPtr) 0, $"No coin selected", "Coins", 0, 0, 2000);
            }
        }

        #endregion

        #region Calculate coin Values

        private ICommand _countCoinCommand;

        public ICommand CountCoinCommand =>
            _countCoinCommand ??= new RelayCommand(OnCulcCoinExecuted, CulcCoinCanExecute);


        // check if can del
        private bool CulcCoinCanExecute(object p) =>
            _selectedCoin != null;

        private void OnCulcCoinExecuted(object id)
        {
            Coin newCoin = coinManager.Recount(_selectedCoin.CoinId);
            coinManager.Update(newCoin);
            MessageBoxTimeout((System.IntPtr) 0, $"{_selectedCoin.Name} - {_selectedCoin.ShortName} recounted. " +
                                                 $"\n Update - right click", "Coins", 0, 0, 3000);
            OnGetTransactionExecuted(_selectedCoin.CoinId);
        }
      
        #endregion

        #region Add transaction

        private ICommand _newTransactionCommand;
        public ICommand NewTransactionCommand =>
            _newTransactionCommand ??= new RelayCommand(OnNewTransactionExecuted);

        
        private void OnNewTransactionExecuted(object id)
        {
            
            var dialog = new EditTransactionWindow{};

            if (dialog.ShowDialog() != true) return;

            Coin debetCoin = (Coin) dialog.cBoxCoinDebet.SelectedItem;
            Coin creditCoin = (Coin) dialog.cBoxCoinCredit.SelectedItem;
            MessageBox.Show(debetCoin.ToString());
          
             var transaction = new Transaction
                          {
                              DateUpdate = DateTime.Now,
                              Side = dialog.Side,
                              Symbol = debetCoin != null ? debetCoin.ShortName + creditCoin?.ShortName : "empty DebetCoin",
                              Amount = 1, //dialog.textBoxAmount.Text,
                              Price = 2,
                              TransactionCoins = new List<Coin>(2)
                              {
                                  debetCoin, 
                                  debetCoin,
                                 // TransactionCoins.Add(debetCoin); 
                              }
                          };   
            MessageBox.Show(transaction.ToString());
            AllTransactions.Add(transaction);
            //transactionManager.AddCoinToTransaction(debetCoin);
            coinManager.AddTransactionToCoin(transaction, debetCoin.CoinId, debetCoin.CoinId);
        }

        #endregion
        
        
         #region Full recount

        private ICommand _fullRecountCommand;
        public ICommand FullRecountCommand =>
            _fullRecountCommand ??= new RelayCommand(OnFullRecountExecuted);

        private void OnFullRecountExecuted(object id)
        {
            PortfolioIndicator startPriceIndicator = new PortfolioIndicator();
            startPriceIndicator.IndicatorName = "Start price";
            startPriceIndicator.Value = 0;
            decimal startPrice = 0;
            foreach (var coin in Coins)
            {
                startPrice += coin.AverageValue;
            }
            startPriceIndicator.Value = startPrice;
            foreach (var ind in PortfolioIndicators)
            {
                if (ind.IndicatorName.Equals(startPriceIndicator.IndicatorName))
                {
                    ind.Value = startPrice;
                }
            }
            
            PortfolioIndicator currentPriceIndicator = new PortfolioIndicator();
            currentPriceIndicator.IndicatorName = "Current price";
            currentPriceIndicator.Value = 0;
            decimal currentPrice = 0;
            foreach (var coin in Coins)
            {
                currentPrice += coin.CurrentValue;
            }
            currentPriceIndicator.Value = currentPrice;
            foreach (var ind in PortfolioIndicators)
            {
                if (ind.IndicatorName.Equals(currentPriceIndicator.IndicatorName))
                {
                    ind.Value = currentPrice;
                }
            }
            
            PortfolioIndicator profit = new PortfolioIndicator();
            profit.IndicatorName = "Profit";
            profit.Value = currentPriceIndicator.Value - startPriceIndicator.Value; 
            foreach (var ind in PortfolioIndicators)
            {
                if (ind.IndicatorName.Equals(profit.IndicatorName))
                {
                    ind.Value = profit.Value;
                }
            }
        }

        #endregion

        
        #region Add Transfer transaction
        
        
        private ICommand _newTransferTransactionCommand;
        public ICommand NewTransferTransactionCommand =>
            _newTransferTransactionCommand ??= new RelayCommand(OnNewTransferTransactionExecuted);
        
        
        private void OnNewTransferTransactionExecuted(object id)
        {
            var dialog = new EditTransactionWindow(id)
                {
                   DebetCoin = _selectedCoin,
                };
                
            if (dialog.ShowDialog() != true) return;
            
            Coin debetCoin = coinManager.GetById(((Coin) dialog.cBoxCoinDebet.SelectedItem).CoinId);
            var transaction = new Transaction()
            {
                DateUpdate = DateTime.Now,
                Side = dialog.Side,
                Symbol = debetCoin?.ShortName,
                Amount = dialog.Amount,
                Price = dialog.Price,
                TransactionCoins = new List<Coin>()
                {
                    debetCoin, 
                }
            };
            debetCoin?.recalcByTransfer(dialog.Amount, dialog.Price);
            transaction?.recalcByTransfer(dialog.Amount, dialog.Price);
            coinManager.Update(debetCoin);
            transactionManager.CreateTransaction(transaction);
            coinManager.AddTransactionToCoin(transaction, debetCoin.CoinId);
            AllTransactions.Add(transaction);
        }
        
        #endregion
        
        #region Delete transaction

        private ICommand _deleteTransactionCommand;
        public ICommand DelTransactionCommand => _deleteTransactionCommand ??= new RelayCommand(OnDeleteTransactionExecuted, DeleteTransactionCanExecute);


        // check if can delete
        private bool DeleteTransactionCanExecute(object p) =>
            _selectedCoin != null;

        private void OnDeleteTransactionExecuted(object id)
        {
            var result = MessageBox.Show("Are you sure?", $"Delete Transaction {_selectedTransaction.Symbol}?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                transactionManager.Delete(_selectedTransaction.TransactionId); //deleting only transaction
                OnGetTransactionExecuted(_selectedTransaction.TransactionId);
                AllTransactions.Remove(SelectedTransaction);
            }
        }

        #endregion
        
        #endregion
    }
}