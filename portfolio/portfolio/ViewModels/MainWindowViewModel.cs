using portfolio.Business.Infrastructure;
using portfolio.Business.Managers;
using portfolio.Command;
using portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        
        
        public MainWindowViewModel()
        {
            factory = new ManagersFactory("DefaultConnection");
            coinManager = factory.GetCoinManager();
            transactionManager = factory.GetTransactionManager();

            if (coinManager.Coins.Count() == 0)
                DbTestData.SetupData(coinManager, transactionManager);

            Coins = new ObservableCollection<Coin>(coinManager.Coins);
            AllTransactions = new ObservableCollection<Transaction>(transactionManager.Transactions);
            Transactions = new ObservableCollection<Transaction>(transactionManager.Transactions);

            //get list transaction for first coin
            if (Coins.Count > 0)
                OnGetTransactionExecuted(Coins[0].CoinId);

            /*//get list transaction for first coin
            if (Transactions.Count > 0)
                OnGetTransactionExecuted(Transactions[0].TransactionId);*/


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

        #region sealected transaction 
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
        public ICommand NewCoinCommand =>
        _newCoinCommand ??= new
       RelayCommand(OnNewCoinExecuted);
        private void OnNewCoinExecuted(object id)
        {
            var dialog = new EditCoinWindow
            {
                //Date = DateTime.Now
            };

            if (dialog.ShowDialog() != true) return;
            var coin = new Coin
            {
                Name = dialog.Name,
                //Date = dialog.DateOfBirth
            };
            

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
        #endregion


    }
}
