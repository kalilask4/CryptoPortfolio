using portfolio.Business.Infrastructure;
using portfolio.Business.Managers;
using portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ObservableCollection<Transaction> TransactionsForCoin { get; set; }
        public string Title { get => titleCoins; set => titleCoins = value; }
        public string TitleTransactions { get => titleTransactions; set => titleTransactions = value; }
        public ObservableCollection<Transaction> Transactions { get; set; }
        
        public MainWindowViewModel()
        {
            factory = new ManagersFactory("DefaultConnection");
            coinManager = factory.GetCoinManager();
            transactionManager = factory.GetTransactionManager();
            Coins = new ObservableCollection<Coin>(coinManager.coins);
            Transactions = new ObservableCollection<Transaction>(transactionManager.transactions);
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
    }
}
