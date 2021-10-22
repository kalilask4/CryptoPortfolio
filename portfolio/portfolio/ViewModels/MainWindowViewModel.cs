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
using System.Windows.Input;

namespace portfolio.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ManagersFactory factory;
        CoinManager coinManager;
        TransactionManager transactionManager;

        private string titleCoins = "Coin Window";
        private string titleTransactions = "Transaction Window";

        #region Public properties
        public ObservableCollection<Coin> Coins { get; set; }
        public ObservableCollection<Transaction> Transactions { get; set; }
        public ObservableCollection<Transaction> TransactionsForCoin { get; set; }
        public ObservableCollection<Transaction> AllTransactions { get; set; }
        public string Title { get => titleCoins; set => titleCoins = value; }
        public string TitleTransactions { get => titleTransactions; set => titleTransactions = value; }

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
            Coins.CollectionChanged += Coins_CollectionChanged;

            AllTransactions = new ObservableCollection<Transaction>(transactionManager.Transactions);
            Transactions = new ObservableCollection<Transaction>(transactionManager.Transactions);

            //get list transaction for first coin
            if (Coins.Count > 0)
                OnGetTransactionExecuted(Coins[0].CoinId);

            //get list transaction for first coin
            //if (Transactions.Count > 0)
               // OnGetTransactionExecuted(Transactions[0].TransactionId);

        }

        private static void Coins_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Coin coin = e.NewItems[0] as Coin;
                    MessageBoxTimeout((System.IntPtr)0, $"{coin.Name} added.", "Coins", 0, 0, 2000);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Coin oldCoin = e.OldItems[0] as Coin;
                    MessageBoxTimeout((System.IntPtr)0, $"{oldCoin.Name} deleted.", "Coins", 0, 0, 2000);
                    break;
            }
        }


        #region selected coin 
        private Coin _selectedCoin;
        public Coin SelectedCoin
        {
            get => _selectedCoin;
            set
            {
                Set(ref _selectedCoin, value);
            }
        }
        #endregion

        #region selected transaction 
        private Transaction _selectedTransaction;
        public Transaction SelectedTransaction
        {
            get => _selectedTransaction;
            set
            {
                Set(ref _selectedTransaction, value);
            }
        }
        #endregion
        #endregion

        #region Command
        #region Add coin
        private ICommand _newCoinCommand;
        public ICommand NewCoinCommand => _newCoinCommand ??= new RelayCommand(OnNewCoinExecuted);

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
                ShortName = dialog.ShortName,
                Amount = dialog.Amount,
                CurrentPrice = dialog.CurrentPrice,
                ValueUSD = dialog.ValueUSD,
                DateUpdate = dialog.DateUpdate
            };

            if (coin.Name == null)
            {
                coin.Name = "Noname";
            }

            if (coin.ShortName == null)
            {
                coin.Name = coin.Name.Substring(0, 3).ToLower();
            }


            var fileName = Path.GetFileName(dialog.PictureName);
            if (fileName != null)
            {
                coin.PictureName = fileName;
            }
            else
            {
                coin.PictureName = "no.png";
            }

            transactionManager.AddCoinToTransaction(coin);

            if (dialog.PictureName != null)
            {
                try
                {
                var target = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);
                File.Copy(dialog.PictureName, target);
                }
                catch (IOException e)
                {
                    MessageBox.Show("This file already exist. Choose another one.");
                }
            }

            Coins.Add(coin);
        }
        #endregion

        #region Choose coin from list
        private ICommand _getTransactionCommand;
        public ICommand GetTransactionCommand =>
            _getTransactionCommand
            ??= new RelayCommand(OnGetTransactionExecuted);

        private void OnGetTransactionExecuted(object id)
        {
                Transactions?.Clear();
                var transactions = coinManager.GetTransactionsOfCoin((int)id);
                foreach (var transaction in transactions)
                {
                    Transactions?.Add(transaction);
                }
        }
        #endregion

        #region Choose transaction from list
        private ICommand _getCoinCommand;
        public ICommand GetCoinCommand =>
            _getCoinCommand
            ??= new RelayCommand(OnGetCoinExecuted);

        private void OnGetCoinExecuted(object id)
        {
            Coins?.Clear();
            var coins = transactionManager.GetCoinsOfTransaction((int)id);
            foreach (var coin in coins)
            {
                Coins?.Add(coin);
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
                CurrentPrice = _selectedCoin.CurrentPrice,
                ValueUSD = _selectedCoin.ValueUSD,
                DateUpdate = _selectedCoin.DateUpdate
            };
            if (dialog.ShowDialog() != true) return;

            // to Images
            var imageFolderPass =
            Path.Combine(Directory.GetCurrentDirectory(), "Images");
            // for new picture
            try
            {

                if (!_selectedCoin.PictureName.Equals(dialog?.PictureName))
            {

                // delete old picture
                File.Delete(Path.Combine(imageFolderPass,
                _selectedCoin.PictureName));
                // get new picture
                var newImage = Path.GetFileName(dialog.PictureName);
                // copy file to Images
                File.Copy(dialog.PictureName, Path.Combine(imageFolderPass,
                newImage));

                _selectedCoin.PictureName = newImage;
            }

        }
            catch
            {
                _selectedCoin.PictureName = "no.png";
            }
        
            _selectedCoin.Name = dialog.Name;
            _selectedCoin.ShortName = dialog.ShortName;
            _selectedCoin.Amount = dialog.Amount;
            _selectedCoin.CurrentPrice = dialog.CurrentPrice;
            _selectedCoin.ValueUSD = dialog.ValueUSD;
            _selectedCoin.DateUpdate = dialog.DateUpdate;

            OnGetCoinExecuted(_selectedCoin.CoinId);
            
        }
        #endregion


        #region Del coin
        private ICommand _delCoinCommand;
        public ICommand DelCoinCommand => _delCoinCommand ??= new RelayCommand(OnDelCoinExecuted, DelCoinCanExecute);


        // check if can del
        private bool DelCoinCanExecute(object p) =>
        _selectedCoin != null;

        private void OnDelCoinExecuted(object id)
        {
            var result = MessageBox.Show("Are you sure?", $"Delete coin {_selectedCoin.Name}?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                //coinManager.Delete(_selectedCoin.CoinId); //deleting only coin and relating, not transaction
                Coins.Remove(_selectedCoin);

                //if (Transactions.Count > 0)
                //    OnGetCointsExecuted(Groups[0].GroupId);
    
            }
        }
        #endregion

        #endregion

    }
}
