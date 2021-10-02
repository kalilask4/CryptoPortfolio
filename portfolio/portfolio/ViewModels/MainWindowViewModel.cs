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
    class MainWindowViewModel : ViewModelBase
    {
        ManagersFactory factory;
        CoinManager coinManager;
        BuyTransactionManager buyTransactionManager;
        SellTransactionManager sellTransactionManager;

        private string titleCoins = "Coin Window";
        private string titleTransactions = "Transaction Window";
        #region Public properties
        /// <summary>
        /// Coin list
        /// </summary>
        public ObservableCollection<Coin> Coins { get; set; }
        /// <summary>
        /// Buy transaction list for coin
        /// </summary>
        public ObservableCollection<BuyTransaction> buyTransactionsForCoin { get; set; }
        public string Title { get => titleCoins; set => titleCoins = value; }

        /// <summary>
        /// Buy transaction list
        /// </summary>
        public ObservableCollection<BuyTransaction> buyTransactions { get; set; }
        public string TitleTransactions { get => titleTransactions; set => titleTransactions = value; }

        /// <summary>
        /// Sell transaction list
        /// </summary>
        public ObservableCollection<SellTransaction> sellTransactions { get; set; }
       // public string TitleTransactions { get => titleTransactions; set => titleTransactions = value; }

        #region sealected coin 
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

        public MainWindowViewModel()
        {
            factory = new ManagersFactory("DefaultConnection");
            coinManager = factory.GetCoinManager();
            buyTransactionManager = factory.GetBuyTransactionManager();
            sellTransactionManager = factory.GetSellTransactionManager();
            //db init
            if (coinManager.coins.Count() == 0)
                DbTestData.SetupData(coinManager);
            buyTransactions = new ObservableCollection<BuyTransaction>(buyTransactionManager.buyTransactions);
            sellTransactions = new ObservableCollection<SellTransaction>(sellTransactionManager.sellTransactions);
            Coins = new ObservableCollection<Coin>(coinManager.coins);
            //Get transaction for first coin
            if (Coins.Count > 0)
                OnGetBuyTransactionExecuted(Coins[0].CoinId);
        }


        /// <summary>
        /// Buy transactions for coin 
        /// </summary>
        public ObservableCollection<BuyTransaction> BuyTransactions { get; set; }
        public string BuyTransactionId { get => BuyTransactionId; set => BuyTransactionId = value; }

        /// <summary>
        /// Sell transactions for coin 
        /// </summary>
        public ObservableCollection<BuyTransaction> SellTransactions { get; set; }
        public string SellTransactionId { get => SellTransactionId; set => SellTransactionId = value; }



        #region sealected buy transaction 
        private BuyTransaction _selectedBuyTransaction;
        public BuyTransaction SelectedBuyTransaction
        {
            get => _selectedBuyTransaction;
            set
            {
                Set(ref _selectedBuyTransaction, value);
            }
        }
        #endregion

        #region sealected sell transaction 
        private SellTransaction _selectedSellTransaction;
        public SellTransaction SelectedSellTransaction
        {
            get => _selectedSellTransaction;
            set
            {
                Set(ref _selectedSellTransaction, value);
            }
        }
        #endregion
        #endregion

        #region Commands
        #region Выбор монеты в списке
        private ICommand _getBuyTransactionsCommand;
        public ICommand GetBuyTransactionCommand =>
            _getBuyTransactionsCommand
            ??= new RelayCommand(OnGetBuyTransactionExecuted);

        /// <summary>
        /// делегат для метода Execute команды GetBuyTransactionsCommand
        /// </summary>
        /// <param name="id">Id монеты</param>
        private void OnGetBuyTransactionExecuted(object id)
        {
            //if (BuyTransactions != null){
            //    BuyTransactions.Clear();
            //}
            BuyTransactions?.Clear();
            var buyTransactions = coinManager.GetBuyTransactionsOfCoin((int)id);
            foreach (var buyTransaction in buyTransactions)
            { 
                BuyTransactions?.Add(buyTransaction);
            }
                
        }
        #endregion
        #endregion
    }

}
