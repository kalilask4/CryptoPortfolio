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

        #region Public properties
        /// <summary>
        /// Buy transaction list
        /// </summary>
        public ObservableCollection<BuyTransaction> buyTransactions { get; set; }
        
        /// <summary>
        /// Sell transaction list
        /// </summary>
        public ObservableCollection<SellTransaction> sellTransactions { get; set; }


        /// <summary>
        /// Coin from transaction
        /// </summary>
        public ObservableCollection<Coin> Coins { get; set; }
        public string CoinName { get => CoinName; set => CoinName = value; }

        #region transaction
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
        #endregion

        private string title = "BuyTransaction Window";
        public MainWindowViewModel()
        {
            factory = new ManagersFactory();
            buyTransactionManager = factory.GetBuyTransactionManager();
            coinManager = factory.GetCoinManager();
            buyTransactions = new ObservableCollection<BuyTransaction>(buyTransactionManager.buyTransactions);
            Coins = new ObservableCollection<Coin>();
        }

    }
}
