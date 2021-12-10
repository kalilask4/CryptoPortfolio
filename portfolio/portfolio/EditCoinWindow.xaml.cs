using Microsoft.Win32;
using portfolio.Command;
using portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Логика взаимодействия для EditCoinWindow.xaml
    /// </summary>
    public partial class EditCoinWindow : Window
    {
        #region Properties
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for
        //Name.This enables animation, styling, binding, etc.
        public static readonly DependencyProperty NameProperty = DependencyProperty
            .Register("Name", typeof(string),
            typeof(EditCoinWindow),
            new PropertyMetadata(default(string)));
        
        public string ShortName
        {
            get { return (string)GetValue(ShortNameProperty); }
            set { SetValue(ShortNameProperty, value); }
        }

        public static readonly DependencyProperty ShortNameProperty = DependencyProperty
            .Register("ShortName", typeof(string),
            typeof(EditCoinWindow),
            new PropertyMetadata(default(string)));

        public decimal Amount
        {
            get { return (decimal)GetValue(AmountProperty); }
            set { SetValue(AmountProperty, value); }
        }

        public static readonly DependencyProperty AmountProperty = DependencyProperty
            .Register("Amount", typeof(decimal),
            typeof(EditCoinWindow),
            new PropertyMetadata(default(decimal)));

        public decimal CurrentPrice
        {
            get { return (decimal)GetValue(CurrentPriceProperty); }
            set { SetValue(CurrentPriceProperty, value); }
        }

        public static readonly DependencyProperty CurrentPriceProperty = DependencyProperty
            .Register("CurrentPrice", typeof(decimal),
            typeof(EditCoinWindow),
            new PropertyMetadata(default(decimal)));

        public decimal AveragePrice
        {
            get { return (decimal)GetValue(AveragePriceProperty); }
            set { SetValue(AveragePriceProperty, value); }
        }

        public static readonly DependencyProperty AveragePriceProperty = DependencyProperty
            .Register("AveragePrice", typeof(decimal),
            typeof(EditCoinWindow),
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

        public string PictureName
        {
            get { return (string)GetValue(PictureNameProperty); }
            set { SetValue(PictureNameProperty, value); }
        }
        // Using a DependencyProperty as the backing store for
        // ImagePass.This enables animation, styling, binding, etc.
        public static readonly DependencyProperty PictureNameProperty = DependencyProperty
            .Register("PictureName", typeof(string), 
            typeof(EditCoinWindow), 
            new PropertyMetadata(default(string)));

        public DateTime DateUpdate
        {
            get { return (DateTime)GetValue(DateUpdateProperty); }
            set { SetValue(DateUpdateProperty, value); }
        }
        // Using a DependencyProperty as the backing store for
        //DateUpdate.This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DateUpdateProperty = DependencyProperty
            .Register("DateUpdate", typeof(DateTime),
            typeof(EditCoinWindow), 
            new PropertyMetadata(default(DateTime)));

        public EditCoinWindow()
        {
            InitializeComponent();
        }

        private ICommand _selectPictureNameCommand;
        public ICommand SelectPictureNameCommand =>
        _selectPictureNameCommand
        ?? new RelayCommand(OnSelectPictureNameExecuted);
        public void OnSelectPictureNameExecuted(object param)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                PictureName = dialog.FileName;
            }
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
        #endregion

        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //tboxShortName.Text = tboxName.Text.Substring(0, 3).ToUpper();
                textBoxValueUSD.Text = (Convert.ToDecimal(textBoxAmount.Text) * Convert.ToDecimal(tbPurchasePrice.Text)).ToString();
               
            }
            catch
            {

                [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
                static extern int MessageBoxTimeout(IntPtr hwnd, String text, String title,
                                     uint type, Int16 wLanguageId, Int32 milliseconds);
                MessageBoxTimeout((System.IntPtr)0, "Fill Coin name.", "Message", 0, 0, 1000);
               //MessageBox.Show("Fill Coin name.");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
