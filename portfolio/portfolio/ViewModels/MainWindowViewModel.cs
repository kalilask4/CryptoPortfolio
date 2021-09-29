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
    class MainWindowViewModel : ViewModelBase
    {
        ManagersFactory factory;
        CoinManager coinManager;
        BuyTransactionManager buyTransactionManager;
        SellTransactionManager sellTransactionManager;

        public MainWindowViewModel()
        {
            factory = new ManagersFactory();
            coinManager = factory.GetCoinManager();
            buyTransactionManager = factory.GetBuyTransactionManager();
            sellTransactionManager = factory.GetSellTransactionManager();
            buyTransactions = new ObservableCollection<BuyTransaction>(buyTransactionManager.buyTransactions);
            sellTransactions = new ObservableCollection<SellTransaction>(sellTransactionManager.sellTransactions);
            Coins = new ObservableCollection<Coin>(coinManager.coins);

      
        }

        #region Public properties
        /// <summary>
        /// Coin list
        /// </summary>
        public ObservableCollection<Coin> Coins { get; set; }

        /// <summary>
        /// Buy transaction list
        /// </summary>
        public ObservableCollection<BuyTransaction> buyTransactions { get; set; }
        
        /// <summary>
        /// Sell transaction list
        /// </summary>
        public ObservableCollection<SellTransaction> sellTransactions { get; set; }

        /// <summary>
        /// Coin 
        /// </summary>
        //public ObservableCollection<Coin> Coins { get; set; }
        //public string CoinName { get => CoinName; set => CoinName = value; }

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

        private string title = "BuyTransactions Window";




       
    }
}
