using portfolio.Business.Infrastructure;
using portfolio.Business.Managers;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace portfolio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern int MessageBoxTimeout(IntPtr hwnd, String text, String title,
                                     uint type, Int16 wLanguageId, Int32 milliseconds);

        //public ObservableCollection<Transaction> AllTransactions;

        public MainWindow()
        {
            InitializeComponent();
                       
        }

        //private void AddCoin_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void rightClickUpdateTabCoin(object sender, ContextMenuEventArgs e)
        {
            MessageBoxTimeout((System.IntPtr)0, "Updated", "Message", 0, 0, 1000);
            //AllTransactions = new ObservableCollection<Transaction>(MainWindowViewModel.TransactionManager.Transactions);
            //command - update coins profit - main window

            grCoinsData.Items.Refresh();
           // dgPortfolioIndicators.Items.Refresh();
            //dgPortfolioPerformance.Items.Refresh();
            // TextBox.TextProperty.Up
            // tbStartPrice.TextP
            //
        }

        private void rightClickUpdateTabTrans(object sender, ContextMenuEventArgs e)
        {
            MessageBoxTimeout((System.IntPtr)0, "Updated", "Message", 0, 0, 1000);
            //AllTransactions = new ObservableCollection<Transaction>(MainWindowViewModel.TransactionManager.Transactions);
            grTransactionData.Items.Refresh();
            
            
                
                //ItemsSource.re();

        }
      

        private void btnTestException_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            try
            {
                s.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
            s.Trim();
        }

        private void LTransactionsItems_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            grCoinsData.SelectedItem = null;
        }
  
        // private void btnFullRecount_Click(object sender, RoutedEventArgs e)
        // {
        //
        // }
    }
}
