using portfolio.Business.Managers;
using portfolio.Command;
using portfolio.Domain.Entities;
using portfolio.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace portfolio
{

    public partial class EditTransactionWindow : Window
    {
        #region Properties
        public string Side
        {
            get { return (string)GetValue(SideProperty); }
            set { SetValue(SideProperty, value); }
        }

        public static readonly DependencyProperty SideProperty = DependencyProperty
            .Register("Side", typeof(string),
            typeof(EditCoinWindow),
            new PropertyMetadata(default(string)));

        public ObservableCollection<Coin> Coins
        {
            get { return (ObservableCollection<Coin>)GetValue(CoinsProperty); }
            set { SetValue(CoinsProperty, value); }
        }

        public static readonly DependencyProperty CoinsProperty = DependencyProperty
            .Register("Coins", typeof(string),
            typeof(EditCoinWindow),
            new PropertyMetadata(default(string)));


        public Coin DebetCoin
        {
            get { return (Coin)GetValue(DebetCoinProperty); }
            set { SetValue(DebetCoinProperty, value); }
        }

        public static readonly DependencyProperty DebetCoinProperty = DependencyProperty
            .Register("DebetCoin", typeof(string),
            typeof(EditCoinWindow),
            new PropertyMetadata(default(string)));


        public decimal Amount
        {
            get { return (decimal)GetValue(AmountProperty); }
            set { SetValue(AmountProperty, value); }
        }

        public static readonly DependencyProperty AmountProperty = DependencyProperty
            .Register("Amount", typeof(decimal),
                typeof(EditTransactionWindow),
                new PropertyMetadata(default(decimal)));
        
        public decimal PurchasePrice
        {
            get { return (decimal)GetValue(PurchasePriceProperty); }
            set { SetValue(PurchasePriceProperty, value); }
        }
        public static readonly DependencyProperty PurchasePriceProperty = DependencyProperty
            .Register("PurchasePrice", typeof(decimal),
                typeof(EditCoinWindow),
                new PropertyMetadata(default(decimal)));
        
        #endregion
        
        public EditTransactionWindow()
        {
            InitializeComponent();

            cBoxSide.ItemsSource = Transaction.sideType.GetRange(1,2);
            cBoxCoinDebet.ItemsSource = MainWindowViewModel.Coins;
            cBoxCoinCredit.ItemsSource = MainWindowViewModel.Coins;
            tbNote.Text =  "*Add exchange - choose buy or sell and coins";
   
        }
        
        public EditTransactionWindow(object id)
        {
            InitializeComponent();
            cBoxSide.ItemsSource = Transaction.sideType.GetRange(0,1);
            cBoxCoinDebet.ItemsSource = MainWindowViewModel.Coins;
            cBoxCoinCredit.Visibility = Visibility.Collapsed;
            tbNote.Text =  "*To add coin without exchange - transfer and only one coin";
            lPrice.Content = "Market price (opt)";
            cBoxCoinDebet.Width = 220;



        }

        private ICommand _okCommand;
        public ICommand OkCommand =>
        _okCommand
        ?? new RelayCommand(OnOkExecuted);
        public void OnOkExecuted(object param)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           // textBoxSum.Text = e.ToString();
           cBoxSide.SelectedItem = 0;
        }

        private void btnCulculateSum_Click(object sender, RoutedEventArgs e)
        {
            textBoxSum.Text = (Convert.ToDecimal(textBoxAmount.Text) * Convert.ToDecimal(textBoxPrice.Text)).ToString();
        }
    }
}
