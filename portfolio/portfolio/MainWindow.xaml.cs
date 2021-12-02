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

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void rightClickUpdateTabCoin(object sender, ContextMenuEventArgs e)
        {
            MessageBoxTimeout((System.IntPtr)0, "Updated", "Message", 0, 0, 1000);
            grCoinsData.Items.Refresh();
            dgPortfolioIndicators.Items.Refresh();
        }

        private void rightClickUpdateTabTransaction(object sender, ContextMenuEventArgs e)
        {
            MessageBoxTimeout((System.IntPtr)0, "Updated", "Message", 0, 0, 1000);
            grTransactionData.Items.Refresh();
            dgPortfolioIndicators.Items.Refresh();
        }
      
        private void LTransactionsItems_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            grCoinsData.SelectedItem = null;
        }
  }
}
